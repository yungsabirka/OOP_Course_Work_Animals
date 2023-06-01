using Course_Work;

namespace OOPLAB
{
    public class Sheep : Preys
    {
        public Sheep()
        {
            SourceImage = "sheep.png";
            Priority = 7;
            MaxSatiety = 2;
            Saturability = 4;
            RadiusOfView = 20;
            MaxSpeed = 1;
            YoungAge = 12;
        }
        public override Animals BorningChild() => new Sheep();
    }
}
