using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    public class Movie
    {
        public static Random rnd = new Random();
        public int Rating = 0;
        
        public virtual String GetInfo()//общее свойство
        {
            var str = String.Format("\nРейтинг: {0}", this.Rating);
            return str;
        }
        public virtual Image GetImage()
        {
            return Properties.Resources.ma;
        }
    }
    public enum FilmType1 { ma, gp, hp}
    public enum FilmType { art, documentary, action, detective, history };//тип фильма
 
    public class Film : Movie
    {
        public int Timing = 0;//Хронометраж
        public int NumberOfAwards = 0;//Количество наград
        public FilmType type = FilmType.art;//Тип фильма
        public FilmType1 type1 = FilmType1.ma;

        public override String GetInfo()//отправляет для вывода
        {
            var str = "Я фильм";
            str += base.GetInfo();

            str += String.Format("\nХронометраж: {0} минут", this.Timing);
            str += String.Format("\nКоличество наград: {0}", this.NumberOfAwards);
            str += String.Format("\nТип: {0}", this.type);
            return str;
        }
        public override Image GetImage()
        {
            switch (type1)
            {
                case FilmType1.ma:
                    return Properties.Resources.ma as Bitmap;
                case FilmType1.gp:
                    return Properties.Resources.gp as Bitmap;
                default:
                    return Properties.Resources.hn as Bitmap;
            }
        }

        public static Film Generate()//генерирует рандомом числа для свойств
        {
            return new Film
            {
                Rating = rnd.Next() % 10,
                Timing = 60 + rnd.Next() % 120,
                NumberOfAwards = rnd.Next() % 11,
                type = (FilmType)rnd.Next(5),
                type1 = (FilmType1)rnd.Next(3)
            };
        }
    }

    public enum SerialType { dru, st, hx }
    public class Serial : Movie
    {
        public int TotalNumberOfEpisodes = 0;//Общее количество серий
        public int NumberOfSeasons = 0;//Количество сезонов
        public SerialType type = SerialType.dru;

        public override String GetInfo()//отправляет для вывода
        {
            var str = "Я сериал";
            str += base.GetInfo();
            str += String.Format("\nОбщее количество серий: {0}", this.TotalNumberOfEpisodes);
            str += String.Format("\nКоличество сезонов: {0}", this.NumberOfSeasons);
            return str;
        }

        public override Image GetImage()
        {
            switch (type)
            {
                case SerialType.dru:
                    return Properties.Resources.dru as Bitmap;
                case SerialType.st:
                    return Properties.Resources.st as Bitmap;
                default:
                    return Properties.Resources.hx as Bitmap;
            }
        }

        public static Serial Generate()//генерирует рандомом числа для свойств
        {
            return new Serial
            {
                Rating = rnd.Next() % 10,
                TotalNumberOfEpisodes = 13 + rnd.Next() % 300,
                NumberOfSeasons = 1 + rnd.Next() % 20,
                type = (SerialType)rnd.Next(3)
            };
        }
    }

    public enum TvType { gal, sto, vu }
    public class TV : Movie
    {
        public int Time = 0;//Продолжительность
        public int AirtimeH = 0;//Эфирное время часы
        public int AirtimeM = 0;//Эфирное время минуты
        public TvType type = TvType.gal;

        public override String GetInfo()//генерирует рандомом числа для свойств
        {
            var str = "Я телепередача";
            str += base.GetInfo();
            str += String.Format("\nПродолжительность: {0} минут", this.Time);
            str += String.Format("\nЭфирное время: {0}:{1}", this.AirtimeH, this.AirtimeM);
            return str;
        }

        public override Image GetImage()
        {
            switch (type)
            {
                case TvType.gal:
                    return Properties.Resources.gal as Bitmap;
                case TvType.sto:
                    return Properties.Resources.sto as Bitmap;
                default:
                    return Properties.Resources.vu as Bitmap;
            }
        }
        public static TV Generate()//отправляет для вывода
        {
            return new TV
            {
                Rating = rnd.Next() % 10,
                Time = 40 + rnd.Next() % 50,
                AirtimeH = rnd.Next() % 23,
                AirtimeM = rnd.Next() % 60,
                type = (TvType)rnd.Next(3)
            };
        }
    }


}