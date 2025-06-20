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
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryDBContext _dbContext;

        public LibraryRepository(LibraryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> GetBookById(int id)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var paramsbook = new DynamicParameters();
                paramsbook.Add("@pId", id);
                var book = await connection.QueryFirstOrDefaultAsync<Book>("GetBookById", paramsbook, commandType: System.Data.CommandType.StoredProcedure);
                return book;
            }
        }
    }
}
