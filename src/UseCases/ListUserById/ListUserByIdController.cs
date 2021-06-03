using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using user_crud.Services;

namespace user_crud.Controllers {

  [ApiController]
  [Route("/users")]
  public class ListUserByIdController : ControllerBase {
    private ListUserByIdService _listUserByIdService;
    public ListUserByIdController(IUsersRepository usersRepository) {
      this._listUserByIdService = new ListUserByIdService(usersRepository);
    }

    [HttpGet("{id}")]
    public Object Handle(string id) {
      User user = this._listUserByIdService.Execute(id);

      return new {
        id = user.id,
        name = user.name,
        email = user.email,
        created_at = user.created_at,
      };
    }

  }
}