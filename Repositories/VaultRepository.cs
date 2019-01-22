using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{

  public class VaultRepository
  {
    // // GetAllVaults
    // public IEnumerable<Vault> GetAllVaults()
    // {
    //   return _db.Query<Vault>("SELECT * FROM vaults");
    // }



    //GetVaultsByUserId


    public IEnumerable<Vault> GetVaultsByUserId(string id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @id", new { id });
    }


    //GetAVaultByVaultId
    public Vault GetVaultById(int id)
    {
      return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM vaults WHERE id = @id", new { id });
    }



    //AddVault //need to make sure that all of my capitalization is correct
    public Vault AddVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"
     INSERT INTO vaults(name,description,userId)
     VALUES(@Name,@Description,@UserId);
     SELECT LAST_INSERT_ID()
     ", newVault);
      newVault.Id = id;
      return newVault;
    }



    //DeleteVault
    public bool DeleteVault(int id)
    {
      int successfullyDeleted = _db.Execute(@"DELETE FROM vaults WHERE id = @id", new { id });
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