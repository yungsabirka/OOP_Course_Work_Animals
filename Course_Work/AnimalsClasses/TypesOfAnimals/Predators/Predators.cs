namespace OOPLAB
{
    abstract class Predators : Animals
    {
        private GameObject EatingTarget(List<GameObject>[,] map)
        {
            if (target is not null)
                if (!map[Coordinate.X, Coordinate.Y].Contains(target))
                    target = null;
                else if (target is ChildPoops)
                {
                    Random chance = new Random();
                    if (chance.Next(0, 6) == 0)
                        ActionsOnMap.DeleteObject(map, target);
                }
                else
                    ActionsOnMap.DeleteObject(map, target);

            return target;
        }

        public override void Eat(List<GameObject>[,] map)
        {
            var food = EatingTarget(map);
            if (food != null)
                Satiety += food.Saturability;
            target = null;
        }
    }
}
