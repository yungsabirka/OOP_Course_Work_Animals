
using Course_Work;

namespace OOPLAB;

class Simulation
{
    public Statistics Statistics;
    public static event Action? Update;
    public delegate void AnimalsMove(List<GameObject>[,] map);
    public static event AnimalsMove? Move;
    public bool isSimulationContinuing = true;
    private readonly int _delay;
    object lockCells = new();
    public static int MaxTurns { get; private set; }
    private List<GameObject>[,] _map;

    public Simulation(List<GameObject>[,] map, int stepsAmount)
    {
        _delay = 200;
        MaxTurns = stepsAmount;
        Statistics = new Statistics(map);
        _map = map;
    }

    public async void Start(Visualisation visualisation)
    {
        while (Statistics.TurnsCount < MaxTurns && isSimulationContinuing)
        {
            await visualisation.GeneratePriorityMap();
            Thread.Sleep(_delay);
            lock (lockCells)
            {
                Update.Invoke();
                Move.Invoke(_map);
            }
            Statistics.RecordStatistics();
        }
    }
}