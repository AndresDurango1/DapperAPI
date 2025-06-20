using Dapper;
using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly PeopleDBContext _peopleDBContext;
        public PeopleRepository(PeopleDBContext peopleDBContext)
        {
            _peopleDBContext = peopleDBContext;
        }
        public async Task<Author> GetAuthorById(Guid id)
        {
            using (var connection = _peopleDBContext.CreateConnection())
            {
                var paramsAuthor = new DynamicParameters();
                paramsAuthor.Add("@pAuthorId", id);
                var author = await connection.QueryFirstOrDefaultAsync<Author>("GetAuthorById", paramsAuthor, commandType: System.Data.CommandType.StoredProcedure);
                return author;
            }

        }
    }
}
