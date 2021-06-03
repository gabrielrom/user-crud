using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using user_crud.Error;
using BC = BCrypt.Net.BCrypt;

namespace user_crud.Services {

  public class IRequest {
    public string name { get; set;}
    public string email { get; set;}
    public string password { get; set;}
  }
  public class CreateUserService {
    private IUsersRepository _usersRepository;

    public CreateUserService(IUsersRepository usersRepository) {
      _usersRepository = usersRepository;
    }

    public async Task<User> Execute(IRequest data) {
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
        password = hashPassword
      });

      return user;
    }

  }
}