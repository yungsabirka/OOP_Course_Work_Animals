
using Course_Work;

namespace OOPLAB;

class Simulation
{
    private readonly Statistics _statistics;
    public static event Action? Update;
    public static event Action? Generate;
    public delegate void AnimalsMove(List<GameObject>[,] map);
    public static event AnimalsMove? Move;
    private readonly int _delay;
    public static int MaxTurns { get; private set; }
    private List<GameObject>[,] _map;

    public Simulation(List<GameObject>[,] map)
    {
        _delay = 500;
        MaxTurns = 200;
        _statistics = new Statistics(map);
        _map = map;
    }

    public void Start()
    {
        while (_statistics.TurnsCount < MaxTurns)
        {
            Update.Invoke();
            Move.Invoke(_map);
            /*Generate.Invoke();*/
            Thread.Sleep(_delay);
            
            /* Console.Clear();*/
            _statistics.RecordStatistics();
            /*_statistics.Print();*/
        }
    }
}