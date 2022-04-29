using CoffeeBaz.Data.Domain;


namespace CoffeeBaz.Data.DataRepository
{
    public interface IRepository<Template> where Template : BaseEntity
    {
        IQueryable<Template> Entity { get; }

        Task<bool> Insert(Template entity, CancellationToken cancellationToken = default);
        Task<bool> Update(Template entity, CancellationToken cancellationToken = default);
        Task<bool> Delete(Template entity, CancellationToken cancellation = default);


        bool Update(int id);
        bool Delete(int id);

        bool Insert(IList<Template> templates);
        bool Update(IList<Template> templates);
        bool Delete(IList<Template> templates);


        IList<Template> GetAll(int tableId=0,
            int productId=0,DateTime? startDate=null,
            DateTime? endDate=null);
        Task<Template> GetById(int id,CancellationToken cancellationToken=default);

    }
}
