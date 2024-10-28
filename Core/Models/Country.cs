using Core.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Country
    {
        private static int _CountryId = 1;

        public int Id;
        public string CountryName { get; set; }

        private double _countryArea;
        public double CountryArea
        {
            get
            {
                return _countryArea;
            }
            set
            {
                if (value > 0)
                {
                    _countryArea = value;
                }
            }
        }

        public string Anthem { get; set; }

        public Region Region { get; set; }

        public Country(string name, double area, string anthem, Region region)
        {
            Id = _CountryId++;
            CountryName = name;
            CountryArea = area;
            Anthem = anthem;
            Region = region;
        }

        public string ShowInfo()
        {
            return $"Id: {Id}, Name: {CountryName}, Area: {CountryArea}, Anthem: {Anthem}, Region: {Region}";
        }
        public override string ToString()
        {
            return ShowInfo();
        }


    }
}
