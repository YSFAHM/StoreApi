using Store.Data.Entities;
using Store.Repository.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IGenericRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        public Task<TEntity> GetByIdAsync(TKey? id);
        public Task<IReadOnlyList<TEntity>> GetAllAsync();
        public Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingAsync();
        Task<TEntity> GetWithSpecifcationByIdAsync(ISpecification<TEntity> specs);
        Task<IReadOnlyList<TEntity>> GetAllWithSpecifcationAsync(ISpecification<TEntity> specs);
        public Task<int> GetCountSpecificationAsync(ISpecification<TEntity> specs);
        Task AddAsync(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);

    }
}
