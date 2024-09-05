using AutoMapper;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Components;
using Shared.Models;
using Shared.Models.Dtos;
using System.Net;
using System.Runtime.CompilerServices;

namespace LibraryAPI.EndPoints
{
    public static class LibraryEndpoints
    {
        public static void ConfigurationLibraryEndpoints(this WebApplication app)
        {
            app.MapGet("/api/books", GetAll).WithName("GetAllBooks")
                .Produces<APIResponse>(200);
            app.MapGet("/api/books/{id:int}", GetById).WithName("GetById")
                .Produces<APIResponse>(200).Produces(404);
            app.MapPost("/api/books", CreateNewBook).WithName("CreateBook")
                .Accepts<BookCreateDto>("application/json").Produces<APIResponse>(201).Produces(400);

            app.MapDelete("/api/books/{id:int}", RemoveBook).WithName("RemoveBook")
                .Produces<APIResponse>(204).Produces(404);

            app.MapPut("/api/books", UpdateBook).WithName("UpdateBook")
                .Accepts<BookUpdateDto>("application/json").Produces<APIResponse>(200)
                .Produces(400);
        }

        public async static Task<IResult> GetAll(ILibraryRepository _repo)
        {
            APIResponse response = new APIResponse();
            response.Result = await _repo.GetAllAsync();
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            return Results.Ok(response);
        }

        public async static Task<IResult> GetById(ILibraryRepository _repo, int id)
        {
            APIResponse response = new APIResponse();
            var book = await _repo.GetByIdAsync(id);
            if (book == null)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.NotFound;
                response.ErrorMessages.Add("Book was not found.");
                return Results.NotFound(response);
            }
            response.Result = book;
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            return Results.Ok(response);
        }

        public async static Task<IResult> CreateNewBook(
            ILibraryRepository _repo, BookCreateDto book_c_dto, IMapper _mapper)
        {
            APIResponse response = new APIResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
            };

           if(await _repo.GetByAuthorAndTitleAsync(book_c_dto.Author, book_c_dto.Title) != null)
            {
                response.ErrorMessages.Add("Book title with the same author already exists.");
                return Results.BadRequest(response);
            }

           // You change type from bookdto to book so that you can add it in the db.
            Book book = _mapper.Map<Book>(book_c_dto);
            await _repo.CreateAsync(book);
            await _repo.SaveAsync();
            response.Result = book;
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.Created;
            return Results.CreatedAtRoute("GetById", new { id = book.Id}, response);

        } 

        public async static Task<IResult> RemoveBook(ILibraryRepository _repo, int id)
        {
            APIResponse response = new APIResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
            };

            var bookToRemove = await _repo.GetByIdAsync(id);
            if(bookToRemove == null)
            {
                response.ErrorMessages.Add("Book was not found");
                return Results.NotFound(response);
            }
            await _repo.DeleteAsync(bookToRemove);
            await _repo.SaveAsync();
            response.Result = bookToRemove;
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.Ok(response);
        }

        public async static Task<IResult> UpdateBook(
            ILibraryRepository _repo, IMapper _mapper, BookUpdateDto book_u_Dto)
        {
            APIResponse response = new APIResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
            };

            await _repo.UpdateAsync(_mapper.Map<Book>(book_u_Dto));
            await _repo.SaveAsync();

            // You change Book-type to BookUpdateDto-type here.
            response.Result = _mapper.Map<BookUpdateDto>
                (await _repo.GetByIdAsync(book_u_Dto.Id));

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            return Results.Ok(response);

        }
    }
}
