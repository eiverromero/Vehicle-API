using Microsoft.AspNetCore.Mvc;
using VehicleApi.Models;

namespace VehicleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private static readonly List<Vehicle> Data = [];

        //GET api/vehicles?make=Ford&year=2020
        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> Get(string? make, int? year)
        {
            var result = Data.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(make))
            {
                result = result.Where(v =>
                    v.Make.Contains(make, StringComparison.InvariantCultureIgnoreCase));
            }

            if (year > 0)
            {
                result = result.Where(v => v.Year == year);
            }

            return Ok(result.ToList());
        }

        // GET: api/vehicles/{id}
        [HttpGet("{id:guid}")]

        public ActionResult<Vehicle> GetByid(Guid id)
        {
            var vehicle = Data.FirstOrDefault(v => v.Id == id);
            if (vehicle == null) return NotFound();
            return Ok(vehicle);
        }

        //POST api/vehicles
        [HttpPost]
        public ActionResult<Vehicle> Create(Vehicle vehicle)
        {
            Data.Add(vehicle);
            return CreatedAtAction(nameof(GetByid), new { id = vehicle.Id }, vehicle);
        }

        //PUT api/vehicles/{id}
        [HttpPut("{id:guid}")]

        public ActionResult<Vehicle> Replace(Guid id, Vehicle vehicle)
        {
            var existing = Data.FirstOrDefault(v => v.Id == id);
            if (existing == null) return NotFound();

            existing.Make = vehicle.Make;
            existing.Year = vehicle.Year;
            existing.Model = vehicle.Model;

            return NoContent();
        }

        //DELETE api/vehicle/{id}
        [HttpDelete("{id:guid}")]
        public ActionResult<Vehicle> Delete(Guid id)
        {
            var existing = Data.FirstOrDefault(v => v.Id == id);
            if (existing == null) return NotFound();

            Data.Remove(existing);
            return NoContent();
        }

    }
}