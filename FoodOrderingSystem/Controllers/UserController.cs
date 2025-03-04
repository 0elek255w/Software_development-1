using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Tables;
using PostgreSQL.Repositories;
using System.Diagnostics.Eventing.Reader;

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

    [HttpGet]
    public ActionResult<List<UserEntity>> Get()
    {
        List<UserEntity> users = this.DbUser.Get();

        return Ok(users);
    }
}
