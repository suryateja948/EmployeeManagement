using System;
using EmployeeManagement.Entities;
using EmployeeManagement.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Mappers
{
    public class BranchSubjectsMapper
    {
        public static BranchSubjectsClass BranchSubjectsMasterToBranchSubjectsModel(BranchSubjects master)
        {
            BranchSubjectsClass result = new BranchSubjectsClass();
            if (master != null)
            {
                result.Id= master.Id;
                result.BranchId = master.BranchId;
                result.SubjectsId = master.SubjectsId;
            }
            return result;
        }


        public static List<BranchSubjectsClass> BranchSubjectsMasterToBranchSubjectsModel(List<BranchSubjects> sub)
        {
            List<BranchSubjectsClass> result = new List<BranchSubjectsClass>();
            foreach (BranchSubjects master in sub)
            {
                result.Add(BranchSubjectsMasterToBranchSubjectsModel(master));
            }
            return result;
        }
    }
}
