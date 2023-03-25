using Microsoft.EntityFrameworkCore;
using PetManagement.Entities;

namespace PetManagement.Services;

public class PetService
{
    private PetDbContext database;

    public PetService(PetDbContext database)
    {
        this.database = database;
    }

    public IEnumerable<Pet> GetAll()
    {
        return this.database.Pets.ToList();
    }

    public Pet? GetById(int id)
    {
        var pet = this.database.Pets.FirstOrDefault(x => x.PetId == id);

        return pet;
    }

    public async Task AddAsync(Pet model)
    {
        await this.database.Pets.AddAsync(model);
        await this.database.SaveChangesAsync();
    }


    public void Update(Pet pet)
    {
        this.database.Pets.Update(pet);
        this.database.SaveChanges();
    }

    public Pet? DeleteById(Pet pet)
    {
        this.database.Pets.Remove(pet);
        this.database.SaveChanges();

        return pet;
    }
}