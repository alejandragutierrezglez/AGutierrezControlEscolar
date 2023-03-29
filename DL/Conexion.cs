using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["AGutierrezControlEscolar"].ConnectionString.ToString();
            //string str= System.Configuration.ConfigurationManager.AppSettings["WebApi"];
            //return str;

        }
    }
}
