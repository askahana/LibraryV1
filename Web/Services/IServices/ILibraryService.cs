using Microsoft.OpenApi.Models;
using Shared.Models.Dtos;

namespace Web.Services.IServices
{
    public interface ILibraryService
    {
        Task<T> GetAllBook<T>();
        Task<T> GetBookById<T>(int id);
        Task<T> CreateBookAsync<T>(BookDto bookDTO);
        Task<T> UpdateBookAsync<T>(BookDto bookDTO);
        Task<T> DeleteBookAsync<T>(int id);
    }
}
