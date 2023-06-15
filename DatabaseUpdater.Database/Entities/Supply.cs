using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseUpdater.Database.Entities;

public class Supply : DatabaseEntity
{
    [Required, NotMapped]
    public Warehouse OutgoingPlace { get; set; }

    [Required, NotMapped]
    public Warehouse IncomingPlace { get; set; }

    [Required]
    public User Supplier { get; set; }

    [Required]
    public User Driver { get; set; }

    [Required]
    public DateTime? PlanSupplyDate { get; set; }

    [Required]
    public DateTime? PlanDispathDate { get; set; }

    public DateTime? SupplyDate { get; set; }

    public DateTime? DispathDate { get; set; }

    public ICollection<SupplyMaterial> SupplyMaterials { get; set; }
}