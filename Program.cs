using System;
using System.Linq;
using System.Collections.Generic;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary of stock ticker symbols and full names
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("ABT", "Abbott Labs");
            stocks.Add("GLD", "Gold Trust");
            stocks.Add("SBUX", "Starbucks");

            //List of tuples representing purchases of stocks
            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();
            purchases.Add((ticker: "GM", shares: 150, price: 23.21));
            purchases.Add((ticker: "GM", shares: 32, price: 17.87));
            purchases.Add((ticker: "CAT", shares: 10, price: 161.09));
            purchases.Add((ticker: "CAT", shares: 5, price: 160.01));
            purchases.Add((ticker: "ABT", shares: 20, price: 58.83));
            purchases.Add((ticker: "ABT", shares: 30, price: 59.90));
            purchases.Add((ticker: "SBUX", shares: 20, price: 59.36));
            purchases.Add((ticker: "SBUX", shares: 150, price: 60.01));

            //Dictionary of total aquisitions 
            Dictionary<string, double> ownership = new Dictionary<string, double>();

            //for each tuple in the purhases list..
            foreach ((string ticker, int shares, double price) t in purchases)
            {
                //variable to hold full name of stock from 'stocks' dictionary.  Retrieved below
                string stock = "";

                //for each kvp in the stocks dictionary...
                foreach (KeyValuePair<string, string> stockKVP in stocks)
                {
                    //if the key from 'stocks' matches the key in the current purchase from 'purchases'
                    if (stockKVP.Key.Equals(t.ticker))
                    {
                        //set the full name of the stock stored in the 'stocks' key value to the 'stock' string
                        //This will be used in the Console.Writeline() that prints aquisitions summary
                        stock = stockKVP.Value;
                    }
                }

                //if the 'ownership' dictionary already has a key matching the stock currently represtented by 'stock'...
                if (ownership.ContainsKey(stock))
                {
                    //...add the value of the shares*price of the current purchase tuple ('t') to the existing 
                    //key value in 'ownership'
                    ownership[stock] += (t.shares * t.price);
                }
                //if not, create a new key value pair in 'ownership' with the key of 'stock' and the value mentioned above
                else
                {
                    ownership.Add(stock, (t.shares * t.price));
                }

            }
            //for each key value pair in 'ownership'...
            foreach (KeyValuePair<string, double> kvp in ownership)
            {
                //...write the full stock name and the total value of those purchased stocks
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            }
        }
    }
}
