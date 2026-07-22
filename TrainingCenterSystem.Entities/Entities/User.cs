namespace TrainingCenterSystem.Entities
{
    public partial class User
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? ProfileImagePath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }

        public bool IsDeleted { get; set; }


        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
