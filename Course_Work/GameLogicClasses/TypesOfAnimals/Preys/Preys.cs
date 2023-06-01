using Course_Work;

namespace OOPLAB
{
    public abstract class Preys : Animals
    {
        public override void Eat(List<GameObject>[,] map)
        {
            var Grass = (Grass)map[Coordinate.X, Coordinate.Y][0];
            Grass.Eaten();
            Satiety += Grass.Saturability;
            target = null;
        }
    }
}
