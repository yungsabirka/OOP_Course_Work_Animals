namespace OOPLAB
{
    abstract class ObjectWhoCanPairing : ObjectWhoCanEat
    {

        public void PairingAnimals(List<GameObject>[,] map)
        {
            var obj = (Animals)target;
            obj.Satiety = 0;
            obj.target = null;
            Satiety = 0;
            target = null;

            Borning(map);
        }
        public bool PairingTargetTest(GameObject target)
        {
            if (Satiety == MaxSatiety)
            {
                if (target is not null)
                {
                    if (GetType() == target.GetType() && !ReferenceEquals(this, target))
                    {
                        var pairingTarget = (Animals)target;
                        return pairingTarget.Satiety == MaxSatiety;
                    }
                }
            }
            return false;
        }
        private void Borning(List<GameObject>[,] map)
        {
            var Factory = new FactoryOnBorningAnimals();
            Factory.SetFather((Animals)this);
            Random chanceOfTwins = new Random();
            int numberOfChild;

            if (this is Predators || (this is Preys && chanceOfTwins.Next(0, 2) == 0))
                numberOfChild = 1;
            else
                numberOfChild = 2;
            for (int i = 0; i < numberOfChild; i++)
            {
                var newChild = Factory.BorningChild();
                newChild.Age = 0;
                ActionsOnMap.AddObject(Coordinate, map, newChild);
            }
        }

    }
}
