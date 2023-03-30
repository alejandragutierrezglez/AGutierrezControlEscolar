using BL;
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

        public ActionResult MateriasGetByAlumno(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.MateriasGetByIdAlumno(IdAlumno);
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);
            alumnoMateria.AlumnosMaterias = result.Objects;
            alumnoMateria.Alumno = (ML.Alumno)resultAlumno.Object;

            return View(alumnoMateria);

        }


        public ActionResult MateriasSinAsignarGetByAlumno(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.MateriasSinAsignarGetByAlumno(IdAlumno);
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();


            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);
            alumnoMateria.AlumnosMaterias = result.Objects;
            alumnoMateria.Alumno = (ML.Alumno)resultAlumno.Object;

            //ML.Result result1 = BL.AlumnoMateria.AddMateriaEF(IdAlumno, IdMateria);
            //alumnoMateria.AlumnosMaterias = result1.Objects;
            //alumnoMateria.Alumno = (ML.Alumno)resultAlumno.Object;


            return View(alumnoMateria);

        }
        [HttpPost]
        public ActionResult MateriasAdd(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            if (alumnoMateria.AlumnosMaterias != null)
            {
                foreach (string idMateria in alumnoMateria.AlumnosMaterias)
                {
                    int idMaterias = int.Parse(idMateria);

                    ML.Result resultt = BL.AlumnoMateria.AddMateriaEF(alumnoMateria.Alumno.IdAlumno.Value, idMaterias);

                }
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "No se pudo realizar la inserción";

            }
            //ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);
            //alumnoMateria.AlumnosMaterias = result.Objects;
            //alumnoMateria.Alumno = (ML.Alumno)resultAlumno.Object;
            result.Correct = true;
            ViewBag.Message = "Se ha agregado la materia";
            return PartialView("Modal");
        }

        public ActionResult MateriasDelete(int IdAlumno, int IdMateria)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.IdAlumnoMateria = IdAlumno;
            ML.Result result = BL.AlumnoMateria.DeleteMateriaEF(IdAlumno, IdMateria);

            if (result.Correct)
            {
                ViewBag.message = "Se ha eliminado el registro";
            }
            else
            {
                ViewBag.message = "Error al eliminar debido a: " + result.ErrorMessage;

            }
            return PartialView("Modal");
        }
    }
}