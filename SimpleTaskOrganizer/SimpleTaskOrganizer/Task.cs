using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskOrganizer
{
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string _description { get; set; }
        public byte _prioriyty { get; set; }
        public DateTime _completedDateTime { get; set; }
        public bool _isCompleted { get; set; }
    }
}
