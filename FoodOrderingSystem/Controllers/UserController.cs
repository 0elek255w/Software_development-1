using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Tables;
using PostgreSQL.Repositories;

namespace FoodOrderingSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepository DbUser;

    public UserController(UserRepository user)
    {
        this.DbUser = user;
    }

    [HttpGet("/user/get")]
    public IEnumerable<UserEntity> Get()
    {
        return this.DbUser.AllUserReturn();
    }

    [HttpPost("/user/add")]
    public IActionResult Post(UserEntity user)
    {
        this.DbUser.AddUser(user);
        return Ok();
    }
}
