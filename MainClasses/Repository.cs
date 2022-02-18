using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BankConsultant
{
    public class Repository
    {
        protected readonly ObservableCollection<Person> LastChangesDatabase = PersonDataBase.LastChangesDb;
        protected readonly ObservableCollection<Person> Database = PersonDataBase.Db;

        /// <summary>
        /// Проверяет изменения в базе
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Получение базы Person
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Person> GetUsers()
        {
            return PersonDataBase.Db;
        }

        /// <summary>
        /// Сохраняет последние изменения
        /// </summary>
        /// <param name="id">Индекс базы данных</param>
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
        /// <summary>
        /// Получает персона по индексу
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Person GetUserById(int id)
        {
            var person = new Person(GetUser(id));

            return person;
        }
        /// <summary>
        /// проверяет данные на совпадения
        /// </summary>
        /// <param name="id">индекс базы данных</param>
        /// <param name="lastChangeId">индекс базы истории</param>
        /// <returns>Возвращает строку с изменениями</returns>
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
        /// <summary>
        /// Метод для сравнения
        /// </summary>
        /// <param name="typeName">Тип изменения</param>
        /// <param name="newText">Новая информация</param>
        /// <param name="oldText">Старая информация</param>
        /// <returns></returns>
        protected string AddChange(string typeName, string newText, string oldText)
        {
            if (newText != oldText)
            {
                return typeName + oldText + "\n";
            }

            return null;
        }
        /// <summary>
        /// Засекречивание данных
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Возвращает строку с ***</returns>
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

        /// <summary>
        /// Получение данных о Person
        /// </summary>
        /// <param name="id">индекс</param>
        /// <returns>Возвращает Person</returns>
        private Person GetUser(int id)
        {
            return Database[id];
        }


    }
}