using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using FitnessTracker;

namespace FitnessTracker.Models
{
  public class Login
  {
    private int _userId;
    private string _userName;
    private string _password;


    public Login(string userName, string password, int Id = 0)
    {
      _userId = Id;
      _userName = userName;
      _password = password;
    }
    public string GetUserName()
    {
      return _userName;
    }
    public string GetPassword()
    {
      return _password;
    }
    public int GetId()
    {
      return _userId;
    }

    public override bool Equals(System.Object otherLogin)
    {
      if (!(otherLogin is Login))
      {
        return false;
      }
      else
      {
        Login newLogin = (Login) otherLogin;
        bool idEquality = (this.GetId() == newLogin.GetId());
        bool nameEquality = (this.GetUserName() == newLogin.GetUserName());
        bool passwordEquality = this.GetPassword() == newLogin.GetPassword();
        return (idEquality && nameEquality && passwordEquality);
      }
    }
    public override int GetHashCode()
    {
      return this.GetUserName().GetHashCode();
    }

  }
}
