using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator
{
    class GameUpdate : AbstractAsynchronousUpdate
    {
        private World world;
        public GameUpdate(World world)
        {
            this.world = world;
        }

        public int UpdateTick { get; private set; }
        public int FrameTick { get; private set; }

        public void incrementFramtick()
        {
            FrameTick++;
        }

        protected override void Update()
        {
            UpdateTick++;
            world.Update();
        }
    }
}
