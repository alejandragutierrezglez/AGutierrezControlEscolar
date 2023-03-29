using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PL.Controllers
{
    public class AlumnoController : Controller
    {

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result= new ML.Result();
            ML.Alumno alumno = new ML.Alumno();

            ServiceReferenceAlumnoo.ServiceAlumnoClient clientAlumno = new ServiceReferenceAlumnoo.ServiceAlumnoClient();
            result = clientAlumno.GetAll();
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
                return View(alumno);
            }
            else
            {
                return View(alumno);
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdAlumno)

        {

            ML.Result resultAlumnos = BL.Alumno.GetAll();
            ML.Alumno alumno = new ML.Alumno();
          
            if (resultAlumnos.Correct)
            {

               alumno.Alumnos = resultAlumnos.Objects;
            }
            if (IdAlumno == null)
            {
                //add //formulario vacio
                return View(alumno);
            }
            else
            {
                //getById
                //ML.Result result = BL.Aseguradora.GetByIdEF(IdAseguradora.Value); //2
                ML.Result result = new ML.Result();
                ServiceReferenceAlumnoo.ServiceAlumnoClient clientAlumno = new ServiceReferenceAlumnoo.ServiceAlumnoClient();
                result = clientAlumno.GetById(IdAlumno.Value);

                if (result.Correct)
                {

                    alumno = (ML.Alumno)result.Object;//unboxing
                    alumno.Alumnos = resultAlumnos.Objects;
                    //update
                    return View(alumno);
                }
                else
                {
                    ViewBag.Message = "Ocurrio al consultar la información de la aseguradora";
                    return View("Modal");
                }
            }
        }
        [HttpPost] //Hacer el registro
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            

            if (alumno.IdAlumno !=  null)
            {

                //UPDATE
                ServiceReferenceAlumnoo.ServiceAlumnoClient clientAlumno = new ServiceReferenceAlumnoo.ServiceAlumnoClient();
                result = clientAlumno.Update(alumno);
                //result = BL.Aseguradora.UpdateEF(aseguradora);
                ViewBag.Message = "Se ha modificado el registro";
            }
            else
            {
                //Add
                ServiceReferenceAlumnoo.ServiceAlumnoClient clientAlumno = new ServiceReferenceAlumnoo.ServiceAlumnoClient();
                result = clientAlumno.Add(alumno);
                //result = BL.Aseguradora.AddEF(aseguradora);
                ViewBag.Message = "Se ha agregado el registro";
            }
            if (result.Correct)
            {
                return PartialView("Modal");
            }
            else
            {
                return PartialView("Modal");
            }
        }


        public ActionResult Delete(ML.Alumno alumno)
        {
           
            ML.Result result = new ML.Result();

            ServiceReferenceAlumnoo.ServiceAlumnoClient clientAlumno = new ServiceReferenceAlumnoo.ServiceAlumnoClient();
            result = clientAlumno.Delete(alumno);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha podido eliminar el registro seleccionado" + result.ErrorMessage;
                return PartialView("Modal");
            }
        }


    }
}