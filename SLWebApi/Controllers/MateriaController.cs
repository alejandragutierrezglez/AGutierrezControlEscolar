using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace SLWebApi.Controllers
{
    public class MateriaController : ApiController
    {
      
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

        [HttpGet]
        [Route("api/Materia/GetById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            ML.Result result = BL.Materia.GetByIdEF(id);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Materia/Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            ML.Result result = BL.Materia.GetByIdEF(id);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/Materia/Add")]
        public IHttpActionResult Add([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.AddEF(materia);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/Materia/Update/{IdMateria}")]
        public IHttpActionResult Update([FromBody] ML.Materia materia)
        {

            ML.Result result = BL.Materia.UpdateEF(materia);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Materia/Delete/{IdMateria}")]
        public IHttpActionResult Delete(int IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.IdMateria = IdMateria;
            ML.Result result = BL.Materia.DeleteEF(IdMateria);
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
