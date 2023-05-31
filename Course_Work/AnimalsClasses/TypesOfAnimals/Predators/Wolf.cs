namespace OOPLAB
{
    public class Wolf : Predators
    {
        public Wolf()
        {
            SourceImage = "wolf.png";
            Priority = 3;
            MaxSatiety = 24;
            MaxSpeed = 3;
            RadiusOfView = 4;
            YoungAge = 19;
        }
        public override Animals BorningChild()=> new Wolf();
    }
}
