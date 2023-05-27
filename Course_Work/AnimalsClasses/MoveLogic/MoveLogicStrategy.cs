using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace OOPLAB
{
    class MoveLogicStrategy
    {
        private IConcreteMoveLogic? _concreteMoveLogic;

        public void SetConcreteStrategy(IConcreteMoveLogic concreteMoveLogic)
        {
            _concreteMoveLogic = concreteMoveLogic;
        }

        public void MoveStrategy(List<GameObject>[,] map, Animals animal)
        {
            if (animal.DeadlyHungerLevel)
            {
                ActionsOnMap.DeleteObject(map, animal);
                return;
            }
            animal.target = null;
            if (!map[animal.Coordinate.X, animal.Coordinate.Y].Contains(animal))
                return;

            if (animal.Age < animal.YoungAge)
                animal.SetStragetyForView(new CheckTargetForChild());
            else if (animal is Preys)
                animal.SetStragetyForView(new CheckTargetForPreys());
            else
                animal.SetStragetyForView(new CheckTargetForPredators());

            animal.CheckAround(map);
            Point newCoordinate;
            var movedObject = ActionsOnMap.DeleteObject(map, animal);

            if (animal.target is not null)
                newCoordinate = animal.TargetMovement();
            else
            {
                var random = Direction.RandomDirection();
                newCoordinate = random;
                newCoordinate += new Size(animal.Coordinate.X, animal.Coordinate.Y);
            }
            while (!animal.InsideBound(newCoordinate, map))
                newCoordinate = Direction.ChangeDirection(newCoordinate, map);

            ActionsOnMap.AddObject(newCoordinate, map, animal);

            if (_concreteMoveLogic is not null)
                _concreteMoveLogic.Move(map, animal);

        }
    }
}
