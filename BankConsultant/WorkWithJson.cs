using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace BankConsultant
{
    public class WorkWithJson
    {
        /// <summary>
        /// Сериализация в JSON файл
        /// </summary>
        internal static void DatabaseToJson()
        {
            var jsonString = JsonSerializer.Serialize(UserWindow.Db);
            var streamWriter =
                new StreamWriter("db.json"); //Запускаем стримрайтер для записи\дозаписи\создания
            streamWriter.WriteLine(jsonString); //Записываем в документ
            streamWriter.Close(); //Закрываем документ
        }

        /// <summary>
        /// Десереализация из JSON файла
        /// </summary>
        internal static void DeserializePersonJson()
        {
            if (File.Exists("db.json"))
            {
                string jsonString = File.ReadAllText("db.json");

                UserWindow.Db = JsonSerializer.Deserialize<ObservableCollection<Person>>(jsonString);
            }
        }
    }
}