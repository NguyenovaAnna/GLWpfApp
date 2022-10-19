using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ContactMethodRepository : IContactMethodRepository
    {
        private readonly EmployeesContext _context;

        public ContactMethodRepository(EmployeesContext context)
        {
            _context = context;
        }

        public ContactMethod Create(ContactMethod entity)
        {
            var contactMethod = _context.ContactMethod.Add(entity);
            this._context.SaveChanges();
            return contactMethod.Entity;
        }

        public void Delete(int id)
        {
            var contactMethod = GetById(id);
            _context.ContactMethod.Remove(contactMethod);
            _context.SaveChanges();
        }

        public IEnumerable<ContactMethod> GetAll()
        {
            return _context.ContactMethod;
        }

        public ContactMethod GetById(int id)
        {
            var result = _context.ContactMethod.FirstOrDefault(e => e.ContactMethodId == id);
            return result;
        }

        public ContactMethod Update(int id, ContactMethod entity)
        {
            _context.ContactMethod.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
