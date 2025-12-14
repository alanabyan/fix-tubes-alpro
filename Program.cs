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
    static Product[] products_0206 = new Product[50];

    static int count_0206 = 0;

    static int nextId_0206 = 1;

    static string[] categories_0206 = { "Mainan", "Baju", "Lainnya" };

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

            int choice_0206 = 0;

            try
            {
                choice_0206 = int.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nInput harus berupa angka!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            Console.Clear();

            switch (choice_0206)
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

        if (count_0206 == 0)
        {
            Console.WriteLine("Tidak ada produk yang tersedia");
            return;
        }

        for (int i_0206 = 0; i_0206 < count_0206; i_0206++)
        {
            var p_0206 = products_0206[i_0206];
            Console.WriteLine($"ID: {p_0206.Id} | {p_0206.Name} | Category: {p_0206.Category} | Stock: {p_0206.Stock} | Price: Rp {p_0206.Price:N0}");
        }
    }

    static void AddProduct()
    {
        Console.WriteLine("--- ADD PRODUCT ---");

        int id = nextId_0206++;

        string name_0206;
        while (true)
        {
            Console.Write("Enter product name: ");
            name_0206 = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(name_0206))
                break;

            Console.WriteLine("Nama tidak boleh kosong! Coba lagi.\n");
        }

        int stock_0206;
        while (true)
        {
            Console.Write("Enter stock: ");
            string stockInput_0206 = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(stockInput_0206))
            {
                Console.WriteLine("Stock tidak boleh kosong!\n");
                continue;
            }

            try
            {
                stock_0206 = int.Parse(stockInput_0206);
                if (stock_0206 < 0)
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

        decimal price_0206;
        while (true)
        {
            Console.Write("Enter price: ");
            string priceInput_0206 = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(priceInput_0206))
            {
                Console.WriteLine("Harga tidak boleh kosong!\n");
                continue;
            }

            try
            {
                price_0206 = decimal.Parse(priceInput_0206);
                if (price_0206 < 0)
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

        int catIndex_0206 = -1;

        while (true)
        {
            Console.WriteLine("\nChoose Category:");
            for (int i_0206 = 0; i_0206 < categories_0206.Length; i_0206++)
            {
                Console.WriteLine($"{i_0206 + 1}. {categories_0206[i_0206]}");
            }

            Console.Write("Enter category (1 - " + categories_0206.Length + "): ");
            string input_0206 = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(input_0206))
            {
                Console.WriteLine("Input kategori tidak boleh kosong!\n");
                continue;
            }

            switch (input_0206)
            {
                case "1":
                    catIndex_0206 = 0;
                    break;
                case "2":
                    catIndex_0206 = 1;
                    break;
                case "3":
                    catIndex_0206 = 2;
                    break;
                default:
                    Console.WriteLine("Kategori tidak valid! Coba lagi.\n");
                    continue;
            }

            break;
        }

        products_0206[count_0206++] = new Product
        {
            Id = id,
            Name = name_0206,
            Stock = stock_0206,
            Price = price_0206,
            Category = categories_0206[catIndex_0206]
        };

        Console.WriteLine("\nProduct berhasil ditambahkan!\n");
    }




    static void EditProduct()
    {
        Console.Clear();
        Console.WriteLine("---EDIT PRODUCT---\n");

        if (count_0206 == 0)
        {
            Console.WriteLine("Belum ada data produk!");
            return;
        }

        ShowAll();
        Console.WriteLine();

        int id_0206;
        while (true)
        {
            try
            {
                Console.Write("Masukkan ID Product yang ingin diubah: ");
                id_0206 = int.Parse(Console.ReadLine()!);
                break;
            }
            catch
            {
                Console.WriteLine("Input harus berupa angka! Coba lagi.");
            }
        }

        int index_0206 = -1;
        for (int i_0206 = 0; i_0206 < count_0206; i_0206++)
        {
            if (products_0206[i_0206].Id == id_0206)
            {
                index_0206 = i_0206;
                break;
            }
        }

        if (index_0206 == -1)
        {
            Console.WriteLine("Product dengan ID tersebut tidak ditemukan!");
            return;
        }


        Console.WriteLine("\nData Produk Saat Ini:");
        Console.WriteLine($"Nama     : {products_0206[index_0206].Name}");
        Console.WriteLine($"Stock    : {products_0206[index_0206].Stock}");
        Console.WriteLine($"Harga    : {products_0206[index_0206].Price}");
        Console.WriteLine($"Kategori : {products_0206[index_0206].Category}\n");

        Console.WriteLine("Masukkan data baru (Enter untuk skip):");

        Console.Write("Nama Baru: ");
        string input_0206 = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(input_0206))
            products_0206[index_0206].Name = input_0206;


        while (true)
        {
            Console.Write("Stock Baru: ");
            input_0206 = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(input_0206)) break;

            try
            {
                products_0206[index_0206].Stock = int.Parse(input_0206);
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
            input_0206 = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(input_0206)) break;

            try
            {
                products_0206[index_0206].Price = decimal.Parse(input_0206);
                break;
            }
            catch
            {
                Console.WriteLine("Harga harus berupa angka!");
            }
        }

        Console.WriteLine("\nPilih Kategori Baru (Enter untuk skip):");

        for (int i_0206 = 0; i_0206 < categories_0206.Length; i_0206++)
            Console.WriteLine($"{i_0206 + 1}. {categories_0206[i_0206]}");

        Console.Write("Input Pilihan Category: ");

        input_0206 = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(input_0206))
        {
            try
            {
                int catChoice = int.Parse(input_0206);
                if (catChoice >= 1 && catChoice <= categories_0206.Length)
                {
                    products_0206[index_0206].Category = categories_0206[catChoice - 1];
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

        if (count_0206 == 0)
        {
            Console.WriteLine("Tidak ada product untuk dihapus");
            return;
        }

        ShowAll();
        Console.WriteLine();

        int id_0206;
        while (true)
        {
            Console.Write("Input ID produk yang ingin dihapus: ");

            try
            {
                id_0206 = int.Parse(Console.ReadLine()!);
                break;
            }
            catch
            {
                Console.WriteLine("ID harus berupa angka!");
            }
        }
        int index_0206 = -1;
        for (int i_0206 = 0; i_0206 < count_0206; i_0206++)
        {
            if (products_0206[i_0206].Id == id_0206)
            {
                index_0206 = i_0206;
                break;
            }
        }
        if (index_0206 == -1)
        {
            Console.WriteLine("Produk dengan ID tersebut tidak ditemukan");
            return;
        }
        for (int i = index_0206; i < count_0206 - 1; i++)
        {
            products_0206[i] = products_0206[i + 1];
        }

        count_0206--;

        Console.WriteLine("Produk berhasil dihapus!");
    }

    static void SearchProduct()
    {
        Console.Write("Enter keyword: ");
        string keyword_0206 = Console.ReadLine()!.ToLower();

        var results_0206 = products_0206
            .Where(p_0206 => p_0206 != null && p_0206.Name.ToLower().Contains(keyword_0206))
            .ToList();

        if (!results_0206.Any())
        {
            Console.WriteLine("No products found!");
            return;
        }

        Console.WriteLine("\n--- SEARCH RESULTS ---");
        foreach (var p_0206 in results_0206)
            Console.WriteLine($"ID: {p_0206.Id}, {p_0206.Name}, Category: {p_0206.Category}, Rp {p_0206.Price:N0}");
    }

    static void FilterByCategory()
    {
        Console.WriteLine("--- FILTER BY CATEGORY ---\n");

        if (count_0206 == 0)
        {
            Console.WriteLine("Tidak ada produk dalam sistem.");
            return;
        }


        for (int i_0206 = 0; i_0206 < categories_0206.Length; i_0206++)
        {
            Console.WriteLine(i_0206 + 1 + ". " + categories_0206[i_0206]);
        }

        int pilih_0206 = 0;
        bool inputValid_0206 = false;


        while (!inputValid_0206)
        {
            Console.Write("\nPilih kategori (1 - " + categories_0206.Length + "): ");

            try
            {
                pilih_0206 = int.Parse(Console.ReadLine()!);


                if (pilih_0206 < 1 || pilih_0206 > categories_0206.Length)
                {
                    Console.WriteLine(" Pilihan tidak tersedia, silakan pilih sesuai nomor kategori.");
                }
                else
                {
                    inputValid_0206 = true;
                }
            }
            catch
            {
                Console.WriteLine(" Input harus berupa angka!");
            }
        }

        string kategori_0206 = categories_0206[pilih_0206 - 1];
        bool ada_0206 = false;

        Console.WriteLine("\n--- Produk kategori: " + kategori_0206 + " ---\n");

        for (int i_0206 = 0; i_0206 < count_0206; i_0206++)
        {
            if (products_0206[i_0206].Category == kategori_0206)
            {
                Console.WriteLine(
                    "ID: " + products_0206[i_0206].Id +
                    " | " + products_0206[i_0206].Name +
                    " | Stock: " + products_0206[i_0206].Stock +
                    " | Price: Rp " + products_0206[i_0206].Price.ToString("N0")
                );
                ada_0206 = true;
            }
        }

        if (!ada_0206)
        {
            Console.WriteLine("Tidak ada produk dalam kategori ini.");
        }
    }
}
