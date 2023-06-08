using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

using PhotoManagementSystem.Domain.Enum;
using PhotoManagementSystem.Domain.Models;
using PhotoManagementSystem.Infrastructure.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IConfiguration configuration;

        public ClientRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Client?> GetClientById(Guid id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Utilities.getClientQuery, connection))
                {
                    command.Parameters.Add("clientId", OracleDbType.Raw).Value = id;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            Client client = new Client
                            {
                                Id = new Guid((byte[])reader["ID_CLIENT"]),
                                Name = reader["NAME"].ToString()!,
                                Email = reader["EMAIL"].ToString()!,
                                Password = reader["PASSWORD"].ToString()!,
                            };
                            return client;
                        }
                    }
                }
            }
            return null;
        }
        public async Task DeleteClientById(Guid clientId)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();


                using (OracleCommand command = new OracleCommand(Utilities.DeletequeryClient, connection))
                {
                    command.Parameters.Add("ID", OracleDbType.Raw).Value = clientId;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }


        public async Task Register(Client client)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Utilities.createClientQuery, connection))
                {
                    command.Parameters.Add("ID_USER", OracleDbType.Raw).Value = client.Id;
                    command.Parameters.Add("NAME", OracleDbType.NVarchar2).Value = client.Name;
                    command.Parameters.Add("EMAIL", OracleDbType.NVarchar2).Value = client.Email;
                    command.Parameters.Add("PASSWORD", OracleDbType.NVarchar2).Value = client.Password;

                    await command.ExecuteNonQueryAsync();
                }
            }

        }

        public async Task UpdateClient(Client client)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();


                using (OracleCommand command = new OracleCommand(Utilities.updateClientQuery, connection))
                {
                    command.Parameters.Add("Name", OracleDbType.NVarchar2).Value = client.Name;
                    command.Parameters.Add("EmailAddress", OracleDbType.NVarchar2).Value = client.Email;
                    command.Parameters.Add("Password", OracleDbType.NVarchar2).Value = client.Password;
                    command.Parameters.Add("Id", OracleDbType.Varchar2).Value = client.Id.ToString();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Client?> GetClientByEmail(string email)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();
                using (OracleCommand command = new OracleCommand(Utilities.getClientByEmailQuery, connection))
                {
                    command.Parameters.Add("EmailAddress", OracleDbType.NVarchar2).Value = email;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            Client client = new Client
                            {
                                Id = new Guid((byte[])reader["ID_USER"]),
                                Name = reader["NAME"].ToString()!,
                                Email = reader["EMAIL"].ToString()!,
                                Password = reader["PASSWORD"].ToString()!
                            };
                            return client;
                        }
                    }
                }
            }
            return null;
        }

    }
}
