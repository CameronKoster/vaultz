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
      return _db.Query<Keep>("SELECT * FROM Keep");
    }

    //GetById
    public Keep GetById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM Keep WHERE id = @id", new { id });
    }


    //AddKeep
    public Keep AddKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
     INSERT INTO Keep(name,img,description,views,userId,isprivate,keeps)
     VALUES(@Name,@Img,@Description,@Views,@UserId,@IsPrivate,@Keeps);
     SELECT LAST_INSERT_ID();
     ", newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    //DeleteKeep
    public bool DeleteKeep(int id)
    {
      int successfullyDeleted = _db.Execute(@"DELETE FROM Keep WHERE id = @id", new { id });
      return successfullyDeleted != 0;
    }

    //constructor
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }

  }
}