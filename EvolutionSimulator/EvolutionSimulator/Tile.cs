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
        public Tile(int maxfood, int regrowRate, int CurrTick)
        {
            food = 0;
            this.maxfood = maxfood;
            this.regrowRate = regrowRate;
            hsv = new HSVColor(360, (double)maxfood / 9999.0, (double)food / (double)maxfood);
            IsFullFood = false;

            tickFoodOffset = regrowRate * CurrTick - food;
        }
        public int food { get; private set; }
        public int maxfood { get; private set; }
        public int regrowRate { get; private set; }

        private int tickFoodOffset;

        private bool IsFullFood;

        private void RecalculateRegrow(int Tick)
        {
            tickFoodOffset = regrowRate * Tick - food;
        }
        public Color getColor(int Tick)
        {
            if(!IsFullFood)
                this.Update(Tick);
            return this.hsv.ToARGBColor();
        }
        HSVColor hsv;

        public int GetPlannedUpdate()
        {
            return (maxfood + tickFoodOffset) / regrowRate + 1;
        }

        public void Update(int Tick)
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
