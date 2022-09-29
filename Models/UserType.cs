using System.ComponentModel;

namespace Evaluacion.Models
{
    public enum UserType
    {
        User,
        Administrator,
        SystemAdmin
    }

    //class for department name
    public class DepartmentName
    {
        public const string IT = "IT";
        public const string Sales = "Sales";
        public const string HR = "HR";
        public const string Production = "Production";
    }

    //Enum for the items
    public enum ItemDepartment
    {
        [Description("IT")]
        IT,
        Sales,
        HR,
        Production
    }
}
