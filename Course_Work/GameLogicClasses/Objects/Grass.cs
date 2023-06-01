using Course_Work;
using OOPLAB;

namespace Course_Work;

class Grass : GameObject
{
    public bool IsGrown { get; private set; }
    public int _growRate;

    public int GrowRate
    {
        get { return _growRate; }
        set
        {
            _growRate = value;
            if (_growRate > 10)
                _growRate = 10;
        }
    }
    public Grass()
    {
        SourceImage = "grass.png";
        Priority = 10;
        Saturability = 1;
        IsGrown = true;
        GrowRate = 10;
        Simulation.Update += Grow;
    }

    public void Eaten()
    {
        IsGrown = false;
        GrowRate = 0;
        SourceImage = "bad_grass.png";
    }

    private void Grow()
    {
        if (IsGrown == false)
        {
            GrowRate++;
            if (GrowRate == 10)
            {
                IsGrown = true;
                SourceImage = "grass.png";
            }
        }
    }
}

