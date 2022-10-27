using System;
using EmployeeManagement.Entities;
using EmployeeManagement.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeManagement.Mappers
{
    public class SubjectsMapper
    {
        public static SubjectsClass SubjectsMasterToSubjectsModel(Subjects master)
        {
            SubjectsClass result = new SubjectsClass();
            if (master != null)
            {
                result.Id = master.Id;
                result.Name = master.Name;
                result.Code = master.Code;
                result.MaxMarks = master.MaxMarks;
                

            }
            return result;
        }


        public static List<SubjectsClass> SubjectsMasterToSubjectsModel(List<Subjects> sub)
        {
            List<SubjectsClass> result = new List<SubjectsClass>();
            foreach (Subjects master in sub)
            {
                result.Add(SubjectsMasterToSubjectsModel(master));
            }
            return result;
        }
    }
}