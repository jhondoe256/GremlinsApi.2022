
using Microsoft.EntityFrameworkCore;

public class GremlinService : IGermlinService
{
    //make a connection to the database
    private AppDbContext _context;

    public GremlinService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddGremlin(GremlinCreate model)
    {
        Gremlin entity = new Gremlin
        {
            JailHouseId = model.JailHouseId,
            Name = model.Name,
        };

        await _context.Gremlins.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;

    }

    public async Task<bool> DeleteGremlin(int id)
    {
        var gremlin = await _context.Gremlins.FindAsync(id);
        if (gremlin is null)
            return false;
        else
        {
            _context.Gremlins.Remove(gremlin);
            return await _context.SaveChangesAsync() > 0;
        }
    }

    public async Task<GremlinDetails> GetGremlinDetail(int id)
    {
        var gremlin = await _context.Gremlins
        .Include(g => g.JailHouse)
        .Include(g => g.Charges)
        .SingleOrDefaultAsync(g => g.Id == id);

        if (gremlin is null)
            return null;
        else
        {
            return new GremlinDetails
            {
                Id = gremlin.Id,
                Name = gremlin.Name,
                JailHouse = new JailHouseListItem
                {
                    Id = gremlin.JailHouse.Id,
                    Name = gremlin.JailHouse.Name
                },
                Charges = gremlin.Charges.Select(c => new ChargeListItem
                {
                    Id = c.Id,
                    CrimeDetails = c.CrimeDetails,
                }).ToList()
            };
        }
    }

    public async Task<List<GremlinListItem>> GetGremlins()
    {
        return await _context.Gremlins.Select(g => new GremlinListItem
        {
            Id = g.Id,
            Name = g.Name,
            JailHouseId = g.JailHouse.Id
        }).ToListAsync();
    }

    public async Task<bool> UpdateGremlin(int id, GremlinEdit model)
    {
        var gremlin = await _context.Gremlins.FindAsync(id);
        if (gremlin is null)
            return false;
        else
        {
            gremlin.Name = model.Name;
            gremlin.JailHouseId = model.JailHouseId;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
