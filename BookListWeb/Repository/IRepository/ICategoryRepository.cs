using BookListWeb.Models;

namespace BookListWeb.Repository.IRepository
{
    public interface ICategoryRepository :IRepository<Category>
    {
        void Update(Category category);
        void Save();
    }
}
