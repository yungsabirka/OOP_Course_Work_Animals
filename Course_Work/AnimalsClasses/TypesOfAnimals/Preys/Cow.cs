namespace OOPLAB
{
    public class Cow : Preys
    {
        public Cow()
        {
            SourceImage = "cow.png";
            Priority = 6;
            MaxSatiety = 3;
            Saturability = 5;
            RadiusOfView = 20;
            MaxSpeed = 1;
            YoungAge = 10;
        }
        public override Animals BorningChild() => new Cow();
    }
}
