
using System.ComponentModel.DataAnnotations;

public class ChargesEdit
{
    [Required]
    public int GremlinId { get; set; }

    [Required]
    public string CrimeDetails { get; set; }

    [Required]
    public DateTime DateOfCharge { get; set; }
}
