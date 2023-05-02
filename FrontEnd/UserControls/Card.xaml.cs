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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using BackEnd;


namespace FrontEnd.UserControls
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
            CardGrid.DataContext = NSData;
        }

        //Hai doi tuong de su dung khi kiem tra nhan su co thay doi hay khong
        public TextboxText NSData { get; set; } = new TextboxText();
        public TextboxText prevNSData { get; set; } = new TextboxText();
        //Khi o nhap khong duoc tro vao nua thi hien thi len
        private void HoTen_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prevNSData.HoTen == NSData.HoTen) return;
            prevNSData.HoTen = NSData.HoTen;
            NSData.HoTen = HoTen.Text;
            NSData.NotifyPropertyChanged("HoTen");
        }

        private void NamSinh_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prevNSData.NamSinh == NSData.NamSinh) return;  
            prevNSData.NamSinh = NSData.NamSinh;
            NSData.NamSinh = NamSinh.Text;
            NSData.NotifyPropertyChanged("NamSinh");
        }

        private void GioiTinh_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prevNSData.GioiTinh == NSData.GioiTinh) return;
            prevNSData.GioiTinh = NSData.GioiTinh;
            NSData.GioiTinh = GioiTinh.Text;
            NSData.NotifyPropertyChanged("GioiTinh");
        }

        private void ChucDanh_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prevNSData.ChucDanh == NSData.ChucDanh) return;
            prevNSData.ChucDanh = NSData.ChucDanh;
            NSData.ChucDanh = ChucDanh.Text;
            NSData.NotifyPropertyChanged("ChucDanh");
        }

        private void ChucVu_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prevNSData.ChucVu == NSData.ChucVu) return;
            prevNSData.ChucVu = NSData.ChucVu;
            NSData.ChucVu = ChucVu.Text;
            NSData.NotifyPropertyChanged("ChucVu");
        }
        //Bao gom phan kiem tra xem kieu du lieu nhap vao co chuyen qua dang long duoc khong
        private void Luong_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prevNSData.Luong == NSData.Luong) return;
            if (!(bool) long.TryParse(NSData.Luong, out long tmp))
            {
                MessageBox.Show("Vui long nhap so nguyen!");
                prevNSData.Luong = "0";
                NSData.Luong = "0"; 
                NSData.NotifyPropertyChanged("Luong");
                return;
            }
            else
            {
                prevNSData.Luong = NSData.Luong;
                NSData.Luong = Luong.Text;
                NSData.NotifyPropertyChanged("Luong");
            }
        }

        private void DonVi_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prevNSData.DonVi == NSData.DonVi) return;
            prevNSData.DonVi = NSData.DonVi;
            NSData.DonVi = DonVi.Text;
            NSData.NotifyPropertyChanged("DonVi");
        }
        //Bao gom phan kiem tra xem kieu du lieu nhap vao co chuyen qua dang double duoc khong
        private void MucDoHoanThanh_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prevNSData.MucDoHoanThanh == NSData.MucDoHoanThanh) return;
            if (!(bool) double.TryParse(NSData.MucDoHoanThanh, out double tmp))
            {
                MessageBox.Show("Vui long nhap so!");
                prevNSData.MucDoHoanThanh = "0";
                NSData.MucDoHoanThanh = "0";
                NSData.NotifyPropertyChanged("MucDoHoanThanh");
                return;
            }
            else
            {
                prevNSData.MucDoHoanThanh = NSData.MucDoHoanThanh;
                NSData.MucDoHoanThanh = MucDoHoanThanh.Text;
                NSData.NotifyPropertyChanged("MucDoHoanThanh");
            }
        }

        private void DanhGia_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prevNSData.DanhGia == NSData.DanhGia) return;
            prevNSData.DanhGia = NSData.DanhGia;
            NSData.DanhGia = DanhGia.Text;
            NSData.NotifyPropertyChanged("DanhGia");
        }
        //Ho tro viec chuyen sang o tiep theo khi nhan enter
        private void HoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NamSinh.Focus();
            }
        }

        private void NamSinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                GioiTinh.Focus();
            }
        }

        private void GioiTinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ChucDanh.Focus();
            }
        }

        private void ChucDanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ChucVu.Focus();
            }
        }

        private void ChucVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Luong.Focus();  
            }
        }

        private void Luong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DonVi.Focus();
            }
        }

        private void DonVi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key== Key.Enter)
            {
                MucDoHoanThanh.Focus();
            }
        }

        private void MucDoHoanThanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DanhGia.Focus();
            }
        }

        private void DanhGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UnFocusButton.Focus();
            }
        }
    }
    //class chua cac thong tin va quan li thong tin co bi thay doi hay khong bang hanh dong
    public class TextboxText : INotifyPropertyChanged
    {
        private string hoTen { get; set; } = string.Empty;
        private string namSinh { get; set; } = string.Empty;
        private string gioiTinh { get; set; } = string.Empty;
        private string chucDanh { get; set; } = string.Empty;   
        private string chucVu { get; set; } = string.Empty;
        private string luong { get; set; } = string.Empty;
        private string donVi { get; set; } = string.Empty;
        private string mucDoHoanThanh { get; set; } = string.Empty;
        private string danhGia { get; set; } = string.Empty;
        private string iD { get; set; } = string.Empty;
        public string HoTen 
        { 
            get
            {
                return hoTen;
            }
            set
            {
                if (hoTen != value)
                {
                    hoTen = value;
                }
            }
        }
        public string NamSinh
        {
            get
            {
                return namSinh;
            }
            set
            {
                if (namSinh != value)
                {
                    namSinh = value;
                }
            }
        }
        public string GioiTinh
        {
            get
            {
                return gioiTinh;
            }
            set
            {
                if (gioiTinh != value)
                {
                    gioiTinh = value;
                }
            }
        }
        public string ChucDanh
        {
            get
            {
                return chucDanh;
            }
            set
            {
                if (chucDanh != value)
                {
                    chucDanh = value;
                }
            }
        }
        public string ChucVu
        {
            get
            {
                return chucVu;
            }
            set
            {
                if (chucVu != value)
                {
                    chucVu = value;
                }
            }
        }
        public string Luong
        {
            get
            {
                return luong;
            }
            set
            {
                //if (value == "")
                //{
                //    if (luong != "0")
                //    {
                //        luong = "0";
                //    }
                //    return;
                //}
                if (luong != value)
                {
                    luong = value;
                }
            }
        }

        public string DonVi
        {
            get
            {
                return donVi;
            }
            set
            {
                if (donVi != value)
                {
                    donVi = value;
                }
            }
        }

        public string MucDoHoanThanh
        {
            get
            {
                return mucDoHoanThanh;
            }
            set
            {
                //if (value == "")
                //{
                //    if (value != "0")
                //    {
                //        mucDoHoanThanh = "0";
                //    }
                //    return;
                //}
                if (mucDoHoanThanh != value)
                {
                    mucDoHoanThanh = value;
                }
            }
        }

        public string DanhGia
        {
            get
            {
                return danhGia;
            }
            set
            {
                if (danhGia != value)
                {
                    danhGia = value;
                }
            }
        }

        public string ID
        {
            get
            {
                return iD;
            }
            set
            {
                if (iD != value)
                {
                    iD = value;
                }
            }
        }

        //public string GioiTinh { get; set; }
        //public string ChucDanh { get; set; }
        //public string ChucVu { get; set; }
        //public string Luong { get; set; }
        //public string DonVi { get; set; }
        //public string MucDoHoanThanh { get; set; }
        //public string DanhGia { get; set; }
        //public string ID { get; set; }
        public TextboxText()
        {
            hoTen = "";
            namSinh = "";
            gioiTinh = "";
            chucDanh = "";
            chucVu = "";
            luong = "0";
            donVi = "";
            mucDoHoanThanh = "0";
            danhGia = "";
            iD = "";
        }

        public TextboxText(NhanSuWrapper other)
        {
            hoTen = other.hoTen;
            namSinh = other.namSinh;
            gioiTinh = other.gioiTinh;
            chucDanh = other.chucDanh;
            chucVu = other.chucVu;
            luong = Convert.ToString(other.luong);
            donVi = other.donVi;
            mucDoHoanThanh = Convert.ToString(other.mucDoHoanThanh);
            danhGia = other.danhGia;
            iD = other.MaSo;
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
