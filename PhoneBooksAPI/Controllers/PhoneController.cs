using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBooksAPI.Models;
using PhoneBooksAPI.Services;

namespace PhoneBooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneController(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        [HttpGet]
        public IEnumerable<Phone> Get()
        {
            return _phoneRepository.GetAll().OrderBy(x => x.FirstName);
        }

        [HttpGet("{id}", Name = "GetPhone")]
        public IActionResult Get(int id)
        {
            var phone = _phoneRepository.GetById(id);
            if (phone == null)
            {
                return NotFound();
            }

            return Ok(phone);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Phone value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            var createdPhone = _phoneRepository.Add(value);

            return CreatedAtRoute("GetPhone", new { id = createdPhone.Id }, createdPhone);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Phone value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            var phone = _phoneRepository.GetById(id);

            if (phone == null)
            {
                return NotFound();
            }

            value.Id = id;

            _phoneRepository.Update(value);

            return NoContent();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var phone = _phoneRepository.GetById(id);
            if (phone == null)
            {
                return NotFound();
            }
            _phoneRepository.Delete(phone);

            return NoContent();
        }
    }
}