using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleCustomerDemo.Logic
{
    public interface IManager<T>
    {
        T GetById(int Id);
        List<T> GetList(Expression<Func<T, bool>> predicate);
        bool AddUpdate(T entity);
        bool IsValid(T entity);
    }
}
