using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            int option;

            Console.WriteLine("***** Movimientos *****");
            Console.WriteLine("1. Insertar.");
            Console.WriteLine("2. Eliminar.");
            Console.WriteLine("3. Actualizar.");
            Console.WriteLine("4. Vista.");

            Console.Write("Ingrese el numero de opcion: ");
            option = int.Parse(Console.ReadLine());


            switch(option)
            {
                case 1:
                    Add();
                break;
                case 2:
                    Delete();
                break;
                case 3:
                    Update();
                break;
                case 4:
                    GetAll();
                break;
            }
         
        }

        public static void Add()
        {
            Alumno alumno = new Alumno();//instancia

            Console.WriteLine("Ingresar el nombre del alumno");
            //quien.que
            alumno.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresar el Apellido Paterno del alumno");
            //quien.que
            alumno.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingresar el Apellido Materno del alumno");
            //quien.que
            alumno.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingresar La Fecha de Nacimiento del alumno");
            //quien.que
            alumno.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Ingresar La Matricula del alumno");
            //quien.que
            alumno.Matricula = Console.ReadLine();
            Console.WriteLine("Ingresar el sexo del alumno");
            //quien.que
            alumno.Sexo = Console.ReadLine();
            Console.WriteLine("Ingresar el Email del alumno");
            //quien.que
            alumno.Email = Console.ReadLine();

            Console.WriteLine("Ingresar el IdSemestre del alumno");
            //quien.que
            alumno.IdSemestre = byte.Parse(Console.ReadLine());


            Resultado resultado = Alumno.Add(alumno);

            if(resultado.Mensaje == "Correcto")
            {
                Console.WriteLine("Alumno Insertado Con Exito");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ocurrio un error al insertar el alumno");
                Console.ReadKey(); 
            }

        }
        public static void Delete()
        {
            Alumno alumno = new Alumno();//instancia

            Console.WriteLine("Ingresar el Id del alumno");
            //quien.que
            alumno.IdAlumno = int.Parse(Console.ReadLine());

            Resultado resultado = Alumno.Delete(alumno);

            if (resultado.Mensaje == "Correcto")
            {
                Console.WriteLine("Alumno Eliminado Con Exito");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ocurrio un error al eliminar al alumno");
                Console.ReadKey();
            }
        }

        public static void Update()
        {
            Alumno alumno = new Alumno();//instancia

            Console.WriteLine("Ingresar el  Nuevo Email del alumno");
            //quien.que
            alumno.Email = Console.ReadLine();

            Console.WriteLine("Ingresar La matricula del alumno");
            //quien.que
            alumno.Matricula = Console.ReadLine();


            Resultado resultado = Alumno.Update(alumno);

            if (resultado.Mensaje == "Correcto")
            {
                Console.WriteLine("Email Actualizado Con Exito");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ocurrio un error al actualizar el email");
                Console.ReadKey();
            }

        }

        public static void GetAll()
        {
            Resultado resultado = Alumno.GetAll();

            if (resultado.Mensaje == "Correcto")
            {
                List<Alumno> List = resultado.Objetos;
                foreach (var item in List)
                {
                    Console.WriteLine("{IdAlumno}:" + item.IdAlumno + "{Nombre}:" + item.Nombre + "{Apellido Paterno}:" + item.ApellidoPaterno + "{Apellido Materno}:" + item.ApellidoMaterno +
                        "{Fecha Nacimiento}:" + item.FechaNacimiento + "{Matricula}:" + item.Matricula + "{Sexo}:" + item.Sexo + "{Email}:" + item.Email + "{IdSemestre}:" + item.IdSemestre );
                }
                Console.ReadKey();
                //alumno = (resultado)
            }
        }
    }
}
