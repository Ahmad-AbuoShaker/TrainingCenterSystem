namespace TrainingCenterSystem.Entities
{
    public partial class Student
    {
        public int PersonID { get; set; } 
        public string? Status { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public string? Level { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public virtual Person Person { get; set; } = null!;
    }
}
