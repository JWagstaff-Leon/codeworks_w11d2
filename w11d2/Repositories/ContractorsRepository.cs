using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using w11d2.Models;

namespace w11d2.Repositories
{
    public class ContractorsRepository
    {
        private readonly IDbConnection _db;

        public ContractorsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Contractor> GetAll()
        {
            string sql = @"
            SELECT *
            FROM contractors;
            ";

            return _db.Query<Contractor>(sql).ToList();
        }

        internal Contractor GetById(int id)
        {
            string sql = @"
            SELECT *
            FROM contractors
            WHERE id = @id;
            ";

            return _db.Query<Contractor>(sql, new { id }).FirstOrDefault();
        }

        internal Contractor Create(Contractor data)
        {
            string sql = @"
            INSERT
            INTO contractors
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";

            data.Id = _db.ExecuteScalar<int>(sql, data);
            return data;
        }

        internal Contractor Edit(Contractor update)
        {
            string sql = @"
            UPDATE contractors
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
            FROM contractors
            WHERE id = @id
            LIMIT 1;
            ";
            _db.Execute(sql, new { id });
        }
    }
}