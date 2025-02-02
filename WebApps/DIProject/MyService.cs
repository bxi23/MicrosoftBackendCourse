using System;

namespace DIProject
{
    public class MyService : IMyService
    {
        private readonly int _serviceID;

        public MyService()
        {
            _serviceID = new Random().Next(10000,99999);
        }

        public void LogCreation(string message)
        {
            Console.WriteLine($"{message} - Service ID: {_serviceID}");
        }
    }
}