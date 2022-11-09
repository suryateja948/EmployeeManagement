using EmployeeManagement.DataAccessProviders.Interfaces;
using EmployeeManagement.DBContext;
using EmployeeManagement.Entities;
using EmployeeManagement.Mappers;
using EmployeeManagement.Model;
using EmployeeManagement.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text;
namespace EmployeeManagement.DataAccessProviders
{
    public class EmployeeDAP : IEmployeeDAP
    {
        private readonly dbContext _context;
        public EmployeeDAP(dbContext context)
        {
            _context = context;
        }
        public async Task<ResponseData> AddEmployee(EmployeeClass user)
        {
            Employee  model = new Employee()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                BranchId = user.BranchId
            };
            
            await _context.Employee.AddAsync(model);
            await _context.SaveChangesAsync();
            return new ResponseData(model.Id, true, "Inserted", 200);

            
        }

        public async Task<ResponseData> AddBranch(BranchClass user)
        {
            Branch model = new Branch()
            {
                Name = user.Name,
                Code = user.code
            };
            await _context.Branch.AddAsync(model);
            await _context.SaveChangesAsync();
            return new ResponseData(model.Id, true, "Inserted", 200);

            
        }

        public async Task<ResponseData> AddMarks(MarksClass user)
        {
            Marks model = new Marks()
            {
                EmployeeId = user.EmployeeId,
                SubjectsId = user.SubjectsId,
                MarksScored = user.MarksScored
            };
            await _context.Marks.AddAsync(model);
            await _context.SaveChangesAsync();
            return new ResponseData(model.Id, true, "Inserted", 200);

            
        }

        public async Task<ResponseData> AddSubjects(SubjectsClass user)
        {
            Subjects model = new Subjects()
            {
                Name = user.Name,
                Code = user.Code,
                MaxMarks = user.MaxMarks
            };
            await _context.Subjects.AddAsync(model);
            await _context.SaveChangesAsync();
            return new ResponseData(model.Id, true, "Inserted", 200);

            
        }

        public async Task<ResponseData>AddBranchSubjects(BranchSubjectsClass user)
        {
            BranchSubjects model = new BranchSubjects()
            {
                    BranchId = user.BranchId,
                    SubjectsId = user.SubjectsId
            };
            
            await _context.BranchSubjects.AddAsync(model);
            await _context.SaveChangesAsync();
            return new ResponseData(user.Id, true, "Inserted", 200);

            
        }

        public async Task<ResponseData<List<EmployeeClass>>>GetEmployees()
        {
            List<Employee> input = await _context.Employee.AsNoTracking().ToListAsync();
            return new ResponseData<List<EmployeeClass>>(EmployeeMapper.EmployeeMasterToEmployeeModel(input), true, "Success", 200);
        }

        public async Task<ResponseData<List<BranchClass>>>GetBranch()
        {
            List<Branch> input = await _context.Branch.AsNoTracking().ToListAsync();
            return new ResponseData<List<BranchClass>>(BranchMapper.BranchMasterToBranchModel(input), true, "Success", 200);
        }

        public async Task<ResponseData<List<MarksClass>>>GetMarks()
        {
           /* List<Marks> input = await _context.Marks.AsNoTracking().OrderByDescending(x => x.MarksScored).ThenBy(a => a.SubjectsId).Take(2).ToListAsync();*/
            List<Marks> input = await _context.Marks.AsNoTracking().OrderByDescending(x => x.MarksScored).ToListAsync();


            /*List<Marks> input = await _context.Marks.AsNoTracking().Where(s => s.EmployeeId<=5).OrderByDescending(x => x.MarksScored).Take(2).ToListAsync();*/
            return new ResponseData<List<MarksClass>>(MarksMapper.MarksMasterToMarksModel(input), true, "Success", 200);
        }

        public async Task<ResponseData<List<SubjectsClass>>>GetSubjects()
        {
            List<Subjects> input = await _context.Subjects.AsNoTracking().ToListAsync();
            return new ResponseData<List<SubjectsClass>>(SubjectsMapper.SubjectsMasterToSubjectsModel(input), true, "Success", 200);
        }

        public async Task<ResponseData<List<BranchSubjectsClass>>> GetBranchSubjects()
        {
            List<BranchSubjects> input = await _context.BranchSubjects.AsNoTracking().ToListAsync();
            return new ResponseData<List<BranchSubjectsClass>>(BranchSubjectsMapper.BranchSubjectsMasterToBranchSubjectsModel(input), true, "Success", 200);
        }

