using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator
{
    class Tile : IUpdateable
    {
        public Tile(ulong maxfood, ulong regrowRate, ulong CurrTick)
        {
            food = 0;
            this.maxfood = maxfood;
            this.regrowRate = regrowRate;
            hsv = new HSVColor(360, (double)maxfood / 9999.0, (double)food / (double)maxfood);
            IsFullFood = false;

            RecalculateRegrow(CurrTick);
        }
        public ulong food { get; private set; }
        public ulong maxfood { get; private set; }
        public ulong regrowRate { get; private set; }

        private ulong tickFoodOffset;

        private bool IsFullFood;

        private void RecalculateRegrow(ulong Tick)
        {
            tickFoodOffset = (ulong)regrowRate * Tick - (ulong)food;
        }
        public Color getColor(ulong Tick)
        {
            if(!IsFullFood)
                this.Update(Tick);
            return this.hsv.ToARGBColor();
        }
        HSVColor hsv;

        public void Update(ulong Tick)
        {
            food = regrowRate * Tick - tickFoodOffset;
            if(food >= maxfood)
            {
                food = maxfood;
                IsFullFood = true;
            }
            hsv.Value = (double)food / (double)maxfood;
        }
    }
}
