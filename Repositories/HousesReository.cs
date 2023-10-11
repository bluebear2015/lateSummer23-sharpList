using server.Models;

namespace server.Repositories;
public class HousesRepository
{

    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal House CreateHouse(House houseData)
    {
        string sql = @"
      INSERT INTO houses
      (sqft, bathrooms, bedrooms, price, description, imgUrl)
      VALUES
      (@sqft, @bathrooms, @bedrooms, @price, @description, @imgUrl);
      SELECT * FROM houses WHERE id = LAST_INSERT_ID();
      ";
        House house = _db.Query<House>(sql, houseData).FirstOrDefault();
        return house;
    }


    internal void RemoveHouse(int houseId)
    {
        string sql = "DELETE FROM houses WHERE id = @houseId";

        int rowsAffected = _db.Execute(sql, new { houseId });


        if (rowsAffected > 1) throw new Exception("Too Much Happened");
        if (rowsAffected < 1) throw new Exception("Nothing Happened");
    }
    //NOTE - this is a note


    internal List<House> getAllHouses()
    {


        string sql = "SELECT * FROM houses;";
        List<House> houses = _db.Query<House>(sql).ToList();
        return houses;

    }

    internal House GetHouseById(int houseId)
    {
        string sql = "SELECT * FROM houses WHERE id = @houseId;";
        House house = _db.Query<House>(sql, new { houseId }).FirstOrDefault();
        return house;
    }


}