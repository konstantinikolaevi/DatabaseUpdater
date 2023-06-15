using System.ComponentModel.DataAnnotations;

namespace DatabaseUpdater.Database.Entities;

public class GroupUser : DatabaseEntity
{
    [Required]
    public Group Group { get; set; }

    [Required]
    public User User { get; set; }
}