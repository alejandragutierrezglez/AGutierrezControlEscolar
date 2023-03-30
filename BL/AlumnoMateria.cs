using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AGutierrezControlEscolarEntities context = new DL.AGutierrezControlEscolarEntities())
                    {
                        var query = context.AlumnoGetAll().ToList();

                        if (query != null)
                        {
                            result.Objects = new List<object>();

                            foreach (var resultAlumno in query)
                            {
                                ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                                alumnoMateria.Alumno = new ML.Alumno();
                                alumnoMateria.Alumno.IdAlumno = resultAlumno.IdAlumno;
                                alumnoMateria.Alumno.Nombre = resultAlumno.Nombre;
                                alumnoMateria.Alumno.ApellidoPaterno = resultAlumno.ApellidoPaterno;
                                alumnoMateria.Alumno.ApellidoMaterno = resultAlumno.ApellidoMaterno;

                                result.Objects.Add(alumnoMateria);
                            }
                            result.Correct = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ex = ex;
                    result.ErrorMessage = ex.Message;
                }
                return result;
            }
        }

        public static ML.Result MateriasGetByIdAlumno(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AGutierrezControlEscolarEntities context = new DL.AGutierrezControlEscolarEntities())
                    {
                        var query = context.MateriasGetByAlumno(IdAlumno).ToList();

                        if (query != null)
                        {
                            result.Objects = new List<object>();

                            foreach (var obj in query)
                            {
                               ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                                alumnoMateria.Materia = new ML.Materia();
                                alumnoMateria.Materia.IdMateria = obj.IdMateria;
                                alumnoMateria.Materia.Nombre= obj.Nombre;
                      

                                alumnoMateria.Alumno = new ML.Alumno();
                                alumnoMateria.Alumno.IdAlumno = obj.IdAlumno;
                                alumnoMateria.Alumno.Nombre = obj.NombreAlumno;
                                alumnoMateria.Alumno.ApellidoPaterno = obj.ApellidoPaterno;
                                alumnoMateria.Alumno.ApellidoMaterno = obj.ApellidoMaterno;


                                result.Objects.Add(alumnoMateria);
                            }
                        }
                    }

                    result.Correct = true;
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ex = ex;
                    result.ErrorMessage = ex.Message;
                }
                return result;
            }

        }

        public static ML.Result MateriasSinAsignarGetByAlumno(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AGutierrezControlEscolarEntities context = new DL.AGutierrezControlEscolarEntities())
                    {
                        var query = context.MateriasSinAsignarByIdAlumno(IdAlumno).ToList();

                        if (query != null)
                        {
                            result.Objects = new List<object>();

                            foreach (var obj in query)
                            {
                                ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                                alumnoMateria.Alumno = new ML.Alumno();
                                alumnoMateria.Materia = new ML.Materia();
                                alumnoMateria.Materia.IdMateria = obj.IdMateria;
                                alumnoMateria.Materia.Nombre = obj.Nombre;
                            

                                result.Objects.Add(alumnoMateria);
                            }
                        }
                    }

                    result.Correct = true;
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ex = ex;
                    result.ErrorMessage = ex.Message;
                }
                return result;
            }

        }

        public static ML.Result AddMateriaEF(int IdAlumno, int IdMateria)
      
        {
            using (DL.AGutierrezControlEscolarEntities context = new DL.AGutierrezControlEscolarEntities())
            {
                Result result = new ML.Result();
                try
                {

                    var query = context.AlumnoMateriaAdd(IdAlumno, IdMateria);
                   

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
                catch (Exception ex)
                {

                    result.ErrorMessage = ex.Message;
                    result.ex = ex;
                    result.Correct = false;
                }
                return result;

            }
        }

        public static ML.Result DeleteMateriaEF(int IdAlumno, int IdMateria)

        {
            using (DL.AGutierrezControlEscolarEntities context = new DL.AGutierrezControlEscolarEntities())
            {
                Result result = new ML.Result();
                try
                {

                    var query = context.AlumnoMateriaDelete(IdAlumno, IdMateria);


                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
                catch (Exception ex)
                {

                    result.ErrorMessage = ex.Message;
                    result.ex = ex;
                    result.Correct = false;
                }
                return result;

            }
        }
    }
}
