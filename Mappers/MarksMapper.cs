using System;
using EmployeeManagement.Entities;
using EmployeeManagement.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeManagement.Mappers
{
    public class MarksMapper
    {
        public static MarksClass MarksMasterToMarksModel(Marks master)
        {
            MarksClass result = new MarksClass();
            if (master != null)
            {
                result.Id = master.Id;
                result.EmployeeId = master.EmployeeId;
                result.SubjectsId = master.SubjectsId;
                result.MarksScored = (float)master.MarksScored;
               

            }
            return result;
        }


        public static List<MarksClass> MarksMasterToMarksModel(List<Marks> mr)
        {
            List<MarksClass> result = new List<MarksClass>();
            foreach (Marks master in mr)
            {
                result.Add(MarksMasterToMarksModel(master));
            }
            return result;
        }
    }
}
