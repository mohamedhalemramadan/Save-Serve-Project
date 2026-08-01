using FluentValidation;
using NurserySystem.Application.DTOs;

namespace NurserySystem.Application.Validators;

public class CreateChildDtoValidator : AbstractValidator<CreateChildDto>
{
    public CreateChildDtoValidator()
    {
        RuleFor(x => x.NameAr)
            .NotEmpty().WithMessage("الاسم بالعربية مطلوب")
            .MaximumLength(100).WithMessage("الاسم بالعربية لا يجب أن يتجاوز 100 حرف");

        RuleFor(x => x.NameEn)
            .NotEmpty().WithMessage("الاسم بالإنجليزية مطلوب")
            .MaximumLength(100).WithMessage("الاسم بالإنجليزية لا يجب أن يتجاوز 100 حرف");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("تاريخ الميلاد مطلوب")
            .LessThan(DateTime.Now).WithMessage("تاريخ الميلاد يجب أن يكون في الماضي");

        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("النوع مطلوب");

        RuleFor(x => x.BloodType)
            .NotEmpty().WithMessage("فصيلة الدم مطلوبة");

        RuleFor(x => x.GuardianNameAr)
            .NotEmpty().WithMessage("اسم ولي الأمر مطلوب");

        RuleFor(x => x.GuardianPhone)
            .NotEmpty().WithMessage("رقم هاتف ولي الأمر مطلوب")
            .Matches(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$")
            .WithMessage("رقم الهاتف غير صحيح");

        RuleFor(x => x.GuardianEmail)
            .EmailAddress().WithMessage("البريد الإلكتروني غير صحيح");

        RuleFor(x => x.GuardianNationalId)
            .NotEmpty().WithMessage("الرقم القومي مطلوب");

        RuleFor(x => x.GuardianRelationship)
            .NotEmpty().WithMessage("صفة ولي الأمر مطلوبة");
    }
}

public class CreateClassRoomDtoValidator : AbstractValidator<CreateClassRoomDto>
{
    public CreateClassRoomDtoValidator()
    {
        RuleFor(x => x.NameAr)
            .NotEmpty().WithMessage("اسم الفصل بالعربية مطلوب");

        RuleFor(x => x.NameEn)
            .NotEmpty().WithMessage("اسم الفصل بالإنجليزية مطلوب");

        RuleFor(x => x.LevelId)
            .GreaterThan(0).WithMessage("المستوى الدراسي مطلوب");

        RuleFor(x => x.MaxCapacity)
            .GreaterThan(0).WithMessage("السعة القصوى يجب أن تكون أكبر من صفر")
            .LessThanOrEqualTo(50).WithMessage("السعة القصوى لا يجب أن تتجاوز 50 طفل");
    }
}

public class CreateLevelDtoValidator : AbstractValidator<CreateLevelDto>
{
    public CreateLevelDtoValidator()
    {
        RuleFor(x => x.NameAr)
            .NotEmpty().WithMessage("اسم المستوى بالعربية مطلوب");

        RuleFor(x => x.NameEn)
            .NotEmpty().WithMessage("اسم المستوى بالإنجليزية مطلوب");

        RuleFor(x => x.Order)
            .GreaterThan(0).WithMessage("ترتيب المستوى يجب أن يكون أكبر من صفر");
    }
}
