using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "AlumnoAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parameter = new SqlParameter[3];

                        parameter[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        parameter[0].Value = alumno.Nombre.ToString();

                        parameter[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        parameter[1].Value = alumno.ApellidoPaterno.ToString();

                        parameter[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        parameter[2].Value = alumno.ApellidoMaterno.ToString();
                    

                        cmd.Parameters.AddRange(parameter);

                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "AlumnoUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parameter = new SqlParameter[4];

                        parameter[0] = new SqlParameter("@IdAlumno", System.Data.SqlDbType.Int);
                        parameter[0].Value = alumno.IdAlumno.ToString();

                        parameter[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        parameter[1].Value = alumno.Nombre.ToString();

                        parameter[2] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        parameter[2].Value = alumno.ApellidoPaterno.ToString();

                        parameter[3] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        parameter[3].Value = alumno.ApellidoMaterno.ToString();

                     
                        cmd.Parameters.AddRange(parameter);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }

            return result;
        }

        public static ML.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "AlumnoDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parameter = new SqlParameter[1];

                        parameter[0] = new SqlParameter("@IdAlumno", System.Data.SqlDbType.Int);
                        parameter[0].Value = alumno.IdAlumno.ToString();

                        cmd.Parameters.AddRange(parameter);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }

            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "AlumnoGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable dataTableAlumnos = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTableAlumnos);

                        if (dataTableAlumnos.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in dataTableAlumnos.Rows)
                            {

                                ML.Alumno alumno = new ML.Alumno();
                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno= row[2].ToString();
                                alumno.ApellidoMaterno= row[3].ToString();
                               

                                result.Objects.Add(alumno);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "AlumnoGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parameters = new SqlParameter[1];

                        parameters[0] = new SqlParameter("@IdAlumno", System.Data.SqlDbType.Int);
                        parameters[0].Value = IdAlumno;

                        cmd.Parameters.AddRange(parameters);

                        //Crear tabla virtual
                        DataTable tableAlumno = new DataTable();

                        //Permite leer la información de la consulta
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //llenar la tabla virtual
                        adapter.Fill(tableAlumno);

                        if (tableAlumno.Rows.Count > 0)
                        {
                            DataRow row = tableAlumno.Rows[0];

                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno= row[2].ToString();  
                            alumno.ApellidoMaterno= row[3].ToString();

                            result.Object = alumno;

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }
            return result;
        }


    }
}
