namespace Academic.Core.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepository<T> Entity { get; }
        IElementRepository<T> Element { get; }
        Task SaveAsync();
    }
}
