using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoBar
{
    public partial class UserControl1 : UserControl
    {
        Bar[] bar = new Bar[10];
        string[] tresc = new string[10];
        int _ilosc = 10;       

        [Category("A - Zadanie")]
        public int Ilosc
        {
            get
            {
                return (_ilosc);
            }
            set
            {
                if (value > 0 && value <= 10)
                {
                    _ilosc = value;
                    this.Size = new Size(bar[value-1].Location.X + bar[value-1].Width, this.Height); // pokaż tylko X pasków
                }
                Refresh();
            }
        }

        public UserControl1()
        {
            InitializeComponent();

            Point miejsce = new Point(5, 0);
            for (int i = 0; i < bar.Length; i++)
            {
                bar[i] = new Bar();
                bar[i].Location = miejsce;
                bar[i].Size = new Size(17, this.Height);
                bar[i].Kolor = Color.Green;
                bar[i].ShowValue = true;
                this.Controls.Add(bar[i]);
                miejsce.X = miejsce.X + bar[i].Width+10;
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(bar[9].Location.X + bar[9].Width, this.Height); // pokaż tylko X pasków
        }


        public void SetValue(int ktory, int ile)
        {
            bar[ktory].Value = ile;
        }

        public void ShowValue(int ktory, bool wyswietl)
        {
            bar[ktory].ShowValue = wyswietl;
        }

        public void SetNapis(int ktory, string jaki)
        {
            bar[ktory].Napis = jaki;

            Point NoweMiejsce = new Point(bar[ktory].Location.X, 0); 
            for (int i = ktory; i < bar.Length; i++)
            {
                bar[i].Location = NoweMiejsce; // Ustaw bar tutaj
                if(!String.IsNullOrEmpty(bar[i].Napis)) // Jeżeli bar ma podpis
                    bar[i].Width = TextRenderer.MeasureText(bar[i].Napis, bar[i].drawFont).Width; // Zmierz i zmień jego szerokość

                NoweMiejsce.X = bar[i].Location.X + bar[i].Width+10; // Oblicz przesunięcie kolejnego bara
            }
        }

        public void SetLimits(int ktory, float min, float max)
        {
            bar[ktory].Min = min;
            bar[ktory].Max = max;
        }

        public void SetWarnings(int ktory, float _alert, float _warning)
        {
            bar[ktory].Alert = _alert;
            bar[ktory].Warning = _warning;
            bar[ktory].EnableWarning = true;
        }
        
        public void SetKolor(int ktory, Color _kolor)
        {
            bar[ktory].Kolor = _kolor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            for(int i = 0; i < bar.Length; i++)
            {
                bar[i].Height = this.Height;
            }
        }
    }
}
