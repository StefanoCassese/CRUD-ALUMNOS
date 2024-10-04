using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeAlumnos
{
    public class BDAlumnosGeneral
    {
        public static SqlConnection Obtenerconexion()
        { 
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-DBLOM0R\\SQLEXPRESS;Initial Catalog=DBAlumnos;Persist Security Info=True;User ID=sa;Password=libertador1252");
            
            conexion.Open();

            return conexion;
        }
    }


}
