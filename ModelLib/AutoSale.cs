using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib
{
    public class AutoSale
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Car> Cars { get; set; }
        public override string ToString()
        {
            return "Car dealer "+Name+" has "+Cars.Count+" cars in possession, you can find him in: "+Address+"\nCars:\n"+ GetCars();
        }
        public string GetCars()
        {
            string temp = "";
            foreach (Car car in Cars)
            {
                temp += car+"\n";
            }
            return temp;
        }
    }

}
