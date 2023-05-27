namespace OOPLAB
{
    class Wolf : Predators, IFactory
    {
        public Wolf()
        {
            SourceImage = "wolf.png";
            Priority = 1;
            MaxSatiety = 24;
            MaxSpeed = 3;
            RadiusOfView = 4;
            YoungAge = 19;
        }
        public Animals BorningChild()
        {
            return new Wolf();
        }
    }
}
