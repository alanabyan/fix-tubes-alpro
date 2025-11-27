using System;

class Product
{
    public int Id;
    public string Name;
    public int Stock;
    public decimal Price;
    public string Category;
}

class Program
{
    static Product[] products = new Product[50];

    static int count = 0;


    static string[] categories = { "Mainan", "Baju", "Lainnya" };

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== PRODUCT CRUD ====");
            Console.WriteLine("1. Show All Products");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Search Product");
            Console.WriteLine("6. Filter by Category");
            Console.WriteLine("7. Exit");
            Console.Write("Choose menu: ");
            int choice = int.Parse(Console.ReadLine()!);

            Console.Clear();

            switch (choice)
            {
                case 1: ShowAll(); break;
                case 2: AddProduct(); break;
                case 3: EditProduct(); break;
                case 4: DeleteProduct(); break;
                case 5: SearchProduct(); break;
                case 6: FilterByCategory(); break;
                case 7: return;
                default: Console.WriteLine("Invalid choice!"); break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void ShowAll()
    {
        Console.WriteLine("--- LIST PRODUCTS ---\n");

        if (count == 0)
        {
            Console.WriteLine("Tidak ada produk yang tersedia");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            var p = products[i];
            Console.WriteLine($"ID: {p.Id} | {p.Name} | Category: {p.Category} | Stock: {p.Stock} | Price: Rp {p.Price:N0}");
        }
    }

    static void AddProduct()
    {
        
    }

    static void EditProduct()
    {
       
    }

    static void DeleteProduct()
    {
       
    }

    static void SearchProduct()
    {
        
    }

    static void FilterByCategory()
    {
        
    }
}
