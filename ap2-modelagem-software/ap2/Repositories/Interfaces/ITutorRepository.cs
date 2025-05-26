namespace AP2.Repositories.Interfaces;

public interface ITutorRepository
{
    Task<IEnumerable<Tutor>> GetAllAsync();
    Task<Tutor?> GetByIdAsync(int id);
    Task<Tutor> AddAsync(Tutor tutor);
    Task UpdateAsync(int id, Tutor tutor);
    Task DeleteAsync(int id);
}