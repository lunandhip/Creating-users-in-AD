using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Форма_для_2гис
{
    public class Translit // объявляем и заполняем словарь с заменами
    {
        Dictionary<string, string> dictionnaryChar = new Dictionary<string, string>()
        {
            {"а","a"},
            {"б","b"},
            {"в","v"},
            {"г","g"},
            {"д","d"},
            {"е","e"},
            {"ё","e"}, 
            {"ж","zh"},
            {"з","z"},
            {"и","i"},
            {"й","y"},
            {"к","k"},
            {"л","l"},
            {"м","m"},
            {"н","n"},
            {"о","o"},
            {"п","p"},
            {"р","r"},
            {"с","s"},
            {"т","t"},
            {"у","u"},
            {"ф","f"},
            {"х","h"},
            {"ц","c"},
            {"ч","ch"},
            {"ш","sh"},
            {"щ","sch"},
            {"ъ",""}, // ъ замещаеться на ничего
            {"ы","y"},
            {"ь",""}, // ь замещаеться на ничего
            {"э","e"},
            {"ю","yu"},
            {"я","ya"}
        };
        public string MagicZone(string source)
        {
            var result = "";// проход по строке для поиска символов подлежащих замене которые находятся в словаре dictionaryChar
            foreach (var ch in source)
            {
                var ss = "";
                // берём каждый символ строки и проверяем его на нахождение его в словаре для замены,
                // если в словаре есть ключ с таким значением то получаем true 
                // и добавляем значение из словаря соответствующее ключу
                if (dictionnaryChar.TryGetValue(ch.ToString(), out ss))
                {
                    result += ss;
                }
                else result += ch;
            }
            return result;
        }
    }
}
