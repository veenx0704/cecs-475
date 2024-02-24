using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Collections;

namespace Stock
{
    public class StockBroker
    {
        public string BrokerName { get; set; }
        public List<Stock> stocks = new List<Stock>();
        public static ReaderWriterLockSlim myLock = new ReaderWriterLockSlim();
        
        readonly string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lab1_output.txt");
        
        public string titles = "Broker".PadRight(10) + "Stock".PadRight(15) + "Value".PadRight(10) + "Changes".PadRight(10) + "Date and Time";


        public StockBroker(string brokerName)
        {
            BrokerName = brokerName;
        }
        
        public void AddStock(Stock stock)
        {
            stocks.Add(stock);
            stock.StockEvent += EventHandler;
        }
        

        void EventHandler(Object sender, EventArgs e)
        {
            try
            { //LOCK Mechanism
                myLock.EnterWriteLock();
                Stock newStock = (Stock)sender;

                DateTime date1 = DateTime.Now;
                
                Console.WriteLine(BrokerName.PadRight(16) + newStock.StockName.PadRight(16) + newStock.CurrentValue.ToString().PadRight(16) + newStock.NumChanges.ToString().PadRight(16) + date1.ToString());

                //Display the output to the file
                using (StreamWriter outputFile = File.AppendText(destPath))
                {
                    outputFile.WriteLine(BrokerName.PadRight(16) + newStock.StockName.PadRight(16) + newStock.CurrentValue.ToString().PadRight(16) + newStock.NumChanges.ToString().PadRight(16) + date1.ToString().PadRight(10));
                }
                //RELEASE the lock
                myLock.ExitWriteLock();
            }
            finally
            { 
            }
        }
    }
}
