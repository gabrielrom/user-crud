using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using user_crud.Services;

namespace user_crud.Controllers {
  public class IRequestBody {
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
  }


  [ApiController]
  [Route("/users")]
  public class CreateUserController : ControllerBase {
    private CreateUserService _createUserService;
    public CreateUserController(IUsersRepository usersRepository) {
      this._createUserService = new CreateUserService(usersRepository);
    }

    [HttpPost]
    public async Task<Object> Handle([FromBody] IRequestBody request) {
      User user = await this._createUserService.Execute(new IRequest() {
        name = request.name,
        email = request.email,
        password = request.password,
      });

      return new {
        id = user.id,
        name = user.name,
        email = user.email,
        created_at = user.created_at,
      };
    }

  }
}