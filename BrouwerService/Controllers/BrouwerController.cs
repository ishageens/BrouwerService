using BrouwerService.Models;
using BrouwerService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
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

        [SwaggerOperation("Alle brouwers")]
        [HttpGet]
        public async Task<ActionResult> FindAll() => base.Ok(await repository.FindAllAsync());

        [SwaggerOperation("Brouwer waarvan je de id kent")]
        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var brouwer = await repository.FindByIdAsync(id);
            if (brouwer == null)
            {
                return base.NotFound();
            }
            return base.Ok(brouwer);
        }

        [SwaggerOperation("Brouwers waarvan je het begin van de naam kent")]
        [HttpGet("naam")]
        public async Task<ActionResult> FindByBeginNaam(string begin) => base.Ok(await repository.FindByBeginNaamAsync(begin));

        [SwaggerOperation("Brouwer verwijderen")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var brouwer = await repository.FindByIdAsync(id);
            if (brouwer == null)
            {
                return base.NotFound();
            }
            await repository.DeleteAsync(brouwer);
            return base.Ok();
        }

        [SwaggerOperation("Brouwer toevoegen")]
        [HttpPost]
        public async Task<ActionResult> Post(Brouwer brouwer)
        {
            if (this.ModelState.IsValid)
            {
                await repository.InsertAsync(brouwer);
                return base.CreatedAtAction(nameof(FindById), new { id = brouwer.Id }, null);
            }
            return base.BadRequest(this.ModelState);
        }

        [SwaggerOperation("Brouwer wijzigen")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Brouwer brouwer)
        {
            if (this.ModelState.IsValid && brouwer.Id == id)
            {
                try
                {
                    await repository.UpdateAsync(brouwer);
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
            return base.BadRequest(this.ModelState);
        }
    }
}
