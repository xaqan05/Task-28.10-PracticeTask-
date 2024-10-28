using Core.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Planet
    {
        private static int _planetId = 1;

        public int Id;

        public string PlanetName;

        private double _planetArea;
        public double PlanetArea
        {
            get
            {
                return _planetArea;
            }
            set
            {
                if (value > 0)
                {
                    _planetArea = value;
                }
            }
        }
        public Planet(string name, double area)
        {
            Id = _planetId++;
            PlanetName = name;
            PlanetArea = area;
        }
        public string ShowInfo()
        {
            return $"Id: {Id}, Name: {PlanetName}, Area: {PlanetArea}";
        }
        public override string ToString()
        {
            return ShowInfo();
        }
    }

}
