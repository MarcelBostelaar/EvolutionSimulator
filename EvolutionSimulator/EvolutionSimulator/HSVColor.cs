using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator
{
    class HSVColor
    {
        public HSVColor(double Hue, double Saturation, double Value)
        {
            if (Saturation < 0 || Saturation > 1)
            {
                throw new Exception("Not allowed");
            }
            if (Value < 0 || Value > 1)
            {
                throw new Exception("Not allowed");
            }
            this.Hue = Hue;
            this.Saturation = Saturation;
            this.Value = Value;
        }
        public double Hue { get { return _Hue; }
            set {
                _Hue = value;
                while (_Hue < 0)
                    _Hue += 360;
                while (_Hue >= 360)
                    _Hue -= 360;
            }
        }
        public double Saturation
        {
            get { return _Saturation; }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new Exception("Value must be within the range of 0...1");
                }
                _Saturation = value;
            }
        }
        public double Value
        {
            get { return _Value; }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new Exception("Value must be within the range of 0...1");
                }
                _Value = value;
            }
        }
        double _Hue, _Saturation, _Value;

        public Color ToARGBColor()
        {
            var Chroma = Value * Saturation;
            var hueDevided = Hue / 60;
            var X = Chroma * (1 - Math.Abs(hueDevided % 2 - 1));
            int IntHueDevided = (int)hueDevided;
            double R, G, B;
            switch (IntHueDevided)
            {//No undefined H possible
                case 0:
                    R = Chroma;
                    G = X;
                    B = 0;
                    break;
                case 1:
                    R = X;
                    G = Chroma;
                    B = 0;
                    break;
                case 2:
                    R = 0;
                    G = Chroma;
                    B = X;
                    break;
                case 3:
                    R = 0;
                    G = X;
                    B = Chroma;
                    break;
                case 4:
                    R = X;
                    G = 0;
                    B = Chroma;
                    break;
                case 5:
                    R = Chroma;
                    G = 0;
                    B = X;
                    break;
                default:
                    throw new Exception("This shouldnt happen");
            }
            var m = Value - Chroma;
            R += m;
            G += m;
            B += m;
            return new Color((float)R, (float)G, (float)B);
        }
    }
}
