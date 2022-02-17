using System;

namespace BankConsultant
{
    public class Manager : Repository
    {
        public void UpdatePerson(int id, Person person)
        {
            SetData(id, person);
            PersonDataBase.Db[id] = person;
        }

        private Person SetData(int id, Person person)
        {
            person.DateOfChanging = DateTime.Now;
            person.WhoChanging = "Менеджер";
            PersonDataBase.Db[id] = person;
            return person;
        }

        protected override string Check(int id, int lastChangeId)
        {
            var changes = base.Check(id, lastChangeId);

            changes += AddChange("Серия паспорта: ", Database[id].PassportSeries,
                LastChangesDatabase[lastChangeId].PassportSeries);
            changes += AddChange("Номер паспорта: ", Database[id].PassportNumber,
                LastChangesDatabase[lastChangeId].PassportNumber);

            return changes;
        }
    }
}