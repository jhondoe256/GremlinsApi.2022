
using Microsoft.EntityFrameworkCore;

public class JailHouseService : IJailHouseService
{
    //private backing field-> private variable
    private AppDbContext _context;

    // tell my IOC -> that whenever a JailHouseService is created please insert the existing instance of The AppDbContext
    // where does this live.... in the API LAYER...
    public JailHouseService(AppDbContext context) // -> passed in by IOC CONTAINER
    {
        _context = context;
    }

    public async Task<bool> AddJailHouse(JaliHouseCreate model)
    {
        //manual map -> converting from JaialHouseCreate to JailHouse
        JailHouse entity = new JailHouse
        {
            Name = model.Name
        };

        //add to database
        await _context.Jails.AddAsync(entity);
        //save to the database
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteJailHouse(int id)
    {
        var jailHouse = await _context.Jails.FindAsync(id);
        if (jailHouse is null)
        {
            return false;
        }
        else
        {
            _context.Jails.Remove(jailHouse);
            await _context.SaveChangesAsync();
            return true;
        }
    }

    public async Task<JailHouseDetail> GetJailHouseDetail(int id)
    {
        JailHouse jail = await _context.Jails.Include(j => j.Gremlins).SingleOrDefaultAsync(j => j.Id == id);
        if (jail is null)
            return null;
        else
            return new JailHouseDetail
            {
                Id = jail.Id,
                Name = jail.Name,
                Gremlins = jail.Gremlins.Select(g => new GremlinListItem
                {
                    Id = g.Id,
                    Name = g.Name,
                    JailHouseId = g.JailHouse.Id
                }).ToList()
            };
    }

    public async Task<List<JailHouseListItem>> GetJailHouses()
    {
        return await _context.Jails.Select(j => new JailHouseListItem
        {
            Id = j.Id,
            Name = j.Name
        }).ToListAsync();
    }

    public async Task<bool> UpdateJailHouse(int id, JailHouseEdit model)
    {
        var jailHouse = await _context.Jails.FindAsync(id);
        if (jailHouse is null)
        {
            return false;
        }
        else
        {
            jailHouse.Name = model.Name;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
