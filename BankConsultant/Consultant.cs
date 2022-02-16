using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BankConsultant
{
    public class Consultant
    {
        protected PersonReader Reader { get; } = new PersonReader();

        public ObservableCollection<Person> GetUsers()
        {
            return Reader.GetPersonsInfo();
        }

        public virtual Person GetUserById(int i)
        {
            var person = new Person(Reader.GetPersonInfo(i));
            
            person.PassportSeries = PrivateData(person.PassportSeries);
            person.PassportNumber = PrivateData(person.PassportNumber);

            return person;
        }

        public string CheckChanges(int what)
        {
            var str = string.Empty;
            var database = PersonDataBase.Db;
            var lastChangesDatabase = PersonDataBase.LastChangesDb;
            for (int i = 0; i < lastChangesDatabase.Count; i++)
            {
                if (database[what].Id == lastChangesDatabase[i].Id)
                {
                    str = Cheking(what, i) + Environment.NewLine;
                }

            }
            return str;
        }

        public void SaveLastChanges(int what)
        {
            if (what > -1)
            {
                if (PersonDataBase.LastChangesDb.Any(x => x.Id ==PersonDataBase.Db[what].Id))
                {
                    var single = PersonDataBase.LastChangesDb.ToList().FindIndex(x => x.Id == PersonDataBase.Db[what].Id);
                    PersonDataBase.LastChangesDb[single] =  new Person(PersonDataBase.Db[what].Id,
                    GetUser(what));
                }
                else
                {
                    PersonDataBase.LastChangesDb.Add(new Person(PersonDataBase.Db[what].Id,
                   GetUser(what)));
                }
            }
        }
        public virtual String Cheking(int where, int i)
        {
            var lastChangesDatabase = PersonDataBase.LastChangesDb;
            var database = PersonDataBase.Db;

            var changes = "Изменено: " + "\n";
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
                changes += "Серия паспорта: " + PrivateData(lastChangesDatabase[i].PassportSeries) + "\n";
            }
            if (database[where].PassportNumber != lastChangesDatabase[i].PassportNumber)
            {
                changes += "Номер паспорта: " + PrivateData(lastChangesDatabase[i].PassportNumber) + "\n";
            }
            if (database[where].PhoneNumber != lastChangesDatabase[i].PhoneNumber)
            {
                changes += "Номер телефона: " + lastChangesDatabase[i].PhoneNumber + "\n";
            }

            return changes;
        }

        private static string PrivateData(string where)
        {
            char[] what = null;
            if (where != null)
            {
                what = where.ToCharArray();

                for (int i = 0; i < what.Length; i++)
                {
                    what[i] = '*';
                }
            }

            var strNew = new string(what);

            return strNew;
        }

        private Person GetUser(int i)
        {
            return PersonDataBase.Db[i];
        }

    }
}