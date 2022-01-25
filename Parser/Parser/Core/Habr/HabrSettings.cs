using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SuperParser.Core.Habr
{
    class HabrSettings : IParserSettings
    {
        public HabrSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public string BaseUrl { get; set; } = "https://habr.ru"; //здесь прописываем url сайта.
        public string Prefix { get; set; } = "page{CurrentId}"; //вместо CurrentID будет подставляться номер страницы
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
