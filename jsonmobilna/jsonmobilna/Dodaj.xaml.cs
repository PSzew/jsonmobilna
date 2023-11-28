using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace jsonmobilna
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dodaj : ContentPage
    {
        bool isInEditMode = false;
        int Id;
        public Dodaj()
        {
            InitializeComponent();
        }
        public Dodaj(Person p,int id)
        {
            InitializeComponent();
            isInEditMode = true;
            name.Text = p.Imie;
            surname.Text = p.Nazwisko;
            age.Text = p.Wiek.ToString();
            Id = id;
        }
        

        private void saveClicked(object sender, EventArgs e)
        {
            if(isInEditMode) 
            {
                global.lista[Id].Imie = name.Text;
                global.lista[Id].Nazwisko = surname.Text;
                global.lista[Id].Wiek = Int32.Parse(age.Text);
                saveList();
                Navigation.PopAsync();
            }
            else
            {
                global.lista.Add(new Person(name.Text, surname.Text, Int32.Parse(age.Text)));
                saveList();
                Navigation.PopAsync();
            }
            

        }
        public void saveList()
        {
            string text = "";
            foreach (var item in global.lista)
            {
                text += item.Imie + ";";
                text += item.Nazwisko + ";";
                text += item.Wiek + "\n";
            }
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "json.txt");
            File.WriteAllText(fileName, text);
        }
    }
}