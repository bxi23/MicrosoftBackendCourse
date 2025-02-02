using System;

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

            string action = Console.ReadLine().ToLower();

            switch (action)
            {
                case "1":
                case "add":
                    AddBook(books);
                    break;
                case "2":
                case "remove":
                    RemoveBook(books);
                    break;
                case "3":
                case "display":
                    DisplayBooks(books);
                    break;
                case "4":
                case "exit":
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
            Console.WriteLine("Book not found.");
        }
    }

    static void DisplayBooks(string[] books)
    {
        Console.WriteLine("Books in the library:");
        bool hasBooks = false;

        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrEmpty(books[i]))
            {
                Console.WriteLine($"- {books[i]}");
                hasBooks = true;
            }
        }

        if (!hasBooks)
        {
            Console.WriteLine("No books in the library.");
        }
    }
}