using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;


namespace DerserializationDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create a Person object with sample data
            PersonSerializer.Person person = new PersonSerializer.Person { UserName = "JohnDoe", UserAge = 30 };

            // Call the function to serialize the Person object to all formats
            PersonSerializer.SerializePerson(person);

            Console.WriteLine("Person object has been serialized to person.dat, person.xml, and person.json");

            // Deserialize Files

           // ============================
            // Binary Deserialization
            // ============================

            // 1. Start Binary Deserialization
            // 2. Create an instance of Stopwatch to measure deserialization time
            Stopwatch stopwatch = new Stopwatch();
            // 3. Start the Stopwatch
            stopwatch.Start();
            // 4. Open a FileStream to read the file named person.dat
            using (var fs = new FileStream("person.dat", FileMode.Open))
            // 5. Create a BinaryReader object using the FileStream
            using (var reader = new BinaryReader(fs))
            {
                // 6. Read the Person object's properties from the BinaryReader
                var deserializedPerson = new PersonSerializer.Person
                {
                    UserName = reader.ReadString(), // a. Read the UserName property
                    UserAge = reader.ReadInt32()    // b. Read the UserAge property
                };
                // 7. Stop the Stopwatch
                stopwatch.Stop();
                // 8. Print the deserialized Person object's properties (UserName and UserAge)
                Console.WriteLine($"Binary Deserialization: UserName: {deserializedPerson.UserName}, UserAge: {deserializedPerson.UserAge}");
                // 9. Print the time taken for Binary Deserialization
                Console.WriteLine($"Binary Deserialization Time: {stopwatch.ElapsedMilliseconds} ms");

                // Verify that properties are not null
                if (deserializedPerson.UserName == null || deserializedPerson.UserAge == 0)
                {
                    Console.WriteLine("Error: Deserialized binary data contains null or default values.");
                }
            }

            // ============================
            // XML Deserialization
            // ============================

            // 1. Start XML Deserialization
            // 2. Create an instance of Stopwatch to measure deserialization time
            Stopwatch stopwatch1 = new Stopwatch();
            // 3. Start the Stopwatch
            stopwatch1.Start();
            // 4. Open a FileStream to read the file named person.xml
            string xmlContent;
            using (var fs = new FileStream("person.xml", FileMode.Open))
            using (var reader = new StreamReader(fs))
            {
                xmlContent = reader.ReadToEnd();
            }
            // 5. Create an XmlSerializer for the Person type
            var serializer = new XmlSerializer(typeof(PersonSerializer.Person));
            // 6. Use StringReader to deserialize the XML data
            using (var stringReader = new StringReader(xmlContent))
            {
                var deserializedPerson = (PersonSerializer.Person)serializer.Deserialize(stringReader);
                // 7. Stop the Stopwatch
                stopwatch1.Stop();
                // 8. Print the deserialized Person object's properties (UserName and UserAge)
                Console.WriteLine($"XML Deserialization: UserName: {deserializedPerson.UserName}, UserAge: {deserializedPerson.UserAge}");
            }
            // 9. Print the time taken for XML Deserialization
            Console.WriteLine($"XML Deserialization Time: {stopwatch1.ElapsedMilliseconds} ms");

            //=======================================================================================================
            // JSON Deserialization
            //=======================================================================================================

            // 1. Start JSON Deserialization
            // 2. Create an instance of Stopwatch to measure deserialization time
            Stopwatch stopwatch2 = new Stopwatch();
            // 3. Start the Stopwatch
            stopwatch2.Start();
            // 4. Read the JSON data from the file named person.json
            string jsonContent = File.ReadAllText("person.json");
            // 5. Deserialize the JSON data to a Person object
            var deserializedPerson1 = JsonSerializer.Deserialize<PersonSerializer.Person>(jsonContent);
            // 6. Stop the Stopwatch
            stopwatch2.Stop();
            // 7. Print the deserialized Person object's properties (UserName and UserAge)
            Console.WriteLine($"JSON Deserialization: UserName: {deserializedPerson1.UserName}, UserAge: {deserializedPerson1.UserAge}");
            // Ensure rquired properties are not left as null
            

            // 8. Print the time taken for JSON Deserialization
            Console.WriteLine($"JSON Deserialization Time: {stopwatch2.ElapsedMilliseconds} ms");

            
        }
    }
}