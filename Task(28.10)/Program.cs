using Core.Data;
using Core.Helpers.Enums;
using Core.Models;
using System;

class Program
{
    static void Main()
    {
        string mainMenuChoice;

        bool condition = false;
        do
        {
            Console.WriteLine("******Menu******");
            Console.WriteLine("1. Country menu");
            Console.WriteLine("2. Planet menu");
            Console.WriteLine("0. Cixis");
            Console.WriteLine(" ");
            Console.Write("Seciminizi edin: ");
            mainMenuChoice = Console.ReadLine();

            switch (mainMenuChoice)
            {
                case "1":
                    Console.Clear();
                    CountryMenu();
                    break;
                case "2":
                    Console.Clear();
                    PlanetMenu();
                    break;
                case "0":
                    Console.Clear();
                    condition = true;
                    Console.WriteLine("Programdan cixilir...");
                    break;
                default:
                    Console.WriteLine("Zehmet olmasa duzgun secim edin.");
                    break;
            }
        } while (!condition);
    }

    static void CountryMenu()
    {
        string countryMenuChoice;
        bool condition = false;
        do
        {
            Console.WriteLine("\nCountry Menu");
            Console.WriteLine("1. Olke yarat");
            Console.WriteLine("2. Butun olkeleri gor");
            Console.WriteLine("3. Olke sec ve update et");
            Console.WriteLine("4. Olke sil");
            Console.WriteLine("5. Regiona gore olkeleri filter et");
            Console.WriteLine("0. Exit");
            Console.WriteLine(" ");
            Console.Write("Seciminizi edin: ");
            countryMenuChoice = Console.ReadLine();

            switch (countryMenuChoice)
            {
                case "1":
                    Console.Clear();
                    CreateCountry();
                    break;
                case "2":
                    Console.Clear();
                    AppDbContext.GetAllCountries();
                    break;
                case "3":
                    Console.Clear();
                    UpdateCountry();
                    break;
                case "4":
                    Console.Clear();
                    RemoveCountry();
                    break;
                case "5":
                    Console.Clear();
                    FilteredCountry();
                    break;
                case "0":
                    Console.Clear();
                    condition = true;
                    Console.WriteLine("Country menu baglanir ...");
                    break;
                default:
                    Console.WriteLine("Zehmet olmasa duzgun secim edin.");
                    break;
            }
        } while (!condition);
    }

    static void PlanetMenu()
    {
        string planetMenuChoice;
        bool condition = false;
        do
        {
            Console.WriteLine("\nPlanet Menu");
            Console.WriteLine("1. Planet yarat");
            Console.WriteLine("2. Butun planetleri gor");
            Console.WriteLine("3. Planet sec ve update et (planetin adini daxil ederek secilecek)");
            Console.WriteLine("4. Plan sil");
            Console.WriteLine("0. Exit");
            Console.WriteLine(" ");
            Console.Write("Seciminizi edin: ");
            planetMenuChoice = Console.ReadLine();

            switch (planetMenuChoice)
            {
                case "1":
                    Console.Clear();
                    CreatePlanet();
                    break;
                case "2":
                    Console.Clear();
                    AppDbContext.GetAllPlanets();
                    break;
                case "3":
                    Console.Clear();
                    UpdatePlanet();
                    break;
                case "4":
                    Console.Clear();
                    RemovePlanet();
                    break;
                case "0":
                    Console.Clear();
                    condition = true;
                    Console.WriteLine("Planet menu baglanir ...");
                    break;
                default:
                    Console.WriteLine("Zehmet olmasa duzgun secim edin.");
                    break;
            }
        } while (!condition);
    }

