using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    // Generic Constraint Yapıcaz (Generic Kısıt). Yani Burada tip olarak sadece Entitiesdeki elamanları almasını istiyoruz.
    // Class : Referans tip olabilir demek.
    // IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    // new() : new'lenebilir olmalı demek. Yani newlenebilir olmasını istediğimiz için. IEntity iplemente eden classları kabul eder.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}