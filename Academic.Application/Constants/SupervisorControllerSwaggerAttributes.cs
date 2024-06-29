using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Constants
{
    public static class SupervisorControllerSwaggerAttributes
    {
        public const string GetAllSupervisorsSummary = "Retrieves all supervisors.";
        public const string GetSupervisorByIdSummary = "Retrieves a single supervisor by ID.";
        public const string AddSupervisorSummary = "Adds a new supervisor.";
        public const string UpdateSupervisorSummary = "Updates an existing supervisor.";
        public const string DeleteSupervisorSummary = "Deletes an existing supervisor.";

        public const string GetAllSupervisorsResponse200 = "A list of supervisors with detailed information.";
        public const string GetAllSupervisorsResponse404 = "If no supervisors are found.";

        public const string GetSupervisorByIdResponse200 = "If the supervisor is found.";
        public const string GetSupervisorByIdResponse404 = "If the supervisor is not found.";

        public const string AddSupervisorResponse201 = "Supervisor added successfully.";
        public const string AddSupervisorResponse400 = "Invalid supervisor data.";

        public const string UpdateSupervisorResponse204 = "Supervisor updated successfully.";
        public const string UpdateSupervisorResponse400 = "Invalid supervisor data.";
        public const string UpdateSupervisorResponse404 = "If the supervisor is not found.";

        public const string DeleteSupervisorResponse204 = "Supervisor deleted successfully.";
        public const string DeleteSupervisorResponse404 = "If the supervisor is not found.";
    }

}
