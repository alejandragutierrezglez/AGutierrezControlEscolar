using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace SLWebApi.Controllers
{
    public class HomeController : ApiController
    {
        [Route("api/Home/Index")]
        public IHttpActionResult Index()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/Materia/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();

            ML.Result result = BL.Materia.GetAllEF();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
