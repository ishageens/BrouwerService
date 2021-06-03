using BrouwerService.Models;
using BrouwerService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrouwerService.Controllers
{
    [Route("brouwers")]
    [ApiController]
    public class BrouwerController : ControllerBase
    {
        private readonly IBrouwerRepository repository;
        public BrouwerController(IBrouwerRepository repository) =>
        this.repository = repository;

        [HttpGet]
        public IActionResult FindAll() => base.Ok(repository.FindAll());

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var brouwer = repository.FindById(id);
            if (brouwer == null)
            {
                return base.NotFound();
            }
            return base.Ok(brouwer);
        }

        [HttpGet("naam")]
        public ActionResult FindByBeginNaam(string begin) => base.Ok(repository.FindByBeginNaam(begin));

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var brouwer = repository.FindById(id);
            if (brouwer == null)
            {
                return base.NotFound();
            }
            repository.Delete(brouwer);
            return base.Ok();
        }

        [HttpPost]
        public IActionResult Post(Brouwer brouwer)
        {
            repository.Insert(brouwer);
            return base.CreatedAtAction(nameof(FindById), new { id = brouwer.Id }, null);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Brouwer brouwer)
        {
            try
            {
                repository.Update(brouwer);
                return base.Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return base.NotFound();
            }
            catch
            {
                return base.Problem();
            }
        }
    }
}
