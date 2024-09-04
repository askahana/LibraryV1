using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace LibraryAPI.Services
{
    public class LibraryRepository : ILibraryRepository
    {
        private LibraryDbContext _context;
        public LibraryRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Book newBook)
        {
            await _context.Books.AddAsync(newBook);
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByAuthorAndTitleAsync(string author, string title)
        {
            return await _context.Books.FirstOrDefaultAsync
                (b => b.Author.ToLower() == author.ToLower() && b.Title.ToLower() == title.ToLower());
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
        }

       
    }
}
