using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseUpdater.Database.Entities;

public class Material : DatabaseEntity
{
    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, MaxLength(50)]
    public string Code { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    [Column(TypeName = "Money")]
    public decimal Price { get; set; }

    public ICollection<SupplyMaterial> SupplyMaterials { get; set; }
}