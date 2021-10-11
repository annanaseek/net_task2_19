using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_task2_19
{
    class Logic
    {
        public string GetNewString(int[] chipher, char[] startString)
        {
            Dictionary<int, char> numberLetter = new Dictionary<int, char>();
            Dictionary<char, int> letterNumber = new Dictionary<char, int>();
            FillDictionary(numberLetter, letterNumber);

            int i = 0;
            for (int j = 0; j < startString.Length; j++)
            {
                if (i > 9) i -= 10;
                startString[j] = GetNewSymbol(startString[j], chipher[i], numberLetter, letterNumber);
                i++;
            }

            return new string(startString);
        }

        char GetNewSymbol(char symbol, int shift, Dictionary<int, char> numberLetter, Dictionary<char, int> letterNumber)
        {
            char current = char.ToLower(symbol);
            if (!letterNumber.ContainsKey(current)) return symbol;

            int newSymbolNumber = letterNumber[current] + shift;
            if (newSymbolNumber > 32) newSymbolNumber -= 32;
            if (char.IsUpper(symbol)) 
                symbol = char.ToUpper(numberLetter[newSymbolNumber]);
            else symbol = numberLetter[newSymbolNumber];
            
            return symbol;
            

        }

        void FillDictionary(Dictionary<int, char> numberLetter, Dictionary<char, int> letterNumber)
        {
            int j = 1072;
            for (int i = 1; i < 33; i++)
            {
                char c = System.Convert.ToChar(j);
                numberLetter.Add(i, c);
                letterNumber.Add(c, i);
                j++;
            }
            

        }
    }
}
