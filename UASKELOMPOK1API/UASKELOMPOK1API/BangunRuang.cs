using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UASKELOMPOK1API
{
    public class BangunRuang
    {
        public abstract class Shape
        {
            public abstract double HitungVolume();
            public abstract double HitungLuasPermukaan();
        }

        // ShapeFactory
        public class ShapeFactory
        {
            private static ShapeFactory instance;

            private ShapeFactory() { }

            public static ShapeFactory Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new ShapeFactory();
                    }
                    return instance;
                }
            }

            public Shape BuatBola(double radius)
            {
                return new Bola(radius);
            }

            public Shape BuatKubus(double sisi)
            {
                return new Kubus(sisi);
            }

            public Shape Buattabung(double radius, double tinggi)
            {
                return new tabung(radius, tinggi);
            }

        }

        public class Bola : Shape
        {
            private double radius;

            public Bola(double radius)
            {
                this.radius = radius;
            }

            public override double HitungVolume()
            {
                return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
            }

            public override double HitungLuasPermukaan()
            {
                return 4 * Math.PI * Math.Pow(radius, 2);
            }

        }

        // Kubus
        public class Kubus : Shape
        {
            private double sisi;

            public Kubus(double sisi)
            {
                this.sisi = sisi;
            }

            public override double HitungVolume()
            {
                return Math.Pow(sisi, 3);
            }

            public override double HitungLuasPermukaan()
            {
                return 6 * Math.Pow(sisi, 2);
            }

        }

        // tabung
        public class tabung : Shape
        {
            private double radius;
            private double tinggi;

            public tabung(double radius, double tinggi)
            {
                this.radius = radius;
                this.tinggi = tinggi;
            }

            public override double HitungVolume()
            {
                return Math.PI * Math.Pow(radius, 2) * tinggi;
            }

            public override double HitungLuasPermukaan()
            {
                double luasAlas = Math.PI * Math.Pow(radius, 2);
                double kelilingAlas = 2 * Math.PI * radius;
                double luasSelimut = kelilingAlas * tinggi;
                return 2 * luasAlas + luasSelimut;
            }

        }
    }
}