        public async Task<ResponseData> UpdateEmployee(EmployeeClass model)
        {
            var itemToUpdate = await _context.Employee.SingleOrDefaultAsync(r => r.Id == model.Id);
            if (itemToUpdate != null)
            {
                
                itemToUpdate.Name = model.Name;
                itemToUpdate.Email = model.Email;
                itemToUpdate.Password = model.Password;
                itemToUpdate.BranchId = model.BranchId;
                await _context.SaveChangesAsync();
                return new ResponseData(model.Id, true, "Updated", 200);
            }
            
            return null;
        }

        public async Task<ResponseData> UpdateBranch(BranchClass model)
        {
            var branch = await _context.Branch.SingleOrDefaultAsync(a => a.Id == model.Id);
            if (branch != null)
            {
                
                branch.Name = model.Name;
                branch.Code = model.code;
                await _context.SaveChangesAsync();
                return new ResponseData(model.Id, true, "Updated", 200);
            }
            
            return null;
        }
        public async Task<ResponseData> UpdateMarks(MarksClass model)
        {
            var marks = await _context.Marks.SingleOrDefaultAsync(r => r.Id == model.Id);
            if (marks != null)
            {
                
                marks.EmployeeId = model.EmployeeId;
                marks.SubjectsId = model.SubjectsId;
                marks.MarksScored = model.MarksScored;
                await _context.SaveChangesAsync();
                return new ResponseData(model.Id, true, "Updated", 200);
            }
            
            return null;
        }

        public async Task<ResponseData> UpdateSubjects(SubjectsClass model)
        {
            var Subjects = await _context.Subjects.SingleOrDefaultAsync(r => r.Id == model.Id);
            if (Subjects != null)
            {
                Subjects.Name = model.Name;
                Subjects.Code = model.Code;
                Subjects.MaxMarks = model.MaxMarks;
                await _context.SaveChangesAsync();
                return new ResponseData(model.Id, true, "Updated", 200);
            }
            
            return null;
        }

        public async Task<ResponseData> UpdateBranchSubjects(BranchSubjectsClass model)
        {
            var branchSubject = await _context.BranchSubjects.SingleOrDefaultAsync(x => x.Id == model.Id);
            if (branchSubject != null)
            {
                
                branchSubject.BranchId = model.BranchId;
                branchSubject.SubjectsId = model.SubjectsId;
                await _context.SaveChangesAsync();
                return new ResponseData(model.Id, true, "Updated", 200);
            }
            
            return null;
        }

        public async Task<ResponseData> DeleteEmployee(int Id)
        {
            var entity = await _context.Employee.AsNoTracking().SingleOrDefaultAsync(t => t.Id == Id );
            if (entity != null)
            {
                _context.Employee.Remove(entity);
                await _context.SaveChangesAsync();
                return new ResponseData(Id, true, "Deleted", 200);
            }
            
            return null;
        }

        public async Task<ResponseData> DeleteBranch(int Id)
        {
            var branch = await _context.Branch.SingleOrDefaultAsync(t => t.Id == Id );
            if (branch != null)
            {
                _context.Branch.Remove(branch);
                await _context.SaveChangesAsync();
                return new ResponseData(Id, true, "Deleted", 200);
            }
            
            return null;
        }
        public async Task<ResponseData> DeleteMarks(int Id)
        {
            var entity = await _context.Marks.SingleOrDefaultAsync(x => x.Id == Id);
            if (entity != null)
            {
                _context.Marks.Remove(entity);
                await _context.SaveChangesAsync();
                return new ResponseData(Id, true, "Deleted", 200);
            }
            
            return null;
        }
        public async Task<ResponseData> DeleteSubjects(int Id)
        {
            var entity = await _context.Subjects.SingleOrDefaultAsync(b => b.Id == Id);
            if (entity != null)
            {
                _context.Subjects.Remove(entity);
                await _context.SaveChangesAsync();
                return new ResponseData(Id, true, "Deleted", 200);
            }
            
            return null;
        }
        public async Task<ResponseData> DeleteBranchSubjects(int Id)
        {
            var entity = await _context.BranchSubjects.SingleOrDefaultAsync(a => a.Id == Id);
            if (entity != null)
            {
                _context.BranchSubjects.Remove(entity);
                await _context.SaveChangesAsync();
                return new ResponseData(Id, true, "Deleted", 200);
            }
            
            return null;
        }

        public async Task<ResponseData<List<MarksClass>>> GetMarksBySubjects()
        {
            List<Subjects> subjects = await _context.Subjects.AsNoTracking().ToListAsync();
            List<Marks> marks = new List<Marks>();
            foreach (Subjects item in subjects )
            {
                List<Marks> subjectmarks = await _context.Marks.AsNoTracking().Where(s => s.SubjectsId==item.Id).OrderByDescending(x => x.MarksScored).Take(2).ToListAsync();
                 foreach(Marks items in subjectmarks)
                 {
                    marks.Add(items);
                 }
            }
            
            return new ResponseData<List<MarksClass>>(MarksMapper.MarksMasterToMarksModel(marks), true, "Success", 200);
        }

        

