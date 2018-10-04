using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using FitnessTracker;

namespace FitnessTracker.Models
{
    public class PersonInfo
    {

    public    string   _firstName { get; set; }
    public    string   _lastName { get; set; }
    public    int     _personId  { get; set; }
    public   string   _phoneNumber { get; set; }
    public   string  _email { get; set; }
    public   double   _personHeight { get; set; }
    public   double   _registerWeight { get; set; }
    public   DateTime  _birthday { get; set; }
    public   string  _gender { get; set; }
    public  double bmi;


    public  PersonInfo(string firstName, string lastName)
    {
      _firstName=firstName;
      _lastName=lastName;
    }
    public PersonInfo(string firstName, string lastName, string phoneNumber, string email, double height, double weight, DateTime birthday, string gender)
    {
      _firstName = firstName;
      _lastName = lastName;
      _phoneNumber = phoneNumber;
      _email = email;
      _personHeight = height;
      _registerWeight = weight;
      _birthday = birthday;
      _gender = gender;
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
           bool areEmailsEqual = this._email.Equals(newPersonInfo._email);
           bool areHeightsEqual = this._personHeight.Equals(newPersonInfo._personHeight);
           bool areWeightsEqual = this._registerWeight.Equals(newPersonInfo._registerWeight);
           bool areDateEqual = this._birthday.Equals(newPersonInfo._birthday);
           bool areGenderEqual = this._gender.Equals(newPersonInfo._gender);
           bool areIdsEqual = this._personId.Equals(newPersonInfo._personId);

           return (areFirstNamesEqual && areSecondNamesEqual && arePhonesEqual && areEmailsEqual
              && areHeightsEqual && areWeightsEqual &&  areDateEqual &&  areGenderEqual &&  areIdsEqual);
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



               PersonInfo newPersonInfo = new PersonInfo(personFirstName, personSecondName,personPhone,
              personEmail,personHeigt ,personWeight,personBirthday,personGender);
               allPersonInfos.Add(newPersonInfo);
           }
           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
           return allPersonInfos;
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
                cmd.Parameters.Add(new MySqlParameter("@personEmail", this._email));
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

        public static PersonInfo Find(int id)
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM persons WHERE person_id = @personId;";

          cmd.Parameters.Add(new MySqlParameter("@personId", id));

          var rdr = cmd.ExecuteReader() as MySqlDataReader;

              int personId = 0;
               string personFirstName = "";
                string personSecondName = "";
                string personGender = "" ;
                 string personPhone = "";
                  string personEmail = "";
                   DateTime personBirthday = new DateTime(1000,11,11);
                   double personHeigt = 0;
                    double personWeight =0;

              while (rdr.Read())
          {
             personId = rdr.GetInt32(0);
              personFirstName = rdr.GetString(1);
               personSecondName = rdr.GetString(2);
               personGender = rdr.GetString(3);
                personPhone = rdr.GetString(4);
                 personEmail = rdr.GetString(5);
                  personBirthday = rdr.GetDateTime(6);
                  personHeigt = rdr.GetDouble(7);
                   personWeight = rdr.GetDouble(8);
          }
        

               PersonInfo foundPersonInfo = new PersonInfo(personFirstName, personSecondName,personPhone,
              personEmail,personHeigt ,personWeight,personBirthday,personGender);


          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }

          return foundPersonInfo;
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

    //  public   double bmi;

      public  double CalculatorBMI()
      {
       return    Math.Round(_registerWeight/(_personHeight/100*_personHeight/100),2);
           
             
            // if(bmi<15){
            //   Console.Write("Very severely underweight	");
            // }else if(bmi>15 && bmi<=16){
            //     Console.Write("Severely underweight	");
            // }else if (bmi>16 && bmi<=18.5) {
            //     Console.Write("Underweight");
            // }else if (bmi>18.5 && bmi<=25) {
            //   Console.Write("Normal (healthy weight)");
            // }else if (bmi>25 && bmi<=30) {
            //   Console.Write("Overweight");
            // }else if (bmi>30 && bmi<=35) {
            //   Console.Write("Obese Class I (Moderately obese)");
            // }else if (bmi>35 && bmi<=40) {
            //   Console.Write("Obese Class II (Severely obese)");
            // }else if (bmi>40 && bmi<=45) {
            //   Console.Write("Obese Class III (Very severely obese)");
            // }else if (bmi>45 && bmi<=50) {
            //   Console.Write("Obese Class IV (Morbidly Obese)");
            // }else if (bmi>50 && bmi<=60) {
            //   Console.Write("Obese Class V (Super Obese)");
            // }else if (bmi>60) {
            //   Console.Write("Obese Class VI (Hyper Obese)");
            // }
            
      }





















    }
}
