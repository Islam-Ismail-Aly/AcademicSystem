using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Constants
{
    public class StudentPhoneControllerSwaggerAttributes
    {
        public const string GetAllStudentPhoneSummary = "Retrieves all StudentPhones.";
        public const string GetStudentPhoneByIdSummary = "Retrieves the studentPhone by its Id.";
        public const string AddStudentPhoneSummary = "Adds a new StudentPhone.";
        public const string UpdateStudentPhoneSummary = "Updates an existing StudentPhone.";
        public const string DeleteStudentPhoneSummary = "Deletes an existing studentPhone.";

        public const string GetAllStudentPhoneResponse200 = "A list of studentPhones with detailed information.";
        public const string GetAllStudentPhoneResponse404 = "If no studentPhones are found.";

        public const string GetStudentPhoneByIdResponse200 = "If the studentPhone is found.";
        public const string GetStudentPhoneByIdResponse404 = "If the studentPhone is not found.";

        public const string AddStudentPhoneResponse201 = "StudentPhone added successfully.";
        public const string AddStudentPhoneResponse400 = "Invalid StudentPhone data.";

        public const string UpdateStudentPhoneResponse204 = "StudentPhone updated successfully.";
        public const string UpdateStudentPhoneResponse400 = "Invalid StudentPhone data.";
        public const string UpdateStudentPhoneResponse404 = "If the StudentPhone is not found.";

        public const string DeleteStudentPhoneResponse204 = "studentPhone is deleted successfully.";
        public const string DeleteStudentPhoneResponse404 = "If the studentPhone is not found.";
    }
}