        public async Task<ResponseData<List<MarksClass>>> GetLeastMarksBySubjects()
        {
            List<Subjects> subjects = await _context.Subjects.AsNoTracking().ToListAsync();
            List<Marks> marks = new List<Marks>();
            foreach (Subjects item in subjects)
            {
                List<Marks> subjectmarks = await _context.Marks.AsNoTracking().Where(s => s.SubjectsId == item.Id).OrderBy(x => x.MarksScored).Take(2).ToListAsync();
                foreach (Marks items in subjectmarks)
                {
                    marks.Add(items);
                }
            }

            return new ResponseData<List<MarksClass>>(MarksMapper.MarksMasterToMarksModel(marks), true, "Success", 200);
        }

        

        public async Task<ResponseData<List<MarksClass>>> GetMarksByBranch()
        {
            List<Branch> branch = await _context.Branch.AsNoTracking().ToListAsync();
            List<BranchSubjects> branchsubject = new List<BranchSubjects>();
            List<Employee> employees = await _context.Employee.AsNoTracking().ToListAsync();
            List<Marks> mark = new List<Marks>();         

            foreach (Branch item in branch)
            {
                List<BranchSubjects> branchSubjects = await _context.BranchSubjects.AsNoTracking().Where(a => a.BranchId == item.Id).ToListAsync();
                foreach (BranchSubjects items in branchSubjects)
                {
                    branchsubject.Add(items);
                }
            }
            foreach (Employee emp in employees)
            {
                List<BranchSubjects> bs = new List<BranchSubjects>();
                bs = (List<BranchSubjects>)branchsubject.FindAll(i => i.BranchId == emp.BranchId);
                /*bs = branchsubject.FindAll(i => i.BranchId == emp.BranchId);*/
                foreach (BranchSubjects item in bs)
                {
                  List<Marks> Finalmarks = await _context.Marks.AsNoTracking().Where(e => e.EmployeeId == emp.Id && e.SubjectsId == item.SubjectsId).OrderByDescending(x => x.MarksScored).Take(2).ToListAsync();
                    foreach (Marks mk in Finalmarks)
                    {
                        mark.Add(mk);  
                    }
                }
                
            }

            return new ResponseData<List<MarksClass>>(MarksMapper.MarksMasterToMarksModel(mark), true, "Success", 200);
        }
        public async Task<ResponseData<List<MarksClass>>>GetTopMarksByBranch()
        {
           /* List<Branch> branch = await _context.Branch.AsNoTracking().ToListAsync();
            List<BranchSubjects> branchsubject = new List<BranchSubjects>();
            List<Employee> employees = await _context.Employee.AsNoTracking().ToListAsync();
            List<Marks> mark = new List<Marks>();*/
          
            List<MarksClass> marks = new List<MarksClass>();
             marks = (from Marks in  _context.Marks join emp in  _context.Employee on Marks.EmployeeId  equals emp.Id select new MarksClass { EmployeeId = Marks.EmployeeId , SubjectsId = Marks.SubjectsId, BranchId = emp.BranchId, Id = Marks.Id, MarksScored = (float)Marks.MarksScored}).OrderBy( x => x.BranchId).ThenByDescending(x =>x.MarksScored).ToList();
            List<MarksClass> Top = new List<MarksClass>();
            int count = 0, Branch = 1;
            foreach (MarksClass item in marks)
            {
                if(item.BranchId!=Branch)
                {
                    count = 0;
                }
                if(count < 2)
                {
                    Branch = item.BranchId;
                    count++;
                    Top.Add(item);
                }
            }
            return new ResponseData<List<MarksClass>>((Top), true, "Success", 200);
        }

        public async Task<ResponseData<List<MarksClass>>> GetLeastMarksByBranch()
        {
            List<MarksClass> marks = new List<MarksClass>();
            marks = (from Marks in _context.Marks join emp in _context.Employee on Marks.EmployeeId equals emp.Id select new MarksClass { EmployeeId = Marks.EmployeeId, SubjectsId = Marks.SubjectsId, BranchId = emp.BranchId, Id = Marks.Id, MarksScored = (float)Marks.MarksScored }).OrderBy(x => x.BranchId).ThenBy(x => x.MarksScored).ToList();
            List<MarksClass> Top = new List<MarksClass>();
            int count = 0, Branch = 1;
            foreach (MarksClass item in marks)
            {
                if (item.BranchId != Branch)
                {
                    count = 0;
                }
                if (count < 2)
                {
                    Branch = item.BranchId;
                    count++;
                    Top.Add(item);
                }
            }
            return new ResponseData<List<MarksClass>>((Top), true, "Success", 200);
        }
    }
}


