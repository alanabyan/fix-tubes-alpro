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

    static int nextId = 1;

    static string[] categories = { "Mainan", "Baju", "Lainnya" };

    static void Main()
    {
        while (true)
        {
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
        Console.WriteLine("--- ADD PRODUCT ---");

        int id = nextId++;

        string name;
        while (true)
        {
            Console.Write("Enter product name: ");
            name = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(name))
                break;

            Console.WriteLine("Nama tidak boleh kosong! Coba lagi.\n");
        }

        int stock;
        while (true)
        {
            Console.Write("Enter stock: ");
            string stockInput = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(stockInput))
            {
                Console.WriteLine("Stock tidak boleh kosong!\n");
                continue;
            }

            try
            {
                stock = int.Parse(stockInput);
                if (stock < 0)
                {
                    Console.WriteLine("Stock tidak boleh negatif!\n");
                    continue;
                }
                break;
            }
            catch
            {
                Console.WriteLine("Stock harus berupa angka!\n");
            }
        }

        decimal price;
        while (true)
        {
            Console.Write("Enter price: ");
            string priceInput = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(priceInput))
            {
                Console.WriteLine("Harga tidak boleh kosong!\n");
                continue;
            }

            try
            {
                price = decimal.Parse(priceInput);
                if (price < 0)
                {
                    Console.WriteLine("Harga tidak boleh negatif!\n");
                    continue;
                }
                break;
            }
            catch
            {
                Console.WriteLine("Harga harus berupa angka!\n");
            }
        }

        int catIndex = -1;

        while (true)
        {
            Console.WriteLine("\nChoose Category:");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }

            Console.Write("Enter category (1 - " + categories.Length + "): ");
            string input = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input kategori tidak boleh kosong!\n");
                continue;
            }

            switch (input)
            {
                case "1":
                    catIndex = 0;
                    break;
                case "2":
                    catIndex = 1;
                    break;
                case "3":
                    catIndex = 2;
                    break;
                default:
                    Console.WriteLine("Kategori tidak valid! Coba lagi.\n");
                    continue;
            }

            break; 
        }

        products[count++] = new Product
        {
            Id = id,
            Name = name,
            Stock = stock,
            Price = price,
            Category = categories[catIndex]
        };

        Console.WriteLine("\nProduct added successfully!\n");
    }




    static void EditProduct()
    {
        Console.Clear();
        Console.WriteLine("---EDIT PRODUCT---\n");

        if (count == 0)
        {
            Console.WriteLine("Belum ada data produk!");
            return;
        }

        int id;
        while (true)
        {
            try
            {
                Console.Write("Masukkan ID Product yang ingin diubah: ");
                id = int.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("Input harus berupa angka! Coba lagi.");
            }
        }

        int index = -1;
        for (int i = 0; i < count; i++)
        {
            if (products[i].Id == id)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Product dengan ID tersebut tidak ditemukan!");
            return;
        }


        Console.WriteLine("\nData Produk Saat Ini:");
        Console.WriteLine($"Nama     : {products[index].Name}");
        Console.WriteLine($"Stock    : {products[index].Stock}");
        Console.WriteLine($"Harga    : {products[index].Price}");
        Console.WriteLine($"Kategori : {products[index].Category}\n");

        Console.WriteLine("Masukkan data baru (Enter untuk skip):");

        Console.Write("Nama Baru: ");
        string input = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(input))
            products[index].Name = input;


        while (true)
        {
            Console.Write("Stock Baru: ");
            input = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(input)) break;

            try
            {
                products[index].Stock = int.Parse(input);
                break;
            }
            catch
            {
                Console.WriteLine("Stock harus berupa angka!");
            }
        }


        while (true)
        {
            Console.Write("Harga Baru: ");
            input = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(input)) break;

            try
            {
                products[index].Price = decimal.Parse(input);
                break;
            }
            catch
            {
                Console.WriteLine("Harga harus berupa angka!");
            }
        }

        Console.WriteLine("\nPilih Kategori Baru (Enter untuk skip):");

        for (int i = 0; i < categories.Length; i++)
            Console.WriteLine($"{i + 1}. {categories[i]}");

        Console.Write("Input Pilihan Category: ");

        input = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(input))
        {
            try
            {
                int catChoice = int.Parse(input);
                if (catChoice >= 1 && catChoice <= categories.Length)
                {
                    products[index].Category = categories[catChoice - 1];
                }
                else
                {
                    Console.WriteLine("Pilihan kategori tidak valid! Kategori tidak diubah.");
                }
            }
            catch
            {
                Console.WriteLine("Kategori harus berupa angka! Kategori tidak diubah.");
            }
        }

        Console.WriteLine("\nProduk berhasil diperbarui!");
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
         Console.WriteLine("--- SEARCH PRODUCT ---");
        if (count == 0)
        {
            Console.WriteLine("Tidak ada produk untuk dicari.");
            return;
        }   
            Console.Write("Masukkan nama produk yang ingin dicari: ");
            string searchName = Console.ReadLine()!.ToLower();
            bool found = false;
            
            for (int i = 0; i < count; i++)
            {
                string productName = products[i].Name.ToLower();
                if (productName == searchName)
                {
                    Console.WriteLine($"Produk ditemukan:");
                    Console.WriteLine($"ID: {products[i].Id}");
                    Console.WriteLine($"Nama: {products[i].Name}");
                    Console.WriteLine($"Category: {products[i].Category}");
                    Console.WriteLine($"Stock: {products[i].Stock}");
                    Console.WriteLine($"Price: Rp {products[i].Price:N0}");
                    found = true;
                    break; 
                }
            }
            if (!found)
            {
                Console.WriteLine($"Produk dengan nama '{searchName}' tidak ditemukan.");
            }
        }
    
    static void FilterByCategory()
{
    Console.WriteLine("--- FILTER BY CATEGORY ---\n");

    if (count == 0)
    {
        Console.WriteLine("Tidak ada produk dalam sistem.");
        return;
    }

    
    for (int i = 0; i < categories.Length; i++)
    {
        Console.WriteLine((i + 1) + ". " + categories[i]);
    }

    int pilih = 0;
    bool inputValid = false;

    
    while (!inputValid)
    {
        Console.Write("\nPilih kategori (1 - " + categories.Length + "): ");

        try
        {
            pilih = int.Parse(Console.ReadLine());

            
            if (pilih < 1 || pilih > categories.Length)
            {
                Console.WriteLine(" Pilihan tidak tersedia, silakan pilih sesuai nomor kategori.");
            }
            else
            {
                inputValid = true; 
            }
        }
        catch
        {
            Console.WriteLine(" Input harus berupa angka!");
        }
    }

    string kategori = categories[pilih - 1];
    bool ada = false;

    Console.WriteLine("\n--- Produk kategori: " + kategori + " ---\n");

    for (int i = 0; i < count; i++)
    {
        if (products[i].Category == kategori)
        {
            Console.WriteLine(
                "ID: " + products[i].Id +
                " | " + products[i].Name +
                " | Stock: " + products[i].Stock +
                " | Price: Rp " + products[i].Price.ToString("N0")
            );
            ada = true;
        }
    }

    if (!ada)
    {
        Console.WriteLine("Tidak ada produk dalam kategori ini.");
    }
}



}
