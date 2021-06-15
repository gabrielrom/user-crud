using System;
using System.Threading.Tasks;
using user_crud.Error;
using user_crud.Utils;
using BC = BCrypt.Net.BCrypt;

namespace user_crud.Services {

  public class IRequest {
    public string name { get; set;}
    public string email { get; set;}
    public string password { get; set;}
  }
  public class CreateUserService {
    private IUsersRepository _usersRepository;
    private VerifyEmail _verifyEmail;

    public CreateUserService(IUsersRepository usersRepository) {
      _usersRepository = usersRepository;
      _verifyEmail = new VerifyEmail();
    }

    public async Task<User> Execute(IRequest data) {
      if (String.IsNullOrEmpty(data.email)) {
        throw new AppError("You cannot send an empty email");
      }

      if (!this._verifyEmail.EmailIsValid(data.email)) {
        throw new AppError("This email is not valid!");
      }

      User userAlreadyExists = this._usersRepository.FindByEmail(
        data.email
      );

      if (userAlreadyExists != null) {
        throw new AppError("This email is already in use");
      }

      string hashPassword = BC.HashPassword(data.password);

      User user = await this._usersRepository.Create(new ICreateDTO() {
        name = data.name,
        email = data.email,
        password = hashPassword,
      });

      return user;
    }

  }
}