using System;

namespace InventoryControlModel
{
    public class MaintenanceCall
    {
        private string titleName;
        private string descriptioName;
        private Equipment equipment;
        private DateTime openingDate;

        public MaintenanceCall(string titleName, string descriptioName, Equipment equipment, DateTime openingDate)
        {
            TitleName = titleName;
            DescriptioName = descriptioName;
            Equipment = equipment;
            OpeningDate = openingDate;
        }

        public string TitleName { get => titleName; set => titleName = value; }
        public string DescriptioName { get => descriptioName; set => descriptioName = value; }
        public Equipment Equipment { get => equipment; set => equipment = value; }
        public DateTime OpeningDate
        {
            get { return openingDate; }
            set 
            { 
                if(value > DateTime.Now)
                    throw new ArgumentException("OpeningDate property cannot be set as a date from the future.");
                openingDate = value; 
            }
        }
    }
}
