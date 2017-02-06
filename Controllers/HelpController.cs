using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Zelda.Controllers
{
    [Route("api/[controller]")]
    public class HelpController : Controller
    {

        // GET api/help
        [HttpGet]
        public string Get()
        {

            string helptext = "# Welcome to this REST API information source! \n \t ## GET api/values \n \t ## POST api/values \n \t\t Content-Type: application/x-www-form-urlencoded \n \t\t Example Body (Bulk edit version): \n \t\t\t inputFirstName:John \n \t\t\t inputLastName:Doe \n \t\t\t inputBirthDate:1989-12-17 \n \t\t\t inputTitle:Legend of Zelda \n \t\t\t inputUrl:http://www.testing.com \n \t\t\t inputDescription:Zelda something something \n \t\t\t inputOwnerName:John Doe \n \t\t\t inputCategory:tehnoloogiauudised \n \t\t\t inputPoints:10";


            return helptext;
        }




    }
}
