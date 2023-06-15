using System.ComponentModel.DataAnnotations;

namespace DatabaseUpdater.Database.Entities;

public class Role : DatabaseEntity
{
    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, MaxLength(50)]
    public string Code { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    public ICollection<Group> Groups { get; set; }
}