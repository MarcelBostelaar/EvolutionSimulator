using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator
{
    class World
    {
        public World(int size)
        {
            this.size = size;
            var random = new Random((int)DateTime.Now.ToFileTime());
            Tiles = new Tile[size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Tiles[x, y] = new Tile(random.Next(100, 9999), random.Next(1, 10));
                }
            }
        }

        public int size { get; private set; }

        public Tile GetTile(int x, int y)
        {
            return Tiles[x, y];
        }

        public void Update()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Tiles[x, y].Update();
                }
            }
        }

        Tile[,] Tiles;
        //creatures list
    }
}
