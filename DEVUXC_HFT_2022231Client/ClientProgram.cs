
using ConsoleTools;
using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Models.Useless;
using NUnit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231Client
{
    public class ClientProgram
    {
        static RestService rest;
        public static void Main(string[] args)
        {
            rest = new RestService("http://localhost:2201/swagger/v1/swagger.Json", "Season");
            var SponsorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Sponsor"))
                .Add("Create", () => Create("Sponsor"))
                .Add("Delete", () => Delete("Sponsor"))
                .Add("Update", () => Update("Sponsor"))
                .Add("Exit", ConsoleMenu.Close);

            var TeamSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Team"))
                .Add("Create", () => Create("Team"))
                .Add("Delete", () => Delete("Team"))
                .Add("Update", () => Update("Team"))
                .Add("Exit", ConsoleMenu.Close);

            var SeasonSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Season"))
                .Add("Create", () => Create("Season"))
                .Add("Delete", () => Delete("Season"))
                .Add("Update", () => Update("Season"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Sponsors", () => SponsorSubMenu.Show())
                .Add("Teams", () => TeamSubMenu.Show())
                .Add("Seasos", () => SeasonSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }

        static void Create(string entity)
        {
            if (entity == "Sponsor")
            {
                Console.Write("Enter Sponsor Name: ");
                string name = Console.ReadLine();
                rest.Post(new Sponsor() { Name = name }, "Sponsor");
            }
            else if (entity == "Team")
            {
                Console.Write("Enter Team Name: ");
                string name = Console.ReadLine();
                rest.Post(new Team() { Name = name }, "Team");
            }
            else if (entity == "Season")
            {
                Console.Write("Enter Season year: ");
                int Year =int.Parse(Console.ReadLine());
                rest.Post(new Season() { SeasonYear = Year }, "Season");
            }
            else if (entity == "Season")
            {
                Console.Write("Enter Season year: ");
                int Year =int.Parse(Console.ReadLine());
                rest.Post(new Season() { SeasonYear = Year }, "Season");
            }
        }
        static void List(string entity)
        {
            if (entity == "Sponsor")
            {
                List<Sponsor> sponsors = rest.Get<Sponsor>("Sponsor");
                foreach (var item in sponsors)
                {
                    Console.WriteLine(item.Name + ": " + item.Money);
                }
            }
            else if (entity== "Team")
            {
                List<Team> teams = rest.Get<Team>("Teams");
                foreach (var item in teams)
                {
                    var drivers = item.Drivers.ToArray();
                    Console.WriteLine(item.Name + ": ");
                    for (int i = 0; i < drivers.Length-1; i++)
                    {
                         Console.Write( " | " + drivers[i].Name +" : " + drivers[i].DriverNumber);
                    }                    
                }
            }
            else if (entity == "Season")
            {
                List<Season> seasons = rest.Get<Season>("Season");
                foreach (var item in seasons)
                {
                    Console.WriteLine(item.SeasonYear);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Sponsor")
            {
                Console.Write("Enter Sponsor's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Sponsor one = rest.Get<Sponsor>(id, "Sponsor");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                Console.Write($"New Money [old: {one.Money}]: ");
                int money = int.Parse(Console.ReadLine());
                one.Money = money;
                rest.Put(one, "Sponsor");
            }
            else if (entity == "Team")
            {
                Console.Write("Enter Team's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Team one = rest.Get<Team>(id, "Team");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                Console.Write("Change Drivers? [y/n]");
                var drivers = one.Drivers.ToArray();
                int count = 0;
                while (Console.ReadLine() == "y")
                {
                    Console.WriteLine("Change this Driver? [y/n]");
                    if (Console.ReadLine() == "y" && count < drivers.Length)
                    {
                        Console.Write($"New Drivers name [old: {drivers[count].Name}]: ");
                        string Dname = Console.ReadLine();
                        Console.Write($"New Drivers DriverNumber [old: {drivers[count].DriverNumber}]: ");
                        int Dnumber = int.Parse(Console.ReadLine());
                        one.Drivers.Add(new Driver() { Name = Dname, DriverNumber = Dnumber });
                        count++;
                    }
                    else { Console.WriteLine("No Drivers Left. "); }
                }
                rest.Put(one, "Team");
            }
            else if (entity == "Season")
            {
                Console.Write("Enter Season's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Season one = rest.Get<Season>(id, "Season");
                Console.Write($"New Year [old: {one.SeasonYear}]: ");
                int year = int.Parse(Console.ReadLine());
                one.SeasonYear = year;
                rest.Put(one, "Season");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Sponsor")
            {
                Console.Write("Enter Sponsor's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Sponsor");
            }
            else if (entity == "Team")
            {
                Console.Write("Enter Team's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Team");
            }
            else if (entity == "Season")
            {
                Console.Write("Enter Season's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Season");
            }
        }
    }
}
