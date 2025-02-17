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
    }
}
