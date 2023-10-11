using server.Models;
using server.Services;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HousesController : ControllerBase
{
    private readonly HousesService _housesService;


    public HousesController(HousesService housesService)
    {
        _housesService = housesService;
    }

    [HttpPost]
    public ActionResult<House> CreateCar([FromBody] House houseData)
    {
        try
        {
            House house = _housesService.CreateHouse(houseData);
            return Ok(house);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }



    [HttpDelete("{houseId}")]
    public ActionResult<string> RemoveHouse(int houseId)
    {
        try
        {
            House house = _housesService.RemoveHouse(houseId);
            return Ok(house);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }



    [HttpGet]
    public ActionResult<List<House>> getAllHouses()
    {
        try
        {
            List<House> houses = _housesService.getAllHouses();
            return Ok(houses);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{houseId}")]

    public ActionResult<House> getHouseById(int houseId)
    {
        try

        {
            House house = _housesService.GetHouseById(houseId);
            return Ok(house);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }

    }


}