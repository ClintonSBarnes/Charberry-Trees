CharberryTree tree = new CharberryTree();
Notifier notifier = new Notifier(tree);
Harvester harvester = new Harvester(tree);

while (true)
    tree.MaybeGrow();

public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }

    public event Action? Ripend;

    public void MaybeGrow()
    {
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripend.Invoke();
            Ripe = false;
        }
    }
}

public class Notifier
{

    public Notifier(CharberryTree tree)
    {
        tree.Ripend += OnRipe;
    }

    public void OnRipe()
    {
        Console.WriteLine("A charberry fruit has ripened!");
    }
}

public class Harvester
{

    public Harvester(CharberryTree tree)
    {
        tree.Ripend += OnRipe;
    }

    public void OnRipe()
    {
        Console.WriteLine("A charberry fruit has been harvested!");

    }
}

