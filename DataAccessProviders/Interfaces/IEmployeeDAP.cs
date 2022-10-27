using EmployeeManagement.Model;
using EmployeeManagement.Util;

namespace EmployeeManagement.DataAccessProviders.Interfaces
{
    public interface IEmployeeDAP
    {
        Task<ResponseData> AddEmployee(EmployeeClass user);
        Task<ResponseData> AddBranch(BranchClass user);
        Task<ResponseData> AddMarks(MarksClass user);
        Task<ResponseData> AddSubjects(SubjectsClass user);
        Task<ResponseData> AddBranchSubjects(BranchSubjectsClass user);
        Task<ResponseData<List<EmployeeClass>>> GetEmployees();
        Task<ResponseData<List<BranchClass>>> GetBranch();
        Task<ResponseData<List<MarksClass>>>GetMarks();
        Task<ResponseData<List<SubjectsClass>>> GetSubjects();
        Task<ResponseData<List<BranchSubjectsClass>>> GetBranchSubjects();
        Task<ResponseData> UpdateEmployee(EmployeeClass model);
        Task<ResponseData> UpdateBranch(BranchClass model);
        Task<ResponseData> UpdateMarks(MarksClass model);
        Task<ResponseData> UpdateSubjects(SubjectsClass model);
        Task<ResponseData> UpdateBranchSubjects(BranchSubjectsClass model);
        Task<ResponseData> DeleteEmployee(int id);
        Task<ResponseData> DeleteBranch(int id);
        Task<ResponseData> DeleteMarks(int id);
        Task<ResponseData> DeleteSubjects(int id);
        Task<ResponseData> DeleteBranchSubjects(int id);
        Task<ResponseData<List<MarksClass>>>GetMarksBySubjects();
        Task<ResponseData<List<MarksClass>>> GetLeastMarksBySubjects();
        Task<ResponseData<List<MarksClass>>> GetMarksByBranch();
        Task<ResponseData<List<MarksClass>>> GetTopMarksByBranch();
        Task<ResponseData<List<MarksClass>>> GetLeastMarksByBranch();










    }
}
