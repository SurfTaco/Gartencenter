using Gartencenter.Model;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Gartencenter
{
    public class Program
    {
        static LibContext lc = new LibContext();
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("\nBenutzernamen und Passwort eingeben:\n");

                    Console.Write("Benutername: ");
                    string username = Console.ReadLine().ToLower();

                    Console.Write("Passwort: ");
                    string password = Console.ReadLine();

                    var User = lc.Accounts.FirstOrDefault(x => x.Username == username);

                    if (User != null && password == User.Password) break;

                    Console.Clear();
                    Console.WriteLine("\nBenutzernamen oder Passwort falsch!\n");
                }

                string input = String.Empty;
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Hauptprogramm:\n\n");

                    Console.WriteLine("1) Artikel anlegen:");
                    Console.WriteLine("2) Lieferung anlegen:");
                    Console.WriteLine("3) Lieferant anlegen:");
                    Console.WriteLine("4) Welcher Artikel wurde am öftesten geliefert:/n");

                    Console.Write("Ihre Eingabe: ");

                    input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            AddArticle();
                            break;
                        case "2":
                            AddDelivery();
                            break;
                        case "3":
                            AddSupplier();
                            break;
                        case "4":
                            GetMostDeliveried();
                            break;
                        default:
                            break;
                    }
                    Console.Clear();
                }
            }
        }

        public static void AddArticle()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Neuen Artikel anlegen:\n");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            decimal price = 0;

            Console.Write("Preis: ");
            while (price == 0)
            {
                input = Console.ReadLine();
                input = input.Replace(".", ",");
                if (!decimal.TryParse(input, out price))
                    Console.WriteLine("Auf die richtige Eingabe achten! z.B. \"6,99\"");
            }

            var cat = lc.Categories.ToList();

            for (int i = 0; i < cat.Count; i++)
                Console.WriteLine($"{i + 1}) {cat[i].Name}");

            Console.WriteLine("\nBitte Kategorie auswählen: ");

            int catId = 0;

            while (catId == 0)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out int id) && --id >= 0 && id < cat.Count)
                    catId = cat[id].Id;
                else
                    Console.WriteLine($"Falsche Eingabe! Nur Zahlen zwischen 1 und {cat.Count} eingeben.");

            }

            Article article = new Article()
            {
                Name = name,
                Price = price,
                CategoryID = catId
            };

            lc.Articles.Add(article);

            lc.SaveChanges();

            Console.WriteLine($"Ein neuer Artikel mit dem Namen {name} und der Kategorie {article.Category.Name} wurde erfolgreich angelegt.");

            Finish();
        }


        public static void AddDelivery()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Neuen Lieferung hinzufügen:\n");

            var lieferanten = lc.Lieferanten.ToArray();
            var articles = lc.Articles.ToList();

            Lieferung lieferung = new()
            {
                DayOfDelivery = DateTime.Now,
                Amount = 0,
                LieferantId = lieferanten[new Random().Next(0, lieferanten.Count())].Id,
                ArticleID = articles[new Random().Next(0, articles.Count())].Id
            };
            int amount = 0;

            Console.Write("Wieviel Stück wurden geliefert? ");

            while (amount == 0)
            {
                if (int.TryParse(Console.ReadLine(), out int newAmount) && newAmount > 0)
                    amount = newAmount;
                else
                    Console.WriteLine("Das ist keine Stückzahl!");
            }

            lieferung.Amount = amount;

            lc.Lieferung.Add(lieferung);

            lc.SaveChanges();

            Console.WriteLine($"Die Lieferung von {lieferung.Amount} Stück \"{lieferung.Article.Name}\" vom Lieferanten {lieferung.Lieferant.Name} wurde erfolgreich angelegt.");

            Finish();
        }
        public static void AddSupplier()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Neuen Lieferanten hinzufügen:\n");

            Console.Write("Name des Lieferanten: ");
            string name = Console.ReadLine();

            Console.Write("Stadt des Lieferanten: ");
            string country = Console.ReadLine();

            lc.Lieferanten.Add(new Lieferant
            {
                Name = name,
                Country = country
            });

            lc.SaveChanges();

            Console.WriteLine($"Der Lieferant {name} wurde erfolgreich angelegt.");

            Finish();
        }

        public static void GetMostDeliveried()
        {
            var most = lc.Lieferung
                .GroupBy(a => a.ArticleID)
                .Select(a => new { Amount = a.Sum(b => b.Amount), Id = a.Key })
                .OrderByDescending(a => a.Amount)
                .First();

            var top = lc.Articles.FirstOrDefault(x => x.Id == most.Id);

            Console.Clear();

            Console.WriteLine($"Der Meistgelieferte Artikel ist \"{top.Name}\" mit insgesammt {most.Amount} Stück");

            Finish();
        }
        public static void Finish()
        {
            Console.WriteLine("Weiter mit beliebiger Taste...");
            Console.ReadKey();
        }
    }
}
