using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Identity.Client;
using Shared.Models.Dtos;
using System.Data;
using Web.Services.IServices;

namespace Web.Services
{
    public class LibraryService : BaseService, ILibraryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LibraryService(IHttpClientFactory clientFactory) :base(clientFactory)
        {
            this._httpClientFactory = clientFactory;
        }

        public async Task<T> CreateBookAsync<T>(BookDto bookDTO)
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                ApiType = StaticDetails.ApiType.POST,
                Url = StaticDetails.LibraryApiBase + "/api/books",
                Data = bookDTO,
                AccessToken = "",
            });
        }

        public async Task<T> DeleteBookAsync<T>(int id)
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                ApiType= StaticDetails.ApiType.DELETE,
                Url = StaticDetails.LibraryApiBase + "/api/books/" + id,
                AccessToken = "",
            });
        }

        public async Task<T> GetAllBook<T>()
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                ApiType= StaticDetails.ApiType.GET,
                Url = StaticDetails.LibraryApiBase + "/api/books",
                AccessToken = "",
            });
        }

        public async Task<T> GetBookById<T>(int id)
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.LibraryApiBase + "/api/books/" + id,
                AccessToken = "",
            });
        }

        public async Task<T> UpdateBookAsync<T>(BookDto bookDTO)
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = bookDTO,
                Url = StaticDetails.LibraryApiBase + "/api/books",
                AccessToken = "",
            });
        }
    }
}
