using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load initial data
            ATM atm = new ATM();

            //Weclome Message
            Console.WriteLine("Welcome to Command Line ATM");
            Console.WriteLine("////////////////////////////");
            Console.WriteLine("");
            DisplayCommands();


            //Display Current Cash Register
            atm.DisplayContents();

            //Enter Command
            string command = String.Empty;
            while (command != "Q")
            {
                Console.WriteLine("Please Enter a Command");
                string[] response = Console.ReadLine().ToUpper().Split(' ');
                command = response[0];

                switch (command)
                {

                    case "R": //Restock
                        atm.Restock();
                        Console.WriteLine("ATM Restocked");
                        atm.DisplayContents();
                        break;

                    case "W": //Withdraw
                        //convert amount string to int, break if doesnt work
                        int withdrawAmount;
                        try
                        {
                            withdrawAmount = Convert.ToInt32(response[1].Split('$')[1]);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid $ Amount, make sure you ncluded '$'");
                            break;
                        }

                        //Prevent Overdrafting
                        if (withdrawAmount > atm.Total)
                        {
                            Console.WriteLine($"Withdrawl amount is more than machine total, please enter an amount smaller than ${atm.Total}");
                            break;
                        }

                        //Attempt Withdrawl
                        var result = atm.Withdraw(withdrawAmount);
                        if (result.success)
                        {
                            Console.WriteLine($"Success: Dispensed ${result.amount}");
                            atm.DisplayContents();
                        }
                        else
                        {
                            Console.WriteLine($"Insufficient Funds to complete this request. Please request a new amount");
                        }

                        break;

                    case "I": //Display Denominations
                        for (int i = 1; i < command.Length; i++)
                        {
                            //Use parsed string to find the denomination in the drawer
                            string denominationName = response[i];
                            int count = atm.GetDenominationCount(denominationName);

                            //If Denomination is not found, alert user
                            if (count == -1)
                            {
                                Console.WriteLine($"Denomination {denominationName} was not found. Did you remember to Include '$'?");
                            }
                            else // Write denomination to the console
                            {
                                Console.WriteLine($"{denominationName} - {count} Bills");
                            }
                        }
                        break;

                    case "Q": //Quit
                        Console.WriteLine("Thanks for using the ATM");
                        System.Threading.Thread.Sleep(2000);
                        break;

                    case "H": //Command list (Help)
                        DisplayCommands();
                        break;

                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }

            }
        }

        /// <summary>
        /// Writes list of commands to the Console
        /// </summary>
        static void DisplayCommands()
        {
            Console.WriteLine("Available Commands:");
            Console.WriteLine("R - Restocks Cash Machine to pre-stock levels");
            Console.WriteLine("W [Amount]  - Withdraws Cash Amount");
            Console.WriteLine("I [Space Separated List of Denominations] - Displays the current count of bills in for each requested denomination");
            Console.WriteLine("Q - Quit");
            Console.WriteLine("H - Display command list");
            Console.WriteLine();
        }
    }
}