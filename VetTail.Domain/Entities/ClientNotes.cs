using VetTail.Domain.Entities.Abstractions;

namespace VetTail.Domain.Entities;

public class ClientNotes: Note
{
    public ulong ClientId { get; set; }
    public Client Client { get; set; }
}
