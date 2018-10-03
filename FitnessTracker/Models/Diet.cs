using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using FitnessTracker;

namespace FitnessTracker.Models
{
    public class Diet
    {
        public DateTime _dietDate{set;get;}
        public double _dietCalories{set;get;}
        public int person_id{set;get;}

        public Diet(DateTime DietDate,double DietCalories,int personId)
        {
            _dietDate=DietDate;
            _dietCalories=DietCalories;
            person_id=personId;


        }

        public override bool Equals(System.Object otherDiet)
 {
     if(!(otherDiet is Diet))
     {
         return false;
     }
     else
     {
         Diet newDiet = (Diet) otherDiet;
         bool areDietNameEqual = this._dietDate.Equals(newDiet._dietDate);
         bool areDietCalEqual = this._dietCalories.Equals(newDiet._dietCalories);

         return (areDietNameEqual);
     }
 }

        public override int GetHashCode()
        {
            return this._dietCalories.GetHashCode();
        }


     public void Save()
     {
     MySqlConnection conn = DB.Connection();
     conn.Open();

     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"INSERT INTO diets (diet_date,diet_calories,person_id)
                     VALUES (@dietDate,@dietCalories,@personId);";

             cmd.Parameters.Add(new MySqlParameter("@dietDate", this._dietDate));
             cmd.Parameters.Add(new MySqlParameter("@dietCalories", this._dietCalories));
             cmd.Parameters.Add(new MySqlParameter("@personId", this.person_id));

     cmd.ExecuteNonQuery();
     conn.Close();
     if (conn != null)
     {
         conn.Dispose();
     }
     }


         public  static  List<Diet> GetAll()
     {
     List<Diet> allDiets=new List<Diet>{};
     MySqlConnection conn =DB.Connection();
     conn.Open();
     var cmd =conn.CreateCommand() as MySqlCommand;
     cmd.CommandText=@"SELECT * FROM Diets;";
     var rdr = cmd.ExecuteReader() as MySqlDataReader;

     while (rdr.Read())
          {
              DateTime DietDate = new DateTime(0);
              double DietCalories = rdr.GetDouble(1);
              int personId=rdr.GetInt32(2);

              Diet newDiet = new Diet(DietDate, DietCalories,personId);
              allDiets.Add(newDiet);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allDiets;
     }

    public static Diet Find(int id)
   {
       MySqlConnection conn = DB.Connection();
       conn.Open();
       var cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"SELECT * FROM Diets WHERE person_id = @searchId;";

       cmd.Parameters.Add(new MySqlParameter("@searchId", id));

       var rdr = cmd.ExecuteReader() as MySqlDataReader;

              DateTime DietDate =new DateTime(1000,11,11);;
              double DietCalories =0;
              int personId =0;


           while (rdr.Read())
       {
            DietDate = rdr.GetDateTime(0);
             personId = rdr.GetInt32(2);
            DietCalories = rdr.GetDouble(1);
       }
        Diet foundDiet = new Diet(DietDate,DietCalories,personId);

       conn.Close();
       if (conn != null)
       {
           conn.Dispose();
       }

       return foundDiet;
   }

        public static void Delete(int id)
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand()as MySqlCommand;

        cmd.CommandText = @"DELETE  FROM diets  WHERE person_id = @id;";
        cmd.Parameters.Add(new MySqlParameter("@id", id));

        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }

    public void Edit(double dietCalories)
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"UPDATE diets SET diet_calories = @DietCalories WHERE person_id = @id;";

                cmd.Parameters.Add(new MySqlParameter("@DietCalories", this._dietCalories));
                cmd.Parameters.Add(new MySqlParameter("@id", this.person_id));

        cmd.ExecuteNonQuery();
        
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        }


        

    }
}
