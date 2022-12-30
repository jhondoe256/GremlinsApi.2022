
using System.ComponentModel.DataAnnotations;

public class ChargeCreate
{
    [Required]
    public int GremlinId { get; set; }

    [Required]
    public string CrimeDetails { get; set; }

}
