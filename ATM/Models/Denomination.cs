namespace ATM
{
    public class Denomination
    {
        public string BillName
        {
            get
            {
                return Value.ToString("$0");
            }
        }
        public int Value { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// Creates a Denomination Category in the Cash Drawer
        /// </summary>
        /// <param name="billType">Bill Value</param>
        /// <param name="quantity">NUmber of Bills</param>
        public Denomination(int billType, int quantity)
        {
            Value = billType;
            Quantity = quantity;
        }
    }
}