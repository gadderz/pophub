using Microsoft.EntityFrameworkCore;
using Pophub.Application.Common.Repositories;
using Pophub.Core.Entities;

namespace Pophub.Infrastructure.Data.Repositories;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;

    public GameRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Game> AddAsync(Game entity)
    {
        _context.Games.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Game entity)
    {
        _context.Games.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Game?> GetByIdAsync(Guid id)
    {
        return await _context.Games.FindAsync(id);
    }

    public async Task<IEnumerable<Game>> ListAllAsync()
    {
        return await _context.Games.ToListAsync();
    }

    public async Task UpdateAsync(Game entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
