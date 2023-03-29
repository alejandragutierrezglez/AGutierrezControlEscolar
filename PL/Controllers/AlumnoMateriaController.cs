using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        [HttpGet]
        public ActionResult GetAll(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = BL.AlumnoMateria.GetAllEF();

            if (result.Correct)
            {
                alumnoMateria.AlumnosMaterias = result.Objects;
                return View(alumnoMateria);
            }
            else
            {
                return View(alumnoMateria);
            }
        }

        [HttpGet]
        public ActionResult GetAll(int IdAlumno)

        {

            ML.Result result = BL.AlumnoMateria.MateriasGetByIdAlumno(IdAlumno);
            ML.Materia materia = new ML.Materia();
            // ML.Result resultDependiente = BL.Dependiente.GetAll();

            if (result.Correct)
            {
                materia.Materias = result.Objects;
                return View(materia);
            }
            else
            {
                return View(materia);
            }
        }



    }
}