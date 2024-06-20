using Core.Entity.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Abstract
{
    public interface IApplicationService<T> where T : class, IEntity, new()
    {
        IDataResult<List<T>> GetAll();
        T GetById(string id);
        IResult Add(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}
