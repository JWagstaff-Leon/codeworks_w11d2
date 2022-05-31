using System;
using System.Collections.Generic;
using w11d2.Repositories;
using w11d2.Models;

namespace w11d2.Services
{
    public class ContractorsService
    {
        private readonly ContractorsRepository _repo;

        public ContractorsService(ContractorsRepository repo)
        {
            _repo = repo;
        }

        internal List<Contractor> GetAll()
        {
            return _repo.GetAll();
        }

        internal Contractor GetById(int id)
        {
            Contractor found = _repo.GetById(id);
            if(found == null)
            {
                throw new Exception("Could not find contractor with that id.");
            }
            return found;
        }
        
        internal Contractor Create(Contractor data)
        {
            return _repo.Create(data);
        }

        internal Contractor Edit(Contractor update)
        {
            Contractor edited = GetById(update.Id);
            edited.Name = update.Name ?? edited.Name;
            edited = _repo.Edit(edited);
            return edited;
        }

        internal Contractor Remove(int id)
        {
            Contractor removed = GetById(id);
            _repo.Remove(id);
            return removed;
        }
    }
}