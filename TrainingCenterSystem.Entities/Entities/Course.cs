namespace TrainingCenterSystem.Entities
{
  
    public partial class Course
    {
        public int CourseID { get; set; }

        public string Title { get; set; } = null!;
        public string? Code { get; set; }
        public string? Description { get; set; }

        public int? InstructorID { get; set; }

        public decimal Price { get; set; }
        public int? DurationHours { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Status { get; set; } = string.Empty;

        public virtual Employee? Instructor { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
