using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace EvolutionSimulator
{
    class GameUpdate : AbstractAsynchronousUpdate
    {
        private World world;
        public GameUpdate(World world, Game game) : base(game)
        {
            this.world = world;
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
        }
    }
}
