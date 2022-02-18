using System;

namespace BankConsultant
{
    public class Manager : Repository
    {
        /// <summary>
        /// Обновляет Person'а
        /// </summary>
        /// <param name="id">индекс в базе</param>
        /// <param name="person"></param>
        public void UpdatePerson(int id, Person person)
        {
            SetData(id, person);
            PersonDataBase.Db[id] = person;
        }

        /// <summary>
        /// Добавляет данные в выбранного Person из коллекции
        /// </summary>
        /// <param name="id">Индекс в базе</param>
        /// <param name="person"></param>
        /// <returns></returns>
        private Person SetData(int id, Person person)
        {
            person.DateOfChanging = DateTime.Now;
            person.WhoChanging = "Менеджер";
            PersonDataBase.Db[id] = person;
            return person;
        }
        /// <summary>
        /// Получает изменения с полными паспортными данными
        /// </summary>
        /// <param name="id">индекс базы</param>
        /// <param name="lastChangeId">индекс базы истории</param>
        /// <returns></returns>
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