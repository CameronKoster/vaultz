using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
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
    [HttpGet("user")]
    public IEnumerable<Keep> Get()
    {
      string uid = HttpContext.User.Identity.Name;
      return _keepRepo.GetKeepsByUserId(uid);
    }



    //AddKeep
    [HttpPost]
    [Authorize] //checks that user is logged in before entering the route
    public ActionResult<Keep> Post([FromBody] Keep payload)  //want to add a string saying that you successfully added a keep.
    {
      payload.UserID = HttpContext.User.Identity.Name;
      Keep response = _keepRepo.AddKeep(payload);
      // if (response == null) throw new Exception("Unable to create keep!");
      // return response;
      if (response != null)
      {
        return Ok("Successfully added!");
      }
      return BadRequest("Unable to add. Try again later.");
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


    //EditKeep
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep keep)
    {
      try
      {
        Keep editedKeep = _keepRepo.EditKeep(id, keep);
        return editedKeep;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("Keep not found!");
      }
    }


    //constructor
    private readonly KeepRepository _keepRepo;
    public KeepsController(KeepRepository keepRepo)
    {
      _keepRepo = keepRepo;
    }
  }
}