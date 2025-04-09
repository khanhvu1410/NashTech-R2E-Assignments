﻿namespace EfCoreAssignmentDay1.Domain.Entities
{
    public class ProjectEmployee
    {
        public int ProjectId { get; set; }

        public required Project Project { get; set; }

        public int EmployeeId { get; set; }

        public required Employee Employee { get; set; }  

        public bool Enable {  get; set; }
    }
}
