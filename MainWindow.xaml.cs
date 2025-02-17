using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp5 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        List<Krater> lista = new List<Krater>();

        public MainWindow() {
            InitializeComponent();
            beolvas("felszin.txt");
            // 2. feladat
            label2.Content = lista.Count;
            // 4. feladat
            //var max = lista.Max(item => item.R);
            var max = lista[0].R;
            foreach (var item in lista) {
                if (item.R > max) {
                    max = item.R;
                    label4.Content = "4.feladat\nA legnagyobb kráter neve és sugara: " + item.Nev + " " + item.R;
                }
            }
            // 6. feladat
            //double tav = tavolsag(100.0,50.0,200.0,80.0);

        }

        //5. feladat
        private double tavolsag(double x1, double y1, double x2, double y2) {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        private void beolvas(string v) {
            using (var sr = new StreamReader(v)) {
                while (!sr.EndOfStream) {
                    var sor = sr.ReadLine().Split('\t');
                    var x = double.Parse(sor[0]);
                    var y = double.Parse(sor[1]);
                    var r = double.Parse(sor[2]);
                    var nev = sor[3];
                    var k = new Krater(x, y, r, nev);
                    lista.Add(k);
                    //Console.WriteLine(k);
                    listadoboz.Items.Add(k);
                    cbFeladat6.Items.Add(k.Nev);
                }
            }
        }

        private void btnFeladat3_Click(object sender, RoutedEventArgs e) {
            var flag = false;
            foreach (var item in lista) {
                if (item.Nev == txtFeladat3.Text) {
                    listadoboz.Items.Clear();
                    listadoboz.Items.Add(item);
                    flag = true;
                    break;
                }
            }
            if (!flag) {
                MessageBox.Show("Nincs ilyen kráter!");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // megkeressük az adott névhez tartozó rekord indexét a listában
            var index = -1;
            foreach (var item in lista) {
                if (item.Nev == cbFeladat6.SelectedValue.ToString()) {
                    index = lista.IndexOf(item);
                    break;
                }
            }
            //MessageBox.Show(lista[index].Nev+" "+ lista[index].X);
            listadoboz.Items.Clear();
            foreach (var item in lista) {

                if (item.Nev == lista[index].Nev) continue;

                var tav = tavolsag(lista[index].X, lista[index].Y, item.X, item.Y);
                if (tav >= lista[index].R + item.R)
                    listadoboz.Items.Add(item.Nev + " " + tav);
            }
        }
    }
}
