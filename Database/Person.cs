using System;

namespace BankConsultant
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime DateOfChanging { get; set; }

        public string WhoChanging { get; set; }


        public Person()
        {
        }

        public Person(Person person)
        {
            Id = person.Id;
            Name = person.Name;
            Surname = person.Surname;
            SecondName = person.SecondName;
            PassportSeries = Convert.ToString(person.PassportSeries);
            PassportNumber = Convert.ToString(person.PassportNumber);
            PhoneNumber = person.PhoneNumber;
            DateOfChanging = person.DateOfChanging;
            WhoChanging = person.WhoChanging;
        }

        public Person(int id, Person person)
        {
            Id = id;
            Name = person.Name;
            Surname = person.Surname;
            SecondName = person.SecondName;
            PassportSeries = Convert.ToString(person.PassportSeries);
            PassportNumber = Convert.ToString(person.PassportNumber);
            PhoneNumber = person.PhoneNumber;
            DateOfChanging = person.DateOfChanging;
            WhoChanging = person.WhoChanging;
        }

        /// <summary>
        /// Возвращает строку
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Name} {Surname} {SecondName}";
    }
}