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


    //GetAll
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      return Ok(_keepRepo.GetAllKeeps());
    }


    //GetById
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      Keep response = _keepRepo.GetById(id);
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
      return Created("/api/keep/" + response.Id, response);
    }

    //DeleteKeep
    [HttpDelete]
    public ActionResult<string> Delete(int id)
    {
      if (_keepRepo.DeleteKeep(id))
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