using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{

  public class VaultRepository
  {
    //GetAll
    public IEnumerable<Vault> GetAllVaults()
    {
      return _db.Query<Vault>("SELECT * FROM Vault");
    }

    //GetById
    public Vault GetById(int id)
    {
      return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM Vault WHERE id = @id", new { id });
    }

    //AddVault
    public Vault AddVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"
     INSERT INTO Vault(name,description,userId)
     VALUES(@Name,@Description,@UserId);
     SELECT LAST_INSERT_ID();
     ", newVault);
      newVault.Id = id;
      return newVault;
    }

    //DeleteVault
    public bool DeleteVault(int id)
    {
      int successfullyDeleted = _db.Execute(@"DELETE FROM Vault WHERE id = @id", new { id });
      return successfullyDeleted != 0;
    }
    //contructor
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}