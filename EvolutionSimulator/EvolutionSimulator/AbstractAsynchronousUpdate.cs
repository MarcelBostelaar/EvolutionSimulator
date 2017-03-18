﻿using System.Threading;
using Microsoft.Xna.Framework;

namespace EvolutionSimulator
{
	/// <summary>
	/// Subclass this abstract class and implement the update function. Then start and stop as you see fit.
	/// </summary>
    abstract class AbstractAsynchronousUpdate
    {
        Thread UpdateThread;
        /// <summary>
        /// Boolean showing if there is currently an update thread running or not.
        /// </summary>
        public bool ThreadIsRunning { get; private set; }

        public AbstractAsynchronousUpdate(Game game)
        {
            ThreadIsRunning = false;
            game.Exiting += Game_Exiting;
        }

        private void Game_Exiting(object sender, System.EventArgs e)
        {
            this.StopThread();
        }

        /// <summary>
        /// Method that can be invoked every monogame update. Will excecute one update if no thread is running, will do nothing if a thread is already doing updates.
        /// </summary>
        public void Invoke()
        {
            if (!ThreadIsRunning)
            {
                Update();
            }
        }

        /// <summary>
        /// Starts the maximum speed update thread if none is already running.
        /// </summary>
        public void StartThread()
        {
            if (!ThreadIsRunning)
            {
				UpdateThread = new Thread(new ThreadStart(LoopUpdate));
                UpdateThread.Start();
                ThreadIsRunning = true;
            }
        }
        /// <summary>
        /// Starts the maximum speed update thread if none is already running, for a specified amount of loops.
        /// </summary>
        /// <param name="loopsAmount">A specified amount of loops to run.</param>
        public void StartThread(int loopsAmount)
        {
            if (!ThreadIsRunning)
            {
                UpdateThread = new Thread(new ThreadStart(() => LoopUpdate(loopsAmount)));
                UpdateThread.Start();
                ThreadIsRunning = true;
            }
        }

        /// <summary>
        /// Stops the maximum speed update thread if one is currently running. Thread will stop at the end of a full update call.
        /// </summary>
        public void StopThread()
        {
            if (ThreadIsRunning)
            {
                DoLoop = false;
                UpdateThread.Join();
            }
        }

        bool DoLoop;
        private void LoopUpdate()
        {
            DoLoop = true;
            while (DoLoop)
            {
                Update();
            }
            ThreadIsRunning = false;
        }
        private void LoopUpdate(int Loops)
        {
            DoLoop = true;
            int count = 0;
            while (DoLoop && count < Loops)
            {
                Update();
                count++;
            }
            ThreadIsRunning = false;
        }
        protected abstract void Update();
    }
}
