using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseUpdater.Database.Entities;

public class Warehouse : DatabaseEntity
{
    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public double Latitude { get; set; }

    [Required]
    public double Longitude { get; set; }

    [NotMapped]
    public ICollection<Supply> OutgoingSupplies { get; set; }

    [NotMapped]
    public ICollection<Supply> IncomingSupplies { get; set; }
}