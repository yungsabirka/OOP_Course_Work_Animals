namespace OOPLAB
{
    class Tiger : Predators, IFactory
    {
        public Tiger()
        {
            SourceImage = "tiger.png";
            Priority = 1;
            MaxSatiety = 30;
            MaxSpeed = 3;
            RadiusOfView = 4;
            YoungAge = 23;
        }
        public Animals BorningChild()
        {
            return new Tiger();
        }
    }
}
