using SOLID.D;
using SOLID.L;
using SOLID.O;
using SOLID.S;
using System;
using System.Diagnostics;

namespace SOLID
{
    class Program
    {
        static public int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            #region Single Responsability Principle

            var j = new Journal();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename);
            Process.Start(filename);

            #endregion

            #region Open-Closed Principle

            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            Console.WriteLine("Green products (old):");
            foreach (var pfp in pf.FilterByColor(products, Color.Green))
                Console.WriteLine($" - {pfp.Name} is green");

            // ^^ BEFORE

            // vv AFTER
            var bf = new BetterFilter();
            Console.WriteLine("Green products (new):");
            foreach (var pfp in bf.Filter(products, new ColorSpecification(Color.Green)))
                Console.WriteLine($" - {pfp.Name} is green");

            Console.WriteLine("Large products");
            foreach (var pfp in bf.Filter(products, new SizeSpecification(Size.Large)))
                Console.WriteLine($" - {pfp.Name} is large");

            Console.WriteLine("Large blue items");
            foreach (var pfp in bf.Filter(products,
              new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large)))
            )
            {
                Console.WriteLine($" - {pfp.Name} is big and blue");
            }

            #endregion

            #region Liskov Substitution

            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc} has area {Area(rc)}");

            // should be able to substitute a base type for a subtype
            /*Square*/
            Rectangle sq = new Square();
            sq.Width = 4;

            Console.WriteLine($"{sq} has area {Area(sq)}");

            #endregion

            #region Interface Segregation

            #endregion

            #region Dependency Inversion

            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Matt" };

            // low-level module
            var relationships = new Relationships();
            //relationships.AddParentAndChild(parent, child1);
            //relationships.AddParentAndChild(parent, child2);

            new Research(relationships);

            #endregion

            Console.ReadKey();
        }
    }
}
