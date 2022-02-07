namespace BankConsultant
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public int PassportSeries { get; set; }
        public int PassportNumber { get; set; }
        public long PhoneNumber { get; set; }


        /// <summary>
        /// Конструктор класса Person
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="secondName"></param>
        /// <param name="passportSeries"></param>
        /// <param name="passportNumber"></param>
        /// <param name="phoneNumber"></param>
        public Person(string name, string surname, string secondName, int passportSeries, int passportNumber,
            long phoneNumber)
        {
            Name = name;
            Surname = surname;
            SecondName = secondName;
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Возвращает строку
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Name} {Surname} {SecondName}";
    }
}