using EmployeeManagement.Entities;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Mappers
{
    public class EmployeeMapper
    {
        public static EmployeeClass EmployeeMasterToEmployeeModel(Employee master)
        {
            EmployeeClass result = new EmployeeClass();
            if (master != null)
            {
                result.Id = master.Id;
                result.Name = master.Name;
                result.Email = master.Email;
                result.Password = master.Password;
                result.BranchId = master.BranchId;
            }
            return result;
        }


        public static List<EmployeeClass> EmployeeMasterToEmployeeModel(List<Employee> roles)
        {
            List<EmployeeClass> result = new List<EmployeeClass>();
            foreach (Employee  master in roles)
            {
                result.Add(EmployeeMasterToEmployeeModel(master));
            }
            return result;
        }
    }
}
