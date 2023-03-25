using Microsoft.AspNetCore.Mvc;
using PetManagement.Entities;
using PetManagement.Services;

namespace PetManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ILogger<PetsController> _logger;
        private readonly PetService petServices;

        public PetsController(ILogger<PetsController> logger, PetService petServices)
        {
            _logger = logger;
            this.petServices = petServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pets = this.petServices.GetAll();

            return Ok(pets);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pet = this.petServices.GetById(id);

            return Ok(pet);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(Pet model)
        {
            await this.petServices.AddAsync(model);

            return Ok();
        }

        // Pets/id
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pet model)
        {
            var pet = this.petServices.GetById(id);
            if (pet == null)
            {
                return NotFound();
            }

            pet.Name = model.Name;
            pet.Description = model.Description;   
            this.petServices.Update(pet);
            return Ok();
        }


        // Pets/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pet = this.petServices.GetById(id);
            if (pet == null)
            {
                return NotFound();
            }

            var deletedPet = this.petServices.DeleteById(pet);

            return Ok(pet);
        }
    }
}