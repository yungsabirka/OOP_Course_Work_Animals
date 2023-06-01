namespace OOPLAB;

public class TurnInfo
{
    public int TurnNumber { get; set; }
    private int _animalsCount;
    public int AnimalsCount
    {
        get => _animalsCount = PredatorsCount + PreysCount;
        private set => _animalsCount = value;
    }
    public int ChildPoopsCount { get; set; }
    public int PreysCount { get; set; }
    public int GrassEatenCount { get; set; }
    public int GrassGrowCount { get; set; }
    public  int PredatorsCount { get; set; }
    public Dictionary<Type, int> PreySpecietyCounter;
    public Dictionary<Type, int> PredatorSpecietyCounter;

    
    public TurnInfo()
    {
        TurnNumber = 0;
        AnimalsCount = 0;
        PreysCount = 0;
        PredatorsCount = 0;
        PreySpecietyCounter = new Dictionary<Type, int>();
        PredatorSpecietyCounter = new Dictionary<Type, int>();
    }
}