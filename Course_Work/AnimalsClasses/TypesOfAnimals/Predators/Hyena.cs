namespace OOPLAB
{
    class Hyena : Predators, IFactory
    {
        public Hyena()
        {
            SourceImage = "fox.png";
            Priority = 1;
            MaxSatiety = 20;
            MaxSpeed = 3;
            RadiusOfView = 4;
            YoungAge = 18;
        }
        public Animals BorningChild()
        {
            return new Hyena();
        }
    }
}
