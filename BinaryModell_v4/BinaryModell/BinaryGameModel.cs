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

        static public string generateRandomBinary(int dif)
        {
            var seed = (int)DateTime.Now.Ticks;
            Random rand = new Random(seed);

            int num = 0;
            string bin = null;
            
            if (dif == 1)
            {
                rand = new Random();
                num = rand.Next(0, 16);
                bin = deciToBinary(num);
            }
            else if (dif == 2)
            {
                rand = new Random();
                num = rand.Next(16, 255);
                bin = deciToBinary(num);
            }
            else if (dif == 3)
            {
                rand = new Random();
                num = rand.Next(256, 4096);
                bin = deciToBinary(num);
            }
            return bin;
        }

        static public string generateRandomDeci()
        {
            var seed = (int)DateTime.Now.Ticks;
            Random rand = new Random(seed);
            string randDeci = null;
            randDeci = Convert.ToString(rand.Next(0, 16));
            return randDeci;
        }

        static public string generateRandomHex(int dif)
        {
            int num = 0;
            string hex = null;
            Random rand;
            if(dif == 1)
            {
                rand = new Random();
                num = rand.Next(0, 16);
                hex = deciToHex(num);
            }
            else if (dif == 2)
            {
                rand = new Random();
                num = rand.Next(16, 255);
                hex = deciToHex(num);
            }
            else if(dif == 3)
            {
                rand = new Random();
                num = rand.Next(256, 4096);
                hex = deciToHex(num);
            }
            return hex;
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

        static public string deciToHex(int deci)
        {
            string hex = deci.ToString("X");
            return hex;
        }

        static public string hexToDeci(string hex)
        {
            string convertedHex = Convert.ToInt32(hex, 16).ToString();
            return convertedHex;
        }

        static private bool checkIfHex(string testHex)
        {
            bool isHex;
            foreach (char c in testHex)
            {
                isHex = ((c >='0' && c <= '9')|| 
                        (c>='a' && c<= 'f') ||
                        (c>='A' && c<= 'F'));
                if(!isHex)
                    return false;
            }
            return true;
        }
    }
}
