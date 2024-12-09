using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr3_up
{
    class Cable
    {  // Конструктор по умолчанию
        public Cable() { }
        //конструктор 
        public Cable(string type, int wireCount, double diameter)
        {
            Type = type;
            WireCount = wireCount;
            Diameter = diameter;
        }

        // Поля
        public string Type { get; set; }
        public int WireCount { get; set; }
        public double Diameter { get; set; }
        //доп.поля
        public bool HasSheath { get; set; }
        public string Manufacturer { get; set; }

        // Функция, определяющая качество объекта
        public double CalculateQuality()
        {
            return Diameter / WireCount;
        }

        // Вывод информации об объекте
        public override string ToString()
        {
            return $" Тип: {Type}, Количество жил: {WireCount}, Диаметр: {Diameter}, Наличие оплетки: {HasSheath}, Производитель: {Manufacturer}";
        }

        // Методы для добавления и удаления объектов
       public static List<Cable> cables = new List<Cable>();
        private static Dictionary<string, Cable> cableDict = new Dictionary<string, Cable>();

        public static void AddCable(Cable cable)
        {
            cables = cables.Concat(new List<Cable> { cable }).ToList();
            cableDict[cable.Type] = cable;
        }

        public static void RemoveCable(Cable cable)
        {

            cables = cables.Where(c => c != cable).ToList();
            cableDict.Remove(cable.Type);

        }

        public static void RemoveCable(string type)
        {
            var cable = cableDict[type];
            cables = cables.Where(c => c != cable).ToList();
            cableDict.Remove(type);
        }

        public static void RemoveCable(int index)
        {
            var cable = cables[index];
            cables = cables.Where((c, i) => i != index).ToList();
            cableDict.Remove(cable.Type);
        }
    }
    }
