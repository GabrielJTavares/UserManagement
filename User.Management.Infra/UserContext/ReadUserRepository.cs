using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Context.UserContext.Interfaces.Repository;
using UserManagement.Domain.UserContext.Entities;
using UserManagement.Infra.UserContext.Queries;

namespace UserManagement.Infra.UserContext
{
    public class ReadUserRepository : IReadUserRepository
    {
        private readonly IDbConnection _connection;

        public ReadUserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<User> GetById(Guid entityId)
        {
            var query = new UserQuery().GetByIdUserQuery(entityId);

            try
            {
                using (_connection)
                    return await _connection.QueryFirstOrDefaultAsync<User>(query.Query, query.Parameter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var query = new UserQuery().GetAllUserQuery();

            try
            {
                using(_connection)
                    return await _connection.QueryAsync<User>(query.Query,query.Parameter);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> IsExist(Guid id)
        {
            var query = new UserQuery().GetIsExistUserQuery(id);

            try
            {
                using (_connection)
                    return await _connection.ExecuteScalarAsync<int>(query.Query, query.Parameter) > 0;
            }
            catch { throw; }
        }
    }
}
