using System;
using System.Collections.Generic;
using cats.DB;
using Microsoft.AspNetCore.Mvc;
using ApiCats.Models;

namespace dogs.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DogsController : ControllerBase
  {
    //NOTE THIS IS NOT HOW TO REALLY DO IT!!!!
    public List<Dog> Dogs { get; set; } = FakeDB.Dogs;


    [HttpGet]
    public ActionResult<IEnumerable<Dog>> Get()
    {
      return Ok(Dogs);
    }

    [HttpGet("{id}")]
    public ActionResult<Dog> Get(string id)
    {
      try
      {
        Dog d = Dogs.Find(dog => dog.Id == id);
        if (d == null) { throw new Exception("Invalid Id"); }
        return Ok(d);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{index}/index")] // '/:index/index'
    public ActionResult<Dog> Get(int index)
    {
      try
      {
        Dog d = Dogs[index];
        return Ok(d);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    public ActionResult<Dog> Post([FromBody] Dog dog)//req.body
    {
      try
      {
        Dogs.Add(dog);
        return Ok(dog);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    [HttpPut("{id}")]
    public ActionResult<Dog> Edit(string id, [FromBody] Dog newDog)
    {
      try
      {

        Dog dogToEdit = Dogs.Find(dog => dog.Id == id);
        if (dogToEdit == null)
        {
          throw new ThisIsCat("Meow");
        }
        newDog.Id = dogToEdit.Id;
        Dogs[Dogs.IndexOf(dogToEdit)] = newDog;
        return Ok(newDog);
      }
      catch (ThisIsCat ae)
      {
        return Unauthorized(ae.Message);
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        int removed = Dogs.RemoveAll(dog => dog.Id == id);
        if (removed == 0)
        {
          throw new Exception("Invalid Id");
        }
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
