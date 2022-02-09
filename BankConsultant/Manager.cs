namespace BankConsultant
{
    public class Manager : Consultant
    {

        public void UpdatePerson(int i, Person person)
        {

                PersonDataBase.Db[i] = person;
            
            
        }

        public override Person GetUserById(int i)
        {
            return PersonDataBase.Db[i];
        }

    }
}