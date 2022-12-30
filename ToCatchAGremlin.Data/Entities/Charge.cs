
using System.ComponentModel.DataAnnotations.Schema;

public class Charge
{
    public int Id { get; set; }
    public string CrimeDetails { get; set; }
    public DateTime DateOfCharge { get; set; }

    //have to make sure that I have a gremlin that I am assigning the charge to
    // 1. Get the Gremin Id (FK)
    [ForeignKey(nameof(Gremlin))]
    public int GremlinId { get; set; }
    // 2. Navigation Property -> wher the FK 'POINTS' TO 
    //    tell EF I NEED ALL THE DATA ABOUT A GREMLIN "Virtual"
    public virtual Gremlin Gremlin { get; set; }
}
