﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace OnlineStoreWPF
{
    public class Product: INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyRaised();
            }
        }
        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyRaised();
            }
        }
        private string imagePath;


        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyRaised();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

    }
}
