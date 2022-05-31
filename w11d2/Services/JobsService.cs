using System;
using System.Collections.Generic;
using w11d2.Repositories;
using w11d2.Models;

namespace w11d2.Services
{
    public class JobsService
    {
        private readonly JobsRepository _repo;

        public JobsService(JobsRepository repo)
        {
            _repo = repo;
        }

        internal Job GetById(int id)
        {
            Job found = _repo.GetById(id);
            if(found == null)
            {
                throw new Exception("Could not find job with that id.");
            }
            return found;
        }

        internal List<CompanyJobVM> GetByContractorId(int contractorId)
        {
            return _repo.GetByContractorId(contractorId);
        }

        internal List<ContractorJobVM> GetByCompanyId(int companyId)
        {
            return _repo.GetByCompanyId(companyId);
        }

        internal Job Create(Job data)
        {
            return _repo.Create(data);
        }

        internal Job Remove(int id)
        {
            Job removed = GetById(id);
            _repo.Remove(id);
            return removed;
        }
    }
}