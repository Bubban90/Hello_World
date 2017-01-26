using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryModell
{
    class BinaryGameModel
    {
        static public string deciToBinary(int deci)
        {
            string binary = Convert.ToString(deci, 2);
            return binary;
        }

        static public string binaryToDeci(string binary)
        {
            string convertedBin = Convert.ToInt32(binary, 2).ToString();
            return convertedBin;
        }

        static public string generateRandomBinary()
        {
            var seed = (int)DateTime.Now.Ticks;
            Random rand = new Random(seed);
            string randBinary = null;
            for (int i = 0; i < 4; i++)
            {
                randBinary += rand.Next(0, 2);
            }
            return randBinary;
        }

        static public string generateRandomDeci()
        {
            var seed = (int)DateTime.Now.Ticks;
            Random rand = new Random(seed);
            string randDeci = null;
            randDeci = Convert.ToString(rand.Next(0, 16));
            return randDeci;
        }

        static public bool checkIfBinary(string testBin)
        {
            foreach (char c in testBin)
            {
                if (c != '0' && c!= '1')
                {
                    return false;
                }
                
            }
            return true;
        }

        static public bool checkIfDecimal(string testDeci)
        {
            foreach(char c in testDeci)
            {
                if(c < '1' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
