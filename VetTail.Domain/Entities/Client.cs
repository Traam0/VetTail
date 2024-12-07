using System.Collections.Generic;
using VetTail.Domain.Common.Abstractions;
using VetTail.Domain.Enums;

namespace VetTail.Domain.Entities;

public class Client : AuditableEntity
{
    public ulong Id { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Image { get; set; }

    public string? CIN { get; set; }
    public ContactMethod PreferredContactMethod { get; set; }


    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }  

    public ICollection<Pet> Pets {  get; set; }    
    public ICollection<ClientNotes> Notes { get;
} 
