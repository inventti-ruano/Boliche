using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BowlingGame
{
    class BowlingGameTest
    {
        private Game g;

        protected void SetUp()
        {
            g = new Game();
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                g.Roll(pins);
        }

        [Test]
        public void GutterGame()
        {
            this.SetUp();
            this.RollMany(20, 0);
            Assert.AreEqual(0, this.g.Score());
        }

        [Test]
        public void AllOnes()
        {
            this.SetUp();
            RollMany(20,1);
            Assert.AreEqual(20, this.g.Score());
        }

        [Test]
        // [Ignore]
        public void oneSpare()
        {
            this.SetUp();
            this.RollSpare();
            //this.g.Roll(3);
            //this.RollMany(17, 0);

            Assert.AreEqual(10, this.g.Score());
        }

        [Test]
        public void oneStrike()
        {
            this.SetUp();
            this.RollStrike();
            g.Roll(3);
            g.Roll(4);
            this.RollMany(16, 0);
            Assert.AreEqual(24, g.Score());
        }

        [Test]
        public void PerfectGame()
        {
            this.SetUp();
            this.RollMany(12, 10);
            Assert.AreEqual(300, g.Score());
        }

        private void RollStrike()
        {
            g.Roll(10);
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }
}
