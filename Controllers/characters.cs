
using System;
     using System;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Transactions;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace webtesting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class characters : ControllerBase
    {
        // public static List<user> knight = new List<user>{
        //     new user(),
        //     new user(){
        //         Id = 2,
        //         name = "Bishop"
        //     }
        // };
        private readonly Icharacterservice _characterservice;

        public characters(Icharacterservice characterservice)
        {
            _characterservice = characterservice;
        }
        [HttpGet("users")]
        public async Task<ActionResult<ServiceResponse<List<user>>>> Get(){
            return Ok(await _characterservice.GetUsers());
        }
        [HttpGet("{index}")]
        public async Task<ActionResult <ServiceResponse<List<user>>>> GetSingle(int index){
            return Ok(await _characterservice.GetuserbyId(index));
        }
       [HttpPost("Add")]
       
        public async Task<ActionResult <List<user>>> AddCharacter(user newuser){
        
            
            return Ok(await _characterservice.AddCharacter(newuser));
        }

 
 
    [HttpGet("verify/{reference}")]
    public async Task<IActionResult> VerifyTransaction(string reference)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "sk_test_712bf0b95312df1baccc54e25615568ab421b749");
            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
            var response = await client.GetAsync($"https://api.paystack.co/transaction/verify/{reference}");
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(response.ReasonPhrase);
            }

            var result = await response.Content.ReadAsStringAsync();
        
            var ent = JsonConvert.DeserializeObject(result);
            //var transaction = System.Text.Json.JsonSerializer.Deserialize<Transaction>(result);
            
            return Ok(result);
        }
    }
}
 
 }
 


        
    
    
