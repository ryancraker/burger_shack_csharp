namespace burger_shack_csharp.Controllers;

[ApiController]
[Route("api/burgers")]
public class BurgersController : ControllerBase
{
    private readonly BurgersService _burgersService;

    public BurgersController(BurgersService burgersService)
    {
        _burgersService = burgersService;
    }

    [HttpGet]
    public ActionResult<List<Burger>> GetAllBurgers()
    {
        try
        {
            List<Burger> burgers = _burgersService.GetAllBurgers();
            return Ok(burgers);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPost]
    public ActionResult<Burger> CreateBurger([FromBody] Burger burgerData)
    {
        try
        {
            Burger burger = _burgersService.CreateBurger(burgerData);
            return Ok(burger);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> DeleteBurger(int id)
    {
        try
        {
            string message = _burgersService.DeleteBurger(id);
            return Ok(message);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Burger> UpdateBurger(int id, [FromBody] Burger update)
    {
        try
        {
            Burger burger = _burgersService.UpdateBurger(id, update);
            return Ok(burger);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}
