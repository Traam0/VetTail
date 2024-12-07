using VetTail.Domain.Entities.Abstractions;

namespace VetTail.Domain.Entities;

public class PetNotes : Note
{
    public string PetId { get; set; }
    public Pet Pet { get; set; }
}
