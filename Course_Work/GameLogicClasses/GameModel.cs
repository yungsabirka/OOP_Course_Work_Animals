using Point = System.Drawing.Point;
using Course_Work;

namespace OOPLAB
{
    class GameModel
    {
        public List<GameObject>[,] map;
        private readonly int _mapLenght;
        private Random _random = new();
        private int _rowNumber;
        private int _columnNumber;
        private readonly List<Animals> _predatorsTypeList;
        private readonly List<Animals> _preysTypeList;
        public GameModel(int amountOfPreys, int amountOfPredators, int amountOfGrass)
        {
            _predatorsTypeList = new List<Animals>
            {
                new Tiger(), new Wolf(), new Bear(), new Hyena()
            };
            _preysTypeList = new List<Animals>
            {
                new Bull(), new Cow(), new Rabbit(), new Sheep()
            };
            _mapLenght = 32;
            map = new List<GameObject>[_mapLenght, _mapLenght];
            for (int i = 0; i < _mapLenght; i++)
                for (int j = 0; j < _mapLenght; j++)
                    map[i, j] = new List<GameObject>();
            GenerateGrass(amountOfGrass);
            GenerateAnimals(amountOfPreys, _preysTypeList);
            GenerateAnimals(amountOfPredators, _predatorsTypeList);
        }
        private void GenerateAnimals(int amountOfAnimals, List<Animals> animalsTypeList)
        {
            for (int i = 0; i < amountOfAnimals; i++)
            {
                ActionsOnMap.AddObject(new Point(_random.Next(0, map.GetLength(0)), _random.Next(0, map.GetLength(1))),
                    map, animalsTypeList[_random.Next(0, _predatorsTypeList.Count)].BorningChild());
            }
        }
        private void GenerateGrass(int amountOfGrass)
        {
            while (amountOfGrass > map.GetLength(0) * map.GetLength(1))
                amountOfGrass /= 2;
            for (int i = 0; i < amountOfGrass; i++)
            {
                do
                {
                    _rowNumber = _random.Next(0, map.GetLength(0));
                    _columnNumber = _random.Next(0, map.GetLength(1));
                }
                while (map[_rowNumber, _columnNumber].Count != 0);
                var grass = new Grass
                {
                    Coordinate = new Point(_rowNumber, _columnNumber)
                };
                ActionsOnMap.AddObject(grass.Coordinate, map, grass);

            }
        }

    }
}


