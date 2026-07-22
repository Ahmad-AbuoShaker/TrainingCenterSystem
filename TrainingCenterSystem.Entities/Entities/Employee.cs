namespace TrainingCenterSystem.Entities
{
    public partial class Employee
    {
        public int PersonID { get; set; }

        public string JobTitle { get; set; } = null!;
        public DateTime? HireDate { get; set; }
        public decimal Salary { get; set; }

        public int? ManagerID { get; set; }

        public string Status { get; set; } = string.Empty;

        public virtual Person Person { get; set; } = null!;

        public virtual Employee? Manager { get; set; }


        public bool IsDeleted { get; set; }

        public virtual ICollection<Employee> Subordinates { get; set; }
            = new List<Employee>();

        public virtual ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}
