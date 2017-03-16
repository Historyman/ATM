using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    public class CashDrawer
    {
        public int Total
        {
            get
            {
                return _contents.Sum(c => c.Quantity * c.Value);

            }
        }
        private List<Denomination> _contents { get; set; }

        /// <summary>
        /// Restocks the machine with the default starting amount
        /// </summary>
        public void Restock()
        {
            _contents = new List<Denomination>();
            _contents.Add(new Denomination(100, 10));
            _contents.Add(new Denomination(50, 10));
            _contents.Add(new Denomination(20, 10));
            _contents.Add(new Denomination(10, 10));
            _contents.Add(new Denomination(5, 10));
            _contents.Add(new Denomination(1, 10));

        }

        public (bool success, int amount, List<Denomination> contents) Withdraw(int amount)
        {
            //Clone the contents of the drawer to revert changes in case the operation fails
            List<Denomination> newDrawer = _contents.Select(d => new Denomination(d.Value, d.Quantity)).ToList();

            //Go through each denomination to withdraw in the most efficient way possible
            int amountCheck = amount;
            foreach (Denomination d in newDrawer)
            {
                //If we can take from this value, do it
                while (amountCheck >= d.Value && d.Quantity > 0)
                {
                    //Remove bill
                    amountCheck -= d.Value;
                    d.Quantity -= 1;
                }
            }

            //Check if operation completed (amountCheck == 0)
            if (amountCheck == 0)
            {
                //replace drawer with new drawer after all transactions succeeded
                _contents = newDrawer;

                //Return result back to main
                return (true, amount, _contents);
            } else
            {
                return (false, 0, _contents);
            }


        }

        /// <summary>
        /// Returns the number of bills of the requested denomination. Returns -1 if not found
        /// </summary>
        /// <param name="denominationName">Name of Denomination eg "$100"</param>
        /// <returns></returns>
        public int GetDenominationCount(string denominationName)
        {
            return _contents.SingleOrDefault(c => c.BillName == denominationName)?.Quantity ?? -1;
        }

        /// <summary>
        /// Writes the Drawer's Contents to the Console
        /// </summary>
        public void DisplayDrawer()
        {
            Console.WriteLine($"Machine Balance: ${Total}");
            foreach (Denomination d in _contents)
            {
                Console.WriteLine($"${d.Value} - {d.Quantity} Bills");
            }
            //Space Row
            Console.WriteLine();
        }

        /// <summary>
        /// Default Constructor.  Calls Restock to set up initial amounts
        /// </summary>
        public CashDrawer()
        {
            Restock();
        }
    }
}