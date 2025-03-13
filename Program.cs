using System;

public class cardHolder
{
    //define the basic properties of a bank user
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;
    //initalise constructor and pass parameters into it

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        //instantiated as new objects
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string CardNum { get; set; }

    public int Pin { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public double Balance { get; set; }

    public static void Main(string[] args)
    {
        //defining functions
        void printOptions() //gives user a set of options once they have sucessfully logged in
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit? ");
            double depositAmount = Double.Parse(Console.ReadLine());
            currentUser.balance += depositAmount;
            Console.WriteLine("Thank you. Your new balance is now: " + currentUser.balance);
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw? ");
            double withdrawAmount = Double.Parse(Console.ReadLine());
            //need logic to prevent them from withdrawing > balance amount
            if (withdrawAmount > currentUser.balance)
            {
                Console.WriteLine("Insufficient funds. Please try again.");
            }
            else
            {
                currentUser.balance -= withdrawAmount;
                Console.WriteLine("Thank you. " + withdrawAmount + " Has been withdrawn from your account. Your new balance is now: " + currentUser.balance);
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Your current balance is: " + currentUser.balance);
        }

        //mock database list
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532768923456789", 1234, "John", "Doe", 1500.75));
        cardHolders.Add(new cardHolder("5263987645123456", 5678, "Alice", "Smith", 2200.50));
        cardHolders.Add(new cardHolder("6011897654321234", 9101, "Michael", "Brown", 3050.00));
        cardHolders.Add(new cardHolder("376012345678901", 2345, "Emily", "Davis", 500.25));
        cardHolders.Add(new cardHolder("4532789765432109", 6789, "David", "Wilson", 1800.90));
        cardHolders.Add(new cardHolder("5263912345678901", 3456, "Sophia", "Martinez", 2750.10));
        cardHolders.Add(new cardHolder("6011123456789012", 7890, "James", "Anderson", 950.45));

        //Prompt user
        Console.WriteLine("Welcome to Esmond's ATM!");
        Console.WriteLine("Please enter a valid debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;
        //user validation loop to stop app crashing

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against mock db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognised. Please try again."); }
            }
            catch { Console.WriteLine("Card not recognised. Please try again."); }
        }
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.pin == userPin)
                {
                    Console.WriteLine("Welcome " + currentUser.firstName);
                    break;
                }
                else
                {
                    Console.WriteLine("Pin not recognised. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Pin not recognised. Please try again.");
            }
        }
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                option = 0;
            }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { Console.WriteLine("Invalid option. Please try again."); }
        }
        while (option != 4);
        Console.WriteLine("You are now exiting. Thank you for using Esmond's ATM!");
    }

}