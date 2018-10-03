using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using FitnessTracker;

namespace FitnessTracker.Models
{
  public class Exercise
  {
      public  string _exerciseName { get; set; }
      public  int _exerciseId { get; set; }


  public Exercise(string exerciseName,int exerciseId=0){
        _exerciseName=exerciseName;
        _exerciseId=exerciseId;
  }


  public override bool Equals(System.Object otherExercise)
 {
     if(!(otherExercise is Exercise))
     {
         return false;
     }
     else
     {
         Exercise newExercise = (Exercise) otherExercise;
         bool areexerciseNameEqual = this._exerciseName.Equals(newExercise._exerciseName);
         return (areexerciseNameEqual);
     }
 }

 public override int GetHashCode()
 {
     return this.exerciseName.GetHashCode();
 }



      public void Save()
     {
     MySqlConnection conn = DB.Connection();
     conn.Open();

     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"INSERT INTO exercises (exercise_name)
                     VALUES (@exerciseName);";

             cmd.Parameters.Add(new MySqlParameter("@exerciseName", this._exerciseName));

     cmd.ExecuteNonQuery();
     _exerciseId = (int) cmd.LastInsertedId;
     conn.Close();
     if (conn != null)
     {
         conn.Dispose();
     }
     }

     public  static  List<Exercise> GetAll()
     {
     List<Exercise> allExercises=new List<Exercise>{};
     MySqlConnection conn =DB.Connection();
     conn.Open();
     var cmd =conn.CreateCommand() as MySqlCommand;
     cmd.CommandText=@"SELECT * FROM exercises;";
     var rdr = cmd.ExecuteReader() as MySqlDataReader;

     while (rdr.Read())
          {
              int exerciseId = rdr.GetInt32(0);
              string exerciseName = rdr.GetString(1);


              Exercise newExercise = new Exercise(exerciseName, exerciseId);
              allExercises.Add(newExercise);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allExercises;
     }



     public static Exercise Find(int id)
   {
       MySqlConnection conn = DB.Connection();
       conn.Open();
       var cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"SELECT * FROM exercises WHERE exercise_id = @exerciseId;";

       cmd.Parameters.Add(new MySqlParameter("@exerciseId", id));

       var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int exerciseId = 0;
            string exerciseName = "";


           while (rdr.Read())
       {
            exerciseId = rdr.GetInt32(0);
            exerciseName = rdr.GetString(1);
       }
        Exercise foundExercise = new Exercise(exerciseName,exerciseId);

       conn.Close();
       if (conn != null)
       {
           conn.Dispose();
       }

       return foundExercise;
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
