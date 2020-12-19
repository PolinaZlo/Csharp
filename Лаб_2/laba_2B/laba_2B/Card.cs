using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2B
{
    class Card
    {
        private string suit = "Отсутствует";

        private char rank = 'e';

        private Card()
        {
        }

        public Card(string suit, char rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public override string ToString()
        {
            string card;
            switch (rank)
            {
                case '2':
                    card = "Двойка";
                    break;
                case '3':
                    card = "Тройка";
                    break;
                case '4':
                    card = "Четвёрка";
                    break;
                case '5':
                    card = "Пятёрка";
                    break;
                case '6':
                    card = "Шестёрка";
                    break;
                case '7':
                    card = "Семёрка";
                    break;
                case '8':
                    card = "Восьмёрка";
                    break;
                case '9':
                    card = "Девятка";
                    break;
                case '0':
                    card = "Десятка";
                    break;
                case 'J':
                    card = "Валет";
                    break;
                case 'Q':
                    card = "Дама";
                    break;
                case 'K':
                    card = "Король";
                    break;
                case 'A':
                    card = "Туз";
                    break;
                default:
                    card = "Нет ранга";
                    break;
            }
            if (suit != "Отсутствует")
            {
                card += " " + suit;
            }
            else
                suit += " и нет масти";
            return card;
        }
    }
}
