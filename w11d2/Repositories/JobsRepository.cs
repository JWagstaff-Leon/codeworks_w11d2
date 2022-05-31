using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using w11d2.Models;

namespace w11d2.Repositories
{
    public class JobsRepository
    {
        private readonly IDbConnection _db;

        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Job GetById(int id)
        {
            string sql = @"
            SELECT *
            FROM jobs
            WHERE id = @id;
            ";
            return _db.Query<Job>(sql, new { id }).FirstOrDefault();
        }

        internal List<CompanyJobVM> GetByContractorId(int contractorId)
        {
            string sql = @"
            SELECT
                com.*,
                job.id AS JobId
            FROM jobs job
            JOIN companies com ON job.companyId = com.id
            WHERE job.contractorId = @contractorId;
            ";
            return _db.Query<CompanyJobVM>(sql, new { contractorId }).ToList();
        }

        internal List<ContractorJobVM> GetByCompanyId(int companyId)
        {
            string sql = @"
            SELECT
                con.*,
                job.id AS JobId
            FROM jobs job
            JOIN contractors con ON job.contractorId = con.id
            WHERE job.companyId = @companyId;
            ";
            return _db.Query<ContractorJobVM>(sql, new { companyId }).ToList();
        }

        internal Job Create(Job data)
        {
            string sql = @"
            INSERT
            INTO jobs
            (contractorId, companyId)
            VALUES
            (@ContractorId, @CompanyId);
            SELECT LAST_INSERT_ID();
            ";
            data.Id =  _db.ExecuteScalar<int>(sql, data);
            return data;
        }

        internal void Remove(int id)
        {
            string sql = @"
            DELETE
            FROM jobs
            WHERE id = @id
            LIMIT 1;
            ";
            _db.Execute(sql, new { id });
        }
    }
}