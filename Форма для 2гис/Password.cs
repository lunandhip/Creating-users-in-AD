using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Форма_для_2гис
{
    class Password
    {
        public static string MagicZone()
        {
            string[] SmallLetters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" }; //генерируем библиотеку 
            string[] Lettes = { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string[] Numbers = { "2", "3", "4", "5", "6", "7", "8", "9" };

            string pass1 = "", pass2 = ""; //Создаем чтобы работать

            Random RandomSmallLetter = new Random();
            for (int i = 0; i < 2; i++)
            {
                pass1 += SmallLetters[RandomSmallLetter.Next(SmallLetters.Length)];
                pass2 += SmallLetters[RandomSmallLetter.Next(SmallLetters.Length)];
            }

            Random RandomLettes = new Random(); // Рандом для рандома символа
            Random RandomNumber = new Random(); // Для выбора рандомного числа



            //Цифру для pass1
            Random MagicNumber = new Random();//Выбираем позицию
            int GetMagicNumber = MagicNumber.Next(2);
            string GegNumber = Numbers[RandomNumber.Next(Numbers.Length)];
            pass1 = pass1.Insert(GetMagicNumber, GegNumber);

            // Cимвол для pass1
            GetMagicNumber = MagicNumber.Next(2, 4); //Генерирует позицию которая будет заменена
            string GegLette = Lettes[RandomLettes.Next(Lettes.Length)];// Выбираем букву
            pass1 = pass1.Insert(GetMagicNumber, GegLette); //Заменяем


            //==================================================

            // Цифру для pass2
            GetMagicNumber = MagicNumber.Next(2); // Определяем новую рандомную позицию
            GegNumber = Numbers[RandomNumber.Next(Numbers.Length)];
            pass2 = pass2.Insert(GetMagicNumber, GegNumber);

            //Букву для pass2
            GetMagicNumber = MagicNumber.Next(2, 4);
            GegLette = Lettes[RandomLettes.Next(Lettes.Length)];
            pass2 = pass2.Insert(GetMagicNumber, GegLette);
            //Суммируем и выводим
            string Password = pass1 + pass2;

            return Password;
        }
    }
}
