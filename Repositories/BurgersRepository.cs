namespace burger_shack_csharp.Repositories;

public class BurgersRepository : IRepository<Burger>
{
    private readonly IDbConnection _db;

    public BurgersRepository(IDbConnection db)
    {
        _db = db;
    }

    public List<Burger> GetAll()
    {
        string sql = "SELECT * FROM burgers";
        return _db.Query<Burger>(sql).ToList();
    }

    public Burger GetById(int id)
    {
        string sql = "SELECT * FROM burgers WHERE id = @Id";
        Burger burger = _db.Query<Burger>(sql, new { Id = id }).SingleOrDefault();
        return burger;
    }

    public Burger Create(Burger burgerData)
    {
        string sql =
            @"INSERT INTO burgers(name, price) VALUES(@Name, @Price);
        SELECT * FROM burgers WHERE id = LAST_INSERT_ID();";
        Burger burger = _db.Query<Burger>(sql, burgerData).SingleOrDefault();
        return burger;
    }

    public Burger Delete(int id)
    {
        string sql = "SELECT * FROM burgers WHERE id = @Id LIMIT 1;";
        Burger burger = _db.Query<Burger>(sql, new { Id = id }).SingleOrDefault();
        string sqlD = "DELETE FROM burgers WHERE id = @Id LIMIT 1;";
        int rowsAffected = _db.Execute(sqlD, new { Id = id });
        if (rowsAffected == 0)
        {
            throw new Exception($"Invalid id: {id} (or your sql sucks)");
        }

        if (rowsAffected > 1)
        {
            throw new Exception($"{rowsAffected} rows have been deleted and that ain't good");
        }
        return burger;
    }

    public Burger Update(int id, Burger burgerData)
    {
        burgerData.Id = id;
        string sql =
            @"UPDATE burgers SET name = @Name, price = @Price WHERE id = @Id;
        SELECT * FROM burgers WHERE id =@Id";
        Burger burger = _db.Query<Burger>(sql, burgerData).SingleOrDefault();
        return burger;
    }
}
