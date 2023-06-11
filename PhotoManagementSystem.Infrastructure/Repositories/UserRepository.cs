using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;

using Oracle.ManagedDataAccess.Client;

using PhotoManagementSystem.Domain.Enum;
using PhotoManagementSystem.Domain.Models;
using PhotoManagementSystem.Infrastructure.Interfaces;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;

        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<User?> GetUserById(Guid id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Utilities.getUserQuery, connection))
                {
                    command.Parameters.Add("userId", OracleDbType.Raw).Value = id;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            User user = new User
                            {
                                Id = new Guid((byte[])reader["ID_USER"]),
                                Name = reader["NAME"].ToString()!,
                                Email = reader["EMAIL"].ToString()!,
                                Password = reader["PASSWORD"].ToString()!,
                                Role = (Role)(short)reader["ROLE"]
                            };
                             return user;
                        }
                    }
                }
            }
                return null;
        }
        public async Task DeleteUserById(Guid userId)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();


                using (OracleCommand command = new OracleCommand(Utilities.Deletequery, connection))
                {

                    
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = userId;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
 

        public async Task RegisterPhotograf(User user)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Utilities.createUserQuery, connection))
                {
                    command.Parameters.Add("ID_USER", OracleDbType.Raw).Value = user.Id;
                    command.Parameters.Add("NAME", OracleDbType.NVarchar2).Value = user.Name;
                    command.Parameters.Add("EMAIL", OracleDbType.NVarchar2).Value = user.Email;
                    command.Parameters.Add("PASSWORD", OracleDbType.NVarchar2).Value = user.Password;
                    command.Parameters.Add("ROLE", OracleDbType.Int32).Value = user.Role;

                    await command.ExecuteNonQueryAsync();
                }
            }
            
        }

        public async Task UpdateUser(User user)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();


                using (OracleCommand command = new OracleCommand(Utilities.updateUserQuery, connection))
                {
                    command.Parameters.Add("Name", OracleDbType.NVarchar2).Value = user.Name;
                    command.Parameters.Add("EmailAddress", OracleDbType.NVarchar2).Value = user.Email;
                    command.Parameters.Add("Id", OracleDbType.Varchar2).Value = user.Id.ToString();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();
                using (OracleCommand command = new OracleCommand(Utilities.getUserByEmailQuery, connection))
                {
                    command.Parameters.Add("EmailAddress", OracleDbType.NVarchar2).Value = email;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            User user = new User
                            {
                                Id = new Guid((byte[])reader["ID_USER"]),
                                Name = reader["NAME"].ToString()!,
                                Email = reader["EMAIL"].ToString()!,
                                Password = reader["PASSWORD"].ToString()!,
                                Role = (Role)(short)reader["ROLE"]
                            };
                            return user;
                        }
                    }
                }
            }
            return null;
        }

        
    }
}
