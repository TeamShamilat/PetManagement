namespace PetManagement.Entities;

public class Owner
{
    public int OwnerId { get; set; } 
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<Pet> Pets { get; set; } = new List<Pet>();
}


