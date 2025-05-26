namespace AP2.Repositories.Interfaces;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetAllAsync();
    Task<Pet?> GetByIdAsync(int id);
    Task<Pet> AddAsync(Pet pet);
    Task UpdateAsync(int id, Pet pet);
    Task DeleteAsync(int id);
}