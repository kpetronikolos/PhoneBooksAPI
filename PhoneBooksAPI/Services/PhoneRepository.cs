using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneBooksAPI.Models;

namespace PhoneBooksAPI.Services
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly PhoneBooksAPIContext _context;

        public PhoneRepository(PhoneBooksAPIContext context)
        {
            _context = context;
        }

        public Phone Add(Phone phone)
        {
            var addedPhone = _context.Add(phone);
            _context.SaveChanges();
            phone.Id = addedPhone.Entity.Id;

            return phone;
        }

        public void Delete(Phone phone)
        {
            _context.Remove(phone);
            _context.SaveChanges();
        }

        public IEnumerable<Phone> GetAll()
        {
            return _context.Phones.ToList();
        }

        public Phone GetById(int id)
        {
            return _context.Phones.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Phone phone)
        {
            var phoneToUpdate = GetById(phone.Id);
            phoneToUpdate.FirstName = phone.FirstName;
            phoneToUpdate.LastName = phone.LastName;
            phoneToUpdate.Type = phone.Type;
            phoneToUpdate.Number = phone.Number;
            _context.Update(phoneToUpdate);
            _context.SaveChanges();

        }
    }
}
