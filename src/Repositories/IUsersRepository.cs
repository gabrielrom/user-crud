using System;
// using System.Collections.Generic;
using System.Threading.Tasks;

namespace user_crud {
  public class ICreateDTO {
    public string name {get; set;}
    public string email {get; set;}
    public string password { get; set;}
  }
  public interface IUsersRepository {
    Task<User> Create(ICreateDTO data);
    User FindByEmail(string email);
    User FindById(string id);
    Task Save();
    Task Delete(User user);
  }
}