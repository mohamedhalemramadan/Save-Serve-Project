namespace NurserySystem.Domain.Entities;

public class Child : BaseEntity
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string? PhotoPath { get; set; }
    public string Gender { get; set; } = string.Empty; // ذكر، أنثى
    public string BloodType { get; set; } = string.Empty;
    public string? MedicalNotes { get; set; } // ملاحظات طبية، حساسية
    public string? VaccinationRecords { get; set; } // سجل التطعيمات
    
    // Guardian Info
    public int GuardianId { get; set; }
    
    // Class Assignment
    public int? ClassRoomId { get; set; }
    
    // Navigation Properties
    public Guardian? Guardian { get; set; }
    public ClassRoom? ClassRoom { get; set; }
    public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
