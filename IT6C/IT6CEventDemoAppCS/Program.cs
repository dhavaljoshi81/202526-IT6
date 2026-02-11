using IT6CEventDemoAppCS;
static string LowInventoryMessage()
{
    return "Warning: Inventory is low. Please restock soon.";
}

static string OverStockInventoryMessage()
{
    return "Warning: Inventory is overstocked. Please halt further purchases.";
}

Product Laptop = new Product()
{
    Id = 1,
    Name = "Laptop",
    Price = 1500.00M,
    Quantity = 10
};

Console.WriteLine(Laptop.CurrentStock);

Laptop.LowInventory += new InventoryStatusHandler(LowInventoryMessage);

Laptop.Sell = 7; // This will not trigger the low inventory event

Console.WriteLine("After selling 7 laptops : " + Laptop.CurrentStock);

Laptop.Sell = 5; // This will trigger the low inventory event

Console.WriteLine("After selling 5 laptops : " + Laptop.CurrentStock);

Laptop.OverStockInventory += new InventoryStatusHandler(OverStockInventoryMessage);

Laptop.Purchase = 20;

Console.WriteLine("After purchasing 20 laptops : " + Laptop.CurrentStock);

Laptop.Purchase = 90;

Console.WriteLine("After purchasing 90 laptops : " + Laptop.CurrentStock);