using System.Threading.Tasks;
using user_crud.Error;

namespace user_crud.Services {

  public class IRequestPut {
    public string id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
  }
  
  public class UpdateUserService {
    
    private IUsersRepository _usersRepository;

    public UpdateUserService(IUsersRepository usersRepository) {
      _usersRepository = usersRepository;
    }

    public async Task Execute(IRequestPut data) {
      User user = this._usersRepository.FindById(data.id);

      if (user == null) {
        throw new AppError("User not found!", 404);
      }

      user.name = data.name;
      user.email = data.email;

      await this._usersRepository.Save();
    }

  }
}