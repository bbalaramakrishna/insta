using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Dtoinstagram;
using WebApplication4.Logic;
using WebApplication4.Iinstagram;
using System.Data;
using Newtonsoft.Json;
namespace WebApplication4.Controller
 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
      
        [Route ("instagramget")]
        [HttpGet]
        public async Task<IActionResult> GetData(int id)
                {
              IinstagramLogic obj =new instagramlogic();
              var result   = await obj.ECEData(id);
              return Ok(result);
                }
           
        [Route ("instagramsignup")]
        [HttpPost]
        public bool Insert(Instagramdto dtoinstagram)
        {
            IinstagramLogic obj = new instagramlogic();
            obj.InsertData(dtoinstagram);
            return true ;
        }
          
        [Route ("instagrammodification")]
        [HttpPut]
        public IActionResult update(int id, string firstName)
                    {
            IinstagramLogic obj = new instagramlogic();
            bool result=obj.updateData(id, firstName);

            if(result == true)
            {
                return Ok("Update Successful");
            }
            else
            {
                return NotFound("Data Not updated");
            }
                
        }
           
        [Route ("instagramdelete")]
        [HttpDelete]
        public bool Delete(int Id)
                    {
          IinstagramLogic  obj  =new instagramlogic();
           bool result =obj.DeleteData(Id);       
            return result;
                    }
            


        }

    }

