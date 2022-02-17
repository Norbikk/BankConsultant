using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BankConsultant
{
    public class Repository
    {
        protected readonly ObservableCollection<Person> LastChangesDatabase = PersonDataBase.LastChangesDb;
        protected readonly ObservableCollection<Person> Database = PersonDataBase.Db;

        public string CheckChanges(int id)
        {
            var str = string.Empty;
            for (int i = 0; i < LastChangesDatabase.Count; i++)
            {
                if (Database[id].Id == LastChangesDatabase[i].Id)
                {
                    str = Check(id, i) + Environment.NewLine;
                }
            }

            return str;
        }

        public ObservableCollection<Person> GetUsers()
        {
            return GetPersonsInfo();
        }

        public void SaveLastChanges(int id)
        {
            if (id == -1)
            {
                return;
            }

            if (PersonDataBase.LastChangesDb.Any(x => x.Id == PersonDataBase.Db[id].Id))
            {
                var single = PersonDataBase.LastChangesDb.ToList().FindIndex(x => x.Id == PersonDataBase.Db[id].Id);
                PersonDataBase.LastChangesDb[single] = new Person(PersonDataBase.Db[id].Id,
                    GetUser(id));
            }
            else
            {
                PersonDataBase.LastChangesDb.Add(new Person(PersonDataBase.Db[id].Id,
                    GetUser(id)));
            }
        }

        public virtual Person GetUserById(int id)
        {
            var person = new Person(GetPersonInfo(id));

            return person;
        }

        protected virtual String Check(int id, int lastChangeId)
        {
            var changes = String.Empty;
            changes += AddChange("Имя: ", Database[id].Name, LastChangesDatabase[lastChangeId].Name);
            changes += AddChange("Фамилия: ", Database[id].Surname, LastChangesDatabase[lastChangeId].Surname);
            changes += AddChange("Отчество: ", Database[id].SecondName, LastChangesDatabase[lastChangeId].SecondName);
            changes += AddChange("Номер телефона: ", Database[id].PhoneNumber,
                LastChangesDatabase[lastChangeId].PhoneNumber);

            return changes;
        }

        protected string AddChange(string typeName, string newText, string oldText)
        {
            if (newText != oldText)
            {
                return typeName + oldText + "\n";
            }

            return null;
        }

        protected static string SecureData(string str)
        {
            char[] chars = null;
            if (str != null)
            {
                chars = str.ToCharArray();

                for (int i = 0; i < chars.Length; i++)
                {
                    chars[i] = '*';
                }
            }

            var strNew = new string(chars);

            return strNew;
        }


        private Person GetUser(int id)
        {
            return Database[id];
        }

        private Person GetPersonInfo(int id)
        {
            return PersonDataBase.Db[id];
        }

        private ObservableCollection<Person> GetPersonsInfo()
        {
            return PersonDataBase.Db;
        }
    }
}