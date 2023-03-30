using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the social network!");

        List<User> users = new List<User>();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create new user");
            Console.WriteLine("2. View user profile");
            Console.WriteLine("3. Send message");
            Console.WriteLine("4. Exit");

            Console.Write("\nEnter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateUser(users);
                    break;
                case 2:
                    ViewProfile(users);
                    break;
                case 3:
                    SendMessage(users);
                    break;
                case 4:
                    Console.WriteLine("\nExiting social network...");
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateUser(List<User> users)
    {
        Console.Write("\nEnter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter your email address: ");
        string email = Console.ReadLine();

        User newUser = new User(name, age, email);
        users.Add(newUser);

        Console.WriteLine("\nUser created successfully!");
    }

    static void ViewProfile(List<User> users)
    {
        Console.Write("\nEnter the name of the user: ");
        string name = Console.ReadLine();

        User user = users.Find(u => u.Name == name);

        if (user == null)
        {
            Console.WriteLine("\nUser not found. Please try again.");
            return;
        }

        Console.WriteLine("\nUser profile:");
        Console.WriteLine("Name: " + user.Name);
        Console.WriteLine("Age: " + user.Age);
        Console.WriteLine("Email: " + user.Email);
    }

    static void SendMessage(List<User> users)
    {
        Console.Write("\nEnter your name: ");
        string name = Console.ReadLine();

        User sender = users.Find(u => u.Name == name);

        if (sender == null)
        {
            Console.WriteLine("\nUser not found. Please try again.");
            return;
        }

        Console.Write("Enter the recipient's name: ");
        string recipientName = Console.ReadLine();

        User recipient = users.Find(u => u.Name == recipientName);

        if (recipient == null)
        {
            Console.WriteLine("\nRecipient not found. Please try again.");
            return;
        }

        Console.Write("Enter the message: ");
        string message = Console.ReadLine();

        Message newMessage = new Message(sender, recipient, message);
        recipient.Inbox.Add(newMessage);

        Console.WriteLine("\nMessage sent successfully!");
    }
}

class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public List<Message> Inbox { get; set; }

    public User(string name, int age, string email)
    {
        Name = name;
        Age = age;
        Email = email;
        Inbox = new List<Message>();
    }
}

class Message
{
    public User Sender { get; set; }
    public User Recipient { get; set; }
    public string Text { get; set; }

    public Message(User sender, User recipient, string text)
    {
        Sender = sender;
        Recipient = recipient;
        Text = text;
    }
}
