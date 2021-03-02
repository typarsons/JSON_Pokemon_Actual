using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JSON_Pokemon_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // this is correct file, build from here\\
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            allPokemonAPI api;
            string url = "https://pokeapi.co/api/v2/pokemon?limit=1200";

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                api = JsonConvert.DeserializeObject<allPokemonAPI>(json);

                foreach (var resultObject in api.results.OrderBy(x => x.name).ToList())
                {

                    lstPokemon.Items.Add(resultObject);
                }//do this again 
            }
        }
        public void lstPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            SelectedPokemo api;
            var selection = (ResultObject)lstPokemon.SelectedItem;
            string urlSelected = selection.url;
           // lbName.Content = selection.name;

            var PokemonSelection = (ResultObject)lstPokemon.SelectedItem;
            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(urlSelected).Result;
                api = JsonConvert.DeserializeObject<SelectedPokemo>(json);
            }

                lbName.Content = api.name;
                lbHeight.Content = api.height;
                lbWeight.Content = api.weight;               
               imgPokemon.Source = new BitmapImage(new Uri(api.sprites.back_default));
            //this will sometimes result in error as certain pokemon such as "mega" forms do not
            //contain a value for front/back_default 
        }


    }
        }
    
