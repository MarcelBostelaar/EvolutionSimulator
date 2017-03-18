﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator
{
    class World : IUpdateable
    {
        public World(int size, int CurrTick)
        {
            this.UpdateSchedule = new LinkedList<Tuple<int, Tile>>();
            this.size = size;
            var random = new Random((int)DateTime.Now.ToFileTime());
            Tiles = new Tile[size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Tiles[x, y] = new Tile(random.Next(100, 9999), random.Next(1, 10), CurrTick);
                    AddUpdateInOrder(Tiles[x, y].GetPlannedUpdate(), Tiles[x, y]);
                }
            }
        }

        public int size { get; private set; }

        public Tile GetTile(int x, int y)
        {
            return Tiles[x, y];
        }

        //public void Update()
        //{
        //    //var currnode = Active.First;
        //    //while (currnode != null)
        //    //{
        //    //    Tiles[currnode.Value.Item1, currnode.Value.Item2].Update();
        //    //    if (Tiles[currnode.Value.Item1, currnode.Value.Item2].Sleeping)
        //    //    {
        //    //        var temp = currnode.Value;
        //    //        currnode = currnode.Next;
        //    //        Active.Remove(temp);
        //    //    }
        //    //    else
        //    //    {
        //    //        currnode = currnode.Next;
        //    //    }
        //    //}
        //    //for (int x = 0; x < size; x++)
        //    //{
        //    //    for (int y = 0; y < size; y++)
        //    //    {
        //    //        Tiles[x, y].Update();
        //    //    }
        //    //}
        //}

        private void AddUpdateInOrder(int Tick, Tile tile)
        {
            var currnode = UpdateSchedule.First;
            while(currnode != null)
            {
                if(currnode.Value.Item1 >= Tick)
                {
                    UpdateSchedule.AddBefore(currnode, new Tuple<int, Tile>(Tick, tile));
                    return;
                }
                else
                {
                    currnode = currnode.Next;
                }
            }
            UpdateSchedule.AddLast(new Tuple<int, Tile>(Tick, tile));
        }

        public void Update(int Tick)
        {
            var currnode = UpdateSchedule.First;
            while(currnode != null)
            {
                if(currnode.Value.Item1 <= Tick)
                {
                    currnode.Value.Item2.Update(Tick);
                    var lastnode = currnode;
                    currnode = currnode.Next;
                    UpdateSchedule.Remove(lastnode);
                }
                else
                {
                    return;
                }
            }
        }

        LinkedList<Tuple<int, Tile>> UpdateSchedule;


        Tile[,] Tiles;
        //creatures list
    }
}
