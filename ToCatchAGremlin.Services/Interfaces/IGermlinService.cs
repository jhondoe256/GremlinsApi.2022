
public interface IGermlinService
{
    Task<bool> AddGremlin(GremlinCreate model);
    Task<GremlinDetails> GetGremlinDetail(int id);
    Task<List<GremlinListItem>> GetGremlins();
    Task<bool> UpdateGremlin(int id, GremlinEdit model);
    Task<bool> DeleteGremlin(int id);
}
