namespace TrainingCenterSystem.Entities
{
    public partial class Enrollment
    {
        public int EnrollmentID { get; set; }

        public int StudentID { get; set; }
        public int CourseID { get; set; }

        public DateTime? EnrollmentDate { get; set; }
        public DateTime? CompletionDate { get; set; }

        public decimal? ProgressPercent { get; set; }
        public decimal? FinalGrade { get; set; }

        public string Status { get; set; } = string.Empty;


        public bool IsDeleted { get; set; }
        public virtual Student Student { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}
