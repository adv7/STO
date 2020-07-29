using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskOrganizer
{
    public interface IDbController
    {
        void AddToDb();
        void RemoveFromDb();
        void EditDbRegistry();
    }
}
