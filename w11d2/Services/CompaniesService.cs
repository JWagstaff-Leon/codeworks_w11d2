using System;
using System.Collections.Generic;
using w11d2.Repositories;
using w11d2.Models;

namespace w11d2.Services
{
    public class CompaniesService
    {
        private readonly CompaniesRepository _repo;

        public CompaniesService(CompaniesRepository repo)
        {
            _repo = repo;
        }

        internal List<Company> GetAll()
        {
            return _repo.GetAll();
        }

        internal Company GetById(int id)
        {
            Company found = _repo.GetById(id);
            if(found == null)
            {
                throw new Exception("Could not find company with that id.");
            }
            return found;
        }
        
        internal Company Create(Company data)
        {
            return _repo.Create(data);
        }

        internal Company Edit(Company update)
        {
            Company edited = GetById(update.Id);
            edited.Name = update.Name ?? edited.Name;
            edited = _repo.Edit(edited);
            return edited;
        }

        internal Company Remove(int id)
        {
            Company removed = GetById(id);
            _repo.Remove(id);
            return removed;
        }
    }
}