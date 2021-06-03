using System;

namespace user_crud {
  public class User {
    public string id { get; private set;}
    public string name { get; set;}
    public string email { get; set; }
    public string password { get; set; }
    public DateTime created_at { get; private set; }

    public User() {
      this.id = Convert.ToString(Guid.NewGuid());
      this.created_at = DateTime.Now;
    }
  } 
}