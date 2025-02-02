using System;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

namespace SerializationDemo
{
    public class Person
    {
        public string UserName { get; set; }
        public int UserAge { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Person person = new Person
            {
                UserName = "JohnDoe",
                UserAge = 30
            };

            Console.WriteLine($"UserName: {person.UserName}, UserAge: {person.UserAge}");

            // Binary Serialization
            using (FileStream fs = new FileStream("person.dat", FileMode.Create))
            {
                //left off here
                BinaryWriter writer = new BinaryWriter(fs);
                writer.Write(person.UserName);
                writer.Write(person.UserAge);
            }

            Console.WriteLine("Binary serialization complete.");

            // XML Serialization
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            using (FileStream fs = new FileStream("person.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, person);
            }

            Console.WriteLine("XML serialization complete.");

            // JSON Serialization
            string jsonString = JsonSerializer.Serialize(person);

            File.WriteAllText("person.json", jsonString);

            Console.WriteLine("JSON serialization complete.");
        }
    }
}
