using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using user_crud.Services;

namespace user_crud.Controllers {
  [ApiController]
  [Route("/users")]
  public class DeleteUserController : ControllerBase {
    private DeleteUserService _deleteUserService;
    
    public DeleteUserController(IUsersRepository usersRepository) {
      this._deleteUserService = new DeleteUserService(usersRepository);
    }

    [HttpDelete("{id}")]
    public async Task<NoContentResult> Handle(string id) {
      await this._deleteUserService.Execute(id);

      return NoContent();
    }

  }
}