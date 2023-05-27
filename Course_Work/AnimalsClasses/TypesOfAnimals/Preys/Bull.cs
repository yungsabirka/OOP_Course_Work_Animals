namespace OOPLAB
{
    class Bull : Preys, IFactory
    {
        public Bull()
        {
            SourceImage = "bull.png";
            Priority = 2;
            MaxSatiety = 4;
            Saturability = 8;
            RadiusOfView = 20;
            MaxSpeed = 2;
            YoungAge = 20;
        }
        public Animals BorningChild()
        {
            return new Bull();
        }
    }
}
