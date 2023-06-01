using Course_Work;
using Point = System.Drawing.Point;

namespace OOPLAB
{
    abstract class Direction
    {
        public static Point ChangeDirection(Point newCoordinate, List<GameObject>[,] map)
        {
            if (newCoordinate.X >= map.GetLength(0))
                newCoordinate.X -= 2;
            if (newCoordinate.X < 0)
                newCoordinate.X += 2;
            if (newCoordinate.Y >= map.GetLength(1))
                newCoordinate.Y -= 2;
            if (newCoordinate.Y < 0)
                newCoordinate.Y += 2;
            return newCoordinate;
        }
        public static Point RandomDirection()
        {
            Point movePoint = new Point(0, 0);
            Random random = new Random();
            while (movePoint.IsEmpty)
            {
                movePoint.X = random.Next(-1, 2);
                movePoint.Y = random.Next(-1, 2);
            }
            return movePoint;
        }
    }
}
