using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr3_up
{
   class PowerCable:Cable
    {//конструктор по умлчанию
        public PowerCable() { }

        //конструктор
        public PowerCable(string type, int wireCount, double diameter, bool hasSheath,string manufacturer,int voltage,int currentRating,double lenght) : base(type, wireCount, diameter)
        {
            HasSheath = hasSheath;
            Manufacturer=manufacturer;
            Voltage=voltage;
            CurrentRating=currentRating;
            Length=lenght;
        }
        //доп свойства
        public int Voltage { get; set; }
        public int CurrentRating { get; set; }
        public double Length { get; set; }
        //метод нахождения качества
        public double CalculateQualityP()
        {
            return HasSheath ? 2 * CalculateQuality() : 0.7 * CalculateQuality();
        }
        //информация об объекте
        public string PrintInfo()
        {
           
            return ("Качество на основе наличии оплетки:" + CalculateQualityP()+", "+base.ToString()+$" Напряжение: {Voltage} В, Ток: {CurrentRating} А, Длина: {Length} м");
        }
    }
}
