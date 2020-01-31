using System;
using System.Collections.Generic;
using System.Text;

namespace Test_CheckOut.CheckOut_System
{
    class Product
    {
        //Variables 
        double _StarterPrice;
        double _MainsPrice;
        Dictionary<String, int> cart = new Dictionary<string, int>();
        double total_cost = 0.0;

        public Product(double starterprice, double mainsprice)
        {
            _StarterPrice = starterprice;
            _MainsPrice = mainsprice;
        }





        public void add_item(String dishtype, int count)
        {
            //Checking cart does not contain the value already
            while (cart.ContainsKey(dishtype) == false)
            {
                cart.Add(dishtype, count);
            }


        }

        public void update_item(String dishtype, int count)
        {
                //Updating the item in cart
                cart[dishtype] = count;
                       

        }

        public void delete_item(String dishtype)
        {
            //deleting the item in cart
            while (cart.ContainsKey(dishtype) == true)
            {
                cart.Remove(dishtype);
            }

        }

        public double CheckOut()
        {

            Dictionary<string, int>.ValueCollection values = cart.Values;

            foreach (KeyValuePair<string, int> entry in cart)
            {
                // do something with entry.Value or entry.Key
                switch (entry.Key)
                {
                    //switch statement to assign the prices
                    case "starter":
                        double price = _StarterPrice * entry.Value;
                        total_cost += price;
                        break;
                    case "mains":
                        double price2 = _MainsPrice * entry.Value;

                        total_cost += price2;
                        break;
                }

            }
            //rounding off to the two decimal places
            total_cost = Math.Round(total_cost, 2, MidpointRounding.AwayFromZero);
            return total_cost;

        }

        public void displayCart()
        {
            foreach (KeyValuePair<string, int> entry in cart)
            {
                //displaying values
                Console.WriteLine("The Dishtype is : {0}  , Dish Quantity is {1}", entry.Key, entry.Value);
            }

        }

        public Dictionary<String, int> getCart()
        {
            //return cart
            return cart;
        }
    }
}
