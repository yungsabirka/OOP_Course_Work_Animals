using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace OOPLAB
{
    class GameModel
    {
        public List<GameObject>[,] map;
        private int _mapLenght;
        public Random RandomValue = new();
        public GameModel()
        {
            _mapLenght = 32;
            map = new List<GameObject>[_mapLenght, _mapLenght];
            for (int i = 0; i < _mapLenght; i++)
                for (int j = 0; j < _mapLenght; j++)
                    map[i, j] = new List<GameObject>();
            GenerateGrass(8, 1);
            GenerateGrass(21, 1);
            GenerateGrass(8, 16);
            GenerateGrass(21, 16);
            GenerateAnimals();
        }

        private void GenerateAnimals()
        {
            for (int i = 0; i < _mapLenght; i++)
            {
                for (int j = 0; j < _mapLenght; j++)
                {
                    int generationChance = RandomValue.Next(1, 41);
                    if (generationChance < 10)
                        switch (GenerateRandPrey())
                        {
                            case 1:
                                ActionsOnMap.AddObject(new Point(i, j), map, new Bull());
                                break;
                            case 2:
                                ActionsOnMap.AddObject(new Point(i, j), map, new Cow());
                                break;
                            case 3:
                                ActionsOnMap.AddObject(new Point(i, j), map, new Rabbit());
                                break;
                            case 4:
                                ActionsOnMap.AddObject(new Point(i, j), map, new Sheep());
                                break;
                        }
                    if (generationChance == 11) switch (GenerateRandPredator())
                        {
                            case 5:
                                ActionsOnMap.AddObject(new Point(i, j), map, new Bear());
                                break;
                            case 6:
                                ActionsOnMap.AddObject(new Point(i, j), map, new Hyena());
                                break;
                            case 7:
                                ActionsOnMap.AddObject(new Point(i, j), map, new Tiger());
                                break;
                            case 8:
                                ActionsOnMap.AddObject(new Point(i, j), map, new Wolf());
                                break;
                        }
                }
            }
        }
        private int GenerateRandPrey()
        {
            int generatedValue = RandomValue.Next(1, 5);
            return generatedValue;
        }
        private int GenerateRandPredator()
        {
            int generatedValue = RandomValue.Next(4, 9);
            return generatedValue;
        }
        private void GenerateGrass(int x, int y)
        {
            int k = 0; bool ex = true;
            for (int i = y; i < y + 15; i++)
            {
                for (int j = x - k; j <= x + k; j++)
                {
                    var grass = new Grass();
                    grass.Coordinate = new Point(j, i);
                    ActionsOnMap.AddObject(grass.Coordinate, map, grass);
                }

                if (k == 7) ex = false;
                if (ex) k++;
                else k--;
            }
        }

    }
}


