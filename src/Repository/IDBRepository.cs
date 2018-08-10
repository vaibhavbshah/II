using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDBRepository<TEntity>
    {
        /// <summary>
        /// Inserts an entity into the repository and sets the entity id
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>True if the insert has been successful otherwise false</returns>
        bool Insert(TEntity entity);
        /// <summary>
        /// Saves (updates) an entity that is already in the repository
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if the update was successful otherwise false</returns>
        bool Update(TEntity entity);
        /// <summary>
        /// Removes an entity from the repository
        /// </summary>
        /// <param name="entity">Entity to remove</param>
        /// <returns>True if an entity was deleted otherwise false</returns>
        bool Delete(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteById(string id);
        /// <summary>
        /// Searches for a list of entities that match a specified predicate
        /// </summary>
        /// <param name="predicate">Predicate to use when searching for entities</param>
        /// <returns></returns>
        IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        //IList<TEntity> SearchFor(PagingFiltering criteria, int pageNo, int pageSize, out long totalCount);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IList<TEntity> SearchFor(string key, string value);

        /// <summary>
        /// Retrieves all the entities from the repository
        /// </summary>
        /// <returns>List of entities</returns>
        IList<TEntity> GetAll();
        /// <summary>
        /// Retrieves an entity by its integer id
        /// </summary>
        /// <param name="id">Id of the entity to retrieve</param>
        /// <returns>A matching entity with the specified id</returns>
        TEntity GetById(string id);


    }
}
