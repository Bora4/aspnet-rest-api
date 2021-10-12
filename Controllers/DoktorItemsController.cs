using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoktorSelector.Models;
using DoktorSelector.DB;
using Npgsql;

namespace DoktorSelector.Controllers
{
    [Route("api/[controller]")]
    public class DoktorItemsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public DoktorItemsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        // GET: api/DoktorItems
        [HttpGet]
        public IEnumerable<DoktorItem> GetDoktorItems([FromHeader] string specialty = "hello")
        {

            return _dataAccessProvider.GetDoktorItemRecords(specialty);
        }

        [HttpPost]
        public IActionResult Create([FromBody] DoktorItem doktor)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddDoktorItemRecord(doktor);
                return Ok();
            }
            return BadRequest();
        }

        // GET: api/DoktorItems/5
        [HttpGet("{id}")]
        public DoktorItem Details(int id)
        {
            return _dataAccessProvider.GetDoktorItemSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] DoktorItem doktor)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateDoktorItemRecord(doktor);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _dataAccessProvider.GetDoktorItemSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteDoktorItemRecord(id);
            return Ok();
        }
    }
}