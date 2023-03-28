using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceAlumno" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceAlumno
    {

        [OperationContract]
        ML.Result Add(ML.Alumno alumno);


        [OperationContract]
        ML.Result Update(ML.Alumno alumno);


        [OperationContract]
        ML.Result Delete(ML.Alumno alumno);


        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        ML.Result GetById(int IdAlumno);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        ML.Result GetAll();
    }
}
