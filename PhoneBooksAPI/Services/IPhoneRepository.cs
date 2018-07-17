using PhoneBooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBooksAPI.Services
{
    public interface IPhoneRepository
    {
        Phone Add(Phone phone);
        IEnumerable<Phone> GetAll();
        Phone GetById(int id);
        void Delete(Phone phone);
        void Update(Phone phone);
    }
}
