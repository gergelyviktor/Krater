using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5 {
    internal class Krater {
        public double X { get; set; }
        public double Y { get; set; }
        public double R { get; set; }
        public string Nev { get; set; }
        public Krater(double x, double y, double r, string nev) { 
            this.X = x;
            this.Y = y;
            this.R = r;
            this.Nev = nev;
        }
    }
}
