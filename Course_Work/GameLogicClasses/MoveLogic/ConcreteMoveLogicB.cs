using Course_Work;

namespace OOPLAB
{
    class ConcreteMoveLogicB : IConcreteMoveLogic
    {
        void IConcreteMoveLogic.Move(List<GameObject>[,] map, Animals animal)
        {
            if (animal.target is not null && animal.Coordinate == animal.target.Coordinate)
            {
                if (animal.Satiety == animal.MaxSatiety
                    && animal.target.GetType() == animal.GetType())
                    animal.PairingAnimals(map);
                else
                    animal.Eat(map);
            }

        }
    }
}
