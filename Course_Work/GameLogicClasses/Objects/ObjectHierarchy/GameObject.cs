using Point = System.Drawing.Point;

namespace Course_Work
{
    public abstract class GameObject
    {
        public string SourceImage { get; set; }
        public int Saturability { get; set; }
        public Point Coordinate { get; set; }

        public int Priority { get; set; }

    }
}