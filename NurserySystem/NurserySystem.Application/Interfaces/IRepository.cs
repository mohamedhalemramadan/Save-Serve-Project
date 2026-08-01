namespace NurserySystem.Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate);
}

public interface IChildRepository : IRepository<Domain.Entities.Child>
{
    Task<IEnumerable<Domain.Entities.Child>> GetChildrenByClassRoomIdAsync(int classRoomId);
    Task<IEnumerable<Domain.Entities.Child>> SearchChildrenAsync(string searchTerm);
}

public interface IClassRoomRepository : IRepository<Domain.Entities.ClassRoom>
{
    Task<IEnumerable<Domain.Entities.ClassRoom>> GetClassRoomsByLevelIdAsync(int levelId);
}

public interface ILevelRepository : IRepository<Domain.Entities.Level>
{
}
