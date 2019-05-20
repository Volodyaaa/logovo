using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using a.Models;

namespace a.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lab1Controller : ControllerBase
    {
        private static List<InstaBlogger> _memCache = new List<InstaBlogger>();

        [HttpGet]
        public ActionResult<IEnumerable<InstaBlogger>> Get()
        {
            return Ok (_memCache);
        }

        [HttpGet("{id}")]
        public ActionResult<InstaBlogger> Get(int id)
        {
            if (_memCache.Count <= id) return NotFound("No such");

            return Ok (_memCache[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] InstaBlogger value)
        {
            var validationResult = value.Validate();

           if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

           _memCache.Add(value);

           return Ok($"{value.ToString()} has been added");
       }

        

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InstaBlogger value)
        {
            if (_memCache.Count <= id) return NotFound("No such");

           var validationResult = value.Validate();

           if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

           var previousValue = _memCache[id];
           _memCache[id] = value;

           return Ok($"{previousValue.ToString()} has been updated to {value.ToString()}");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_memCache.Count <= id) return NotFound("No such");

           var valueToRemove = _memCache[id];
           _memCache.RemoveAt(id);

           return Ok($"{valueToRemove.ToString()} has been removed");

        }
    }
}
