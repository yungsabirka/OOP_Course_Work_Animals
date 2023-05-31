using Point = System.Drawing.Point;

namespace OOPLAB
{
    public abstract class GameObject
    {
        public string SourceImage { get; set; }
        public int Saturability { get; set; }
        public Point Coordinate { get; set; }

        public int Priority { get; set; }

    }
}