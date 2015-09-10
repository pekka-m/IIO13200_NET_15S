using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht2
{
    class BLLotto
    {
        public string type;
        private int smallestNumber, largestNumber, numberCount;
        private List<List<int>> numbers = new List<List<int>>();

        public List<List<int>> Draw(string game, int draws)
        {
            this.type = game;
            Random rnd = new Random();
            switch (this.type)
            {
                case "Suomi":
                    this.smallestNumber = 1;
                    this.largestNumber = 39;
                    this.numberCount = 7;
                    break;

                case "VikingLotto":
                    this.smallestNumber = 1;
                    this.largestNumber = 48;
                    this.numberCount = 6;
                    break;

                case "EuroJackpot":
                    this.smallestNumber = 1;
                    this.largestNumber = 50;
                    this.numberCount = 5;
                    break;
            }
            for (int i = 0; i < draws; i++)
            {
                List<int> li = new List<int>();
                for (int j = 0; j < this.numberCount; j++)
                {
                    li.Add(rnd.Next(this.smallestNumber, this.largestNumber));
                }
                if (this.type == "EuroJackpot")
                {
                    for (int j = 0; j < 2; j++)
                    {
                        li.Add(rnd.Next(1, 11));
                    }
                }
                numbers.Add(li);
            }
            return numbers;
        }
    }
}
