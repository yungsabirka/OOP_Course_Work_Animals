namespace OOPLAB
{
    public class Hyena : Predators
    {
        public Hyena()
        {
            SourceImage = "fox.png";
            Priority = 4;
            MaxSatiety = 20;
            MaxSpeed = 2;
            RadiusOfView = 4;
            YoungAge = 18;
        }
        public override Animals BorningChild() => new Hyena();
    }
}
