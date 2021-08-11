using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using EW.Pets.Models;
using EW.Pets.Utils;
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
        public static async Task<IActionResult> GetPet(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "pets")]
            HttpRequest req, ILogger log)
        {
            var repo = new Repository();
            var pets = await repo.GetPets();

            return new OkObjectResult(new { pets = pets});
        }
        
        [FunctionName("PostGets")]
        public static async Task<IActionResult> PostPet(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "pets")]
            HttpRequestMessage req, ILogger log)
        {
            string requestBody = await req.Content.ReadAsStringAsync();
            Pet pet = JsonConvert.DeserializeObject<Pet>(requestBody);
            
            var repo = new Repository();
            repo.Save(pet: pet);

            var result = new OkObjectResult(pet) {StatusCode = 201};
            return result;
        }
    }
}