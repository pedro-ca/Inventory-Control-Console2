using System;

namespace InventoryControlModel
{
    public class Equipment
    {
        private string equipmentName;
        private float acquisitionPrice;
        private string serialNumber;
        private DateTime manufacturingDate;
        private string manufacturerName;

        public Equipment(string equipmentName, float acquisitionPrice, string serialNumber, DateTime manufacturingDate, string manufacturerName)
        {
            EquipmentName = equipmentName;
            AcquisitionPrice = acquisitionPrice;
            SerialNumber = serialNumber;
            ManufacturingDate = manufacturingDate;
            ManufacturerName = manufacturerName;
        }

        public string EquipmentName
        {
            get { return equipmentName; }
            set
            {
                if (value.Length < 6)
                    throw new ArgumentException("EquipmentName property has a minimun lenght of 6.");
                equipmentName = value;
            }
        }
        public float AcquisitionPrice { get => acquisitionPrice; set => acquisitionPrice = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public DateTime ManufacturingDate
        {
            get { return manufacturingDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("ManufacturingDate property cannot be set as a date from the future.");
                manufacturingDate = value;
            }
        }
        public string ManufacturerName { get => manufacturerName; set => manufacturerName = value; }
    }
}
