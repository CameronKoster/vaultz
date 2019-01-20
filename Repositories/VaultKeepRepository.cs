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
       SELECT * FROM VaultKeeps vk
       INNER Join Keep k ON k.id = vk.KeepId
       WHERE(vaultId = @vaultId);
       ", new { vaultId });
    }
    //GetVaultByBookId
    public IEnumerable<Vault> GetVaultsByKeepId(int keepId)
    {
      return _db.Query<Vault>($@"
        SELECT * FROM VaultKeeps vk
        INNER JOIN Vault v ON v.id = vk.VaultId
        WHERE (keepId = @keepid);
      ", new { keepId });
    }
    //AddAVaultKeep
    public VaultKeep VaultKeep(VaultKeep vk)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO VaultKeep(vaultId, keepId)
      VALUES(@VaultId, @KeepId);
      SELECT LAST_INSERT_ID();
      ", vk);
      vk.Id = id;
      return vk;
    }
    //DeleteVaultKeep
    public bool DeleteVaultKeep(VaultKeep vk)
    {
      int success = _db.Execute(@"
      DELETE FROM VaultKeeps WHERE keepId = @KeepId AND vaultId = @VaultId", vk);
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