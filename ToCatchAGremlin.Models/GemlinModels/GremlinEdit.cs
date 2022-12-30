using System.ComponentModel.DataAnnotations;


public class GremlinEdit
{
    [Required]
    public int JailHouseId { get; set; }

    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}
