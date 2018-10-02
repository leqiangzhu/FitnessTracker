using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using FitnessTracker;

namespace FitnessTracker.Models
{
    public class PersonInfo
    {
    private   string   _firstName { get; set; };
    private   string   _lastName { get; set; };
    private   int     _personId  { get; set; };
    private  string   _phoneNumber { get; set; };
    private  string  _email { get; set; };
    private  double   _personHeight { get; set; };
    private  double   _registerWeight { get; set; };
    private  datetime  _birthday { get; set; };
    private  string  _gender { get; set; };


    public  PersonInfo ()
    {

    }

    public override bool Equals(System.Object otherPersonInfo)
   {
       if(!(otherPersonInfo is PersonInfo))
       {
           return false;
       }
       else
       {
           PersonInfo newPersonInfo = (PersonInfo) otherPersonInfo;
           bool areFirstNamesEqual = this._firstName.Equals(newPersonInfo._firstName);
           bool areSecondNamesEqual = this._lastName.Equals(newPersonInfo._lastName);
           bool arePhonesEqual = this._phoneNumber.Equals(newPersonInfo._phoneNumber);
           bool areEmailsEqual = this._eamil.Equals(newPersonInfo._eamil);
           bool areHeightsEqual = this._height.Equals(newPersonInfo._personHeight);
           bool areWeightsEqual = this._registerWeight.Equals(newPersonInfo._registerWeight);
           bool areDateEqual = this._birthday.Equals(newPersonInfo._birthday);
           bool areGenderEqual = this._gender.Equals(newPersonInfo._gender);
           bool areIdsEqual = this._personId.Equals(newPersonInfo._personId);

           return (areNamesEqual && areIdsEqual);
       }
   }

         public override int GetHashCode()
         {
             return this._firstName.GetHashCode();
         }


      public  static  List<PersonInfo> GetAllInfo()
      {
      List<PersonInfo> allPersonInfos=new List<PersonInfo>{};
      MySqlConnection conn =DB.Connection();
      conn.Open();
      var cmd =conn.CreateCommand() as MySqlCommand;
      cmd.CommandText=@"SELECT * FROM persons;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
           {
              int personId = rdr.GetInt32(0);
               string personFirstName = rdr.GetString(1);
                string personSecondName = rdr.GetString(2);
                string personGender = rdr.GetString(3);
                 string personPhone = rdr.GetString(4);
                  string personEmail = rdr.GetString(5);
                   DateTime personBirthday = rdr.GetDateTime(6);
                   double personHeigt = rdr.GetDouble(7);
                    double personWeight = rdr.GetDouble(8);

               PersonInfo newPersonInfo = new PersonInfo(patronName, patronId);
               allPersonInfos.Add(newPatron);
           }
           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
           return PersonInfo;
    }



    public void Save()
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO persons (person_first, person_second,
                                      person_gender,person_phone,person_email,
                                      person_birthday,person_height,person_weight)
                        VALUES (
                                      @personFirst, @personSecond,@personGender,@personPhone,
                                      @personEmail,@personBirthday,@personHeigt,@personWeight);";

                cmd.Parameters.Add(new MySqlParameter("@personFirst", this._firstName));
                cmd.Parameters.Add(new MySqlParameter("@personSecond", this._lastName));
                cmd.Parameters.Add(new MySqlParameter("@personGender", this._gender));
                cmd.Parameters.Add(new MySqlParameter("@personPhone", this._phoneNumber));
                cmd.Parameters.Add(new MySqlParameter("@personEmail", this._eamil));
                cmd.Parameters.Add(new MySqlParameter("@personBirthday", this._birthday));
                cmd.Parameters.Add(new MySqlParameter("@personHeigt", this._personHeight));
                cmd.Parameters.Add(new MySqlParameter("@personWeight", this._registerWeight));

        cmd.ExecuteNonQuery();
        _personId = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        }













    }
}
