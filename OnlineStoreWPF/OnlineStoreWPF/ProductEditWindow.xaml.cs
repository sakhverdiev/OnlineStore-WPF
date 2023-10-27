using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;


namespace OnlineStoreWPF
{
    /// <summary>
    /// Interaction logic for ProductEditWindow.xaml
    /// </summary>
    public partial class ProductEditWindow : Window, INotifyPropertyChanged
    {
        private Product product;

        public Product Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyRaised();
            }
        }

        public ProductEditWindow()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void Button_AddOrDelete_Click(object sender, RoutedEventArgs e)
        {
            if (btnAddOrDeleteProduct.Content.ToString() == "Add")
            {
                if (string.IsNullOrWhiteSpace(txbProdName.Text) || string.IsNullOrWhiteSpace(txbProdPrice.Text) || txbProdPrice.Text == "0" || imgSelectedProduct.Source == null)
                {
                    MessageBox.Show("Please fill in the information!");

                }
                else
                {
                    Product.Name = txbProdName.Text;
                    Product.Price = double.Parse(txbProdPrice.Text);
                    ((MainWindow)Application.Current.MainWindow).Products.Add(Product);
                    Close();

                }
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).TempProducts.Remove(Product);
                ((MainWindow)Application.Current.MainWindow).Products.Remove(Product);
                Close();
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

        private void Button_ImageChange_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Select a picture";
            openFile.Multiselect = false;
            openFile.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg";
            if (openFile.ShowDialog() == true)
            {
                imgSelectedProduct.Source = new BitmapImage(new Uri(openFile.FileName));
                if (Product == null)
                {
                    Product = new Product()
                    {
                        Name = txbProdName.Text,
                        Price = double.Parse(txbProdPrice.Text)
                    };
                }
                Product.ImagePath = openFile.FileName;
            }
        }
    }
}
