using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;





namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {


    //GetAllKeeps //only where public
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> GetAllKeeps()
    {
      return Ok(_keepRepo.GetAllKeeps());
    }



    //GetKeepsByUserId
    [HttpGet("{userId}")]
    public ActionResult<IEnumerable<Keep>> Get(int userId)
    {
      var response = _keepRepo.GetKeepsByUserId(userId);
      if (response != null)
      {
        return Ok(response);
      }
      return BadRequest();
    }


    //AddKeep
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep payload)  //want to add a string saying that you successfully added a keep.
    {
      Keep response = _keepRepo.AddKeep(payload);
      if (response == null) throw new Exception("Unable to create keep!");
      return response;
    }



    //DeleteKeep
    [HttpDelete("{keepId}")]
    public ActionResult<string> Delete(int keepId)
    {
      if (_keepRepo.DeleteKeep(keepId))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete. Try again later.");
    }



    //constructor
    private readonly KeepRepository _keepRepo;
    public KeepsController(KeepRepository keepRepo)
    {
      _keepRepo = keepRepo;
    }
  }
}