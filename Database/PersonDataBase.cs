using System.Collections.ObjectModel;
using System.Linq;

namespace BankConsultant
{
    public static class PersonDataBase
    {
        public static ObservableCollection<Person> Db { get; set; } = new();
        public static ObservableCollection<Person> LastChangesDb = new();


        /// <summary>
        /// Сортировка по фамилии
        /// </summary>
        public static void SortingBase()
        {
            ObservableCollection<Person> list = new ObservableCollection<Person>(Db.OrderBy(x => x.Surname));
            Db = list;
        }

        /// <summary>
        /// Удаление выбранного человека из датабазы
        /// </summary>
        /// <param name="index"></param>
        public static void Remove(int index)
        {
            for(int i = 0; i< LastChangesDb.Count; i++)
            {
                if (Db[index].Id == LastChangesDb[i].Id)
                {
                    LastChangesDb.RemoveAt(i);
                }
            }
            Db.RemoveAt(index);
            
        }
    }
}