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

    //GetById
    [HttpGet("{id}")]

    //AddKeep


    //DeleteKeep













    //constructor
    private readonly KeepRepository _keepRepo;
    public KeepsController(KeepRepository keepRepo)
    {
      _keepRepo = keepRepo;
    }
  }
}