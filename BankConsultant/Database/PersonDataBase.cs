﻿using System.Collections.ObjectModel;

namespace BankConsultant
{
    public static class PersonDataBase
    {
        public static ObservableCollection<Person> Db { get; set; } = new();
        public static ObservableCollection<Person> LastChangesDb = new();
    }
}