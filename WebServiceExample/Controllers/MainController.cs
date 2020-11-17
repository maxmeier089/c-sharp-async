using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebServiceExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {

        private readonly ILogger<MainController> logger;

        public MainController(ILogger<MainController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public async Task<MainData> Get()
        {
            logger.Log(LogLevel.Information, "main/get");

            MainData data = await Task.Run(() =>
            {
                return new MainData()
                {
                    Text = "N" + new Random().Next(9999)
                };
            });

            logger.Log(LogLevel.Information, "main/get result: " + data.Text);

            return data; 
        }

    }
}
