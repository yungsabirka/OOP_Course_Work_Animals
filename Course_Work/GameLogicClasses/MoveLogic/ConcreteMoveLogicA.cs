using Course_Work;

namespace OOPLAB
{
    class ConcreteMoveLogicA : IConcreteMoveLogic
    {
        void IConcreteMoveLogic.Move(List<GameObject>[,] map, Animals animal)
        {
            ActionsOnMap.AddObject(animal.Coordinate, map, new ChildPoops(map));
        }
    }
}
