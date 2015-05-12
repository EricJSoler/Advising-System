﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sharpAdvising
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Test_0506Entities : DbContext
    {
        public Test_0506Entities()
            : base("name=Test_0506Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PrerequisiteTree> PrerequisiteTrees { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
    
        public virtual ObjectResult<read_by_dep_num_Result> read_by_dep_num(string departmentID, string numberID)
        {
            var departmentIDParameter = departmentID != null ?
                new ObjectParameter("DepartmentID", departmentID) :
                new ObjectParameter("DepartmentID", typeof(string));
    
            var numberIDParameter = numberID != null ?
                new ObjectParameter("NumberID", numberID) :
                new ObjectParameter("NumberID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<read_by_dep_num_Result>("read_by_dep_num", departmentIDParameter, numberIDParameter);
        }
    
        public virtual ObjectResult<string> read_courseID_by_program_department(string departmentID, string program)
        {
            var departmentIDParameter = departmentID != null ?
                new ObjectParameter("DepartmentID", departmentID) :
                new ObjectParameter("DepartmentID", typeof(string));
    
            var programParameter = program != null ?
                new ObjectParameter("program", program) :
                new ObjectParameter("program", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("read_courseID_by_program_department", departmentIDParameter, programParameter);
        }
    
        public virtual ObjectResult<read_program_by_departmentID_programID_Result> read_program_by_departmentID_programID(string departmentID, string programID)
        {
            var departmentIDParameter = departmentID != null ?
                new ObjectParameter("DepartmentID", departmentID) :
                new ObjectParameter("DepartmentID", typeof(string));
    
            var programIDParameter = programID != null ?
                new ObjectParameter("programID", programID) :
                new ObjectParameter("programID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<read_program_by_departmentID_programID_Result>("read_program_by_departmentID_programID", departmentIDParameter, programIDParameter);
        }
    
        public virtual ObjectResult<string> read_subjects_by_program(string programID)
        {
            var programIDParameter = programID != null ?
                new ObjectParameter("programID", programID) :
                new ObjectParameter("programID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("read_subjects_by_program", programIDParameter);
        }
    }
}
