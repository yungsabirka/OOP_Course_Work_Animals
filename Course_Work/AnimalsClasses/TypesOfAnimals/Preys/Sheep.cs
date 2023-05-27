namespace OOPLAB
{
    class Sheep : Preys, IFactory
    {
        public Sheep()
        {
            SourceImage = "sheep.png";
            Priority = 2;
            MaxSatiety = 2;
            Saturability = 4;
            RadiusOfView = 20;
            MaxSpeed = 2;
            YoungAge = 12;
        }
        public Animals BorningChild()
        {
            return new Sheep();
        }
    }
}
