using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Manager
    {
        //manager class creates and manages all the other class instances
        private static Beverage _coffee = new Coffee("Coffee", 10);
        private static Beverage _tea = new Tea("Tea", 8);
        private static Beverage _cocoa = new Cocoa("Cocoa", 7);
        private static Beverage[] _beverages = new Beverage[] { _coffee, _tea, _cocoa };
        private static VendingMachine _vdm = new VendingMachine(_beverages);
        private static ingredients _sugar = new ingredients("Sugar");
        private static ingredients _milk = new ingredients("Milk");
        private static ingredients _coffeeBeans = new ingredients("Coffee Beans");
        private static ingredients _cocoaBeans = new ingredients("Cocoa Beans");
        private static ingredients _teaLeaves = new ingredients("Tea Leaves");
        public static ingredients Sugar { get { return _sugar; } }
        public static ingredients Milk { get { return _milk; } }
        public static ingredients CoffeeBeans { get { return _coffeeBeans; } }
        public static ingredients CocoaBeans { get { return _cocoaBeans; } }
        public static ingredients TeaLeaves { get { return _teaLeaves; } }

        public static double Balance { get; set; }
        public static int Cups { get; set; }
        public static int Water { get; set; }
        public static string Prepare(int i)
        {
            //this method sends the recieved i that arrived from the main.cs to the vending machine instance,
            //and calls to the vending machine's corresponding method
            //has a catching for exception case that might happens in case of insufficient ingredients
            try
            {
                return _vdm.DrinkSelect(i);
            }
            catch (InsufficientingredientsException e)
            {
                return e.Message.ToString();
            }
            
        }
        public static void NewBev(Beverage beverage)
        {
            //for future features, calls vending machine's method that add new kind of beverage
            _vdm.AddBev(beverage);
        }
        public static void DeleteBev()
        {
            _vdm.RemoveBev();
        }
        public static void Restock()
        {
            //restocking the ingredients values
            Cups += 20;
            Water += 800;
            Sugar.Amount += 20;
            Milk.Amount += 10;
            CoffeeBeans.Amount += 5;
            CocoaBeans.Amount += 5;
            TeaLeaves.Amount += 5;
        }

        [Serializable]
        public class InsufficientingredientsException : Exception
        {
            //creating a custom exception for throwing for insufficient ingredients
            public InsufficientingredientsException() { }
            public InsufficientingredientsException(string message) : base(message) { }
            public InsufficientingredientsException(string message, Exception inner) : base(message, inner) { }
            protected InsufficientingredientsException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
