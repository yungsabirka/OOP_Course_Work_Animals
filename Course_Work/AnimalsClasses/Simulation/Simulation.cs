
using Course_Work;

namespace OOPLAB;

class Simulation
{
    private readonly Statistics _statistics;
    public static event Action? Update;
    public delegate void AnimalsMove(List<GameObject>[,] map);
    public static event AnimalsMove? Move;
    private readonly int _delay;
    public static int MaxTurns { get; private set; }
    private List<GameObject>[,] _map;

    public Simulation(List<GameObject>[,] map)
    {
        _delay = 1000;
        MaxTurns = 100;
        _statistics = new Statistics(map);
        _map = map;
    }

    public async void Start(Visualisation visualisation)
    {
        while (_statistics.TurnsCount < MaxTurns)
        {
            Update.Invoke();
            Move.Invoke(_map);
            Thread.Sleep(_delay);
            await visualisation.GeneratePriorityMap();
            /* Console.Clear();*/
            _statistics.RecordStatistics();
            /*_statistics.Print();*/
        }
    }
}