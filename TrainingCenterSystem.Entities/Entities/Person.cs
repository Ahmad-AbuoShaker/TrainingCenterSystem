namespace TrainingCenterSystem.Entities
{
    public partial class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public bool Gender { get; set; }


        public bool IsDeleted { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Student? Student { get; set; }
        public virtual User? User { get; set; }

    }
}
