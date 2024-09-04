using Shared.Models;

namespace LibraryAPI.Services
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> GetByAuthorAndTitleAsync(string author, string title);
        Task CreateAsync(Book newBook);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task SaveAsync();
    }
}
