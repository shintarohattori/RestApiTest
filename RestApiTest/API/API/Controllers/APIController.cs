using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        // APIModelの初期データ。本来はデータベースなどから取得する。
        private static List<APIModel> items = new List<APIModel>() {
            new APIModel() { Id = 1, Name = @"服部"},
            new APIModel() { Id = 2, Name = @"名取"},
            new APIModel() { Id = 3, Name = @"青嶋"},
        };

        [HttpGet]
        public ActionResult<List<APIModel>> GetAll()
    => items;

        [HttpGet("{id}", Name = "API")]
        public ActionResult<APIModel> GetById(int id)
        {
            var item = items.Find(i => i.Id == id);
            if (item == null)
                return NotFound();
            return item;
        }
    }
}