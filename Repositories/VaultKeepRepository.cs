using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{

  public class VaultKeepRepository
  {
    //GetKeepsByVaultId
    public IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
    {
      return _db.Query<Keep>(@"
       SELECT * FROM vaultkeeps vk
       INNER JOIN keeps k ON k.id = vk.keepId
       WHERE(vk.vaultId = @VaultId);
       ", new { vaultId });
    }







    //AddAVaultKeep
    public VaultKeep AddVaultKeep(VaultKeep vk)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultkeeps(vaultId, keepId, userId)
      VALUES(@VaultId, @KeepId, @UserId);
      SELECT LAST_INSERT_ID();
      ", vk);
      vk.Id = id;
      return vk;
    }



    //DeleteVaultKeep
    public bool DeleteVaultKeep(VaultKeep vk)
    {
      int success = _db.Execute(@"
      DELETE FROM vaultkeeps WHERE keepId = @KeepId AND vaultId = @VaultId", vk);
      return success != 0;
    }



    //constructor
    private readonly IDbConnection _db;
    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}