using BackOffice.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Infrastructure.Repositorys
{

    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly BackofficeDbContext _dbContext;

        public GenericRepository(BackofficeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TModel> GetEverythingAsync(Expression<Func<TModel, bool>> filter)
        {
            try
            {
                TModel model = await _dbContext.Set<TModel>().FirstOrDefaultAsync(filter);
                return model;
            }
            catch
            {
                throw;
            }

        }

        public async Task<TModel> CreateAsync(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;

            }

        }

        public async Task<bool> UpdateAsync(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }

        }
        public async Task<TModel> GetByIdAsync(int id)
        {
            try
            {
                TModel model = await _dbContext.Set<TModel>().FindAsync(id);
                return model;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> SoftDeleteAsync(TModel model)
        {
            try
            {
                var propertyInfo = typeof(TModel).GetProperty("IsDeleted");
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(model, true);
                    _dbContext.Set<TModel>().Update(model);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while soft deleting the model.", ex);
            }
        }

        public async Task<IQueryable<TModel>> VerifyDataExistenceAsync(Expression<Func<TModel, bool>> filter = null)
        {
            try
            {
                IQueryable<TModel> ModelQuery = filter == null ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(filter);
                return ModelQuery;
            }
            catch
            {
                throw;
            }

        }

    }

}
