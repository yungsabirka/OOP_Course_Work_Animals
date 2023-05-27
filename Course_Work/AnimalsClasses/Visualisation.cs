using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course_Work;

namespace OOPLAB
{
    class Visualisation
    {

        public Visualisation(GameModel gameModel, GamePage gamePage)
        {
            _gamePage = gamePage;
            _gameModel = gameModel;
            Simulation.Update += Test;
        }
        private GameModel _gameModel;
        private GamePage _gamePage;
        private List<GameObject>[,] _priorityMap;
        private Image[,] _imageArray;
        public List<GameObject>[,] VisualisationMap(List<GameObject>[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    _priorityMap[i, j] = null;
                    _priorityMap[i,j].Add(EasyVisualisation(map[i,j]));
                }
            }
            return _priorityMap;
        }

        private GameObject EasyVisualisation(List<GameObject> cell)
        {
            var priorityQueue = new PriorityQueue<GameObject, int>();
            foreach (var item in cell)
                priorityQueue.Enqueue(item, item.Priority);

            if (priorityQueue.Count > 0)
                return priorityQueue.Dequeue();
            else
                return null;
        }

        public void Test()
        {
            var _imageArray = new Image[32, 32];
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (_gameModel.map[i, j].Count != 0)
                        _imageArray[i, j] = new Image { Source = _gameModel.map[i, j][0].SourceImage };
                    else
                        _imageArray[i, j] = new Image { Source = "square.png" };
                }
            }

            var horizontalStackLayout = new HorizontalStackLayout
            {
                BackgroundColor = new Color(255, 255, 255),
                HorizontalOptions = LayoutOptions.Center
            };
            for (int i = 0; i < _imageArray.GetLength(0); i++)
            {
                var vertivalStackLayout = new VerticalStackLayout();
                for (int j = 0; j < _imageArray.GetLength(1); j++)
                {
                    var image = _imageArray[i, j];

                    image.WidthRequest = 25; // Установите желаемую ширину
                    image.HeightRequest = 25; // Установите желаемую высоту

                    vertivalStackLayout.Children.Add(image);
                }
                horizontalStackLayout.Children.Add(vertivalStackLayout);
            }
            _gamePage.Content = horizontalStackLayout;
        }
    }
}
