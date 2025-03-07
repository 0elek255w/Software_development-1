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

    [HttpPost("GetUser")]
    public ActionResult<UserEntity> Get(
        [FromForm] string email,
        [FromForm] string password
    ) {
        UserEntity? user = this.DbUser.Get(email, password, out string errorMessage);

        if (user == null)
            return BadRequest(errorMessage); // replace with Forbid()

        return Ok(user);
    }

    [HttpPost("CreateUser")]
    public ActionResult<bool> Create(
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

        bool isValid = this.DbUser.Create(user);

        if (!isValid)
            return Conflict($"user with email {email} already exists");

        return Ok();
    }

    [HttpPut]
    public ActionResult<bool> Update(
        [FromForm] string email,
        [FromForm] string password,
        [FromForm] string newName
    ) {
        bool isValid = this.DbUser.Update(email, password, newName, out string errorMessage);

        if (!isValid)
            return BadRequest(errorMessage);

        return Ok();
    }

    [HttpDelete("{email}")]
    public ActionResult<bool> Delete(string email, string password)
    {
        bool isValid = this.DbUser.Delete(email, password);

        if (!isValid)
            BadRequest(); // replace with Forbid()

        return Ok();
    }
}
