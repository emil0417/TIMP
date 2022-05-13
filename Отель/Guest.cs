using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Отель
{
    class Guest // класс гостя
    {
        public string Name { get; set; } //имя
        public string SeName { get; set; }//фамилия
        public string FatherName { get; set; }//отчество
        public string Grazgdanstvo { get; set; }//гражданство
        public string Pasport { get; set; }//номер и серия паспорта
        public int DayBirth { get; set; }//день рождения
        public int MonhBirth { get; set; }// месяц рождения
        public int YearBirth { get; set; }//год рожления
        public string NumberPhon { get; set; }//номер телефона
        public int InDay { get; set; }//день приезда
        public int InMonth { get; set; }//месяц приезда
        public int InYear { get; set; }//год приезда
        public int OutDay { get; set; }// день отъезда
        public int OutMonth { get; set; }//месяц отъезда
        public int OutYear { get; set; }//год отъезда
        public int PersNomer { get; set; }//номер в гостиннице
    }

    class GuestZap : Guest //класс наследуемый от класса гостя, необходим для осуществления записи гостя
    {

    }

}
