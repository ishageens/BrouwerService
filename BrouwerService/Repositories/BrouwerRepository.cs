using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrouwerService.Models;
using Microsoft.EntityFrameworkCore;

namespace BrouwerService.Repositories
{
    public class BrouwerRepository : IBrouwerRepository
    {
        private readonly BierlandContext context;
        public BrouwerRepository(BierlandContext context) => this.context = context;
        public async Task DeleteAsync(Brouwer brouwer)
        {
            context.Brouwers.Remove(brouwer);
            await context.SaveChangesAsync();
        }
        public async Task<List<Brouwer>> FindAllAsync() => await context.Brouwers.AsNoTracking().ToListAsync();
        public async Task<List<Brouwer>> FindByBeginNaamAsync(string begin) => await context.Brouwers.AsNoTracking().Where(brouwer => brouwer.Naam.StartsWith(begin)).ToListAsync();
        public async Task<Brouwer> FindByIdAsync(int id) => await context.Brouwers.FindAsync(id);
        public async Task InsertAsync(Brouwer brouwer)
        {
            context.Brouwers.Add(brouwer);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Brouwer brouwer)
        {
            context.Brouwers.Update(brouwer);
            await context.SaveChangesAsync();
        }
    }
}