using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
        public class Vehicle
        {
            public const int ABS = 180;
            public const int Air_Cond = 150;
            public const int GPS = 140;

            public string Name { get; set; }
            public double Price { get; set; }
            public string FormattedPrice
            {
            get
            { 
                return string.Format("${0}", Price);
            }
            }
            public bool OnABS { get; set; }
            public bool OnAirCond { get; set; }
            public bool OnGPS { get; set; }

            public string TotalValueFormatted
            {
            get
            {
                return string.Format("Final Price: $ {0}",
                    Price
                    + (OnABS ? Vehicle.ABS : 0)
                    + (OnAirCond ? Vehicle.Air_Cond : 0)
                    + (OnGPS ? Vehicle.GPS : 0)
                    );
            }

        }
    }
}

