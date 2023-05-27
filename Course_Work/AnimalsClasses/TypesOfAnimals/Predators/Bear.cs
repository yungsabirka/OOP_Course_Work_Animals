namespace OOPLAB
{
    class Bear : Predators, IFactory
    {

        public Bear()
        {
            SourceImage = "bear.png";
            Priority = 1;
            MaxSatiety = 40;
            MaxSpeed = 2;
            RadiusOfView = 3;
            YoungAge = 20;
        }

        public Animals BorningChild()
        {
            return new Bear();
        }
    }
}
