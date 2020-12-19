using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2B
{
    class Deck
    {
        private Card[] card = new Card[52];

        public Deck()
        {
            for (byte i = 0; i < 52; i++)
            {
                SetCard(i);
            }
        }

        private void SetCard(byte index)
        {
            byte number = index;
            number += 2;
            while (number > 14)
                number -= 13;
            char rank = 'e';
            switch (number)
            {
                case 2:
                    rank = '2';
                    break;
                case 3:
                    rank = '3';
                    break;
                case 4:
                    rank = '4';
                    break;
                case 5:
                    rank = '5';
                    break;
                case 6:
                    rank = '6';
                    break;
                case 7:
                    rank = '7';
                    break;
                case 8:
                    rank = '8';
                    break;
                case 9:
                    rank = '9';
                    break;
                case 10:
                    rank = '0';
                    break;
                case 11:
                    rank = 'J';
                    break;
                case 12:
                    rank = 'Q';
                    break;
                case 13:
                    rank = 'K';
                    break;
                case 14:
                    rank = 'A';
                    break;
            }
            string suit = "Отсутствует";
            if (index < 13)
            {
                suit = "Пик";
            }
            else if (index < 26)
            {
                suit = "Черви";
            }
            else if (index < 39)
            {
                suit = "Бубен";
            }
            else if (index < 52)
            {
                suit = "Крести";
            }
            card[index] = new Card(suit, rank);
        }

        public string GetCard(byte index)
        {
            return card[index].ToString();
        }

        public void Shuffle()
        {
            Card buf;
            int index1;
            int index2;
            Random rnd = new Random();
            for (byte i = 0; i < 52; i++)
            {
                index1 = rnd.Next(0, 52);
                index2 = rnd.Next(0, 52);
                buf = card[index1];
                card[index1] = card[index2];
                card[index2] = buf;
            }
        }

    }
}
