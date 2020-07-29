using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskOrganizer
{
    class Task : IDbController
    {
        private string _description = String.Empty;
        private byte _prioriyty = 3;

        public Task(string Description, byte Priority)
        {
            _description = Description;
            _prioriyty = Priority;
        }

        public string GetDescription()
        {
            return _description;
        }
        
        public byte GetPriority()
        {
            return _prioriyty;
        }

        public void AddToDb()
        {
            throw new NotImplementedException();
        }

        public void EditDbRegistry()
        {
            throw new NotImplementedException();
        }

        public void RemoveFromDb()
        {
            throw new NotImplementedException();
        }
    }
}
