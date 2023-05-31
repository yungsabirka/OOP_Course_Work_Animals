﻿namespace OOPLAB
{
    public class Bull : Preys
    {
        public Bull()
        {
            SourceImage = "bull.png";
            Priority = 5;
            MaxSatiety = 4;
            Saturability = 8;
            RadiusOfView = 20;
            MaxSpeed = 2;
            YoungAge = 20;
        }
        public override Animals BorningChild() => new Bull();
    }
}
