using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskOrganizer
{
    public class PriorityColorSetter
    {
        private byte _priorityValue;
        //TODO add more colors
        private string[] _priorityBackGroundColor = { "#49796B", "#FF6666" };

        public string GetPriorityBackGroundColor(byte priority)
        {
            switch (priority)
            {
                case 1:
                    return _priorityBackGroundColor[0];
                case 2:
                    return _priorityBackGroundColor[0];
                case 3:
                    return _priorityBackGroundColor[0];
                case 4:
                    return _priorityBackGroundColor[1];
                case 5:
                    return _priorityBackGroundColor[1];
                default:
                    return _priorityBackGroundColor[0];
            }
        }
    }
}
