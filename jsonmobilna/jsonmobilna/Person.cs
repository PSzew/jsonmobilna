using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace jsonmobilna
{
    public class Person
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }

        public Person(string imie,string nazwisko,int wiek)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
        }
        public Person()
        {

        }
    }
    public class global
    {
        public static ObservableCollection<Person> lista = new ObservableCollection<Person>();
    }

}
