using SimpleCustomerDemo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleCustomerDemo.Logic
{
    public class CustomerManager : IManager<Customer>
    {
        private readonly CustomerDemoContext db;
        private Logging log;

        public CustomerManager(CustomerDemoContext dbContext)
        {
            db = dbContext;
            log = new Logging(dbContext);
        }

        public bool AddUpdate(Customer entity)
        {
            if (IsValid(entity))
            {
                try
                {
                    if (db.Customers.Any(x => x.Id == entity.Id)) db.Customers.Update(entity);
                    else db.Customers.Add(entity);

                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    log.LogException(ex);
                }
            }

            return false;
        }

        public Customer GetById(int Id)
        {
            try
            {
                Id = Math.Abs(Id);

                if (db.Customers.Any(x => x.Id == Id))
                {
                    return db.Customers.First(x => x.Id == Id);
                }
            }
            catch (Exception ex)
            {
                log.LogException(ex);
            }
            return new Customer();
        }

        public List<Customer> GetList(Expression<Func<Customer, bool>> predicate)
        {
            try
            {
                if (predicate == null)
                {
                    return db.Customers.Where(x => x.Id > 0).ToList();
                }
                else
                {
                    if (db.Customers.Any(predicate))
                    {
                        return db.Customers.Where(predicate).ToList();
                    }
                    else
                    {
                        return db.Customers.Where(x => x.Id > 0).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                log.LogException(ex);
                return new List<Customer>();
            }
        }

        public bool IsValid(Customer entity)
        {
            try
            {
                if (entity == null) return false;
                if (!string.IsNullOrWhiteSpace(entity.FirstName)
                    && !string.IsNullOrWhiteSpace(entity.LastName)
                    && !string.IsNullOrWhiteSpace(entity.Phone)
                    && !string.IsNullOrWhiteSpace(entity.Email)
                    && !string.IsNullOrWhiteSpace(entity.Address1)
                    && !string.IsNullOrWhiteSpace(entity.City)
                    && !string.IsNullOrWhiteSpace(entity.StateCode)
                    && !string.IsNullOrWhiteSpace(entity.ZipCode)
                    && entity.DateOfBirth != DateTime.MinValue) return true;

                return false;
            }
            catch (Exception ex)
            {
                log.LogException(ex);
                return false;
            }
        }
    }
}
