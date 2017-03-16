using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load initial data
            CashDrawer drawer = new CashDrawer();

            //Weclome Message
            Console.WriteLine("Welcome to Command Line ATM");
            Console.WriteLine("Available Commands:");
            Console.WriteLine("R - Restocks Cash Machine to pre-stock levels");
            Console.WriteLine("W [Amount]  - Withdraws Cash Amount");
            Console.WriteLine("I [Denomination] - Displays the number of bills in that denomination present in the cash machine");
            Console.WriteLine("Q - Quit");
            Console.WriteLine();

            //Display Current Cash Register
            drawer.DisplayDrawer();

            //Enter Command
            string response = String.Empty;
            while (response != "Q")
            {
                Console.WriteLine("Please Enter a Command");
                string[] command = Console.ReadLine().ToUpper().Split(' ');

                switch (command[0])
                {
                    
                    case "R": //Restock
                        drawer.Restock();
                        drawer.DisplayDrawer();
                        break;
                    
                    case "W": //Withdraw
                        //convert amount string to int, break if doesnt work
                        int withdrawAmount;
                        try
                        {
                            withdrawAmount = Convert.ToInt32(command[1].Split('$')[1]);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid $ Amount, make sure you Included '$'");
                            break;
                        }

                        //Prevent Overdrafting
                        if (withdrawAmount > drawer.Total)
                        {
                            Console.WriteLine($"Withdrawl amount is more that drawer Total, please enter an amount smaller than {drawer.Total}");
                            break;
                        }

                        //Attempt Withdrawl
                        var result = drawer.Withdraw(withdrawAmount);
                        if (result.success)
                        {
                            Console.WriteLine($"Success: Dispensed ${result.amount}");
                            drawer.DisplayDrawer();
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
                            string denominationName = command[i];
                            int count = drawer.GetDenominationCount(denominationName);

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
                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }

            }

        }
    }
}