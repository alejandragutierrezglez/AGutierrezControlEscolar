using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia

        [HttpGet]
        public ActionResult GetAll()
        {

            ML.Materia materia = new ML.Materia();

            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            try
            {
                using (var client = new HttpClient())
                {
                    string str = System.Configuration.ConfigurationManager.AppSettings["WebApi"];
                    client.BaseAddress = new Uri(str);

                    var responseTask = client.GetAsync("Materia/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }
                    }
                    materia.Materias = result.Objects;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;

            }

            return View(materia);
        }


        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {

            ML.Result resultMaterias = BL.Materia.GetAllEF();
            ML.Materia materia = new ML.Materia();

            if (resultMaterias.Correct)
            {
                materia.Materias = resultMaterias.Objects;
            }
            if (IdMateria == null)
            {
                //add //formulario vacio
                return View(materia);
            }
            else
            {
                ML.Result result = new ML.Result();
                //getById
                //ML.Result result = BL.Materia.GetByIdEF(IdMateria.Value); //2
                using (var client = new HttpClient())
                    try
                    {
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApi"]);
                        var responseTask = client.GetAsync("Materia/GetById/" + IdMateria);
                        responseTask.Wait();

                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)

                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();

                            ML.Materia resultItemList = new ML.Materia();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;


                            materia = (ML.Materia)result.Object;//unboxing
                            materia.Materias = resultMaterias.Objects;


                            //update
                            return View(materia);
                        }
                        else
                        {
                            ViewBag.Message = "Ocurrio al consultar la información de la materia";
                            return View("Modal");
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Correct = false;
                        result.ErrorMessage = ex.Message;
                        result.ex = ex;
                    }

                return View(materia);
            }
        }



        [HttpPost] //Hacer el registro //AQUI SE HACE CONSUMO MEDIANTE CONTROLADOR DE ADD Y UPDATE
        public ActionResult Form(ML.Materia materia)
        {
              if (materia.IdMateria != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApi"]);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Update/" + materia.IdMateria, materia);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha modificado el registro";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Message = "No se ha modificado el registro";
                        return PartialView("Modal");
                    }
                }
                 //return View("GetAll");
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApi"]);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Add", materia);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha agregado el registro";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Message = "No se ha agregado el registro";
                        return PartialView("Modal");
                    }
                }
            }
        }

        public ActionResult Delete(int IdMateria) //Eliminar //Aqui se hace consumo mediante controlador
        {
            ML.Result resultListMaterias = new ML.Result();
            ML.Materia materia = new ML.Materia();
            materia.IdMateria = IdMateria;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApi"]);

                var postTask = client.GetAsync("Materia/Delete/" + IdMateria);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    resultListMaterias = BL.Materia.GetAllEF();
                    ViewBag.Message = "Se ha eliminado el registro";
                    return PartialView("Modal");
                }
            }
            resultListMaterias = BL.Materia.GetAllEF();
            return View("GetAll", resultListMaterias);
        }



    }
}