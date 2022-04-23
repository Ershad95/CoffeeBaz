using CoffeeBaz.Data.Domain;


namespace CoffeeBaz.Data.DataRepository
{
    public interface IRepository<Template> where Template : BaseEntity
    {
        IQueryable<Template> Entity { get; }

        bool Insert(Template entity);
        bool Update(Template entity);
        bool Delete(Template entity);


        bool Update(int id);
        bool Delete(int id);

        bool Insert(IList<Template> templates);
        bool Update(IList<Template> templates);
        bool Delete(IList<Template> templates);


        IList<Template> GetAll(int tableId=0,
            int productId=0,DateTime? startDate=null,
            DateTime? endDate=null);
        Template GetById(int id);

    }
}
