using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class VaultKeepsController : ControllerBase
  {

    //GetKeepsByVaultId
    [HttpGet("{vaultId}")]

    public IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
    {
      // var id = HttpContext.User.Identity.Name;
      return _vaultKeepRepo.GetKeepsByVaultId(vaultId);
    }







    //AddVaultKeep
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep payload)  //want to add a string saying that you successfully added a Vault.
    {
      payload.UserId = HttpContext.User.Identity.Name;
      VaultKeep response = _vaultKeepRepo.AddVaultKeep(payload);
      if (response == null) throw new Exception("Unable to create vault!");
      return response;
    }



    //DeleteVaultKeep
    [HttpPut]
    public ActionResult<string> DeleteVaultKeep([FromBody]VaultKeep vk)
    {
      var result = _vaultKeepRepo.DeleteVaultKeep(vk);
      if (result == true)
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete. Try again later.");
    }



    //constructor
    private readonly VaultKeepRepository _vaultKeepRepo;
    public VaultKeepsController(VaultKeepRepository vaultKeepRepo)
    {
      _vaultKeepRepo = vaultKeepRepo;
    }
  }
}