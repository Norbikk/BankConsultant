using System.Collections.ObjectModel;
using System.Linq;


namespace BankConsultant
{
    public class PersonReader
    {
        public Person GetPersonInfo(int i)
        {
            return PersonDataBase.Db[i];
        }

        public ObservableCollection<Person> GetPersonsInfo()
        {
            return PersonDataBase.Db;
        }
        

    }
}