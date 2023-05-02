using System;
using System.Collections.Generic;
using System.Linq;
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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Shapes;

namespace FrontEnd.UserControls
{
    /// <summary>
    /// Interaction logic for AddCard.xaml
    /// </summary>
    public partial class AddCard : UserControl
    {
        public AddCard()
        {
            InitializeComponent();
        }
        public IDString IDBoxText { get; set; } = new IDString();

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            changeIDBoxText();
        }

        private void IDBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                changeIDBoxText();
            }
        }
        //Xoa het thong tin trong textbox ID sau khi them ID
        private void changeIDBoxText()
        {
            if (IDBox.Text.Length == 0)
            {
                MessageBox.Show("Vui long nhap ID", "ID");
            }
            else
            {
                IDBoxText.IDData = IDBox.Text;
                IDBox.Text = string.Empty;
            }
        }
    }
    //Class dung de chua kieu du lieu co the kiem tra thong tin ID co thay doi hay ko
    public class IDString : INotifyPropertyChanged
    {
        private string IDdata = "";
        public string IDData
        {
            get { return this.IDdata; }
            set 
            { 
                if (this.IDdata != value)
                {
                    this.IDdata = value;
                    this.NotifyPropertyChanged("IDData");
                    this.IDdata = "";
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                if (this == null)
                {
                    MessageBox.Show("Co loi xay ra, vui long thu lai");
                    return;
                }
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
