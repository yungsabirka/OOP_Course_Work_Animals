namespace OOPLAB
{
    class Cow : Preys, IFactory
    {
        public Cow()
        {
            SourceImage = "cow.png";
            Priority = 2;
            MaxSatiety = 3;
            Saturability = 5;
            RadiusOfView = 20;
            MaxSpeed = 2;
            YoungAge = 10;
        }
        public Animals BorningChild()
        {
            return new Cow();
        }
    }
}
