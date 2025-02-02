using System;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create variables for books
            string[] books = new string[5];

            // Loop indefinitely
            while (true)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Remove a book");
                Console.WriteLine("3. Display books");
                Console.WriteLine("4. Exit");

                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        AddBook(books);
                        break;
                    case "2":
                        RemoveBook(books);
                        break;
                    case "3":
                        DisplayBooks(books);
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please choose 1, 2, 3, or 4.");
                        break;
                }
            }
        }

        static void AddBook(string[] books)
        {
            Console.Write("Enter the title of the book to add: ");
            string newBook = Console.ReadLine();
            bool added = false;

            for (int i = 0; i < books.Length; i++)
            {
                if (string.IsNullOrEmpty(books[i]))
                {
                    books[i] = newBook;
                    Console.WriteLine($"Book '{newBook}' added.");
                    added = true;
                    break;
                }
            }

            if (!added)
            {
                Console.WriteLine("No more space to add new books.");
            }
        }

        static void RemoveBook(string[] books)
        {
            Console.Write("Enter the title of the book to remove: ");
            string bookToRemove = Console.ReadLine();
            bool removed = false;

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null && books[i].Equals(bookToRemove, StringComparison.OrdinalIgnoreCase))
                {
                    books[i] = null;
                    Console.WriteLine($"Book '{bookToRemove}' removed.");
                    removed = true;
                    break;
                }
            }

            if (!removed)
            {
                Console.WriteLine($"Book '{bookToRemove}' not found.");
            }
        }

        static void DisplayBooks(string[] books)
        {
            Console.WriteLine("Books in the library:");

            foreach (var book in books)
            {
                if (!string.IsNullOrEmpty(book))
                {
                    Console.WriteLine(book);
                }
            }
        }
    }
}
