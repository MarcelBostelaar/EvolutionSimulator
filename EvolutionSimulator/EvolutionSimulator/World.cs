using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator
{
    class World : IUpdateable
    {
        public World(int size, ulong CurrTick)
        {
            this.size = size;
            var random = new Random((int)DateTime.Now.ToFileTime());
            Tiles = new Tile[size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Tiles[x, y] = new Tile((ulong)random.Next(100, 9999), (ulong)random.Next(1, 10), CurrTick);
                }
            }
        }

        public int size { get; private set; }

        public Tile GetTile(int x, int y)
        {
            return Tiles[x, y];
        }
        public void Update(ulong Tick)
        {

        }


        Tile[,] Tiles;
        //creatures list
    }
}
