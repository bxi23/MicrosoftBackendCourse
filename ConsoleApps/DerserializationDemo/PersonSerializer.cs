using System.Text.Json;
using System.Xml.Serialization;
using System.IO;

namespace DerserializationDemo
{
    public class PersonSerializer
    {
        public class Person
        {
            public string UserName { get; set; }
            public int UserAge { get; set; }
        }

        public static void SerializePersonToFile(Person person, string fileName)
        {
            // Open a FileStream to create or open the file
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                // Create a BinaryWriter object using the FileStream
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    // Write the Person object's properties to the BinaryWriter
                    writer.Write(person.UserName);
                    writer.Write(person.UserAge);
                }
            }
        }

        public static void SerializePersonToXml(Person person, string fileName)
        {
            // Create an XmlSerializer for the Person type
            XmlSerializer serializer = new XmlSerializer(typeof(Person));

            // Open a FileStream to create or open the file
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                // Serialize the Person object to XML and write it to the file
                serializer.Serialize(fs, person);
            }
        }

        public static void SerializePersonToJson(Person person, string fileName)
        {
            // Serialize the Person object to JSON
            string jsonString = JsonSerializer.Serialize(person);

            // Write the JSON string to the file
            File.WriteAllText(fileName, jsonString);
        }

        public static void SerializePerson(Person person)
        {
            SerializePersonToFile(person, "person.dat");
            SerializePersonToXml(person, "person.xml");
            SerializePersonToJson(person, "person.json");
        }
    }
}