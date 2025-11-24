using System;

public interface IChair
{
    void SitOn();
    void HasLegs();
}

public interface ISofa
{
    void LieOn();
    void HasCushions();
}

public interface ICoffeeTable
{
    void PutCup();
    void GetMaterial();
}

public class VictorianChair : IChair
{
    public void SitOn() => Console.WriteLine("Сидим на викторианском стуле с резьбой");
    public void HasLegs() => Console.WriteLine("Викторианский стул: 4 резные ножки");
}

public class VictorianSofa : ISofa
{
    public void LieOn() => Console.WriteLine("Лежим на роскошном викторианском диване");
    public void HasCushions() => Console.WriteLine("Викторианский диван: бархатные подушки");
}

public class VictorianCoffeeTable : ICoffeeTable
{
    public void PutCup() => Console.WriteLine("Ставим чашку на викторианский журнальный столик");
    public void GetMaterial() => Console.WriteLine("Викторианский столик: красное дерево");
}

public class ModernChair : IChair
{
    public void SitOn() => Console.WriteLine("Сидим на современном эргономичном стуле");
    public void HasLegs() => Console.WriteLine("Современный стул: хромированные ножки");
}

public class ModernSofa : ISofa
{
    public void LieOn() => Console.WriteLine("Расслабляемся на современном угловом диване");
    public void HasCushions() => Console.WriteLine("Современный диван: кожаные подушки");
}

public class ModernCoffeeTable : ICoffeeTable
{
    public void PutCup() => Console.WriteLine("Ставим чашку на стеклянный современный столик");
    public void GetMaterial() => Console.WriteLine("Современный столик: стекло и металл");
}

public interface IFurnitureFactory
{
    IChair CreateChair();
    ISofa CreateSofa();
    ICoffeeTable CreateCoffeeTable();
}

public class VictorianFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair() => new VictorianChair();
    public ISofa CreateSofa() => new VictorianSofa();
    public ICoffeeTable CreateCoffeeTable() => new VictorianCoffeeTable();
}

public class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair() => new ModernChair();
    public ISofa CreateSofa() => new ModernSofa();
    public ICoffeeTable CreateCoffeeTable() => new ModernCoffeeTable();
}

public class FurnitureStore
{
    private readonly IChair _chair;
    private readonly ISofa _sofa;
    private readonly ICoffeeTable _coffeeTable;

    public FurnitureStore(IFurnitureFactory factory)
    {
        _chair = factory.CreateChair();
        _sofa = factory.CreateSofa();
        _coffeeTable = factory.CreateCoffeeTable();
    }

    public void DisplayFurniture()
    {
        Console.WriteLine("\n=== КОМПЛЕКТ МЕБЕЛИ ===");
        _chair.SitOn();
        _chair.HasLegs();

        _sofa.LieOn();
        _sofa.HasCushions();

        _coffeeTable.PutCup();
        _coffeeTable.GetMaterial();
    }
}
