namespace NurserySystem.Application.DTOs;

public class ClassRoomDto
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int LevelId { get; set; }
    public string? LevelName { get; set; }
    public int MaxCapacity { get; set; }
    public int CurrentCount { get; set; }
    public bool IsFull => CurrentCount >= MaxCapacity;
}

public class CreateClassRoomDto
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int LevelId { get; set; }
    public int MaxCapacity { get; set; }
}

public class UpdateClassRoomDto
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int LevelId { get; set; }
    public int MaxCapacity { get; set; }
}

public class LevelDto
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int Order { get; set; }
    public int ClassRoomsCount { get; set; }
}

public class CreateLevelDto
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int Order { get; set; }
}
