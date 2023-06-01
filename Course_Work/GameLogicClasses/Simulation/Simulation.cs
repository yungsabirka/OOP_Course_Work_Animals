
using Course_Work;

namespace OOPLAB;

class Simulation
{
    public Statistics Statistics;
    public static event Action? Update;
    public delegate void AnimalsMove(List<GameObject>[,] map);
    public static event AnimalsMove? Move;
    private readonly int _delay;
    object lockCells = new();
    public static int MaxTurns { get; private set; }
    private List<GameObject>[,] _map;

    public Simulation(List<GameObject>[,] map)
    {
        _delay = 200;
        MaxTurns = 300;
        Statistics = new Statistics(map);
        _map = map;
    }

    public async void Start(Visualisation visualisation)
    {
        while (Statistics.TurnsCount < MaxTurns)
        {
            lock (lockCells)
            {
                Update.Invoke();
                Move.Invoke(_map);
            }
            Thread.Sleep(_delay);
            await visualisation.GeneratePriorityMap();
            /* Console.Clear();*/
            Statistics.RecordStatistics();
            /*_statistics.Print();*/
        }
    }
}