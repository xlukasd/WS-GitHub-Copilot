﻿namespace Exercise_Performance.Help
{
    public class Course
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid Lecturer { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
