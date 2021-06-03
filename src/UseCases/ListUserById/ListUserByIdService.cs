using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using user_crud.Error;

namespace user_crud.Services {
  public class ListUserByIdService {

    private IUsersRepository _usersRepository;
    public ListUserByIdService(IUsersRepository usersRepository) {
      _usersRepository = usersRepository;
    }

    public User Execute(string id) {
      User user = this._usersRepository.FindById(id);

      if (user == null) {
        throw new AppError("User not found!", 404);
      }

      return user;
    }

  }
}