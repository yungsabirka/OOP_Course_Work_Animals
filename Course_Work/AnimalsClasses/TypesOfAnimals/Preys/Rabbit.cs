namespace OOPLAB
{
    class Rabbit : Preys, IFactory
    {
        public Rabbit()
        {
            SourceImage = "rabbit.png";
            Priority = 2;
            MaxSpeed = 3;
            MaxSatiety = 1;
            Saturability = 2;
            RadiusOfView = 20;
            YoungAge = 12;
        }
        public Animals BorningChild()
        {
            return new Rabbit();
        }
    }
}
