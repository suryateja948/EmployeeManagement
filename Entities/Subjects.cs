﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Entities
{
    public partial class Subjects
    {
        public Subjects()
        {
            BranchSubjects = new HashSet<BranchSubjects>();
            Marks = new HashSet<Marks>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int MaxMarks { get; set; }

        public virtual ICollection<BranchSubjects> BranchSubjects { get; set; }
        public virtual ICollection<Marks> Marks { get; set; }
    }
}