using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Отель
{
    class Nomer //клас номера в гостиннице
    {
        public string Lux { get; set; } // люкс или не люс
        public int Prise { get; set; }// стоимость
        public int Storey { get; set; }//этаж
        public int KolvoMest { get; set; }//количество мест в номере
        public string Vid { get; set; }//вид из окна
        public int KolBedroom { get; set; }//количество спальных комнат
        public string Seif { get; set; }// наличие сейфа
        public string Internet { get; set; }//наличие интернета
        public int Namber { get; set; }// номер 
        public string DataOt { get; set; }// дата отъезда из номера
    }

}
