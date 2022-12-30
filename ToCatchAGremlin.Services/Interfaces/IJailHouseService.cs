
public interface IJailHouseService
{
    Task<bool> AddJailHouse(JaliHouseCreate model);
    Task<JailHouseDetail> GetJailHouseDetail(int id);
    Task<List<JailHouseListItem>> GetJailHouses();
    Task<bool> UpdateJailHouse(int id, JailHouseEdit model);
    Task<bool> DeleteJailHouse(int id);
}
