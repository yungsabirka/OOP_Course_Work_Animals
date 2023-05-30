using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Course_Work;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace OOPLAB
{
    class Visualisation
    {
        private ObservableCollection<ObservableCollection<MyString>> _priorityMap;

        public Visualisation(List<GameObject>[,] gameModel, GamePage gamePage)
        {
            _gamePage = gamePage;
            _gameModelMap = gameModel;
            _priorityMap = new ObservableCollection<ObservableCollection<MyString>>();
            InitializePriorityMap();
        }

        private readonly List<GameObject>[,] _gameModelMap;
        private readonly GamePage _gamePage;
        private void InitializePriorityMap()
        {
            for (int i = 0; i < _gameModelMap.GetLength(0); i++)
            {
                var row = new ObservableCollection<MyString>();
                for (int j = 0; j < _gameModelMap.GetLength(1); j++)
                {
                    if (EasyVisualisation(_gameModelMap[i, j]) != null)
                        row.Add(new MyString(EasyVisualisation(_gameModelMap[i, j])));
                    else
                        row.Add(new MyString("square.png"));
                }
                _priorityMap.Add(row);
            }
        }

        private static string EasyVisualisation(List<GameObject> cell)
        {
            if (cell.Count == 0)
                return null;
            var priorityQueue = new PriorityQueue<GameObject, int>();
            foreach (var item in cell)
                priorityQueue.Enqueue(item, item.Priority);

            return priorityQueue.Dequeue().SourceImage;
        }

        async public Task AddImagesToPage()
        {
            var horisontalStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = new Color(255, 255, 255)
            };
            foreach (var row in _priorityMap)
            {
                var verticalStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical
                };
                foreach (var item in row)
                {
                    var image = new Image
                    {
                        HeightRequest = 25,
                        WidthRequest = 25,
                        BindingContext = item.ValueString
                    };
                    image.SetBinding(Image.SourceProperty, new Binding($"."));
                    verticalStackLayout.Children.Add(image);
                }
                horisontalStackLayout.Children.Add(verticalStackLayout);
            }
            _gamePage.Content = horisontalStackLayout;

            await GenerateImageArrayAsync();
        }

        public async Task GenerateImageArrayAsync()
        {
            //await Task.Run(() => UpdatePriorityMap());
            /*            while (true)
                        {*/
            //await Task.Delay(500);
            Device.BeginInvokeOnMainThread(() =>
            {
                UpdatePriorityMap();
            });
            //}
        }

        private void UpdatePriorityMap()
        {
            for (int i = 0; i < _gameModelMap.GetLength(0); i++)
            {
                for (int j = 0; j < _gameModelMap.GetLength(1); j++)
                {
                    if (EasyVisualisation(_gameModelMap[i, j]) != null)
                        _priorityMap[i][j] = new MyString(EasyVisualisation(_gameModelMap[i, j]));
                    else
                        _priorityMap[i][j] = new MyString("square.png");
                }
            }
        }
    }
}