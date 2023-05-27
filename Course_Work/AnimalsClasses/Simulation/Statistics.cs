using System.Collections;

namespace OOPLAB;

class Statistics : IEnumerable<TurnInfo>
{
    private readonly List<TurnInfo> _turnsCollection;
    public int TurnsCount { get; private set; }
    private readonly List<GameObject>[,] _map;

    public TurnInfo CurrentTurnInfo => this[TurnsCount - 1];

    public Statistics(List<GameObject>[,] map)
    {
        Simulation.Update += RecordStatistics;
        _map = map;
        TurnsCount = 0;
        _turnsCollection = new List<TurnInfo>();
    }
    public IEnumerator<TurnInfo> GetEnumerator() => _turnsCollection.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _turnsCollection.GetEnumerator();
    
    public TurnInfo this[int index]
    {
        get => _turnsCollection[index];
        private set => _turnsCollection[index] = value;
    }
    
    public void RecordStatistics()
    {
        TurnsCount++;
        _turnsCollection.Add(new TurnInfo());
        this[TurnsCount - 1].TurnNumber = TurnsCount;
        CountPredators();
        CountPreys();
    }
    
    private int CountPredators()
    {
        foreach (var cell in _map)
        {
            foreach (var animal in cell)
            {
                if (animal is Predators)
                {
                    this[TurnsCount-1].PredatorSpecietyCounter.TryAdd(animal.GetType(), 0);
                    this[TurnsCount-1].PredatorSpecietyCounter[animal.GetType()]++;
                    this[TurnsCount-1].PredatorsCount++;
                }
            }
        }

        return this[TurnsCount-1].PredatorsCount;
    }

    private int CountPreys()
    {
        foreach (var cell in _map)
        {
            foreach (var animal in cell)
            {
                if (animal is Preys)
                {
                    this[TurnsCount-1].PreySpecietyCounter.TryAdd(animal.GetType(), 0);
                    this[TurnsCount-1].PreySpecietyCounter[animal.GetType()]++;
                    this[TurnsCount-1].PreysCount++;
                }
            }
        }

        return this[TurnsCount-1].PreysCount;
    }

    public bool ContainsPredatorCount(int count)
    {
        foreach (var turn in this)
        {
            if (turn.PredatorsCount == count)
                return true;
        }

        return false;
    }
    
    public bool ContainsPreyCount(int count)
    {
        foreach (var turn in this)
        {
            if (turn.PreysCount == count)
                return true;
        }

        return false;
    }
    
}