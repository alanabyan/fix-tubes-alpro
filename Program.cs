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

            int choice = 0;

            try
            {
                choice = int.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nInput harus berupa angka!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }

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
                default: Console.WriteLine("\nPilihan menu tidak tersedia!"); break;
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
        Console.WriteLine ("---ADD PRODUCT---\n");

        int id;
        while(true)
        {
            Console.Write("Input ID: ");
            if(int.TryParse(Console.ReadLine(), out id))
            break;

            Console.WriteLine("ID harus berupa angka!");
        }
        Console.Write("Input Nama: ");
        string name = Console.ReadLine()!;

        int stock;
        while(true)
        {
            Console.Write("Input Stock: ");
            if(int.TryParse(Console.ReadLine(), out stock))
            break;

            Console.WriteLine("Stock harus berupa angka!");
        }

        decimal price;
        while(true)
        {
            Console.Write("Input Price (RP): ");
            if(decimal.TryParse(Console.ReadLine(), out price));
            break;

            Console.WriteLine("Harga harus berupa angka!");
        }

        Console.WriteLine("\nPilih Category: ");
        for(int i = 0; i<categories.Length; i++)
            Console.WriteLine($"{i + 1}. {categories[i]}");
        
        int catChoice;
        string category = "";
        while(true)
        {
            Console.Write("Input Pilihan Category (1-bebas)");
            if (int.TryParse(Console.ReadLine(), out catChoice)&& catChoice >= 1 && catChoice <= categories.Length)
            {
                category = categories[catChoice - 1];
                break;
            }
            Console.WriteLine("Pilihan Kategori tidak valid!");
        }
        products[count]= new Product
        {
            Id = id,
            Name = name,
            Stock = stock,
            Price = price,
            Category = category
        };

        count++;

        Console.WriteLine("\nProduk berhasil ditambahkan");
    }

    static void EditProduct()
    {
       
    }

    static void DeleteProduct()
    {
      Console.WriteLine("----DELETE PRODUCT----");

      if(count == 0)
        {
            Console.WriteLine("Tidak ada proudct untuk dihapus");
            return;
        }
        int id;
        while(true)
        {
            Console.Write("Input ID produk yang ingin dihapus: ");
            if(int.TryParse(Console.ReadLine(), out id))
            break;

            Console.WriteLine("ID harus berupa angka!");
        }
        int index = -1;
        for(int i = 0; i < count; i++)
        {
            if(products[i].Id == id)
            {
                index = i;
                break;
            }
        }
        if (index == -1)
        {
            Console.WriteLine("Produk dengan ID tersebut tidak ditemukan");
            return;
        }
        for (int i = index; i < count - 1; i++)
        {
            products[i] = products[i + 1];
        }

        count--;

        Console.WriteLine("Produk berhasil dihapus!");
    }

    static void SearchProduct()
    {
        
    }

    static void FilterByCategory()
    {
        Console.WriteLine("mas");
    }
}
