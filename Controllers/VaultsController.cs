using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class VaultsController : ControllerBase
  {

    //GetAllVaults //only where public
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> GetAllVaults()
    {
      return Ok(_vaultRepo.GetAllVaults());
    }

    //GetVaultsByUserId
    [HttpGet("{userId}")]
    public ActionResult<IEnumerable<Vault>> Get(string userId)
    {
      var response = _vaultRepo.GetVaultsByUserId(userId);
      if (response != null)
      {
        return Ok(response);
      }
      return BadRequest();
    }



    //AddVault
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault payload)  //want to add a string saying that you successfully added a Vault.
    {
      payload.UserID = HttpContext.User.Identity.Name;
      Vault response = _vaultRepo.AddVault(payload);
      if (response == null) throw new Exception("Unable to create vault!");
      return response;
    }



    //DeleteVault
    [HttpDelete("{vaultId}")]
    public ActionResult<string> Delete(int vaultId)
    {

      if (_vaultRepo.DeleteVault(vaultId))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete. Try again later.");
    }

    //constructor
    private readonly VaultRepository _vaultRepo;
    public VaultsController(VaultRepository vaultRepo)
    {
      _vaultRepo = vaultRepo;
    }
  }
}