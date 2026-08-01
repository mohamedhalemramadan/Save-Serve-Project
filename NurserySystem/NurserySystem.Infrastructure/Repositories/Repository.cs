using Microsoft.EntityFrameworkCore;
using NurserySystem.Application.Interfaces;
using NurserySystem.Domain.Entities;

namespace NurserySystem.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return _context.SaveChangesAsync();
    }

    public virtual Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return _context.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
    {
        return await Task.FromResult(_dbSet.Where(predicate).ToList());
    }
}

public class ChildRepository : Repository<Child>, IChildRepository
{
    public ChildRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Child>> GetChildrenByClassRoomIdAsync(int classRoomId)
    {
        return await _dbSet
            .Where(c => c.ClassRoomId == classRoomId)
            .Include(c => c.Guardian)
            .Include(c => c.ClassRoom)
                .ThenInclude(cl => cl!.Level)
            .ToListAsync();
    }

    public async Task<IEnumerable<Child>> SearchChildrenAsync(string searchTerm)
    {
        return await _dbSet
            .Where(c => c.NameAr.Contains(searchTerm) || c.NameEn.Contains(searchTerm))
            .Include(c => c.Guardian)
            .Include(c => c.ClassRoom)
                .ThenInclude(cl => cl!.Level)
            .ToListAsync();
    }
}

public class ClassRoomRepository : Repository<ClassRoom>, IClassRoomRepository
{
    public ClassRoomRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ClassRoom>> GetClassRoomsByLevelIdAsync(int levelId)
    {
        return await _dbSet
            .Where(c => c.LevelId == levelId)
            .Include(c => c.Level)
            .ToListAsync();
    }
}

public class LevelRepository : Repository<Level>, ILevelRepository
{
    public LevelRepository(ApplicationDbContext context) : base(context)
    {
    }
}
