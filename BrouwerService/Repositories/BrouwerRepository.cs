using System.Linq;
using BrouwerService.Models;
using Microsoft.EntityFrameworkCore;

namespace BrouwerService.Repositories
{
    public class BrouwerRepository : IBrouwerRepository
    {
        private readonly BierlandContext context;
        public BrouwerRepository(BierlandContext context) => this.context = context;
        public IQueryable<Brouwer> FindAll() =>
        context.Brouwers.AsNoTracking().AsQueryable();
        public Brouwer FindById(int id) => context.Brouwers.Find(id);
        public IQueryable<Brouwer> FindByBeginNaam(string begin) =>
        context.Brouwers.AsNoTracking()
        .Where(brouwer => brouwer.Naam.StartsWith(begin));
        public void Insert(Brouwer brouwer)
        {
            context.Brouwers.Add(brouwer);
            context.SaveChanges();
        }
        public void Delete(Brouwer brouwer)
        {
            context.Brouwers.Remove(brouwer);
            context.SaveChanges();
        }
        public void Update(Brouwer brouwer)
        {
            context.Brouwers.Update(brouwer);
            context.SaveChanges();
        }
    }
}