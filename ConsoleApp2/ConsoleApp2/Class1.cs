using System;
using System.Collections.Generic;

public abstract class Product
{
    public string Name { get; set; }
    public virtual decimal Price { get; set; }

    public abstract string GetInformation();

    public decimal GetDiscountedPrice()
    {
        decimal discountRate = 0.10m;
        return Price * (1 - discountRate);
    }
}

public class Toy : Product
{
    public string AgeGroup { get; set; }

    public override string GetInformation()
    {
        return $"Toy: {Name}, Price: {Price:C}, Age Group: {AgeGroup}";
    }
}

public class Meat : Product
{
    public string Cut { get; set; }

    public override string GetInformation()
    {
        return $"Meat: {Name}, Price: {Price:C}, Cut: {Cut}";
    }
}

public class Drink : Product
{
    public bool IsAlcoholic { get; set; }

    public override string GetInformation()
    {
        return $"Drink: {Name}, Price: {Price:C}, Alcoholic: {IsAlcoholic}";
    }
}

public class Electronics : Product
{
    public string WarrantyPeriod { get; set; }

    public override string GetInformation()
    {
        return $"Electronics: {Name}, Price: {Price:C}, Warranty: {WarrantyPeriod}";
    }
}

public class Clothing : Product
{
    public string Size { get; set; }

    public override string GetInformation()
    {
        return $"Clothing: {Name}, Price: {Price:C}, Size: {Size}";
    }
}

class Program2
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Toy { Name = "Action Figure", Price = 19.99m, AgeGroup = "5-10 years" },
            new Meat { Name = "Steak", Price = 29.99m, Cut = "Ribeye" },
            new Drink { Name = "Coke", Price = 1.99m, IsAlcoholic = false },
            new Electronics { Name = "Smartphone", Price = 699.99m, WarrantyPeriod = "2 years" },
            new Clothing { Name = "T-Shirt", Price = 14.99m, Size = "L" }
        };

        foreach (var product in products)
        {
            Console.WriteLine(product.GetInformation());
            Console.WriteLine($"Discounted Price: {product.GetDiscountedPrice():C}\n");
        }
    }
}