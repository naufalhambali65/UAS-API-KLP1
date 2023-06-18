using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UASKELOMPOK1API.BangunRuang;
using static UASKELOMPOK1API.Fisika;
using static UASKELOMPOK1API.Statistika;

namespace UASKELOMPOK1API
{
    public class API
    {
        public enum ShapeCategory
        {
            Bola,
            Kubus,
            Tabung
        }
        public enum RumusCategory
        {
            Kecepatan,
            Gaya,
            Daya,
            Debit,
            Arus
        }
        
        public enum StatistikCategory
        {
            Mean,
            Median,
            Jangkauan,
            SimpanganBaku,
            SimpanganRataRata
        }

        private static API instance;
        private ShapeFactory shapeFactory;
        private RumusFactory rumusFactory;
        private StatistikFactory statistikFactory;

        private API()
        {
            shapeFactory = ShapeFactory.Instance;
            rumusFactory = RumusFactory.Instance;
            statistikFactory = StatistikFactory.Instance;
        }

        public static API Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new API();
                }
                return instance;
            }
        }

        public Shape BuatBangunRuang(ShapeCategory kategori, double arg1 = 0, double arg2 = 0)
        {
            switch (kategori)
            {
                case ShapeCategory.Bola:
                    return shapeFactory.BuatBola(arg1);
                case ShapeCategory.Tabung:
                    return shapeFactory.Buattabung(arg1, arg2);
                case ShapeCategory.Kubus:
                    return shapeFactory.BuatKubus(arg1);
                default:
                    throw new Exception("Kategori tidak valid");
            }
        }

        public Hitung HitungRumusFisika(RumusCategory kategori, double arg1 = 0, double arg2 = 0)
        {
            switch (kategori)
            {
                case RumusCategory.Kecepatan:
                    return rumusFactory.RumusKecepatan(arg1, arg2);
                case RumusCategory.Gaya:
                    return rumusFactory.RumusGaya(arg1, arg2);
                case RumusCategory.Daya:
                    return rumusFactory.RumusDaya(arg1, arg2);
                case RumusCategory.Debit:
                    return rumusFactory.RumusDebit(arg1, arg2);
                case RumusCategory.Arus:
                    return rumusFactory.RumusArus(arg1, arg2);
                default:
                    throw new Exception("Kategori tidak valid");
            }
        }

        public Data HitungDataStatistik(StatistikCategory kategori, string arg1)
        {
            switch (kategori)
            {
                case StatistikCategory.Mean:
                    return statistikFactory.HitungMean(arg1);
                case StatistikCategory.Median:
                    return statistikFactory.HitungMedian(arg1);
                case StatistikCategory.Jangkauan:
                    return statistikFactory.HitungJangkauan(arg1);
                case StatistikCategory.SimpanganBaku:
                    return statistikFactory.HitungSimpanganBaku(arg1);
                case StatistikCategory.SimpanganRataRata:
                    return statistikFactory.HitungSimpanganRata(arg1);
                default:
                    throw new Exception("Kategori tidak valid");
            }
        }

            
     
    }
}
