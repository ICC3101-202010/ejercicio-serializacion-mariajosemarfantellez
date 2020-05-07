using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ejercicio_Serializacion
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> personas = new List<Person>();
            Person p = new Person("", "", 0);
            bool mj = true;
            while (mj)
            {
                Console.WriteLine("\nSi desea crear una persona presione a\n");
                Console.WriteLine("\nSi desea ver la lista de personas presione b\n");
                Console.WriteLine("\nSi desea guardar el archivo presione c\n");
                Console.WriteLine("\nSi desea cargar el archivo presione d\n");
                Console.WriteLine("\nSi desea salir presione e\n");
                string respuesta = Console.ReadLine();

                if (respuesta.ToLower() == "a")
                {
                    Console.WriteLine("Diga el nombre\n");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Diga el apellido\n");
                    string apellido = Console.ReadLine();
                    Console.WriteLine("Diga la edad\n");
                    string Edad = Console.ReadLine();
                    int edad = Convert.ToInt32(Edad);
                    Person p1 = new Person(nombre, apellido, edad);
                    personas.Add(p1);
                }
                if (respuesta.ToLower() == "b")
                {
                    foreach(Person x in personas)
                    {
                        Console.WriteLine(x.Name);
                        Console.WriteLine(x.LastName);
                        Console.WriteLine(x.Age);
                    }
                }
                if (respuesta.ToLower() == "c")
                {
                    Person obj = new Person();
                    obj.Name = "Maria";
                    obj.LastName = "Marfan";
                    obj.Age = 21;

                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                    foreach (Person i in personas)
                    {
                        formatter.Serialize(stream, i);
                    }
                    stream.Close();

                }
                if (respuesta.ToLower() == "d")
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                    Person obj = (Person)formatter.Deserialize(stream);
                    stream.Close();
                    foreach(Person i in personas)
                    {
                        Console.WriteLine(obj.Name);
                        Console.WriteLine(obj.LastName);
                        Console.WriteLine(obj.Age);
                    }

                }
                if (respuesta.ToLower() == "e")
                {
                    mj = false;
                }


            }
        }
    }
}
