namespace OOPLAB
{
    class CheckTargetForPreys : ICheckTarget
    {
        public bool CheckTarget(GameObject target, ObjectWhoCanLookAround animal)
        {
            if (target is Grass grass)
            {
                if (grass.IsGrown)
                {
                    animal.target = target;
                    return true;
                }
            }

            if (animal.PairingTargetTest(target) || target is Predators)
            {
                animal.target = target;
                return true;
            }
            return false;
        }
    }
}
