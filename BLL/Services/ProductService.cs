using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    //public interface IProductService
    //{
    //    public IQueryable<ProductModel> Query();
    //    public ServiceBase Create(Products record);
    //    public ServiceBase Update(Products record);
    //    public ServiceBase Delete(int id);
    //}
    public class ProductService : ServiceBase, IService<Products, ProductModel>
    {
        public ProductService(Db db) : base(db)
        {
        }
        public IQueryable<ProductModel> Query()
        {
           return _db.Products.Include(p => p.Category).OrderByDescending(p=>p.CreatedDate).ThenBy(p=>p.Name).
                Select(p=> new ProductModel {Record = p});

        }

        public ServiceBase Create(Products record)
        {
            if (_db.Products.Any(p => p.Name.ToLower() == record.Name.ToLower().Trim()))
                return Error("Product with the same name exists!");
            record.Name = record.Name?.Trim();
            _db.Products.Add(record);
            _db.SaveChanges();
            return Success("Product created successfully.");
        }

         
        public ServiceBase Update(Products record)
        {
            if (_db.Products.Any(p => p.Id != record.Id && p.Name.ToLower() == record.Name.ToLower().Trim()))
                return Error("Product with the same name exists!");
            record.Name = record.Name?.Trim();
            _db.Products.Update(record);
            _db.SaveChanges();
            return Success("Product updated successfully.");
        }
        
        public ServiceBase Delete(int id)
        {
            var entity = _db.Products.SingleOrDefault(p=>p.Id == id);
            if (entity is null)
                return Error("Product can't be found!");
            _db.Products.Remove(entity);
            _db.SaveChanges();
            return Success("Product deleted successfully.");

        }

       
    }
}
