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
using System.Windows.Shapes;
using FrontEnd.UserControls;
using FrontEnd;

namespace FrontEnd.WindowBox
{
    /// <summary>
    /// Interaction logic for CardInfo.xaml
    /// </summary>
    public partial class CardInfo : Window
    {
        public CardInfo(Card ctmp)
        {
            InitializeComponent();
            //Sua nut delete thanh close va hien thi len man hinh
            ctmp.DeleteCardContent.Text = "Close";
            ctmp.DeleteCard.IsCancel = true;
            ctmp.DeleteCard.Click += CloseCard_Click;
            WindowBox.Children.Add(ctmp);
        }
        //thoat cua so khi nhan Close
        private void CloseCard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
