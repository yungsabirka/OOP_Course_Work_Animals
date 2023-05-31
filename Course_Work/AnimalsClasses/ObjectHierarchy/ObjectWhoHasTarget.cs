using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace OOPLAB
{
    public abstract class ObjectWhoHasTarget : GameObject
    {
        public GameObject target;
        public int MaxSpeed { get; set; }
        public Point TargetMovement()
        {
            Point newCoordinate = new();
            Point coordinateDifferences = new()
            {
                X = target.Coordinate.X - Coordinate.X,
                Y = target.Coordinate.Y - Coordinate.Y
            };

            if (this is Preys && target is Predators)
            {
                coordinateDifferences =
                    new Point(-coordinateDifferences.X, -coordinateDifferences.Y);
            }
            if (MaxSpeed < Math.Abs(coordinateDifferences.X))
                newCoordinate.X = MaxSpeed * Math.Sign(coordinateDifferences.X);
            else
                newCoordinate.X = coordinateDifferences.X;
            if (MaxSpeed < Math.Abs(coordinateDifferences.Y))
                newCoordinate.Y = MaxSpeed * Math.Sign(coordinateDifferences.Y);
            else
                newCoordinate.Y = coordinateDifferences.Y;

            newCoordinate += new Size(Coordinate.X, Coordinate.Y);

            return newCoordinate;
        }
    }
}