    static void CreateCountry()
    {

        string name;
        double area;
        string anthem;
        Region? region = null;
        string regionChoice;

        bool condition;

        Console.Write("Olke adi daxil edin:");
        name = Console.ReadLine();
        Console.WriteLine(" ");

        do
        {
            Console.Write("Area daxil edin:");
            condition = double.TryParse(Console.ReadLine(), out area);

        } while (!condition);
        Console.WriteLine(" ");

        Console.Write("Anthem daxil edin:");

        anthem = Console.ReadLine();

        Console.WriteLine(" ");
        bool condition1 = false;


        Console.WriteLine("1.Avropa\r\n2.Asiya\r\n3.Amerika\r\n4.Afrika\r\n5.Avstraliya\r\n6.Antraktida");
        Console.Write("Yuxarida verilenlere esasen region secin:");
        regionChoice = Console.ReadLine();
        switch (regionChoice)
        {
            case "1":
                region = Region.Avropa;
                break;
            case "2":
                region = Region.Asiya;
                break;
            case "3":
                region = Region.Amerika;

                break;
            case "4":
                region = Region.Afrika;
                break;
            case "5":
                region = Region.Avstraliya;
                break;
            case "6":
                region = Region.Antraktida;
                break;
            default:
                Console.WriteLine("Duzgun secim edin.");
                break;
        }

        Country country = new Country(name, area, anthem, region.Value);

        AppDbContext.CreateCountry(country);

        Console.WriteLine("Olke ugurla yaradildi.");

    }

    static void UpdateCountry()
    {
        int id;
        string name;
        bool conditon = false;

        AppDbContext.GetAllCountries();

        do
        {
            Console.Write("Deyisdirmek istediyiniz olkenin id-sin daxil edin:");
            conditon = int.TryParse(Console.ReadLine(), out id);

            Console.WriteLine(" ");
            Console.Write("Yeni adi daxil edin:");

            name = Console.ReadLine();

            AppDbContext.UpdateCountry(id, name);

        } while (!conditon);

    }

    static void FilteredCountry()
    {
        Region? region = null;
        string regionChoice;



        Console.WriteLine("1.Avropa\r\n2.Asiya\r\n3.Amerika\r\n4.Afrika\r\n5.Avstraliya\r\n6.Antraktida");
        Console.WriteLine(" ");
        Console.Write("Yuxarida verilenlere esasen region secin:");
        regionChoice = Console.ReadLine();
        switch (regionChoice)
        {
            case "1":
                region = Region.Avropa;
                break;
            case "2":
                region = Region.Asiya;
                break;
            case "3":
                region = Region.Amerika;

                break;
            case "4":
                region = Region.Afrika;
                break;
            case "5":
                region = Region.Avstraliya;
                break;
            case "6":
                region = Region.Antraktida;
                break;
            default:
                Console.WriteLine("Duzgun secim edin.");
                break;
        }

        List<Country> countries = AppDbContext.GetCountryByRegion(region.Value);

        if (countries.Count == 0)
        {
            Console.WriteLine("Hec bir olke tapilmadi.");
        }
        else
        {
            foreach (var item in countries)
            {
                Console.WriteLine(item);
            }
        }
    }
    static void RemoveCountry()
    {
        int id;
        bool conditon = false;
        AppDbContext.GetAllCountries();
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        do
        {
            Console.WriteLine("Silmek istediyiniz olke adini daxil edin:");
            conditon = int.TryParse(Console.ReadLine(), out id);

        } while (!conditon);

        AppDbContext.RemoveCountry(id);

    }

    static void CreatePlanet()
    {
        Console.Clear();
        string name;
        double area;
        bool condition;

        Console.Write("Planetin adini daxil edin:");
        name = Console.ReadLine();

        Console.WriteLine(" ");

        do
        {
            Console.Write("Planetin areasini daxil edin:");
            condition = double.TryParse(Console.ReadLine(), out area);

        } while (!condition);

        Planet planet = new Planet(name, area);

        AppDbContext.CreatePlanet(planet);

        Console.WriteLine("Planet ugurla yaradildi.");
    }
    static void UpdatePlanet()
    {
        int id;
        string name;
        bool conditon = false;

        AppDbContext.GetAllPlanets();

        do
        {
            Console.Write("Deyisdirmek istediyiniz planetin id-sin daxil edin:");
            conditon = int.TryParse(Console.ReadLine(), out id);

            Console.WriteLine(" ");
            Console.Write("Yeni adi daxil edin:");

            name = Console.ReadLine();

            AppDbContext.UpdatePlanet(id, name);

        } while (!conditon);

    }
    static void RemovePlanet()
    {
        int id;
        bool conditon = false;
        AppDbContext.GetAllPlanets();
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        do
        {
            Console.WriteLine("Silmek istediyiniz planet id daxil edin:");
            conditon = int.TryParse(Console.ReadLine(), out id);

        } while (!conditon);

        AppDbContext.RemovePlanet(id);

    }
}
