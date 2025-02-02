using Microsoft.AspNetCore.Mvc;

namespace LoggingLab.Controllers
{
    public class ErrorHandlingController : ControllerBase
    {
        // Controller actions go here

        [HttpGet("division")]
        public int GetDivisionResult(int numerator, int denominator)
        {
            try{
                return numerator / denominator;
            }
            catch (System.DivideByZeroException ex)
            {
                // Log the exception
                Console.WriteLine($"Error: Division by zero is not allowed. \n {ex.Message}");
                return 0;
            }
        }
    }
}