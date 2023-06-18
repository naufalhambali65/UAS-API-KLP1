using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UASKELOMPOK1API
{
    public class Fisika
    {
        public abstract class Hitung
        {
            public abstract double HitungRumus();
        }

        public class RumusFactory
        {
            private static RumusFactory instance;

            private RumusFactory() { }

            public static RumusFactory Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new RumusFactory();
                    }
                    return instance;
                }
            }

            public Hitung RumusKecepatan(double arg1, double arg2)
            {
                return new Kecepatan(arg1, arg2);
            }

            public Hitung RumusGaya(double arg1, double arg2)
            {
                return new Gaya(arg1, arg2);
            }

            public Hitung RumusDaya(double arg1, double arg2)
            {
                return new Daya(arg1, arg2);
            }

            public Hitung RumusDebit(double arg1, double arg2)
            {
                return new DebitAir(arg1, arg2);
            }

            public Hitung RumusArus(double arg1, double arg2)
            {
                return new ArusListrik(arg1, arg2);
            }

        }

        public class Kecepatan : Hitung
        {
            private double jarak;
            private double waktu;

            public Kecepatan(double jarak, double waktu)
            {
                this.jarak = jarak;
                this.waktu = waktu;
            }


            public override double HitungRumus()
            {
                return jarak / waktu;
            }

        }

        public class Gaya : Hitung
        {
            private double massa;
            private double percepatan;

            public Gaya(double massa, double percepatan)
            {
                this.massa = massa;
                this.percepatan = percepatan;

            }

            public override double HitungRumus()
            {
                return massa * percepatan;
            }

        }

        public class Daya : Hitung
        {
            private double usaha;
            private double waktu;

            public Daya(double usaha, double waktu)
            {
                this.usaha = usaha;
                this.waktu = waktu;

            }

            public override double HitungRumus()
            {
                return usaha * waktu;
            }

        }

        public class DebitAir : Hitung
        {
            private double volume;
            private double waktu;

            public DebitAir(double volume, double waktu)
            {
                this.volume = volume;
                this.waktu = waktu;

            }

            public override double HitungRumus()
            {
                return volume / waktu;
            }

        }

        public class ArusListrik : Hitung
        {
            private double tegangan;
            private double hambatan;

            public ArusListrik(double tegangan, double hambatan)
            {
                this.tegangan = tegangan;
                this.hambatan = hambatan;

            }

            public override double HitungRumus()
            {
                return tegangan / hambatan;
            }

        }
    }
}
