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
        public void DatabaseToJson(ObservableCollection<Person> what, string where)
        {
            var jsonString = JsonSerializer.Serialize(what);
            var streamWriter =
                new StreamWriter(where); //Запускаем стримрайтер для записи\дозаписи\создания
            streamWriter.WriteLine(jsonString); //Записываем в документ
            streamWriter.Close(); //Закрываем документ
        }

        /// <summary>
        /// Десереализация из JSON файла
        /// </summary>
        public static ObservableCollection<Person> DeserializePersonJson(string where)
        {
            ObservableCollection<Person> what = new();
            if (File.Exists(where))
            {
                string jsonString = File.ReadAllText(where);

                what = JsonSerializer.Deserialize<ObservableCollection<Person>>(jsonString);
            }

            return what;
        }
    }
}