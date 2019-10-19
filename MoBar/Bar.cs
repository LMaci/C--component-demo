using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace MoBar
{
    public class Bar : Control
    {
        public int szerokosc = 10;
        float _value = 0;
        float _alert = 0;
        float _warning = 0;
        float _min = 0;
        float _max = 100;
        int procent = 100;
        //Color _kolor = Color.FromName("Green");
        public Font drawFont = new Font("Arial", 8, FontStyle.Bold);

        public string _napis;

        [Category("A - Zadanie")]
        public bool EnableWarning { get; set; }
        [Category("A - Zadanie")]
        public bool ShowValue { get; set; }

        [Category("A - Zadanie")]
        public float Value
        {
            get
            {
                return (_value);
            }
            set
            {
                _value = value;
                Invalidate();
            }
        }

        [Category("A - Zadanie")]
        public Color Kolor { get; set; }

        [Category("A - Zadanie")]
        public float Alert
        {
            get
            {
                return (_alert);
            }
            set
            {
                _alert = value;
                Invalidate();
            }
        }

        [Category("A - Zadanie")]
        public float Warning
        {
            get
            {
                return (_warning);
            }
            set
            {
                _warning = value;
                Invalidate();
            }
        }

        [Category("A - Zadanie")]
        public string Napis
        { 
            get
            {
                return (_napis);
            }
            set
            {
                _napis = value;
                Invalidate();
            }
        }


        [Category("A - Zadanie")]
        public float Min
        {
            get
            {
                return (_min);
            }
            set
            {
                _min = value;
                Invalidate();
            }
        }

        [Category("A - Zadanie")]
        public float Max
        {
            get
            {
                return (_max);
            }
            set
            {
                _max = value;
                Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen penLine = new Pen(Color.Green, 1); // Pędzel do rysowania słupków
            SolidBrush drawBrush = new SolidBrush(Color.Black); // Pędzel do pisania tekstu
            SizeF dlugosc = g.MeasureString(Napis, drawFont); //Sprawdzenie dlugosci napisu
            SizeF dlugosc2 = g.MeasureString(Value.ToString(), drawFont);

            if (string.IsNullOrEmpty(Napis)) //Jeżeli nie ma tekstu to przesuwa pędzel w bok
            {
                dlugosc.Width = penLine.Width+16;
            }

            penLine.Width = 10;
            if (EnableWarning) // Włącz / wyłącz powiadomienia
            {
                if (Value >= Warning)
                    penLine.Color = Color.Red;
                else if (Value >= Alert)
                    penLine.Color = Color.DarkOrange;
                else penLine.Color = Kolor;
            } else penLine.Color = Kolor;

            float translate = (Value - Min) * 85     / (Max - Min); // oblicz gdzie ma skończyć rysować
            float a = Size.Height - dlugosc.Height - ((Size.Height - dlugosc.Height) * translate) / 100; // oblicz gdzie ma skończyć rysować

            g.DrawLine(penLine, dlugosc.Width/2, Size.Height-dlugosc.Height, dlugosc.Width/2, a); // Zacznij rysować nad napisem, skończ pod wartością
            g.DrawString(Napis, drawFont, drawBrush, 0, Size.Height-13); // narysuj napis
            if(ShowValue)
                g.DrawString(Value.ToString(), drawFont, drawBrush, (dlugosc.Width / 2 - dlugosc2.Width / 2), a-13); // narysuj wartość
            szerokosc = (int)dlugosc.Width; // przekaż szerokość kontrolki
        }
        
         
    }
}
