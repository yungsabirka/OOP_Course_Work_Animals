namespace OOPLAB
{
    public class Tiger : Predators
    {
        public Tiger()
        {
            SourceImage = "tiger.png";
            Priority = 2;
            MaxSatiety = 30;
            MaxSpeed = 3;
            RadiusOfView = 4;
            YoungAge = 23;
        }
        public override Animals BorningChild() => new Tiger();
    }
}
