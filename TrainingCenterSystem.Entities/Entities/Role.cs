namespace TrainingCenterSystem.Entities
{
    public partial class Role
    {
        public int RoleID { get; set; }

        public string RoleName { get; set; } = null!;

        public bool IsDeleted { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
