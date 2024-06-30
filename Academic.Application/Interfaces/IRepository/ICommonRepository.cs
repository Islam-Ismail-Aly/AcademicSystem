namespace Academic.Application.Interfaces.IRepository
{
    public interface ICommonRepository<T> where T : class
    {
        Task<int> CountAsync();
    }
}
