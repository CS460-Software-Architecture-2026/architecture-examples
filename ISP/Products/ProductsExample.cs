using Before = ISP.Products.Before;
using After = ISP.Products.After;
using ISP.Products.After.Labels;
using ISP.Products.After.Restocking;

namespace ISP.Products;

public class ProductsExample
{
    public void Run()
    {
        Console.WriteLine("BEFORE: both clients depend on the entire product contract");
        var before = new Before.Product("Notebook", 80m, "NB-01", 3, 10);
        new Before.LabelPrinter().Print(before);
        Console.WriteLine(new Before.RestockPlanner().Plan(before));

        Console.WriteLine();
        Console.WriteLine("AFTER: each client depends on the view it uses");
        var after = new After.Product("Notebook", 80m, "NB-01", 3, 10);
        new LabelPrinter().Print(after);
        Console.WriteLine(new RestockPlanner().Plan(after));
    }
}
