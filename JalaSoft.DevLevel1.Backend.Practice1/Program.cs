int option;

do
{
    Console.WriteLine("############### WELCOME TO ITALIAN RESTAURANT ###############\n");
    Console.WriteLine("1. New orders");
    Console.WriteLine("2. Exit\n");
    option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            MakeOrders();
            break;
        default:
            break;
    }

} while (option != 2);

static void MakeOrders()
{
    int count = 0;
    string name = string.Empty;
    string paymentMethod = string.Empty;

    while (count != 5)
    {
        Console.WriteLine("######## New Order ##########");
        Console.Write("Please, enter your name: ");
        name = Console.ReadLine();

        Console.WriteLine(" _________________________");
        Console.WriteLine("|        Dishes           |");
        Console.WriteLine("|   1. Spaghetti $10.99   |");
        Console.WriteLine("|   2. Lasagna $12.99     |");
        Console.WriteLine("|   3. Pizza $8           |");
        Console.WriteLine("|   4. Calzone $6         |");
        Console.WriteLine("|_________________________|");
        Console.WriteLine("|       Beverages         |");
        Console.WriteLine("|   5. Soda $6.5          |");
        Console.WriteLine("|   6. Wine $9            |");
        Console.WriteLine("|   7. Beer $7.5          |");
        Console.WriteLine("|_________________________|");
        Console.WriteLine("|   8. ORDER              |");
        Console.WriteLine("|_________________________|\n");
        Console.Write("Select items: ");
        List<int> itemsSelected = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
        Console.WriteLine(" ____________________");
        Console.WriteLine("|    a) Cash         |");
        Console.WriteLine("|    b) Card         |");
        Console.WriteLine("|____________________|\n");
        Console.Write("Select payment method: ");
        paymentMethod = Console.ReadLine();

        Console.WriteLine(" --------------------------------------------------------");
        Console.WriteLine("|    Delivering Order {0} - Customer {1}\n", count + 1, name);
        calc(itemsSelected);
        Console.WriteLine(paymentMethod == "a" ? "|    Payment method: Cash" : "|     Payment method: Card");
        Console.WriteLine("|________________________________________________________|");
        count++;
    }

}

static void calc(List<int> items)
{
    string[] list = { "Spaghetti", "Lasagna", "Pizza", "Calzone", "Soda", "Wine", "Beer" };
    double[] prices = { 10.99, 12.99, 8, 6, 6.5,9, 7.5};

    int[] array = { 1, 2, 3, 4, 5, 6, 7 };
    int[] arrAux = new int[7];
    double[] result = new double[7];
    foreach(int i in array)
    {
        foreach (int j in items) {
            if (i == j)
            {
                arrAux[i - 1]++;
            }
        }
    }

    for(int x = 0; x < 7; x++)
    {
        result[x] = arrAux[x] * prices[x];
        if (result[x] > 0)
        {
            Console.WriteLine("|        " + list[x] + " (" + arrAux[x]+ ") " + "$" + result[x]);
        }
        if(x == 6)
        {
            double total = result.Sum();
            Console.WriteLine("\n|        El precio total es {0:N2}\n", total);
        }
    }

}
