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
            this.Active = new LinkedList<Tuple<int, int>>();
            this.size = size;
            var random = new Random((int)DateTime.Now.ToFileTime());
            Tiles = new Tile[size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Tiles[x, y] = new Tile(random.Next(100, 9999), random.Next(1, 10));
                    Active.AddFirst(new Tuple<int, int>(x, y));
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
            var currnode = Active.First;
            while (currnode != null)
            {
                Tiles[currnode.Value.Item1, currnode.Value.Item2].Update();
                if (Tiles[currnode.Value.Item1, currnode.Value.Item2].Sleeping)
                {
                    var temp = currnode.Value;
                    currnode = currnode.Next;
                    Active.Remove(temp);
                }
                else
                {
                    currnode = currnode.Next;
                }
            }
            //for (int x = 0; x < size; x++)
            //{
            //    for (int y = 0; y < size; y++)
            //    {
            //        Tiles[x, y].Update();
            //    }
            //}
        }
        LinkedList<Tuple<int, int>> Active;


        Tile[,] Tiles;
        //creatures list
    }
}
