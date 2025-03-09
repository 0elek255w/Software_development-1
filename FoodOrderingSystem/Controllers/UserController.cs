using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Tables;
using PostgreSQL.Repositories;
using PostgreSQL.Objects;

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
    public ActionResult<UserObject> Get(
        [FromBody] UserObject userRecieve
    ) {
        if (userRecieve.Password == null)
            return BadRequest("password is null");

        UserEntity? user = this.DbUser.Get(userRecieve.Email, userRecieve.Password, out string errorMessage);

        if (user == null)
            return BadRequest(errorMessage); // replace with Forbid()

        UserObject userSend = new UserObject(user.ID, user.Email, null, user.Name, user.Email, user.Type);
        return Ok(userSend);
    }

    [HttpPost("CreateUser")]
    public ActionResult<bool> Create(
        [FromBody] UserObject userRecieve
    ) {
        UserEntity user = new UserEntity();

        if (userRecieve.Password == null)
            return BadRequest("password is null");

        if (userRecieve.Name == null)
            return BadRequest("name is null");

        if (userRecieve.Image == null)
            user.Image = string.Empty;
        else
            user.Image = userRecieve.Image;

        user.Email = userRecieve.Email;
        user.Password = userRecieve.Password;
        user.Name = userRecieve.Name;
        user.Type = "user";

        // check if userRecieve.Type is valid

        bool isValid = this.DbUser.Create(user, out string errorMessage);

        if (!isValid)
            return Conflict(errorMessage);

        return Created();
    }

    [HttpPut]
    public ActionResult<bool> Update(
        [FromBody] UserObject userRecieve
    ) {
        if (userRecieve.Password == null)
            return BadRequest("password is null");

        bool isValid = this.DbUser.Update(userRecieve.Email, userRecieve.Password, userRecieve.Name, userRecieve.Image, out string errorMessage);

        if (!isValid)
            return BadRequest(errorMessage);

        return Ok();
    }

    [HttpDelete]
    public ActionResult<bool> Delete(
        [FromBody] UserObject userRecieve
    ) {
        if (userRecieve.Password == null)
            return BadRequest("password is null");

        bool isValid = this.DbUser.Delete(userRecieve.Email, userRecieve.Password, out string errorMessage);

        if (!isValid)
            BadRequest(errorMessage); // replace with Forbid()

        return Ok();
    }
}
