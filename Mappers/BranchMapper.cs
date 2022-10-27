using EmployeeManagement.Entities;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Mappers
{
    public class BranchMapper
    {
        public static BranchClass BranchMasterToBranchModel(Branch master)
        {
            BranchClass result = new BranchClass();
            if (master != null)
            {
                result.Id = master.Id;
                result.Name = master.Name;
                result.code = master.Code;
            }
            return result;
        }


        public static List<BranchClass> BranchMasterToBranchModel(List<Branch> br)
        {
            List<BranchClass> result = new List<BranchClass>();
            foreach (Branch master in br)
            {
                result.Add(BranchMasterToBranchModel(master));
            }
            return result;
        }
    }
}

