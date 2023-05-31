namespace OOPLAB
{
    class ChildPoops : GameObject
    {
        private int TimeOfExistense { get; set; }

        private List<GameObject>[,] _map;
        private void Decomposition()
        {
            TimeOfExistense++;
            if (TimeOfExistense == 4)
            {
                if (_map[Coordinate.X, Coordinate.Y].Count != 0)
                {
                    if (_map[Coordinate.X, Coordinate.Y][0] is Grass)
                    {
                        var grass = (Grass)_map[Coordinate.X, Coordinate.Y][0];
                        grass.GrowRate += 3;
                    }
                }
                ActionsOnMap.DeleteObject(_map, this);
            }

        }
        public ChildPoops(List<GameObject>[,] map)
        {
            SourceImage = "square.png";
            Priority = 20;
            Saturability = 0;
            Simulation.Update += Decomposition;
            _map = map;
        }

    }
}
