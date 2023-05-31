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
            newCoordinate =
                new Point(CheckCoordinateDiferences(coordinateDifferences.X), 
                CheckCoordinateDiferences(coordinateDifferences.Y));
            newCoordinate += new Size(Coordinate.X, Coordinate.Y);

            return newCoordinate;
        }

        private int CheckCoordinateDiferences(int coordinateDifferences) =>
            (MaxSpeed < Math.Abs(coordinateDifferences)) ?
                MaxSpeed * Math.Sign(coordinateDifferences) : coordinateDifferences;

    }
}
