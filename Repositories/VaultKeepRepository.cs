using System.Data;

namespace Keepr.Repositories
{

  public class VaultKeepRepository
  {

    //GetBooksByVaultId

    //GetVaultByBookId

    //GetVaultsByUserId

    //GetKeepsByVaultId





    //constructor
    private readonly IDbConnection db
    public VaultKeepRepository(IDbConnection _db)
    {
      _db = db;
    }
  }
}