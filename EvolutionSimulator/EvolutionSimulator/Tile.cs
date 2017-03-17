using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator
{
    class Tile
    {
        public Tile(int maxfood, int regrowRate)
        {
            food = 0;
            this.maxfood = maxfood;
            this.regrowRate = regrowRate;
            hsv = new HSVColor(360, (double)maxfood / 9999.0, (double)food / (double)maxfood);
            Sleeping = false;
        }
        public bool Sleeping { get; private set;  }
        public int food { get; private set; }
        public int maxfood { get; private set; }
        public int regrowRate { get; private set; }
        public Color Color {
            get {
                return hsv.ToARGBColor();
            }
        }
        HSVColor hsv;
        public void Update()
        {
            food += regrowRate;
            if (food > maxfood)
            {
                food = maxfood;
                Sleeping = true;
            }
            hsv.Value = (double)food / (double)maxfood;
        }
    }
}
