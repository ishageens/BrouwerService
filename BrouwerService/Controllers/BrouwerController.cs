using BrouwerService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
