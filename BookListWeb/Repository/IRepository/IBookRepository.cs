using BookListWeb.Models;

namespace BookListWeb.Repository.IRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        void Update(Book book);
        void Save();
    }
}
