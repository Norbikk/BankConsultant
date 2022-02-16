using System;

namespace BankConsultant
{
    public class Manager : Consultant
    {
        public void UpdatePerson(int i, Person person)
        {
            SetData(i, person);
            PersonDataBase.Db[i] = person;
        }

        private Person SetData(int i, Person person)
        {
            person.DateOfChanging = DateTime.Now;
            person.WhoChanging = "Менеджер";
            PersonDataBase.Db[i] = person;
            return person;
        }
        
        public override Person GetUserById(int i)
        {
            return PersonDataBase.Db[i];
        }
        
        public override String Cheking(int where, int i)
        {
            var lastChangesDatabase = PersonDataBase.LastChangesDb;
            var database = PersonDataBase.Db;

            var changes = "Изменено: " +"\n";
            if (database[where].Name != lastChangesDatabase[i].Name)
            {
                changes += "Имя: " + lastChangesDatabase[i].Name + "\n";
            }
            if (database[where].Surname != lastChangesDatabase[i].Surname)
            { 
                changes += "Фамилия: " + lastChangesDatabase[i].Surname + "\n";
            }
            if (database[where].SecondName != lastChangesDatabase[i].SecondName)
            {
                changes += "Отчество: " + lastChangesDatabase[i].SecondName + "\n";
            }
            if (database[where].PassportSeries != lastChangesDatabase[i].PassportSeries)
            {
                changes += "Серия паспорта: " + lastChangesDatabase[i].PassportSeries + "\n";
            }
            if (database[where].PassportNumber != lastChangesDatabase[i].PassportNumber)
            {
                changes += "Номер паспорта: " + lastChangesDatabase[i].PassportNumber + "\n";
            }
            if (database[where].PhoneNumber != lastChangesDatabase[i].PhoneNumber)
            {
                changes += "Номер телефона: " + lastChangesDatabase[i].PhoneNumber + "\n";
            }

            return changes;
        }
    }
}