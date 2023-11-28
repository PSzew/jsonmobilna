using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace jsonmobilna
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();          
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "json.txt");
            if (File.Exists(fileName))
            {
                global.lista.Clear();
                foreach (var item in File.ReadAllLines(fileName))
                {
                    string[] strings = item.Split(';');
                    global.lista.Add(new Person() { Imie = strings[0], Nazwisko = strings[1], Wiek = Int32.Parse(strings[2])});
                }
            }
            ListView.ItemsSource = global.lista;
        }

        private void AddPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Dodaj());
        }

        private void EditInvoke(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Dodaj(((SwipeItem)sender).CommandParameter as Person,ListView.TabIndex));
        }

        private void DeleteInvoke(object sender, EventArgs e)
        {
            global.lista.Remove(((SwipeItem)sender).CommandParameter as Person);
            string text = "";
            foreach (var item in global.lista)
            {
                text += item.Imie + ";";
                text += item.Nazwisko + ";";
                text += item.Wiek + "\n";
            }
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "json.txt");
            File.WriteAllText(fileName, text);
            OnAppearing();
        }

        private void searchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue == "")
                ListView.ItemsSource = global.lista;
            var searchResult = global.lista.Where(person => person.Imie.StartsWith(e.NewTextValue));
            ListView.ItemsSource = searchResult;
        }
    }
}
