using System;
using Newtonsoft.Json;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string jsonString = "{\"Name\":\"John Doe\",\"Age\":30}";
        
        Person person = JsonConvert.DeserializeObject<Person>(jsonString);
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

        Person newPerson = new Person { Name = "Jane Smith", Age = 25 };
        string newJsonString = JsonConvert.SerializeObject(newPerson);
        Console.WriteLine($"Serialized JSON: {newJsonString}");
    }
}