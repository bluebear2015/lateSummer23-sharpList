using server.Models;
using server.Repositories;

namespace server.Services;

public class HousesService
{
    private readonly HousesRepository _repo;
    public HousesService(HousesRepository repo)
    {
        _repo = repo;
    }

    internal House CreateHouse(House houseData)
    {
        House house = _repo.CreateHouse(houseData);
        return house;
    }

    internal string RemoveHouse(int houseId)
    {
        House house = this.GetHouseById(houseId);

        _repo.RemoveHouse(houseId);


    }

    internal List<House> getAllHouses()
    {
        List<House> house = _repo.getAllHouses();
        return house;

    }

    internal House GetHouseById(int houseId)
    {
        House house = _repo.GetHouseById(houseId);
        if (house == null) throw new Exception($"no house with id: {houseId}");
        return house;
    }
}