using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using user_crud.Error;

namespace user_crud.Services {
  public class DeleteUserService {
    private IUsersRepository _usersRepository;
    public DeleteUserService(IUsersRepository usersRepository) {
      _usersRepository = usersRepository;
    }

    public async Task Execute(string id) {
      User user = this._usersRepository.FindById(id);

      if (user == null) {
        throw new AppError("User not found!", 404);
      }

      await this._usersRepository.Delete(user);
    }

  }
}