using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht3
{
    public class Pelaaja : INotifyPropertyChanged
    {
        private string Etunimi;
        private string Sukunimi;
        private string Kokonimi;
        private string Seura;
        private double Siirtohinta;

        public string etunimi
        {
            get
            {
                return Etunimi;
            }
            set
            {
                if (Etunimi != value)
                {
                    Etunimi = value;
                    NotifyPropertyChanged("etunimi");
                    NotifyPropertyChanged("kokonimi");
                }
            }
        }
        public string sukunimi
        {
            get
            {
                return Sukunimi;
            }
            set
            {
                if (Sukunimi != value)
                {
                    Sukunimi = value;
                    NotifyPropertyChanged("sukunimi");
                    NotifyPropertyChanged("kokonimi");
                }
            }
        }
        public string kokonimi { get { return Etunimi + " " + Sukunimi + ", " + Seura; } }
        public string seura
        {
            get
            {
                return Seura;
            }
            set
            {
                if (Seura != value)
                {
                    Seura = value;
                    NotifyPropertyChanged("seura");
                    NotifyPropertyChanged("kokonimi");
                }
            }
        }
        public double siirtohinta
        {
            get
            {
                return Siirtohinta;
            }
            set
            {
                if (Siirtohinta != value)
                {
                    Siirtohinta = value;
                    NotifyPropertyChanged("siirtohinta");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
