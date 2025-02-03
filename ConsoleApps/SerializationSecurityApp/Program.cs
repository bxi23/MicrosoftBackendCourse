using System;


namespace SerializationSercurityApp
{
    class Program
    {
        static void Main(string[] args)
        {

            User newUser = new User
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "password123"
            };

            string userHash = newUser.GenerateHash();
            string serializedData = SerializeUserData(newUser);
            User deserializedUser = DeserializeUserData(serializedData, true);
            Console.WriteLine($"SErialized Data: User hash: {userHash}");

        }

        static string SerializeUserData(User user)
        {
            if (
                string.IsNullOrWhiteSpace(user.Name) 
                || string.IsNullOrWhiteSpace(user.Email) 
                || string.IsNullOrWhiteSpace(user.Password))
            {
            Console.WriteLine("Invalid data. Serialization aborted.");
            return string.Empty;
            }

            user.EncryptData();
            return System.Text.Json.JsonSerializer.Serialize(user);
        }

        static User DeserializeUserData(string jsonData, bool isTrustedSource)
        {
            if (!isTrustedSource)
            {
            Console.WriteLine("Deserialization blocked: Untrusted source");
            return null;
            }

            return System.Text.Json.JsonSerializer.Deserialize<User>(jsonData);
        }
    }
}