using System;
using SimpleStorage;

class Program
{
    static void Main()
    {
        var storageManager = new StorageManager();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("1. Legg til produkt");
            Console.WriteLine("2. Fjern produkt");
            Console.WriteLine("3. Søk etter produkt");
            Console.WriteLine("4. Vis alle produkter");
            Console.WriteLine("5. Avslutt");
            Console.Write("Velg en handling: ");
            var action = Console.ReadLine();
            Console.Clear();

            switch (action)
            {
                case "1":
                    AddProduct(storageManager);
                    break;
                case "2":
                    RemoveProduct(storageManager);
                    break;
                case "3":
                    SearchProduct(storageManager);
                    break;
                case "4":
                    ListAllProducts(storageManager);
                    break;
                case "5":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Ugyldig valg, prøv igjen.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static void AddProduct(StorageManager storageManager)
    {
        Console.Write("Skriv inn produkt-ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.Write("Skriv inn produktnavn: ");
            var name = Console.ReadLine();
            try
            {
                storageManager.AddProduct(id, name);
                Console.WriteLine("Produkt lagt til.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("Ugyldig ID, prøv igjen.");
        }
    }

    static void RemoveProduct(StorageManager storageManager)
    {
        Console.Write("Skriv inn produkt-ID som skal fjernes: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (storageManager.RemoveProduct(id))
            {
                Console.WriteLine("Produkt fjernet.");
            }
            else
            {
                Console.WriteLine("Produkt ikke funnet.");
            }
        }
        else
        {
            Console.WriteLine("Ugyldig ID, prøv igjen.");
        }
    }

    static void SearchProduct(StorageManager storageManager)
    {
        Console.Write("Skriv inn produkt-ID eller navn du vil søke etter: ");
        var input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input)) // Check that input is not empty
        {
            try
            {
                var products = storageManager.SearchProducts(input);

                if (products.Count > 0)
                {
                    Console.WriteLine("Funnet produkter:");
                    foreach (var product in products)
                    {
                        Console.WriteLine($"ID: {product.ID}, Navn: {product.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Ingen produkter funnet.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("Søketerm kan ikke være tomt.");
        }
    }

    static void ListAllProducts(StorageManager storageManager)
    {
        var products = storageManager.GetAllProducts();
        if (products.Any())
        {
            Console.WriteLine("Alle produkter i lager:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ID}, Navn: {product.Name}");
            }
        }
        else
        {
            Console.WriteLine("Ingen produkter i lager.");
        }
    }
}