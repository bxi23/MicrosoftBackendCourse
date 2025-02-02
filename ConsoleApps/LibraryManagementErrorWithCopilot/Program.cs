using System;
using System.Collections.Generic;

class LibraryManager
{
    static Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();
    static Dictionary<string, bool> checkedOutBooks = new Dictionary<string, bool>();

    static void Main()
    {
        // Initialize an array to store books
        string[] books = new string[5];

        while (true)
        {
            DisplayBooks(books);
            DisplayUsers();

            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Remove a book");
            Console.WriteLine("3. Search for a book");
            Console.WriteLine("4. Create a user");
            Console.WriteLine("5. Check out a book");
            Console.WriteLine("6. Check in a book");
            Console.WriteLine("7. Exit");

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
                    SearchBook(books);
                    break;
                case "4":
                    CreateUser();
                    break;
                case "5":
                    CheckOutBook(books);
                    break;
                case "6":
                    CheckInBook(books);
                    break;
                case "7":
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid input. Please choose a number between 1 and 7.");
                    break;
            }
        }
    }

    // Method to display books in the library
    static void DisplayBooks(string[] books)
    {
        Console.WriteLine("\nBooks in the library:");
        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrEmpty(books[i]))
            {
                Console.WriteLine($"- {books[i]} (Checked out: {checkedOutBooks[books[i]]})");
            }
        }
    }

    // Method to display users
    static void DisplayUsers()
    {
        Console.WriteLine("\nUsers:");
        foreach (var user in users)
        {
            Console.WriteLine($"- {user.Key} (Borrowed books: {string.Join(", ", user.Value)})");
        }
    }

    // Method to add a book to the library
    static void AddBook(string[] books)
    {
        if (Array.Exists(books, book => string.IsNullOrEmpty(book)))
        {
            Console.WriteLine("Enter the title of the book to add:");
            string newBook = Console.ReadLine();

            for (int i = 0; i < books.Length; i++)
            {
                if (string.IsNullOrEmpty(books[i]))
                {
                    books[i] = newBook;
                    checkedOutBooks[newBook] = false;
                    Console.WriteLine($"Book '{newBook}' added.");
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("The library is full. No more books can be added.");
        }
    }

    // Method to remove a book from the library
    static void RemoveBook(string[] books)
    {
        Console.WriteLine("Enter the title of the book to remove:");
        string bookToRemove = Console.ReadLine();
        bool removed = false;

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] != null && books[i].Equals(bookToRemove, StringComparison.OrdinalIgnoreCase))
            {
                books[i] = null;
                checkedOutBooks.Remove(bookToRemove);
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

    // Method to search for a book in the library
    static void SearchBook(string[] books)
    {
        Console.WriteLine("Enter the title of the book to search:");
        string bookToSearch = Console.ReadLine();
        bool found = false;

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] != null && books[i].Equals(bookToSearch, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Book '{bookToSearch}' is available in the library.");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Book not found in the library.");
        }
    }

    // Method to create a user
    static void CreateUser()
    {
        Console.WriteLine("Enter the name of the user:");
        string userName = Console.ReadLine();

        if (!users.ContainsKey(userName))
        {
            users[userName] = new List<string>();
            Console.WriteLine($"User '{userName}' created.");
        }
        else
        {
            Console.WriteLine("User already exists.");
        }
    }

    // Method to check out a book to a user
    static void CheckOutBook(string[] books)
    {
        Console.WriteLine("Enter the name of the user:");
        string userName = Console.ReadLine();

        if (!users.ContainsKey(userName))
        {
            Console.WriteLine("User does not exist.");
            return;
        }

        if (users[userName].Count >= 3)
        {
            Console.WriteLine("User has already borrowed 3 books.");
            return;
        }

        Console.WriteLine("Enter the title of the book to check out:");
        string bookToCheckOut = Console.ReadLine();
        bool found = false;

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] != null && books[i].Equals(bookToCheckOut, StringComparison.OrdinalIgnoreCase))
            {
                if (checkedOutBooks[bookToCheckOut])
                {
                    Console.WriteLine("Book is already checked out.");
                }
                else
                {
                    users[userName].Add(bookToCheckOut);
                    checkedOutBooks[bookToCheckOut] = true;
                    Console.WriteLine($"Book '{bookToCheckOut}' checked out to '{userName}'.");
                }
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Book not found in the library.");
        }
    }

    // Method to check in a borrowed book
    static void CheckInBook(string[] books)
    {
        Console.WriteLine("Enter the name of the user:");
        string userName = Console.ReadLine();

        if (!users.ContainsKey(userName))
        {
            Console.WriteLine("User does not exist.");
            return;
        }

        Console.WriteLine("Enter the title of the book to check in:");
        string bookToCheckIn = Console.ReadLine();

        if (users[userName].Contains(bookToCheckIn))
        {
            users[userName].Remove(bookToCheckIn);
            checkedOutBooks[bookToCheckIn] = false;
            Console.WriteLine($"Book '{bookToCheckIn}' checked in from '{userName}'.");
        }
        else
        {
            Console.WriteLine("Book not found in user's borrowed list.");
        }
    }
}