using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseUpdater.Database.Entities;

public class User : DatabaseEntity
{
    [Required, MaxLength(30)]
    public string Login { get; set; }

    [Required, MaxLength(30)]
    public string Password { get; set; }

    [Required, MaxLength(30)]
    public string Name { get; set; }

    [Required, MaxLength(30)]
    public string Surname { get; set; }

    [MaxLength(30)]
    public string Patronymic { get; set; }

    [Required, Column(TypeName = "character(11)")]
    public string PhoneNumber { get; set; }

    public ICollection<GroupUser> GroupUsers { get; set; }

    public ICollection<Location> Locations { get; set; }

    public string FullName => $@"{Surname} {Name} {Patronymic}";
}