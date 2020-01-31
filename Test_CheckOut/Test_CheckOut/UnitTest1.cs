using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Test_CheckOut.CheckOut_System;

namespace Test_CheckOut
{

    [TestClass]
    public class UnitTest1
    {
        public double starter_price = 4.4;
        public double mains_price = 7.00;
        public static int startercount = 0;
        public static int mainscount = 0;

        #region Check_TotalCost
        [TestMethod]
        public void Check_TotalCost()
        {

            //setting the starter Quantity as 3
            startercount = 3;

            //setting the mains Quantity as 1
            mainscount = 1;

            //creating new Object of Product
            Product product = new Product(starter_price, mains_price);

            //adding items to cart
            product.add_item("starter", startercount);
            product.add_item("mains", mainscount);

            //storing total cost
            double Actual_total_Cost = product.CheckOut();

            Console.WriteLine("The Total Cost Actual is : {0}", Actual_total_Cost);
            double Expected_total_Cost = startercount * starter_price + mainscount * mains_price;

            Expected_total_Cost = Math.Round(Expected_total_Cost, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine("Expected Cost : {0} ", Expected_total_Cost);

            //Asserting both Values are same 
            Assert.AreEqual(Expected_total_Cost, Actual_total_Cost);
        }
        #endregion Check_items_added_Successfully

        #region testmethod2
        [TestMethod]
        public void Check_items_added_Successfully()
        {
            //setting the starter Quantity as 3
            startercount = 13;

            //setting the mains Quantity as 1
            mainscount = 1;

            //creating new Object of Product
            Product product = new Product(starter_price, mains_price);

            //adding items to cart
            product.add_item("starter", startercount);
            product.add_item("mains", mainscount);

            product.displayCart();
            Dictionary<String, int> cart = new Dictionary<string, int>();
            cart = product.getCart();

            //Using Assertions
            foreach (KeyValuePair<string, int> entry in cart)
            {
                switch (entry.Key)
                {
                    case "starter":
                        Assert.AreEqual(startercount, entry.Value);
                        break;
                    case "mains":
                        Assert.AreEqual(mainscount, entry.Value);
                        break;
                }
            }

        }
        #endregion Check_items_added_Successfully

        #region check_items_updated
        [TestMethod]
        public void Check_Update_Item()
        {
            //setting the starter Quantity as 3
            startercount = 9;

            //setting the mains Quantity as 1
            mainscount = 2;

            //creating new Object of Product
            Product product = new Product(starter_price, mains_price);

            //adding items to cart
            product.add_item("starter", startercount);
            product.add_item("mains", mainscount);

            //Console Output before updating
            product.displayCart();

            int new_startercount = 10;

            product.update_item("starter", new_startercount);

            //console output after updation
            product.displayCart();

            Dictionary<String, int> cart = new Dictionary<string, int>();
            cart = product.getCart();

            Assert.AreEqual(cart["starter"], new_startercount);


                #endregion check_items_updated

            }

        #region deleteitem
        [TestMethod]
        public void Check_delete_item()
        {
            //setting the starter Quantity as 3
            startercount = 9;

            //setting the mains Quantity as 1
            mainscount = 2;

            //creating new Object of Product
            Product product = new Product(starter_price, mains_price);

            //adding items to cart
            product.add_item("starter", startercount);
            product.add_item("mains", mainscount);

            Console.WriteLine("List of items in cart before deletion");

            product.displayCart();

            Console.WriteLine("List of items in cart After deletion");

            product.delete_item("starter");

            product.displayCart();
            
            Dictionary<String, int> cart = new Dictionary<string, int>();
            cart = product.getCart();

            Console.WriteLine("Expected Boolean Value: {0} , Actual Boolean Value {1} ", false , cart.ContainsKey("starter"));

            Assert.AreEqual(false, cart.ContainsKey("starter"));

        }
        #endregion deleteitem
    }
}
