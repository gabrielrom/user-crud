using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace user_crud {
  public class UsersRepository : IUsersRepository {
    private DataContext repository;

    public UsersRepository([FromServices]DataContext context) {
      repository = context;
    }

    public async Task<User> Create(ICreateDTO data) {
      User user = new User() {
        name = data.name,
        email = data.email,
        password = data.password
      };

      repository.Add(user);
      await repository.SaveChangesAsync();

      return user;
    }

    public User FindByEmail(string email) {
      User user = (
        from data in repository.Users
        where data.email == email
        select data).FirstOrDefault();

      return user;
    }

    public User FindById(string id) {
      User user = (
        from data in repository.Users
        where data.id == id
        select data).FirstOrDefault();

      return user;
    }
  }
}