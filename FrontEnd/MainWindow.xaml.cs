using System;
using System.IO;
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
using FrontEnd.UserControls;
using System.ComponentModel;
using System.Collections.ObjectModel;
using FrontEnd.WindowBox;
using Microsoft.Win32;
using BackEnd;


namespace FrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Khoi dong cua so
            InitializeComponent();
            //Gan hanh dong khi tao 1 the
            MainAddCard.IDBoxText.PropertyChanged += MainAddCard_PropertyChanged;
        }
        //Cay nhi phan o C#
        BinarySearchTreeWrapper EmployeeTree = new BinarySearchTreeWrapper();

        //chuyen kieu
        public NhanSuWrapper ToNhanSuWrapper(TextboxText content)
        {
            NhanSuWrapper tmp = new NhanSuWrapper();
            tmp.MaSo = content.ID;
            tmp.hoTen = content.HoTen;
            tmp.namSinh = content.NamSinh;
            tmp.gioiTinh = content.GioiTinh;
            tmp.chucDanh = content.ChucDanh;
            tmp.chucVu = content.ChucVu;
            tmp.luong = Convert.ToInt64(content.Luong); 
            tmp.donVi = content.DonVi;
            tmp.mucDoHoanThanh = Convert.ToDouble(content.MucDoHoanThanh);
            tmp.danhGia = content.DanhGia;
            return tmp;
        }

        //chuyen kieu, khong the gan truc tiep vi se gan con tro thay vi gia tri
        public void ToTextBoxText(Card card, NhanSuWrapper content)
        {
            card.NSData.ID = content.MaSo;
            card.NSData.HoTen = content.hoTen;
            card.NSData.NamSinh = content.namSinh;
            card.NSData.GioiTinh = content.gioiTinh;
            card.NSData.ChucDanh = content.chucDanh;
            card.NSData.ChucVu = content.chucVu;
            card.NSData.Luong = Convert.ToString(content.luong);
            card.NSData.DonVi = content.donVi;
            card.NSData.MucDoHoanThanh = Convert.ToString(content.mucDoHoanThanh);
            card.NSData.DanhGia = content.danhGia;

            card.prevNSData.ID = content.MaSo;
            card.prevNSData.HoTen = content.hoTen;
            card.prevNSData.NamSinh = content.namSinh; 
            card.prevNSData.GioiTinh = content.gioiTinh;
            card.prevNSData.ChucDanh = content.chucDanh;
            card.prevNSData.ChucVu = content.chucVu;
            card.prevNSData.Luong = Convert.ToString(content.luong);
            card.prevNSData.DonVi = content.donVi;
            card.prevNSData.MucDoHoanThanh = Convert.ToString(content.mucDoHoanThanh);
            card.prevNSData.DanhGia = content.danhGia;
        }

        //Hanh dong khi tao 1 the
        private void MainAddCard_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            for (int i = 0; i < CardHolder.Children.Count - 1; i++)
            {
                if (CardHolder.Children[i] is Card)
                {
                    Card card = (Card)CardHolder.Children[i];
                    if (card.NSData.ID == MainAddCard.IDBoxText.IDData)
                    {   
                        MessageBox.Show("ID da ton tai", "ID");
                        return;
                    }
                }
            }
            Card tmp = new Card();
            tmp.NSData.ID = MainAddCard.IDBoxText.IDData;
            //tmp.Name = MainAddCard.IDBoxText.IDData;
            tmp.NSData.PropertyChanged += Card_PropertyChaged;
            tmp.DeleteCard.Click += DeleteCard_Click;
            CardHolder.Children.Insert(CardHolder.Children.Count - 1, tmp);
            EmployeeTree.insertNode(ToNhanSuWrapper(tmp.NSData));
        }
        
        //Hanh dong khi xoa the
        private void DeleteCard_Click(object sender, RoutedEventArgs e)
        { 
            for (int i = 0; i < CardHolder.Children.Count - 1; i++)
            {
                if (CardHolder.Children[i] is Card)
                {
                    Card card = (Card)CardHolder.Children[i];
                    if (card.DeleteCard == (sender as Button))
                    {
                        CardHolder.Children.RemoveAt(i);
                        EmployeeTree.deleteNode(ToNhanSuWrapper(card.NSData)); 
                        break;
                    }
                }
            }
        }

        //Hanh dong khi thong tin the thay doi
        private void Card_PropertyChaged(object? sender, PropertyChangedEventArgs e)
        {
            //string? tmp = e.PropertyName;
            TextboxText? tmptbt = sender as TextboxText;
            if (tmptbt == null)
            {
                MessageBox.Show("Co loi xay ra, vui long thu lai");
                return;
            }
            //MessageBox.Show(tmptbt.GetType().GetProperty(tmp).GetValue(tmptbt, null) as string);    
            EmployeeTree.updateNode(ToNhanSuWrapper(tmptbt));
        }

        //Xu li tim kiem
        public void Search()
        {
            NhanSuWrapper tmp = new NhanSuWrapper(EmployeeTree.findInfo(SearchBar.Text));
            if (tmp.MaSo == "")
            {
                MessageBox.Show("Khong tim thay", "Search");
            }
            else
            {
                Card ctmp = new Card();
                ctmp.HoTen.IsReadOnly = true;
                ctmp.NamSinh.IsReadOnly = true;
                ctmp.GioiTinh.IsReadOnly = true;
                ctmp.ChucDanh.IsReadOnly = true;
                ctmp.ChucVu.IsReadOnly = true;
                ctmp.Luong.IsReadOnly = true;
                ctmp.DonVi.IsReadOnly = true;
                ctmp.MucDoHoanThanh.IsReadOnly = true;
                ctmp.DanhGia.IsReadOnly = true;

                ToTextBoxText(ctmp, tmp);
                CardInfo citmp = new CardInfo(ctmp);
                citmp.Show();
            }
        }

        //Hanh dong khi tim kiem bang enther
        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Search();
        }
        //Hanh dong khi tim kiem bang nhan nut tim kiem
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }
        //Hanh dong khi sap xep
        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            NhanSuWrapper[] EmployeeArray = new NhanSuWrapper[CardHolder.Children.Count - 1];
            EmployeeTree.printLNR(EmployeeArray);
            CardHolder.Children.RemoveRange(0, CardHolder.Children.Count - 1);
            for (int i = 0; i < EmployeeArray.Length; i++)
            {
                Card card = new Card();
                ToTextBoxText(card, EmployeeArray[i]);
                card.NSData.PropertyChanged += Card_PropertyChaged;
                card.DeleteCard.Click += DeleteCard_Click;
                CardHolder.Children.Insert(CardHolder.Children.Count - 1, card);
            }
        }
        //Hanh dong khi danh gia
        private void EvaluateButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeTree.analyze();
            for (int i = 0; i < CardHolder.Children.Count - 1; i++)
            {
                if (CardHolder.Children[i] is Card)
                {
                    Card tmp = new Card();
                    Card cur = (Card) CardHolder.Children[i];
                    ToTextBoxText(tmp, EmployeeTree.findInfo(cur.NSData.ID));
                    CardHolder.Children.RemoveAt(i);
                    tmp.NSData.PropertyChanged += Card_PropertyChaged;
                    tmp.DeleteCard.Click += DeleteCard_Click;
                    CardHolder.Children.Insert(i, tmp);
                }
            }
        }
        //xoa moi the
        private void DeleteAllCard()
        {
            CardHolder.Children.RemoveRange(0, CardHolder.Children.Count - 1);
            EmployeeTree = new BinarySearchTreeWrapper();
        }
        //ten file dang xu li
        string? currentFileName = null;
        //xu li viec mo file
        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            String[] tmp;
            OpenFileDialog nsFile = new OpenFileDialog();
            nsFile.Filter = "QLNS File (*.qls)|*.qls";
            if (nsFile.ShowDialog() == true)
            {
                DeleteAllCard();
                currentFileName = nsFile.FileName;
                this.Title = Path.GetFileName(nsFile.FileName) + " - QLNS - NPTK";
                tmp = File.ReadAllLines(nsFile.FileName);
                int cnt = Convert.ToInt32((string)tmp[0]);
                int buff = 0;
                for (int i = 0; i < cnt; i++)
                {
                    NhanSuWrapper tmpns = new NhanSuWrapper();
                    Card tmpc = new Card();
                    tmpc.NSData.HoTen = tmp[buff + 1];
                    tmpc.NSData.NamSinh = tmp[buff + 2];
                    tmpc.NSData.GioiTinh = tmp[buff + 3];
                    tmpc.NSData.ChucDanh = tmp[buff + 4];
                    tmpc.NSData.ChucVu = tmp[buff + 5];
                    tmpc.NSData.Luong = tmp[buff + 6];
                    tmpc.NSData.DonVi = tmp[buff + 7];
                    tmpc.NSData.MucDoHoanThanh = tmp[buff + 8];
                    tmpc.NSData.DanhGia = tmp[buff + 9];
                    tmpc.NSData.ID = tmp[buff + 10];
                    tmpc.NSData.PropertyChanged += Card_PropertyChaged;
                    tmpc.DeleteCard.Click += DeleteCard_Click;
                    CardHolder.Children.Insert(CardHolder.Children.Count - 1, tmpc);    
                    EmployeeTree.insertNode(ToNhanSuWrapper(tmpc.NSData));
                    if (buff == 0) buff = 10;
                    else buff += 10;
                }
            }
        }
        //xu li viec doc file
        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            string tmp = "";
            tmp = Convert.ToString(CardHolder.Children.Count - 1) + '\n';
            for (int i = 0; i < CardHolder.Children.Count; i++)
            {
                if (CardHolder.Children[i] is Card)
                {
                    Card tmpc = (Card)CardHolder.Children[i];
                    tmp = tmp + tmpc.NSData.HoTen + '\n';
                    tmp = tmp + tmpc.NSData.NamSinh + '\n';
                    tmp = tmp + tmpc.NSData.GioiTinh + '\n';
                    tmp = tmp + tmpc.NSData.ChucDanh + '\n';
                    tmp = tmp + tmpc.NSData.ChucVu + '\n';
                    tmp = tmp + tmpc.NSData.Luong + '\n';
                    tmp = tmp + tmpc.NSData.DonVi + '\n';
                    tmp = tmp + tmpc.NSData.MucDoHoanThanh + '\n';
                    tmp = tmp + tmpc.NSData.DanhGia + '\n';
                    tmp = tmp + tmpc.NSData.ID + '\n';
                }
            }

            if (currentFileName == null)
            {
                SaveFileDialog nsFile = new SaveFileDialog();
                nsFile.Filter = "QLNS File (*.qls)|*.qls";
                if (nsFile.ShowDialog() == true)
                {
                    File.WriteAllText(nsFile.FileName, tmp);
                    currentFileName = nsFile.FileName;
                    this.Title = Path.GetFileName(nsFile.FileName) + " - QLNS - NPTK";
                }
            }
            else
            {
                File.WriteAllText(currentFileName, tmp);
                MessageBox.Show("Saved", "Save");
            }
        }
    }
}
