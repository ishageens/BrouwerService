﻿using BrouwerService.Models;
using System.Linq;
namespace BrouwerService.Repositories
{
    public interface IBrouwerRepository
    {
        IQueryable<Brouwer> FindAll();
        Brouwer FindById(int id);
        IQueryable<Brouwer> FindByBeginNaam(string begin);
        void Insert(Brouwer brouwer);
        void Delete(Brouwer brouwer);
        void Update(Brouwer brouwer);
    }
}