namespace NurserySystem.Application.DTOs;

public class ChildDto
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public int Age => CalculateAge();
    public string Gender { get; set; } = string.Empty;
    public string BloodType { get; set; } = string.Empty;
    public string? MedicalNotes { get; set; }
    public string? PhotoPath { get; set; }
    
    // Guardian Info
    public int GuardianId { get; set; }
    public string? GuardianName { get; set; }
    public string? GuardianPhone { get; set; }
    
    // Class Info
    public int? ClassRoomId { get; set; }
    public string? ClassRoomName { get; set; }
    public string? LevelName { get; set; }
    
    // Subscription Info
    public bool HasActiveSubscription { get; set; }
    public DateTime? SubscriptionEndDate { get; set; }
    
    private int CalculateAge()
    {
        var today = DateTime.Today;
        var age = today.Year - DateOfBirth.Year;
        if (DateOfBirth.Date > today.AddYears(-age)) age--;
        return age;
    }
}

public class CreateChildDto
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string BloodType { get; set; } = string.Empty;
    public string? MedicalNotes { get; set; }
    public string? VaccinationRecords { get; set; }
    
    // Guardian
    public string GuardianNameAr { get; set; } = string.Empty;
    public string GuardianNameEn { get; set; } = string.Empty;
    public string GuardianPhone { get; set; } = string.Empty;
    public string? GuardianAlternatePhone { get; set; }
    public string GuardianEmail { get; set; } = string.Empty;
    public string GuardianAddress { get; set; } = string.Empty;
    public string GuardianNationalId { get; set; } = string.Empty;
    public string GuardianRelationship { get; set; } = string.Empty;
    
    // Class
    public int? ClassRoomId { get; set; }
}

public class UpdateChildDto
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string BloodType { get; set; } = string.Empty;
    public string? MedicalNotes { get; set; }
    public string? VaccinationRecords { get; set; }
    public int? ClassRoomId { get; set; }
}
