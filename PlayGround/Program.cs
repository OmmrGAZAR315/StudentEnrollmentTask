namespace PlayGround
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Source.ProductList;
            var customerList = Source.CustomerList;
            //Q1
            var top3 = list.OrderByDescending(p => p.UnitPrice).Take(3).ToArray();
            foreach (var VARIABLE in top3) Console.WriteLine(VARIABLE.ProductName);
            //Q2
            var v = list.Skip(5).Take(5).ToArray();
            //Q3
            var q3 = list.TakeWhile(p => p.UnitPrice < 25)
                .OrderBy(p => p.UnitPrice)
                .ToArray();
            //Q4
            var q4 = list.All(p => p is { Category: "Seafood", UnitsInStock: > 0 });
            Console.WriteLine(q4);
            //Q5
            int[] ids = { 3, 9, 13, 18 };
            var q5 = ids.Contains(9);
            Console.WriteLine(q5);

            //Q6
            var t = list.GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Category, x => x.Count);
            foreach (var VARIABLE in t)
            {
                Console.WriteLine(VARIABLE.Key + " : " + VARIABLE.Value);
            }

            //Q7
            var q7 = list.GroupBy(p => new { p.Category, p.ProductName })
                .ToArray();
            foreach (var VARIABLE in q7)
            {
                Console.WriteLine(VARIABLE.Key.Category + " : " + VARIABLE.Key.ProductName);
            }

            //Q8
            var q8 = list.GroupBy(p => p.Category)
                .Where(g => g.Count() > 3)
                .ToArray();
            foreach (var VARIABLE in q8)
            {
                Console.WriteLine(VARIABLE.Key);
            }

            //q9
            var q9 = from p in customerList
                group p by p.Country
                into g
                select new
                {
                    Country = g.Key, Count = g.Count(),
                    TotalOrderValue = (from c in g
                        from order in c.Orders
                        select order.Total).Sum(),
                    TotalOrderValue2 = g.SelectMany(c => c.Orders)
                        .Sum(o => o.Total)
                };
            foreach (var VARIABLE in q9)
            {
                Console.WriteLine(VARIABLE.Country + " : " + VARIABLE.Count + " : " + VARIABLE.TotalOrderValue);
            }

            //Q10
            var q10 = list.Sum(p => p.UnitPrice);
            Console.WriteLine(q10);
            //Q11
            var q11 = list.Min(p => p.UnitPrice);
            var q111 = list.Max(p => p.UnitPrice);
            Console.WriteLine(q11);
            Console.WriteLine(q111);
            //Q12
            var q12 = list.Select(p => p.ProductName).Distinct().ToArray();
            foreach (var VARIABLE in q12)
            {
                Console.WriteLine(VARIABLE);
            }

            //Q13
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };
            var q13 = setA.Except(setB);
            foreach (var VARIABLE in q13)
            {
                Console.WriteLine(VARIABLE);
            }

            //Q14
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };
            var q14 = list1.Except(list2, StringComparer.OrdinalIgnoreCase);
            foreach (var VARIABLE in q14)
            {
                Console.WriteLine(VARIABLE);
            }

            //Q15
            Dictionary<int, Product> productDic =
                list
                    .Where(p => p.ProductID == 18)
                    .GroupBy(p => p.ProductID)
                    .ToDictionary(g => g.Key, g => g.First());
            Console.WriteLine(productDic[18].ProductName);
            
            //Q16
            var q16 = list.First(p => p.UnitPrice > 50);
            Console.WriteLine(q16.ProductName);
            //Q17
            var q17 = list.FirstOrDefault(p => p.UnitPrice > 500);
            //Q18
            var q18 = Enumerable.Range(1, 10).Select(i => $"7 x {i} = {i * 7}").ToArray();
            foreach (var VARIABLE in q18)
                Console.WriteLine(VARIABLE);
            //Q19
            var q19 = Enumerable.Range(1, 30).Where(i=>i%2==0).ToArray();
            foreach (var VARIABLE in q19)
                Console.WriteLine(VARIABLE);

            Console.WriteLine("----------");
            //Q20
            var concated = list.Take(3).Select(p=>p.ProductName).Concat(customerList.Take(3).Select(c=>c.CustomerName)).ToArray();

            foreach (var s in concated)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("#####");
            //Q21
            var zipped = list.Zip(customerList, (p, c) => new { Product = p, Customer = c });
            foreach (var VARIABLE in zipped)
            {
                Console.WriteLine(VARIABLE.Product.ProductName + " Sold To " + VARIABLE.Customer.CustomerID);
            }
            
        }
    }
}