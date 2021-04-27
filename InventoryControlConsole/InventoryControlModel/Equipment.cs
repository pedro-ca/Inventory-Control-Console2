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
            if(!isValidEquipmentName(equipmentName))
                throw new ArgumentException("EquipmentName property has a minimun lenght of 6.");
            if (!isValidManufacturingDate(manufacturingDate))
                throw new ArgumentException("ManufacturingDate property cannot be set as a date from the future.");

            this.equipmentName = equipmentName;
            this.acquisitionPrice = acquisitionPrice;
            this.serialNumber = serialNumber;
            this.manufacturingDate = manufacturingDate;
            this.manufacturerName = manufacturerName;
        }

        private bool isValidEquipmentName(string name)
        {
            return name.Length >= 6;
        }

        private bool isValidManufacturingDate(DateTime date)
        {
            return date <= DateTime.Now;
        }

        public override string ToString()
        {
            return $"Attributes: Name = {equipmentName}, Acquisition Price = {acquisitionPrice}, Serial = {serialNumber}, Manufacturing Date = {manufacturingDate}, ManufacturerName = {manufacturerName}";
        }

        public string EquipmentName { get => equipmentName; }
    }
}
