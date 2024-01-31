using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.UserContext.Entities;
using UserManagement.Infra.Shared;

namespace UserManagement.Infra.UserContext.Queries
{
    internal class UserQuery : BaseQuery
    {
        public QueryModel InsertUserQuery(User Entity)
        {
            this.Table = Map.UserTable;
            this.Query = @$"INSERT INTO {this.Table}
                            (
                             Id
                            ,Name
                            ,DocumentNumber
                            ,Email
                            ,Password
                            ,Active
                            ,CreationDate
                            ,UpdateDate
                            )
                            VALUES
                            (
                              @Id
                             ,@Name
                             ,@DocumentNumber
                             ,@Email
                             ,@Password
                             ,@Active
                             ,@CreationDate
                             ,@UpdateDate
                            )";

            this.Parameter = new
            {
                Entity.Id,
                Entity.Name,
                Entity.DocumentNumber,
                Entity.Email,
                Entity.Password,
                Active = 1,
                CreationDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
            };

            return new QueryModel(this.Query, this.Parameter);
        }
        public QueryModel AlterStatusUserQuery(User Entity)
        {
            this.Table = Map.UserTable;
            this.Query = @$"UPDATE {this.Table} 
                            SET [Active] = @Active,
                                [UPDATEDATE] = @UpdateDate
                            WHERE Id = @Id";

            this.Parameter = new
            {
                Entity.Id,
                Entity.Active,
                UpdateDate = DateTime.UtcNow
            };

            return new QueryModel(this.Query, this.Parameter);
        }
        public QueryModel UpdateUserQuery(User Entity)
        {
            this.Table = Map.UserTable;
            this.Query = @$"UPDATE {this.Table} 
                            SET [Name] = @Name,
                                [DocumentNumber] = @DocumentNumber,
                                [Email] = @Email,
                                [Password] = @Password,
                                [UPDATEDATE] = @UpdateDate
                            WHERE Id = @Id";

            this.Parameter = new
            {
                Entity.Id,
                Entity.Name,
                Entity.DocumentNumber,
                Entity.Email,
                Entity.Password,
                UpdateDate = DateTime.UtcNow
            };

            return new QueryModel(this.Query, this.Parameter);
        }
        public QueryModel GetByIdUserQuery(Guid EntityId)
        {
            this.Table = Map.UserTable;
            this.Query = @$"SELECT 
                                   [Id]
                                  ,[Name]
                                  ,[DocumentNumber]
                                  ,[Email]
                                  ,[Password]
                                  ,[Active]
                            FROM {this.Table} (nolock)
                            WHERE ID = @Id";

            this.Parameter = new
            {
                Id = EntityId
            };

            return new QueryModel(this.Query, this.Parameter);
        }
        public QueryModel GetAllUserQuery()
        {
            this.Table = Map.UserTable;
            this.Query = @$"SELECT 
                                   [Id]
                                  ,[Name]
                                  ,[DocumentNumber]
                                  ,[Email]
                                  ,[Password]
                                  ,[Active]
                            FROM {this.Table} (nolock)";



            return new QueryModel(this.Query, this.Parameter);
        }

        public QueryModel DeleteUserQuery(Guid EntityId)
        {
            this.Table = Map.UserTable;
            this.Query = @$"DELETE
                            {this.Table} (nolock)
                            WHERE ID = @Id";

            this.Parameter = new
            {
                Id = EntityId
            };

            return new QueryModel(this.Query, this.Parameter);
        }

        public QueryModel GetIsExistUserQuery(Guid id)
        {
            this.Table = Map.UserTable;
            this.Query = @$"SELECT COUNT(1)
                            FROM {this.Table} (nolock)
                            WHERE ID = @Id";

            this.Parameter = new
            {
                Id = id,
            };

            return new QueryModel(this.Query, this.Parameter);
        }
    }

}

