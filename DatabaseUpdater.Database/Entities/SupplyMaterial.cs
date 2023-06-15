using System.ComponentModel.DataAnnotations;

namespace DatabaseUpdater.Database.Entities;

public class SupplyMaterial : DatabaseEntity
{
    [Required]
    public int Number { get; set; }

    [Required]
    public Material Material { get; set; }

    [Required]
    public Supply Supply { get; set; }
}