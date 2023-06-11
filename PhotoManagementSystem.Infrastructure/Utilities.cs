using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Infrastructure
{
    public static class Utilities
    {
        public const string createUserQuery = @"INSERT INTO Photographer_Administrator (ID_USER, NAME, PASSWORD, EMAIL, ROLE)
                                VALUES (:ID_USER, :NAME, :PASSWORD, :EMAIL, :ROLE)";
        public const string getUserQuery = "SELECT * FROM Photographer_Administrator WHERE ID_USER = :userId";
        public const string getUserByEmailQuery = "SELECT * FROM Photographer_Administrator WHERE EMAIL = :EmailAddress";
        public const string Deletequery = "DELETE FROM Photographer_Administrator WHERE ID_USER = :ID";
        public const string UpdateUserQuery = "UPDATE Photographer_Administrator SET NAME = :Name, EMAIL = :EmailAddress, PASSWORD = :Password, ROLE = :Role WHERE ID_USER = :Id";
        public const string updateUserQuery = @"UPDATE Photographer_Administrator SET 
                                    NAME = :Name,
                                    EMAIL = :EmailAddress,
                                    WHERE ID_USER = :Id";

        public const string createClientQuery = @"INSERT INTO Clients (ID_CLIENT, NAME, PASSWORD, EMAIL)
                                VALUES (:ID_CLIENT, :NAME, :PASSWORD, :EMAIL)";
        public const string getClientQuery = "SELECT * FROM Clients WHERE ID_CLIENT = :clientId";
        public const string getClientByEmailQuery = "SELECT * FROM Clients WHERE EMAIL = :EmailAddress";
        public const string DeletequeryClient = "DELETE FROM Clients WHERE ID_CLIENT = :ID";
        public const string UpdateClientQuery = "UPDATE Clients SET NAME = :Name, EMAIL = :EmailAddress, PASSWORD = :Password WHERE ID_CLIENT = :Id";
        public const string updateClientQuery = "UPDATE Clients SET NAME = :Name, EMAIL = :EmailAddress,  PASSWORD = :Password WHERE ID_CLIENT = :Id";

        public const string createAppointmentQuery = @"INSERT INTO Appointments_Fhoto (ID_APPOINTMENTS, ID_USER, ID_CLIENT, APPOINTMENT_DATE, LOCATION, DURATION, PREFERENCE, SERVICE, PRICE, STATUS)
                                VALUES (:ID_APPOINTMENTS, :ID_USER, :ID_CLIENT, :APPOINTMENT_DATE, :LOCATION, :DURATION, :PREFERENCE, :SERVICE, :PRICE, :STATUS)";
    }
}
