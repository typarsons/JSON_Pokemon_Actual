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
                }
                var selection = (ResultObject)lstPokemon.SelectedItem;
                string url2 = selection.url;
                using (var client2 = new HttpClient())
                {
                    string json2 = client.GetStringAsync(url).Result;
                    api = JsonConvert.DeserializeObject<allPokemonAPI>(json);
                    foreach (var pokemonSprites in api.results.OrderBy(x => x.name).ToList())
                    {
                        lstSprite.Items.Add(pokemonSprites);
                    }
                }

            }


            //void lstPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
            //{

            //    var selection = (ResultObject)lstPokemon.SelectedItem;
            //    lbName.Content = selection.name;
            //    lbHeight.Content = selection.height;

                //var selection2 = (ResultObject)lstPokemon.SelectedItem;
                //string url2 = selection.url;
                //using (var client = new HttpClient())
                //{
                //    string json = client.GetStringAsync(url2).Result;
                //    api = JsonConvert.DeserializeObject<allPokemonAPI>(json);

                //    foreach (var pokemonSprite in api.results.OrderBy(x => x.name).ToList())
                //    {
                //        lstPokemon.Items.Add(pokemonSprite);
                //    }
                //}
                //var selection2 = (PokemonSprites)lstPokemon.SelectedItem;
                //imgPokemon.Source = new BitmapImage(new Uri(selection2.back_default));

                // imgPokemon.Source = new BitmapImage(new Uri(selection.back_default));

                //var selectedpokemon = (PokemonSprites)lstPokemon.SelectedItem;
                //imgPokemon.Source = new BitmapImage(new Uri(selectedpokemon.back_default));
            }
        }
    }
