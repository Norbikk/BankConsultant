using System;

namespace BankConsultant
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string PhoneNumber { get; set; }


        /// <summary>
        /// Конструктор класса Person
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="secondName"></param>
        /// <param name="passportSeries"></param>
        /// <param name="passportNumber"></param>
        /// <param name="phoneNumber"></param>
        public Person(string name, string surname, string secondName, string passportSeries, string passportNumber,
            string phoneNumber)
        {
            Name = name;
            Surname = surname;
            SecondName = secondName;
            PassportSeries = Convert.ToString(passportSeries);
            PassportNumber = Convert.ToString(passportNumber);
            PhoneNumber = phoneNumber;
        }
        public Person()
        {

        }
        public Person(Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
            SecondName = person.SecondName;
            PassportSeries = Convert.ToString(person.PassportSeries);
            PassportNumber = Convert.ToString(person.PassportNumber);
            PhoneNumber = person.PhoneNumber;
        }

        /// <summary>
        /// Возвращает строку
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Name} {Surname} {SecondName}";
    }
}