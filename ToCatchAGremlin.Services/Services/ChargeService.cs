
using Microsoft.EntityFrameworkCore;

public class ChargeService : IChargeService
{
    private AppDbContext _context;

    public ChargeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddCharge(ChargeCreate model)
    {
        var entity = new Charge
        {
            GremlinId = model.GremlinId,
            CrimeDetails = model.CrimeDetails,
            DateOfCharge = DateTime.Now
        };

        await _context.Charges.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }


    public Task<bool> DeleteCharge(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ChargeDetails> GetChargeDetail(int id)
    {
        var charge = await _context.Charges
        .Include(c => c.Gremlin)
        .FirstOrDefaultAsync(x => x.Id == id);
        if (charge is null)
            return null;
        else
        {
            return new ChargeDetails
            {
                Id = charge.Id,
                CrimeDetails = charge.CrimeDetails,
                DateOfCharge = charge.DateOfCharge,
                Gremlin = new GremlinListItem
                {
                    Id = charge.Gremlin.Id,
                    Name = charge.Gremlin.Name
                }
            };
        }
    }

    public async Task<List<ChargeListItem>> GetCharges()
    {
        return await _context.Charges.Select(c => new ChargeListItem
        {
            Id = c.Id,
            CrimeDetails = c.CrimeDetails
        }).ToListAsync();
    }

    public Task<bool> UpdateCharge(int id, ChargesEdit model)
    {
        throw new NotImplementedException();
    }
}
