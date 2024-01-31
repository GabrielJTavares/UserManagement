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
    public class UserRepository : IUserRepository
    {

        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> Create(User entity)
        {
            var query = new UserQuery().InsertUserQuery(entity);

            try
            {
                using (_connection)
                    return await _connection.ExecuteAsync(query.Query, query.Parameter) == 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(User entity)
        {
            var query = new UserQuery().AlterStatusUserQuery(entity);

            try
            {
                using (_connection)
                    return await _connection.ExecuteAsync(query.Query, query.Parameter) == 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Update(User entity)
        {
            var query = new UserQuery().UpdateUserQuery(entity);

            try
            {
                using (_connection)
                    return await _connection.ExecuteAsync(query.Query, query.Parameter) == 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
