namespace EmployeeManagement.Model
{
    public class MarksClass
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int SubjectsId { get; set; }
        public int BranchId { get; set; }
        public float MarksScored { get; set; }
    }
}
