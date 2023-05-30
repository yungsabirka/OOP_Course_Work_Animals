using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using OOPLAB;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Course_Work
{
    public partial class GamePage : ContentPage
    {

        public GamePage()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, EventArgs e)
        {
            var gameModel = new GameModel();
            var simulation = new Simulation(gameModel.map);
            var visualisation = new Visualisation(gameModel.map, this);
            //visualisation.AddImagesToPage();
            simulation.Start(visualisation);
            
        }
    }
}