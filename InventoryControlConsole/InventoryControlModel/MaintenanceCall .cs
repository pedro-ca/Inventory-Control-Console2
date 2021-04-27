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
            if (!IsValidEquipment(equipment))
                throw new ArgumentException("Equipment property cannot be set instantiated as a null value.");
            if (!IsValidDateTime(openingDate))
                throw new ArgumentException("OpeningDate property cannot be set as a date from the future.");

            this.titleName = titleName;
            this.descriptioName = descriptioName;
            this.equipment = equipment;
            this.openingDate = openingDate;
        }

        private static bool IsValidEquipment(Equipment equipment)
        {
            return equipment != null;
        }

        private static bool IsValidDateTime(DateTime date)
        {
            return date <= DateTime.Now;
        }

        public int DaysOpen()
        {
            return (DateTime.Now - openingDate).Days;
        }

        public override string ToString()
        {
            return $"Attributes: Title = {titleName}, Description = {descriptioName}, Equipment = {equipment.EquipmentName}, Opening Date = {openingDate}";
        }
    }
}
