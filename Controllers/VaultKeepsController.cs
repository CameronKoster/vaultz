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
      return _vaultKeepRepo.GetKeepsByVaultId(vaultId);
    }



    //GetVaultsByKeepId
    [HttpGet("{keepId}")]
    public IEnumerable<Vault> GetVaultsByKeepId(int keepId)
    {
      return _vaultKeepRepo.GetVaultsByKeepId(keepId);
    }



    //AddVaultKeep
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep payload)  //want to add a string saying that you successfully added a Vault.
    {
      VaultKeep response = _vaultKeepRepo.AddVaultKeep(payload);
      if (response == null) throw new Exception("Unable to create vault!");
      return response;
    }



    //DeleteVaultKeep
    [HttpDelete("{id}")]
    public ActionResult<string> DeleteVaultKeep(VaultKeep vk)
    {
      var result = _vaultKeepRepo.DeleteVaultKeep(vk);
      if (result != null)
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