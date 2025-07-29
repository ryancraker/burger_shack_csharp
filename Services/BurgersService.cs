namespace burger_shack_csharp.Services;

public class BurgersService
{
    private readonly BurgersRepository _repositiory;

    public BurgersService(BurgersRepository repository)
    {
        _repositiory = repository;
    }

    public List<Burger> GetAllBurgers()
    {
        return _repositiory.GetAll();
    }

    public Burger CreateBurger(Burger burgerData)
    {
        Burger burger = _repositiory.Create(burgerData);
        return burger;
    }

    public string DeleteBurger(int id)
    {
        Burger burger = _repositiory.Delete(id);
        return $"{burger.Name} has been removed from the menu";
    }

    public Burger UpdateBurger(int id, Burger update)
    {
        Burger burger = _repositiory.Update(id, update);
        return burger;
    }
}
