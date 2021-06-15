using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using user_crud.Services;

namespace user_crud.Controllers
{
  public class IRequestPutBody {
    public string name {get; set;}
    public string email { get; set;}
  }

  [ApiController]
  [Route("/users")]
  public class UpdateUserController : ControllerBase {
    private UpdateUserService _updateUserService;
    public UpdateUserController(IUsersRepository usersRepository) {
      this._updateUserService = new UpdateUserService(usersRepository);
    }

    [HttpPut("{id}")]
    public async Task<NoContentResult> Handle(
      string id, 
      [FromBody] IRequestPutBody data
    ) {
      await this._updateUserService.Execute(new IRequestPut() {
        id = id,
        name = data.name,
        email = data.email,
      });

      return NoContent();
    }
  }
}