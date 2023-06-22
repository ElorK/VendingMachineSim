using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Tea : Beverage
    {
        //string array of ingredients [I tried to use the Ingredients class instances but had problem with returning values so I used string array instead]
        private string[] _ingredients = new string[] { "Tea Leaves", "Sugar"};
        public Tea(string name, double price) : base(name, price)
        {
        }
        public override string AddIng()
        {
            //overriding the parent abstract method to create a string of the ingredients
            string ingredients = "";
            for (int i = 0; i < _ingredients.Length; i++)
                ingredients = ingredients + $" {_ingredients[i]}, ";
            return ingredients;
        }
        public override int HotWater()
        {
            //return the indevidual value of water amount
            return 150;
        }
        public override int Stirring()
        {
            //return the indevidual value stirring amount
            return 5;
        }
        public override bool EnoughIng()
        {
            if (Manager.TeaLeaves.Amount <= 0 || Manager.Sugar.Amount <= 0)
                return false;
            Manager.TeaLeaves.Amount--;
            Manager.Sugar.Amount--;
            return true;
        }
    }
}
