
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Gremlin
{
    //unique identifier
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    //public string Charge { get; set; }

    public List<Charge> Charges { get; set; }

    //make an FK for the JailHouse
    [ForeignKey(nameof(JailHouse))]
    public int JailHouseId { get; set; }

    //Navigation Property
    public virtual JailHouse JailHouse { get; set; }
}
