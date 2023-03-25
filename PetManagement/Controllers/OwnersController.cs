using Microsoft.AspNetCore.Mvc;
using PetManagement.Entities;
using PetManagement.Services;

namespace OwnerManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly ILogger<OwnersController> _logger;
        private readonly OwnerService ownerServices;

        public OwnersController(ILogger<OwnersController> logger, OwnerService ownerServices)
        {
            _logger = logger;
            this.ownerServices = ownerServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var owners = this.ownerServices.GetAll();

            return Ok(owners);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var owner = this.ownerServices.GetById(id);

            return Ok(owner);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(Owner model)
        {
            await this.ownerServices.AddAsync(model);

            return Ok();
        }

        // Owners/id
        [HttpPut("{id}")]
        public IActionResult Update(int id, Owner model)
        {
            var owner = this.ownerServices.GetById(id);
            if (owner == null)
            {
                return NotFound();
            }

            owner.Name = model.Name;
            owner.Description = model.Description;
            this.ownerServices.Update(owner);
            return Ok();
        }


        // Owners/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var owner = this.ownerServices.GetById(id);
            if (owner == null)
            {
                return NotFound();
            }

            var deletedOwner = this.ownerServices.DeleteById(owner);

            return Ok(owner);
        }
    }
}