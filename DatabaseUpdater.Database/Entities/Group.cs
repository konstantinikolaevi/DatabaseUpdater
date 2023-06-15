using System.ComponentModel.DataAnnotations;

namespace DatabaseUpdater.Database.Entities;

public class Group : DatabaseEntity
{
    [Required, MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    public Role Role { get; set; }

    public ICollection<GroupUser> GroupUsers { get; set; }
}