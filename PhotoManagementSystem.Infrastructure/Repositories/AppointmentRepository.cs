using Microsoft.Extensions.Configuration;

using Oracle.ManagedDataAccess.Client;

using PhotoManagementSystem.Domain.Models;
using PhotoManagementSystem.Infrastructure.Interfaces;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IConfiguration configuration;

        public AppointmentRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task CreateAppointmentRes(Appointment appointment)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                using (OracleCommand command = new OracleCommand(Utilities.createAppointmentQuery, connection))
                {
                    command.Parameters.Add("ID_APPOINTMENTS", OracleDbType.Raw).Value = appointment.Id;
                    command.Parameters.Add("ID_USER", OracleDbType.Raw).Value = appointment.IdUser;
                    command.Parameters.Add("ID_CLIENT", OracleDbType.Raw).Value = appointment.IdClient;
                    command.Parameters.Add("APPOINTMENT_DATE", OracleDbType.Date).Value = appointment.Date;
                    command.Parameters.Add("LOCATION", OracleDbType.NVarchar2).Value = appointment.Location;
                    command.Parameters.Add("DURATION", OracleDbType.Decimal).Value = appointment.Duration;
                    command.Parameters.Add("PREFERENCE", OracleDbType.NVarchar2).Value = appointment.Preferences;
                    command.Parameters.Add("SERVICE", OracleDbType.NVarchar2).Value = appointment.Service;
                    command.Parameters.Add("PRICE", OracleDbType.Decimal).Value = appointment.Price;
                    command.Parameters.Add("STATUS", OracleDbType.NVarchar2).Value = appointment.Status;


                    var test =
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
