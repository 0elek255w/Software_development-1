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

    [HttpGet("{email}")]
    public ActionResult<Guid> Get(string email, string password)
    {
        UserEntity? user = this.DbUser.Get(email, password);

        if (user == null)
            return Forbid();

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<Guid> Create(
        [FromForm] string name,
        [FromForm] string email,
        [FromForm] string password
    ) {
        UserEntity user = new UserEntity
        {
            ID = Guid.NewGuid(),
            Name = name,
            Email = email,
            Password = password,
            Type = "user", // tmp temp
            Orders = new List<OrderEntity>()
        };

        // check if UserEntity.Type is valid

        Guid userID = this.DbUser.Create(user);

        return Ok(userID);
    }

    [HttpPut("{email}")]
    public ActionResult<string> Update(string email, [FromBody] UserEntity user)
    {
        this.DbUser.Update(email, user.Name);

        return Ok(email);
    }

    [HttpDelete("{email}")]
    public ActionResult<bool> Delete(string email, string password)
    {
        bool isValid = this.DbUser.Delete(email, password);

        if (!isValid)
            Forbid();

        return Ok();
    }
}
