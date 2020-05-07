using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ejercicio_Serializacion
{
    [Serializable]
    public class Person
    {
        private string name;
        private string lastName;
        private int age;
        public Person(string name, string lastName, int age)
        {
            this.name = name;
            this.lastName = lastName;
            this.age = age;
        }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set =>  lastName = value; }
        public int Age { get => age; set => age = value; }
        public Person() { }

    }
}
