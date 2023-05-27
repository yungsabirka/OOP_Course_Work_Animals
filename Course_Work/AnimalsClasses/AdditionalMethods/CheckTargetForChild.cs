namespace OOPLAB
{
    class CheckTargetForChild : ICheckTarget
    {
        public bool CheckTarget(GameObject target, ObjectWhoCanLookAround animal)
        {
            if (target is not null)
            {
                if (target.GetType() == animal.GetType() && !ReferenceEquals(animal, target))
                {
                    animal.target = target;
                    return true;
                }
            }
            return false;
        }
    }
}
