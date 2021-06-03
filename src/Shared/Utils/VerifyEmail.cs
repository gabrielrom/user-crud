using System;

namespace user_crud.Utils {
  public class VerifyEmail {
    public bool EmailIsValid (string email) {
      // "gabriel@gmail.com" => ["gabriel", "gmail.com"]
      string[] emailSplited = email.Split('@');

      if (!email.Contains('@')) {
        return false;
      } else if (String.IsNullOrEmpty(emailSplited[1])) {
        return false;
      } else if (!email.Contains(".com")) {
        return false;
      }

      return true;
    }
  }
}