using AP2.Data;
using AP2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AP2.Repositories;

public class PetRepository : IPetRepository
{
    private readonly AppDbContext _context;

    public PetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pet>> GetAllAsync() =>
        await _context.Pets.Include(l => l.TutorId).ToListAsync();

    public async Task<Pet?> GetByIdAsync(int id) =>
        await _context.Pets.Include(l => l.TutorId)
            .FirstOrDefaultAsync(l => l.Id == id);

    public async Task<Pet> AddAsync(Pet pet)
    {
        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();
        return pet;
    }

    public async Task UpdateAsync(int id, Pet pet)
    {
        _context.Pets.Update(pet);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var pet = await GetByIdAsync(id);
        if (pet is null) return;
        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
    }
}