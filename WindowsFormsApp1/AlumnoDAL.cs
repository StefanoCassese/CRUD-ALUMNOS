using RegistroDeAlumnos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class AlumnoDAL
    {
        public static int AgregarAlumno(Alumno alumno) 
        {
            int retorna = 0;

            using (SqlConnection conexion = BDAlumnosGeneral.Obtenerconexion())
            {
                string query = "insert into dbo.Alumno (nombre,edad,curso,direccion) values('"+alumno.nombre+"' , "+alumno.edad+ " , '"+alumno.curso+ "' , '"+alumno.direccion+"')";
                SqlCommand comando = new SqlCommand(query,conexion);

                retorna=comando.ExecuteNonQuery();
            
            }
            return retorna;
        }

        public static List<Alumno> PresentarRegistro() 
        {
          List<Alumno> lista = new List<Alumno>();

            using (SqlConnection conexion = BDAlumnosGeneral.Obtenerconexion())
            {
                string query = "select * from dbo.Alumno";
                SqlCommand comando = new SqlCommand(query,conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read()) 
                {
                    Alumno alumno = new Alumno();
                    alumno.id = reader.GetInt32(0);
                    alumno.nombre = reader.GetString(1);
                    alumno.edad= reader.GetInt32(2);
                    alumno.curso= reader.GetString(3);
                    alumno.direccion= reader.GetString(4);
                    lista.Add(alumno);
                }
                conexion.Close();
                return lista; 

            }

        }

        public static int ModificarAlumno(Alumno alumno)
        {
            int result = 0;
            using (SqlConnection conexion = BDAlumnosGeneral.Obtenerconexion())
            {
                string query = "update alumno set nombre='"+alumno.nombre+"' , edad= "+alumno.edad+ " , curso='"+alumno.curso+ "' , direccion='"+alumno.direccion+"' where id = "+alumno.id+"  ";
                SqlCommand comando = new SqlCommand( query,conexion);


                result = comando.ExecuteNonQuery();
               
            }
            return result;

        }

        public static int EliminarAlumno(int id)
        {
            int retorna = 0;

            using (SqlConnection conexion = BDAlumnosGeneral.Obtenerconexion())
            {
                string query = "Delete from Alumno  where id = " + id +" ";
                SqlCommand comando = new SqlCommand(query, conexion);

                retorna = comando.ExecuteNonQuery();

            }
            return retorna;
        }

    }
}
