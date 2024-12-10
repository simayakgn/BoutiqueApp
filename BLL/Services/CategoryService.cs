using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;


namespace BLL.Services
{
    public interface ICategoryService
    {
        public IQueryable<CategoryModel> Query();

        public ServiceBase Create(Category record);
        public ServiceBase Update(Category record);
        public ServiceBase Delete(int id);
    }
    public class CategoryService : ServiceBase, ICategoryService
    {
        public CategoryService(Db db) : base(db)
        {

        }
        public IQueryable<CategoryModel> Query()
        {
            return _db.Categories.OrderBy(s => s.Name).Select(s => new CategoryModel() { Record = s });
        }

        public ServiceBase Create(Category record)
        {
            if (_db.Categories.Any(s => s.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Category with the same name exists!");
            record.Name = record.Name?.Trim();
            //record.Description = record.Description.Trim();
            _db.Categories.Add(record);
            _db.SaveChanges(); // Commit to the database
            return Success("Category created successfully.");
        }

        public ServiceBase Update(Category record)
        {
            if (_db.Categories.Any(s => s.Id != record.Id && s.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Category with the same name exists!");
            Category entity = _db.Categories.SingleOrDefault(s => s.Id == record.Id);
            if (entity is null)
                return Error("Category can't be found!");
            entity.Name = record.Name.Trim();
            entity.Description = record.Description?.Trim();
            _db.Categories.Update(entity);
            _db.SaveChanges(); // commit to the database
            return Success("Category updated successfully.");
        }
        public ServiceBase Delete(int id)
        {
            var entity = _db.Categories
               .Include(c => c.Products)
               .SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return Error("Category can't be found!");

            if (entity.Products.Any()) // count=0
                return Error("Category has relational products!");

            _db.Categories.Remove(entity);
            _db.SaveChanges(); // commit to the database
            return Success("Category deleted successfully.");
        }
    }
}
