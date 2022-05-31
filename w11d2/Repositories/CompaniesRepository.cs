using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using w11d2.Models;

namespace w11d2.Repositories
{
    public class CompaniesRepository
    {
        private readonly IDbConnection _db;

        public CompaniesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Company> GetAll()
        {
            string sql = @"
            SELECT *
            FROM companies;
            ";

            return _db.Query<Company>(sql).ToList();
        }

        internal Company GetById(int id)
        {
            string sql = @"
            SELECT *
            FROM companies
            WHERE id = @id;
            ";

            return _db.Query<Company>(sql, new { id }).FirstOrDefault();
        }

        internal Company Create(Company data)
        {
            string sql = @"
            INSERT
            INTO companies
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";

            data.Id = _db.ExecuteScalar<int>(sql, data);
            return data;
        }

        internal Company Edit(Company update)
        {
            string sql = @"
            UPDATE companies
            SET
                name = @Name,
                rate = @rate
            WHERE id = @Id
            LIMIT 1;
            ";
            _db.Execute(sql, update);
            return update;
        }

        internal void Remove(int id)
        {
            string sql = @"
            DELETE
            FROM companies
            WHERE id = @id
            LIMIT 1;
            ";
            _db.Execute(sql, new { id });
        }
    }
}