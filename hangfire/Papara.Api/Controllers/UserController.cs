using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Papara.Core.Dtos;
using Papara.Core.Entites;
using Papara.Core.Enums;
using Papara.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Papara.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly Func<CacheTech, ICacheService> _cacheService;
        private IMapper mapper;

        public UserController(IUserRepository repository, Func<CacheTech, ICacheService> cacheService, IMapper mapper)
        {
            _repository = repository;
            _cacheService = cacheService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task DataFromApi()

         {
            HttpWebRequest httpWeb = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/posts ");
            httpWeb.Method = "GET";

            HttpWebResponse webResponse = (HttpWebResponse)httpWeb.GetResponse();
            Console.WriteLine(webResponse.StatusCode);
            Console.WriteLine(webResponse.Server);

            string Json;
            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                Json = reader.ReadToEnd();
            }
            List<UserDto> items = (List<UserDto>)JsonConvert.DeserializeObject(Json, typeof(List<UserDto>));
            var mapp = mapper.Map<List<User>>(items);
            foreach (var item in mapp)
            {
                await _repository.AddAsync(item);
            }
            
            Console.WriteLine(items);


        }
        [HttpPost]
        [Route("invoice")]
        public IActionResult Invoice()
        {
            RecurringJob.AddOrUpdate(() => DataFromApi(), "*/5 * * * * *");
            return Ok($" Repeat every 5 minutes!");
        }

        [HttpGet("GetById")]
        public IActionResult GetAllApi(int id)
        {
            var repo = _repository.GetByIdAsync(id).Result;
            return Ok(repo);
        }

        [HttpGet("GetAll")]
        public IActionResult GetById()
        {
            var repo = _repository.GetAllAsync();
            return Ok(repo);
        }
    }
}
