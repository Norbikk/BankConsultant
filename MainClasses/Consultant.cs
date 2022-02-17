namespace BankConsultant
{
    public class Consultant : Repository
    {
        public override Person GetUserById(int id)
        {
            var person = base.GetUserById(id);
            person.PassportSeries = SecureData(person.PassportSeries);
            person.PassportNumber = SecureData(person.PassportNumber);

            return person;
        }
        protected override string Check(int id, int lastChangeId)
        {
            var changes = base.Check(id, lastChangeId);

            if (Database[id].PassportSeries != LastChangesDatabase[lastChangeId].PassportSeries)
            {
                changes += "Серия паспорта: " + SecureData(LastChangesDatabase[lastChangeId].PassportSeries) + "\n";
            }

            if (Database[id].PassportNumber != LastChangesDatabase[lastChangeId].PassportNumber)
            {
                changes += "Номер паспорта: " + SecureData(LastChangesDatabase[lastChangeId].PassportNumber) + "\n";
            }


            return changes;
        }


    }
}