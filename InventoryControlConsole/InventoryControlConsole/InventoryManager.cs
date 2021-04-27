using InventoryControlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlConsole
{
    class InventoryManager
    {
        private const string ErrorIndexNotFound = "Operation error: Index not found or out of range.";
        private const string SucessDeleteOp = "Delete operation sucessfull.";
        private const string SucessRegisterOp = "Register operation sucessfull.";
        private const string SucessEditOp = "Edit operation sucessfull.";

        private static Equipment[] equipmentArray = new Equipment[30];
        private static MaintenanceCall[] maintenanceCallArray = new MaintenanceCall[30];

        public string ViewEquipments()
        {
            string header = "-+-+-+-+- REGISTERED EQUIPMENTS -+-+-+-+-\n";
            string arrayToString = " ";
            for (int i = 0; i < equipmentArray.Length; i++)
            {
                if (equipmentArray[i] != null)
                {
                    Equipment equip = equipmentArray[i];
                    arrayToString += $"\n*Equipment {i}:";
                    arrayToString += "\n  -" + equip.ToString();
                }
            }

            return header + arrayToString;
        }

        public string ViewMaintenanceCalls()
        {
            string header = "-+-+-+-+- REGISTERED MAINTENANCES -+-+-+-+-\n";
            string arrayToString = " ";
            for (int i = 0; i < maintenanceCallArray.Length; i++)
            {
                if (maintenanceCallArray[i] != null)
                {
                    MaintenanceCall maint = maintenanceCallArray[i];
                    arrayToString += $"\n*Maintenance Call {i}:";
                    arrayToString += "\n  - " + maint.ToString();
                    arrayToString += "\n  - Days Open: " + maint.DaysOpen().ToString();
                }
            }
            return header + arrayToString;
        }

        public string RegisterEquipment()
        {
            try
            {
                Console.WriteLine("-Enter the name of the new equipment. Must be a string bigger than 6.");
                string name = Console.ReadLine();
                Console.WriteLine("-Enter the aquisition price of the new equipment. Must be a valid.");
                string price = Console.ReadLine();
                Console.WriteLine("-Enter the serial number.");
                string serial = Console.ReadLine();
                Console.WriteLine("-Enter the manufacturer name.");
                string manufacturer = Console.ReadLine();

                Equipment newEquipment = new Equipment(name, float.Parse(price), serial, DateTime.Now, manufacturer);

                for (int i = 0; i < equipmentArray.Length; i++)
                {
                    if (equipmentArray[i] == null)
                    {
                        equipmentArray[i] = newEquipment;
                        break;
                    }
                }

                return SucessRegisterOp;
            }
            catch (Exception e)
            {
                return "Operation error: " + e.Message;
            }
        }
        public string  RegisterMaintenanceCall()
        {
            try
            {
                Console.WriteLine("-Enter the name of the new maintenance call. ");
                string name = Console.ReadLine();
                Console.WriteLine("-Enter the description of the new maintenance call. ");
                string desc = Console.ReadLine();
                Console.WriteLine("-Enter the index of equipment new maintenance call. ");
                string indx = Console.ReadLine();

                MaintenanceCall newMaintenance = new MaintenanceCall(name, desc, equipmentArray[int.Parse(indx)], DateTime.Now);

                for (int i = 0; i < maintenanceCallArray.Length; i++)
                {
                    if (maintenanceCallArray[i] == null)
                    {
                        maintenanceCallArray[i] = newMaintenance;
                        break;
                    }
                }

                return SucessRegisterOp;
            }
            catch (Exception e)
            {
                return "Operation error: " + e.Message;
            }
        }

        public string EditEquiment(int arrayIndex)
        {
            string delMsg = DeleteEquipment(arrayIndex);
            if (delMsg.Equals(ErrorIndexNotFound))
            {
                return ErrorIndexNotFound;
            }
            else
            {
                string regMsg = RegisterEquipment();
                if (!regMsg.Equals(SucessRegisterOp))
                {
                    return regMsg;
                }
                else
                {
                    return SucessEditOp;
                }
            }
        }

        public string EditMaintenanceCall(int arrayIndex)
        {
            string delMsg = DeleteMaintenanceCall(arrayIndex);
            if (delMsg.Equals(ErrorIndexNotFound))
            {
                return ErrorIndexNotFound;
            }
            else
            {
                string regMsg = RegisterMaintenanceCall();
                if (!regMsg.Equals(SucessRegisterOp))
                {
                    return regMsg;
                }
                else
                {
                    return SucessEditOp;
                }
            }
        }

        public string DeleteEquipment(int arrayIndex)
        {
            try
            {
                equipmentArray[arrayIndex] = null;

            }
            catch (IndexOutOfRangeException)
            {
                return ErrorIndexNotFound;
            }
            return SucessDeleteOp;
        }

        public string DeleteMaintenanceCall(int arrayIndex)
        {
            try
            {
                maintenanceCallArray[arrayIndex] = null;
            }
            catch (IndexOutOfRangeException) 
            {
                return ErrorIndexNotFound;
            }

            return SucessDeleteOp;
        }
    }
}
