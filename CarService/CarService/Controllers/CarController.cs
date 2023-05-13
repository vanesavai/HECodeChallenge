using CarService.Classes;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {

        [HttpGet("GetListOfCars")]
        public async Task<IActionResult> Get()
        {
                //TODO: Add logic to get data from database using a mapper or ORM (i.e. entity framework)
                return Ok( DatabaseMock.carsDb.ToArray());
        }

        [HttpGet("GetCarById")]
        public async Task<IActionResult> GetCarById(int carId)
        {
            //TODO: Add logic to get data from database using a mapper or ORM (i.e. entity framework)
            return Ok(DatabaseMock.carsDb.Where(x=>x.Id==carId).FirstOrDefault());
        }

        [HttpPost("UpdateCar")]
        public async Task<IActionResult> UpdateCar(Car car)
        {
            //TODO: Add logic to get data from database using a mapper or ORM (i.e. entity framework)

            Car? carToBeUpdated = DatabaseMock.carsDb.FirstOrDefault(x => x.Id == car.Id);
            if (carToBeUpdated != null)
            {
                carToBeUpdated.Make = car.Make;
                carToBeUpdated.Model = car.Model;
                carToBeUpdated.Doors = car.Doors;
                carToBeUpdated.Color = car.Color;
                carToBeUpdated.Price = car.Price;
            }
            return Ok();
        }

        [HttpPut( "InsertCar")]
        public async Task<IActionResult> InsertCar(Car car)
        {
            //TODO: Add logic to get data from database using a mapper or ORM (i.e. entity framework)

            Car? carToBeUpdated = DatabaseMock.carsDb.Where(x => x.Id == car.Id).FirstOrDefault();
            if (carToBeUpdated == null)
            {
                DatabaseMock.carsDb.Add(car);
            }
            return Ok(car);
        }

        [HttpDelete( "DeleteCar")]
        public async Task<IActionResult> DeleteCar(int carId)
        {
            //TODO: Add logic to get data from database using a mapper or ORM (i.e. entity framework)

            Car? carToBeRemoved = DatabaseMock.carsDb.Where(x=>x.Id == carId).FirstOrDefault();
            if (carToBeRemoved != null)
            {
                DatabaseMock.carsDb.Remove(carToBeRemoved);
            }
            return Ok(carToBeRemoved);
        }




    }
}