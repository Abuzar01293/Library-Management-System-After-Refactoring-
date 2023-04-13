using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool Availability { get; set; }

    public Book(string title, string author, string isbn, bool availability)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Availability = availability;
    }
}

class Member
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public List<Book> BooksBorrowed { get; set; }

    public Member(string name, string address, string phone)
    {
        Name = name;
        Address = address;
        Phone = phone;
        BooksBorrowed = new List<Book>();
    }

    public void BorrowBook(Book book)
    {
        if (book.Availability)
        {
            book.Availability = false;
            BooksBorrowed.Add(book);
            Console.WriteLine($"Book '{book.Title}' is borrowed by {Name}.");
        }
        else
        {
            Console.WriteLine($"Book '{book.Title}' is not available for borrowing.");
        }
    }

    public void ReturnBook(Book book)
    {
        if (BooksBorrowed.Contains(book))
        {
            book.Availability = true;
            BooksBorrowed.Remove(book);
            Console.WriteLine($"Book '{book.Title}' is returned by {Name}.");
        }
        else
        {
            Console.WriteLine($"Book '{book.Title}' is not borrowed by {Name}.");
        }
    }
}

class Library
{
    private List<Book> books;
    private List<Member> members;

    public Library()
    {
        books = new List<Book>();
        members = new List<Member>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Book '{book.Title}' is added to the library.");
    }

    public void RemoveBook(Book book)
    {
        if (books.Contains(book))
        {
            books.Remove(book);
            Console.WriteLine($"Book '{book.Title}' is removed from the library.");
        }
        else
        {
            Console.WriteLine($"Book '{book.Title}' is not found in the library.");
        }
    }

    public List<Book> SearchBook(string title)
    {
        List<Book> foundBooks = new List<Book>();

        foreach (var book in books)
        {
            if (book.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            {
                foundBooks.Add(book);
            }
        }

        return foundBooks;
    }

    public void AddMember(Member member)
    {
        members.Add(member);
        Console.WriteLine($"Member '{member.Name}' is added to the library.");
    }

    public void RemoveMember(Member member)
    {
        if (members.Contains(member))
        {
            members.Remove(member);
            Console.WriteLine($"Member '{member.Name}' is removed from the library.");
        }
        else
        {
            Console.WriteLine($"Member '{member.Name}' is not found in the library.");
        }
    }

    public List<Member> SearchMember(string name)
    {
        List<Member> foundMembers = new List<Member>();

        foreach (var member in members)
        {
            if (member.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            {
                foundMembers.Add(member);
            }
        }

        return foundMembers;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create library
        Library library = new Library();

        // Create books
        Book book1 = new Book("Book 1
