using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDapper
{
    
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String FechaNacimiento { get; set; }
        public String Matricula { get; set; }
        public String Sexo { get; set; }
        public String Email { get; set; }
        
        public byte IdSemestre { get; set; }

        public static Resultado Add(Alumno alumno)
        {
            Resultado resultado = new Resultado();

            try
            {
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    var query = context.Execute($"AlumnoAdd '{alumno.Nombre}', '{alumno.ApellidoPaterno}', '{alumno.ApellidoMaterno}', ' {alumno.FechaNacimiento}', '{alumno.Matricula}', '{alumno.Sexo}', '{alumno.Email}', '{alumno.IdSemestre}'");

                    if(query > 0)
                    {
                        resultado.Mensaje = "Correcto";
                    }
                    else
                    {
                        resultado.Mensaje = "Error";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Mensaje = "Error" + ex;
            }

            return resultado;
        }

        public static Resultado Delete(Alumno alumno)
        {
            Resultado resultado = new Resultado();

            try
            {
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    var query = context.Execute($"AlumnoDelete '{alumno.IdAlumno}'");

                    if (query > 0)
                    {
                        resultado.Mensaje = "Correcto";
                    }
                    else
                    {
                        resultado.Mensaje = "Error";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Mensaje = "Error" + ex;
            }

            return resultado;
        }

        public static Resultado Update(Alumno alumno)
        {
            Resultado resultado = new Resultado();

            try
            {
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    var query = context.Execute($"AlumnoUpdate '{alumno.Email}', '{alumno.Matricula}'");

                    if (query > 0)
                    {
                        resultado.Mensaje = "Correcto";
                    }
                    else
                    {
                        resultado.Mensaje = "Error";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Mensaje = "Error" + ex;
            }

            return resultado;
        }

        public static Resultado GetAll()
        {
            Resultado resultado = new Resultado();

            try
            {
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    var query = context.Query<Alumno>($"AlumnoGetAll");
                    //var query = context.Execute($"AlumnoGetAll");

                    resultado.Objetos = new List<Alumno>();

                    if (query != null)
                    {
                        foreach(var item in query)
                        {
                            resultado.Objetos.Add(item);
                        }
                        resultado.Mensaje = "Correcto";
                    }
                   
                }
            }
            catch (Exception ex)
            {
                resultado.Mensaje = "Error" + ex;
            }

            return resultado;
        }
    }
}
