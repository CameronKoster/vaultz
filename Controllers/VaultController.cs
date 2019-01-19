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
    //GetAll
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      return Ok(_vaultRepo.GetAllVaults());
    }

    //GetById
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      Vault response = _vaultRepo.GetById(id);
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
      Vault response = _vaultRepo.AddVault(payload);
      return Created("/api/Vault/" + response.Id, response);
    }

    //DeleteVault
    [HttpDelete]
    public ActionResult<string> Delete(int id)
    {
      if (_vaultRepo.DeleteVault(id))
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