using Course_Work;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OOPLAB
{
    class Visualisation
    {
        private string[,] _priorityMap { get; set; }

        public Visualisation(List<GameObject>[,] map, GamePage gamePage)
        {
            _gamePage = gamePage;
            _map = map;
            _priorityMap = new string[map.GetLength(0), map.GetLength(1)];
            UpdatePriorityMap();
           // Simulation.Visualise += AddImagesToPage;
        }

        private readonly List<GameObject>[,] _map;
        private readonly GamePage _gamePage;

        /*public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }*/

        private void UpdatePriorityMap()
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i, j].Count > 0)
                    {
                        var priorityQueue = new PriorityQueue<GameObject, int>();
                        foreach (var item in _map[i, j])
                            priorityQueue.Enqueue(item, item.Priority);

                        _priorityMap[i, j] = priorityQueue.Dequeue().SourceImage;
                    }
                    else
                    {
                        _priorityMap[i, j] = "square.png";
                    }
                }
            }
        }

        public void AddImagesToPage()
        {
                UpdatePriorityMap();
                var horisontalStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    BackgroundColor = new Color(255, 255, 255),
                    HorizontalOptions = LayoutOptions.Center,
                    BindingContext = '.'
                };
                for (int i = 0; i < _priorityMap.GetLength(0); i++)
                {
                    var verticalStackLayout = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical
                    };
                    for (int j = 0; j < _priorityMap.GetLength(1); j++)
                    {
                        var image = new Image
                        {
                            HeightRequest = 25,
                            WidthRequest = 25,
                            Source = _priorityMap[i, j]
                            //BindingContext = _priorityMap[i, j]
                        };
                    //image.SetBinding(Image.SourceProperty, new Binding("."));
                    verticalStackLayout.Children.Add(image);
                    }
                    horisontalStackLayout.Children.Add(verticalStackLayout);
                }
                    _gamePage.Content = horisontalStackLayout;

            //await GenerateImageArrayAsync();
        }
        /*[Obsolete]
        private async Task GenerateImageArrayAsync()
        {
            while (true)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    UpdatePriorityMap();
                    OnPropertyChanged(nameof(_priorityMap));
                });
                await Task.Delay(500);
            }
        }*/
    }
}