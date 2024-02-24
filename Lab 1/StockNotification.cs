using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Collections;

namespace Stock
{
    public class StockNotification : EventArgs
    {
        public string StockName { get; set; }
        public int CurrentValue { get; set; }
        public int NumChanges { get; set; }

        /// <summary>
        /// Stock notification attributes that are set and changed
        /// </summary>
        /// <param name="stockName">Name of stock</param>
        /// <param name="currentValue">Current value of the stock</param>
        /// <param name="numChanges">Number of changes the stock goes through</param>
        public StockNotification(string stockName, int currentValue, int numChanges)
        {
            // !NOTE!: Fill in below of what the notification will do using the comments above
            this.StockName = stockName;
            this.CurrentValue = currentValue;
            this.NumChanges = numChanges;

            // You should add logic here to describe what the notification will do
            // For example:
            // Console.WriteLine($"Stock {stockName} has reached a value of {currentValue} after {numChanges} changes.");
            // Or you can trigger some other action like updating a database, sending an email, etc.
        }
    }
}
