namespace VetTail.Domain.Enums;

public enum Role
{
    StaffMember = 1,
    Veterinarian = StaffMember << 1,
    Owner = Veterinarian << 1
}
