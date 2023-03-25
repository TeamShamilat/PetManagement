namespace PetManagement.Entities;

public class Pet
{
    public int PetId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int OwnerId { get; set; }
    public Owner? Owner { get; set; }
    
}


