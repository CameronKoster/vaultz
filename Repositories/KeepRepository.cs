using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{

  public class KeepRepository
  {

    //GetAll
    public IEnumerable<Keep> GetAllKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE IsPrivate = 0");
    }



    //GetKeepsByUserId
    public IEnumerable<Keep> GetKeepsByUserId(string id)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @id", new { id });
    }



    //AddKeep
    public Keep AddKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
     INSERT INTO keeps(name,img,description,userId,isprivate)
     VALUES(@Name,@Img,@Description,@UserId,@IsPrivate);
     SELECT LAST_INSERT_ID();
     ", newKeep);
      newKeep.Id = id;
      return newKeep;
    }



    //DeleteKeep
    public bool DeleteKeep(int keepId, string userId)
    {
      int successfullyDeleted = _db.Execute(@"DELETE FROM keeps WHERE id = @keepId && userid = @userId", new { keepId, userId });
      return successfullyDeleted != 0;
    }


    //EditKeep
    public Keep EditKeep(int id, Keep newKeep)
    {
      try
      {
        return _db.QueryFirstOrDefault<Keep>(@"
                UPDATE keeps SET
                Name = @Name,
                Description = @Description,
                isPrivate = @isPrivate
                WHERE id = @Id
                ", newKeep);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

    //constructor
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }

  }
}