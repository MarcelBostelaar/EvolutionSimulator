using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace EvolutionSimulator
{
    class GameUpdate : AbstractAsynchronousUpdate
    {
        private World world;
        Stopwatch time;
        public GameUpdate(World world, Game game) : base(game)
        {
            this.world = world;
            time = new Stopwatch();
            time.Start();
        }

        public ulong UpdateTick { get; private set; }
        public ulong FrameTick { get; private set; }

        public void incrementFramtick()
        {
            FrameTick++;
        }

        protected override void Update()
        {
            UpdateTick++;
            world.Update(UpdateTick);
            if (UpdateTick == 2147483647)
            {
                time.Stop();
                int lol = 1;
            }
        }
    }
}
