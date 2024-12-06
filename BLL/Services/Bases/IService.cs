namespace BLL.Services.Bases
{
    public interface IService<TEntitiy, TModel> where TEntitiy : class, new() where TModel : class, new()
    {
        public IQueryable<TModel> Query();
        public ServiceBase Create(TEntitiy record);
        public ServiceBase Update(TEntitiy record);
        public ServiceBase Delete(int id);
    }
}
