using System.Collections;
using Course_Work;

namespace OOPLAB;

public class Statistics : IEnumerable<TurnInfo>
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
        CountGrass();
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
    private void CountGrass()
    {
        foreach(var cell in _map)
        {
            foreach( var grass in cell)
            {
                if (grass is Grass grassTemp)
                {
                    if (grassTemp.GrowRate < 10)
                        this[TurnsCount - 1].GrassEatenCount++;
                    if (grassTemp.GrowRate == 10)
                        this[TurnsCount - 1].GrassGrowCount++;
                }
            }
        }
    }
    
}