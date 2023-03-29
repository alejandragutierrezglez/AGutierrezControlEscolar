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
                        var query = context.Materias.FromSqlRaw($"MateriasGetByAlumno '{IdAlumno}'").ToList();

                        if (query != null)
                        {
                            result.Objects = new List<object>();

                            foreach (var obj in query)
                            {
                                ML.Materia materia = new ML.Materia();

                                materia.IdMateria= obj

                                dependiente.IdDependiente = obj.IdDependiente;

                                dependiente.Empleado = new ML.Empleado();
                                dependiente.Empleado.NumeroEmpleado = obj.NumeroEmpleado;

                                dependiente.Nombre = obj.Nombre;
                                dependiente.ApellidoPaterno = obj.ApellidoPaterno;
                                dependiente.ApellidoMaterno = obj.ApellidoMaterno;
                                dependiente.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                                dependiente.EstadoCivil = obj.EstadoCivil;
                                dependiente.Genero = obj.Genero;
                                dependiente.Telefono = obj.Telefono;
                                dependiente.RFC = obj.Rfc;

                                dependiente.DependienteTipo = new ML.DependienteTipo();
                                dependiente.DependienteTipo.IdDependienteTipo = obj.IdDependienteTipo;


                                result.Objects.Add(dependiente);


                            }
                        }
                    }
                    result.Correct = true;
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.Ex = ex;
                    result.ErrorMessage = ex.Message;
                }
                return result;
            }

        }
    }
}
