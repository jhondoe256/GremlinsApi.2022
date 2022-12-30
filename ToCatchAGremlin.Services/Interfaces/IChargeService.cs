
public interface IChargeService
{
    Task<bool> AddCharge(ChargeCreate model);
    Task<ChargeDetails> GetChargeDetail(int id);
    Task<List<ChargeListItem>> GetCharges();
    Task<bool> UpdateCharge(int id, ChargesEdit model);
    Task<bool> DeleteCharge(int id);
}
