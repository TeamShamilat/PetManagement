using PetManagement.Entities;

namespace PetManagement.Services;

public class OwnerService
{
    private PetDbContext database;

    public OwnerService(PetDbContext database)
    {
        this.database = database;
    }

    public IEnumerable<Owner> GetAll()
    {
        return this.database.Owners.ToList();
    }

    public Owner? GetById(int id)
    {
        var model = this.database.Owners.FirstOrDefault(x => x.OwnerId == id);

        return model;
    }

    public async Task AddAsync(Owner model)
    {
        await this.database.Owners.AddAsync(model);
        await this.database.SaveChangesAsync();
    }


    public void Update(Owner model)
    {
        this.database.Owners.Update(model);
        this.database.SaveChanges();
    }

    public Owner? DeleteById(Owner model)
    {
        this.database.Owners.Remove(model);
        this.database.SaveChanges();

        return model;
    }
}