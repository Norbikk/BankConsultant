using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows.Controls;

namespace BankConsultant
{
    public class WorkWithJson
    {
        
        /// <summary>
        /// Сериализация в JSON файл
        /// </summary>
        public void DatabaseToJson()
        {
            var jsonString = JsonSerializer.Serialize(PersonDataBase.Db);
            var streamWriter =
                new StreamWriter("db.json"); //Запускаем стримрайтер для записи\дозаписи\создания
            streamWriter.WriteLine(jsonString); //Записываем в документ
            streamWriter.Close(); //Закрываем документ
        }
        
        /// <summary>
        /// Десереализация из JSON файла
        /// </summary>
        public static void DeserializePersonJson()
        {
            if (File.Exists("db.json"))
            {
                string jsonString = File.ReadAllText("db.json");

                PersonDataBase.Db = JsonSerializer.Deserialize<ObservableCollection<Person>>(jsonString);
            }
        }
    }
}