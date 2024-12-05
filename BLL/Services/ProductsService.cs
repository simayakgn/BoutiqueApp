/*using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;

namespace BLL.Services
{
    public interface IProductsService
    {
        public IQueryable<ProductsModel> Query();
        public ServiceBase Create(Products record);
        public ServiceBase Update(Products record);
        public ServiceBase Delete(int id);
    }
    public class ProductsService : ServiceBase, IProductsService
    {
        public ProductsService(Db db) : base(db)
        {
            
        }
        public IQueryable<ProductsModel> Query()
        {
            return _db.Products.OrderBy(s => s.Name).Select(s => new ProductsModel() { Record = s });
        }
        
        public ServiceBase Create(Products record)
        {
            if (_db.Products.Any(s => s.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Species with the same name exists!");
            record.Name = record.Name.Trim();
            _db.Products.Add(record);
            _db.SaveChanges(); // Commit to the database
            return Success("Product created successfully.");
        }

        public ServiceBase Update(Products record)
        {
            if (_db.Products.Any(s => s.Id != record.Id && s.Name.ToUpper()== record.Name.ToUpper().Trim()))
                return Error("Product with the same name exists!");
            var entity = _db.Products.SingleOrDefault(s => s.Id == record.Id);
            if (entity is null)
                return Error("Product can't be found!");
            entity.Name =record.Name.Trim();
            _db.Products.Update(entity);
            _db.SaveChanges(); // commit to the database
            return Success("Product updated successfully.");
        }
        public ServiceBase Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}*/
