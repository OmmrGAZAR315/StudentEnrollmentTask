namespace PlayGround
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Source.ProductList;

            //Q1
            var result = list.Where(p => p.Category == "Seafood")
                .Select(p => new { p.ProductName, p.UnitPrice });
            foreach (var p in result)
                Console.WriteLine(p);

            //Q2
            var result2 = list.Select(p => new { p.ProductName });
            foreach (var p in result2)
                Console.WriteLine(p);

            //Q3
            var result3 = list.OrderBy(p => p.UnitPrice)
                .Select(p => new { p.ProductName, p.UnitPrice });
            foreach (var p in result3)
                Console.WriteLine(p);

            //Q4
            var result4 = list.Where(p => 30 > p.UnitPrice && p.UnitPrice > 10);
            foreach (var p in result4)
                Console.WriteLine(p);

            //Q5
            var result5 = list.Where(p => p.UnitsInStock > 0)
                .Where(p => p.Category == "Condiments");
            foreach (var p in result5)
                Console.WriteLine(p);

            //Q6
            var result6 = list.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                Stock = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var p in result6)
                Console.WriteLine(p);

            //Q7
            var result7 = list.Select((p, i) => "Product " + (i + 1) + ": " + p.ProductName);
            foreach (var p in result7)
                Console.WriteLine(p);

            //Q8
            var result8 = list.OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);
            foreach (var p in result8)
                Console.WriteLine(p);

            //Q9
            var result9 = list.Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitPrice)
                .Select(p => new { p.ProductName, p.UnitsInStock });
            foreach (var p in result9)
                Console.WriteLine(p);

            //Q10
            var customers = Source.CustomerList;
            var result10 =
                from c in customers
                from o in c.Orders
                where o.OrderDate >= new DateTime(1997, 1, 1)
                select new { c.CustomerID, o.OrderDate };
            foreach (var p in result10)
                Console.WriteLine(p);

            var result11 = list.Select((p, i) => $"(i+1) {p.ProductName}");
            foreach (var p in result11)
                Console.WriteLine(p);

            String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            Arr.OrderBy(a => a.Length).ThenBy(a => a, StringComparer.OrdinalIgnoreCase);

            foreach (var s in Arr)
                Console.WriteLine(s);
            
            string[] digits = { "zero", "one", "two", "three", "four",
                "five", "six", "seven", "eight", "nine" };
            var result12 = digits.Where(d => d[1] == 'i').Reverse();
            foreach (var d in result12)
                Console.WriteLine(d);
        }
    }
}