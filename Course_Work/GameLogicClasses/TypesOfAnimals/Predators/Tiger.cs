using Course_Work;

namespace OOPLAB
{
    public class Tiger : Predators
    {
        public Tiger()
        {
            SourceImage = "tiger.png";
            Priority = 2;
            MaxSatiety = 30;
            MaxSpeed = 2;
            RadiusOfView = 4;
            YoungAge = 23;
        }
        public override Animals BorningChild() => new Tiger();
    }
}
