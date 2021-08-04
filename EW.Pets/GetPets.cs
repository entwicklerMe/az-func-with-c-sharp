using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EW.Pets
{
    public static class GetPets
    {
        [FunctionName("GetPets")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "pets")]
            HttpRequest req, ILogger log)
        {
            var pets = new List<string> {"Hamster", "Kaninchen", "Maus", "Katze"};

            return new OkObjectResult(new { pets = pets});
        }
    }
}