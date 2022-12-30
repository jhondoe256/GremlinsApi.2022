
using System.ComponentModel.DataAnnotations;

public class GremlinCreate
{
    [Required]
    public int JailHouseId { get; set; }
    
    [Required]
    public string Name { get; set; }
}
