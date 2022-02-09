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

        private static string PrivateData(string where)
        {
            char[] what = null;
            if (where != null)
            {
                what = where.ToString().ToCharArray();

                for (int i = 0; i < what.Length; i++)
                {
                    what[i] = '*';
                }
            }

            var strNew = new string(what);

            return strNew;
        }


    }
}