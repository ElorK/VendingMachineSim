using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class ingredients
    {
        //class for managing the ingredients stock by name and amount
        private string _name;
        private int _amount;
        public ingredients(string name)
        {
            _name = name;
            _amount = 0;
        }
        public string Name { get { return _name; } }
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public override string ToString()
        {
            return _name;
        }
        //public string this[int index]
        //{
        //    get { return _name; }
        //}
    }
}
