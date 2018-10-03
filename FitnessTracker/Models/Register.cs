using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using FitnessTracker;

namespace FitnessTracker.Models
{
  public class Register
  {
    private int _userId;
    private string _userName;
    private string _password;


    public Register(string userName, string password, int Id = 0)
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

    public override bool Equals(System.Object otherRegister)
    {
      if (!(otherRegister is Register))
      {
        return false;
      }
      else
      {
        Register newRegister = (Register) otherRegister;
        bool idEquality = (this.GetId() == newRegister.GetId());
        bool nameEquality = (this.GetUserName() == newRegister.GetUserName());
        bool passwordEquality = this.GetPassword() == newRegister.GetPassword();
        return (idEquality && nameEquality && passwordEquality);
      }
    }
    public override int GetHashCode()
    {
      return this.GetUserName().GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO register (username, password) VALUES (@UserName, @Password);";

      MySqlParameter userName = new MySqlParameter();
      userName.ParameterName = "@UserName";
      userName.Value = this._userName;
      cmd.Parameters.Add(userName);

      MySqlParameter password = new MySqlParameter();
      password.ParameterName = "@Password";
      password.Value = this._password;
      cmd.Parameters.Add(password);
      cmd.ExecuteNonQuery();
      _userId = (int) cmd.LastInsertedId;

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

    public static Register Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `register` WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int userId = 0;
      string userName = "";
      string password = "";
      while (rdr.Read())
      {
        userId = rdr.GetInt32(0);
        userName = rdr.GetString(1);
        password = rdr.GetString(2);
      }
      Register foundRegister = new Register(userName, password, userId);


      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundRegister;
    }

    public void ClearAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM exercises;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }

    
  }
}
