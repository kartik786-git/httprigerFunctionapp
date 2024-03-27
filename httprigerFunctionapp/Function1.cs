using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace httprigerFunctionapp
{
    public static class Function1
    {
        [FunctionName("twoactions")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("twoactions processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);


            string responseMessage = string.IsNullOrEmpty(name)
               ? $"{data}"
               : $"result {name}. ";

            log.LogInformation($"{name} {data}");
            return new OkObjectResult(responseMessage);
        }

        [FunctionName("ReadBlogs")]
        public static async Task<IActionResult> ReadBlogs(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] 
        HttpRequest req,ILogger log)
        {
            log.LogInformation("ReadBlogs processed a get request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            string responseMessage =
         $"result - {data}";
            log.LogInformation($"{data}");
            return new OkObjectResult(responseMessage);
        }

        [FunctionName("CreateBlog")]
        public static async Task<IActionResult> CreateBlog(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
        HttpRequest req,
            ILogger log)
        {
            log.LogInformation("CreateBlog processed a post request.");


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            string responseMessage =
                 $"result {data}";
            log.LogInformation($"{data}");
            return new OkObjectResult(responseMessage);
        }

        [FunctionName("UpdateBlog")]
        public static async Task<IActionResult> UpdateBlog(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("UpdateBlog processed a put request.");


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            string responseMessage =
                 $"Result - {data}";
            log.LogInformation($"{data}");
            return new OkObjectResult(responseMessage);
        }

        [FunctionName("DeleteBlog")]
        public static async Task<IActionResult> DeleteBlog(
           [HttpTrigger(AuthorizationLevel.Function, "delete", Route = null)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("DeleteBlog processed a delete request.");


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            string responseMessage =
                $"result {data}";
            log.LogInformation($"{data}");
            return new OkObjectResult(responseMessage);
        }
    }
}
