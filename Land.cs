using System;
using System.Collections.Generic;
using System.Text;

//Land class with the properties class inherited.
namespace Assingment
{
    public class Land : Properties //Inheritance
    {
        public double Area
        { get; set; }
        //Constructor with the base parameters inherited from Properties class. Just adds a new parameter, area.
        public Land(User seller, string address, string postcode, double area) : base(seller, address, postcode)
        {
            Area = area;
        }
        // Allows for the list to be properly displayed in console
        public override string ToString()
        {
            return $"Land: {Postcode}, {Address}, {Area} m^2";
        }
        // Method for calculting the taxpayable. It is override so that the same Method name can be called depending on the context, House or Land.
        public override double TaxPayable()
        {
            double tax = Math.Round(5.50 * Area);
            return tax;

        }


    }
}
