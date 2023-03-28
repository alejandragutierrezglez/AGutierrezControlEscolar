using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result AddEF(ML.Materia materia)
        {
            using (DL.AGutierrezControlEscolarEntities context = new DL.AGutierrezControlEscolarEntities())
            {
                Result result = new ML.Result();
                try
                {

                    var query = context.MateriaAdd(materia.Nombre,materia.Costo);

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

        public static ML.Result UpdateEF(ML.Materia materia)
        {
            using (DL.AGutierrezControlEscolarEntities context = new DL.AGutierrezControlEscolarEntities())
            {
                Result result = new ML.Result();
                try
                {

                    var query = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);

                    if (Convert.ToInt32(query) > 0)
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

        public static ML.Result DeleteEF(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezControlEscolarEntities context = new DL.AGutierrezControlEscolarEntities())
                {
                    var query = context.MateriaDelete(idMateria);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ex=ex;
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AGutierrezControlEscolarEntities context = new DL.AGutierrezControlEscolarEntities())
                    {
                        var query = context.MateriaGetAll().ToList();


                        if (query != null)
                        {
                            result.Objects = new List<object>();

                            foreach (var resultMateria in query)
                            {
                                ML.Materia materia = new ML.Materia();
                                materia.IdMateria = resultMateria.IdMateria;
                                materia.Nombre= resultMateria.Nombre;
                                materia.Costo = resultMateria.Costo.Value;                              


                                result.Objects.Add(materia);
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

        public static ML.Result GetByIdEF(int IdMateria)
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AGutierrezControlEscolarEntities context = new DL.AGutierrezControlEscolarEntities())
                    {
                        var query = context.MateriaGetById(IdMateria).FirstOrDefault();

                        if (query != null)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.Nombre = query.Nombre;
                            materia.Costo = query.Costo.Value;

                            result.Object = materia;

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo realizar la consulta";
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
    }
}
