using Core.Helpers.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public static class AppDbContext
    {
        static List<Planet> planets = new List<Planet>();
        static List<Country> countries = new List<Country>();

        public static void CreateCountry(Country country)
        {
            countries.Add(country);
        }

        public static void RemoveCountry(int id)
        {
            if (countries.Count == 0)
            {
                Console.WriteLine("Hec bir olke yaratmamisiniz.");
            }
            else
            {
                for (int i = 0; i < countries.Count; i++)
                {
                    if (id == countries[i].Id)
                    {
                        countries.Remove(countries[i]);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bu id-li olke movcud deyil");
                    }
                }
            }


        }

        public static void GetAllCountries()
        {
            if (countries.Count == 0)
            {
                Console.WriteLine("Hec bir olke yaratmamisiz.");
            }
            else
            {

                foreach (var country in countries)
                {
                    Console.WriteLine(country);
                }
            }
        }
        public static List<Country> GetCountryByRegion(Region region)
        {
            List<Country> newCountries = new List<Country>();
            for (int i = 0; i < countries.Count; i++)
            {
                if (countries[i].Region == region)
                {
                    newCountries.Add(countries[i]);
                }
            }
            return newCountries;
        }

        public static void UpdateCountry(int id, string name)
        {
            if (countries.Count == 0)
            {
                Console.WriteLine("Hec bir olke yaratmamisiniz.");
            }
            else
            {
                for (int i = 0; i < countries.Count; i++)
                {
                    if (countries[i].Id == id)
                    {
                        countries[i].CountryName = name;
                        Console.WriteLine(" ");
                        Console.WriteLine("Olke adi update edildi.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bele olke movcud deyil.");
                    }
                }
            }

        }

        public static void CreatePlanet(Planet planet)
        {
            planets.Add(planet);
        }

        public static void RemovePlanet(int id)
        {

            if (planets.Count == 0)
            {
                Console.WriteLine("Hec bir planet yaratmamisiniz");
            }
            else
            {
                for (int i = 0; i < planets.Count; i++)
                {
                    if (id == planets[i].Id)
                    {
                        planets.Remove(planets[i]);
                        Console.WriteLine("Planet ugurla silindi.");
                    }
                    else
                    {
                        Console.WriteLine("Bele planet movcud deyil.");
                    }
                }
            }
        }

        public static void GetAllPlanets()
        {
            if (planets.Count == 0)
            {
                Console.WriteLine("Hec bir planet movcud deyil.");
            }
            else
            {
                foreach (var item in planets)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static void UpdatePlanet(int id, string name)
        {
            if (planets.Count == 0)
            {
                Console.WriteLine("Hec bir planet yaratmamisiniz.");
            }
            else
            {
                for (int i = 0; i < planets.Count; i++)
                {
                    if (id == planets[i].Id)
                    {
                        planets[i].PlanetName = name;
                        Console.WriteLine("Planet adi update edildi.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bele planet movcud deyil.");
                    }
                }
            }


        }
    }
}
