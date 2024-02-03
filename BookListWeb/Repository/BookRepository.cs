using BookListWeb.Data;
using BookListWeb.Models;
using BookListWeb.Repository.IRepository;

namespace BookListWeb.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Book book)
        {
            _db.Books.Update(book);
        }
    }
}
