using InventoryControlModel;
using System;


namespace InventoryControlConsole
{
    class Program
    {
        private static Equipment[] equipmentArray = new Equipment[20];
        private static MaintenanceCall[] maintenanceCallArray = new MaintenanceCall[20];

        private static void ShowErrorText(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.ReadLine();
        }

        private static void ViewEquipments()
        {
            Console.WriteLine("-+-+-+-+- REGISTERED EQUIPMENTS -+-+-+-+-");
            for (int i=0; i < equipmentArray.Length; i++)
            {
                if (equipmentArray[i] != null)
                {
                    Equipment equip = equipmentArray[i];
                    Console.WriteLine($"*Equipment {i}:");
                    Console.WriteLine("  -EquipmentName = " + equip.EquipmentName);
                    Console.WriteLine("  -AcquisitionPrice = " + equip.AcquisitionPrice);
                    Console.WriteLine("  -SerialNumber = " + equip.SerialNumber);
                    Console.WriteLine("  -ManufacturingDate = " + equip.ManufacturingDate);
                    Console.WriteLine("  -ManufacturerName = " + equip.ManufacturerName);
                    Console.WriteLine("  -Equipment name = " + equip.EquipmentName);
                }
            }
        }

        private static void ViewMaintenanceCalls()
        {
            Console.WriteLine("-+-+-+-+- REGISTERED MAINTENANCES -+-+-+-+-");
            for (int i = 0; i < maintenanceCallArray.Length; i++)
            {
                if (maintenanceCallArray[i] != null)
                {
                    MaintenanceCall maint = maintenanceCallArray[i];
                    Console.WriteLine($"*Maintenance Call {i}:");
                    Console.WriteLine("  -TitleName = " + maint.TitleName);
                    Console.WriteLine("  -DescriptioName = " + maint.DescriptioName);
                    Console.WriteLine("  -Equipment = " + maint.Equipment.EquipmentName);
                    Console.WriteLine("  -OpeningDate = " + maint.OpeningDate);
                    Console.WriteLine("  -DaysOpen = " + (DateTime.Now - maint.OpeningDate).Days.ToString());
                }
            }
        }
        
        private static void RegisterEquipment()
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

                Console.WriteLine("Sucessfully added " + name);
            }
            catch (Exception e)
            {
                ShowErrorText(e.Message);
            }
        }
        private static void RegisterMaintenanceCall()
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

                Console.WriteLine("Sucessfully added " + name);
            }
            catch (Exception e)
            {
                ShowErrorText(e.Message);
            }
        }

        private static void EditEquiment(int arrayIndex)
        {
            if (!DeleteEquipment(arrayIndex))
            {
                ShowErrorText("Operation error: Index not found or out of bounds.");
            }
            else
            {
                RegisterEquipment();
            }
        }

        private static void EditMaintenanceCall(int arrayIndex)
        {
            if (!DeleteMaintenanceCall(arrayIndex))
            {
                ShowErrorText("Operation error: Index not found or out of bounds.");
            }
            else
            {
                RegisterMaintenanceCall();
            }
        }

        private static bool DeleteEquipment(int arrayIndex)
        {
            try
            {
                if (equipmentArray[arrayIndex] != null)
                {
                    equipmentArray[arrayIndex] = null;
                    Console.WriteLine("Delete operation sucessful");
                    return true;
                }
            }
            catch (IndexOutOfRangeException){}
            return false;
        }

        private static bool DeleteMaintenanceCall(int arrayIndex)
        {
            try
            {
                if (maintenanceCallArray[arrayIndex] != null)
                {
                    maintenanceCallArray[arrayIndex] = null;
                    Console.WriteLine("Delete operation sucessful");
                    return true;
                }
                
            }
            catch (IndexOutOfRangeException){}
            return false;
        }

        private static void EquipmentControl()
        {
            Console.WriteLine("-+-+-+-+- EQUIPMENTS -+-+-+-+-");
            Console.WriteLine("-Enter the desired operation. Commands:");
            Console.WriteLine(" * show = Show all registered equipments and atributes.");
            Console.WriteLine(" * regis = Register a new equipment.");
            Console.WriteLine(" * edit = Edit an existing equipment.");
            Console.WriteLine(" * delet = Delete an existing equipment.");
            Console.WriteLine("Equipment");
            string operationOption = Console.ReadLine();

            string indexString;
            int index;

            switch (operationOption.ToLowerInvariant())
            {
                case "show":
                    ViewEquipments();
                    break;

                case "regis":
                    RegisterEquipment();
                    break;

                case "edit":
                    ViewEquipments();
                    Console.WriteLine("-Enter the index of the Equipment to edit. Must be an integer.");
                    indexString = Console.ReadLine();
                    if (int.TryParse(indexString, out index))
                    {
                        EditEquiment(index);
                    }
                    else
                    {
                        ShowErrorText("Operation error: Index must be a valid integer number.");
                    }

                    break;

                case "delet":
                    ViewEquipments();
                    Console.WriteLine("-Enter the index of the Equipment to delete. Must be an integer.");
                    indexString = Console.ReadLine();
                    if(int.TryParse(indexString, out  index))
                    {
                        if (!DeleteEquipment(index))
                        {
                            ShowErrorText("Operation error: Index not found or out of bounds.");
                        }
                    }
                    else
                    {
                        ShowErrorText("Operation error: Index must be a valid integer number.");
                    }
                    break;

                default:
                    ShowErrorText("Operation error: Use only one of the available commands.");
                    break;
            }
        }

        private static void MaintenanceCallControl()
        {
            Console.WriteLine("-+-+-+-+- MAINTENANCE CALLS -+-+-+-+-");
            Console.WriteLine("-Enter the desired operation. Commands:");
            Console.WriteLine(" * show = Show all registered maintenances and atributes.");
            Console.WriteLine(" * regis = Register a new maintenances.");
            Console.WriteLine(" * edit = Edit an existing maintenances.");
            Console.WriteLine(" * delet = Delete an existing maintenances.");
            Console.WriteLine("Equipment");
            string operationOption = Console.ReadLine();

            string indexString;
            int index;

            switch (operationOption.ToLowerInvariant())
            {
                case "show":
                    ViewMaintenanceCalls();
                    break;

                case "regis":
                    RegisterMaintenanceCall();
                    break;

                case "edit":
                    ViewMaintenanceCalls();
                    Console.WriteLine("-Enter the index of the Maintenance to edit. Must be an integer.");
                    indexString = Console.ReadLine();
                    if (int.TryParse(indexString, out index))
                    {
                        EditMaintenanceCall(index);
                    }
                    else
                    {
                        ShowErrorText("Operation error: Index must be a valid integer number.");
                    }

                    break;

                case "delet":
                    ViewMaintenanceCalls();
                    Console.WriteLine("-Enter the index of the Equipment to delete. Must be an integer.");
                    indexString = Console.ReadLine();
                    if (int.TryParse(indexString, out index))
                    {
                        if (!DeleteMaintenanceCall(index))
                        {
                            ShowErrorText("Operation error: Index not found or out of bounds.");
                        }
                    }
                    else
                    {
                        ShowErrorText("Operation error: Index must be a valid integer number.");
                    }
                    break;

                default:
                    ShowErrorText("Operation error: Use only one of the available commands.");
                    break;
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-+-+-+-+- INVENTORY CONTROL CONSOLE -+-+-+-+-");
                Console.WriteLine("-Do you want to administrate Equipments or Maintenance Calls? Commands:");
                Console.WriteLine(" * equip = Show, Register, Edit and Delete Equipments.");
                Console.WriteLine(" * maint = Show, Register, Edit and Delete Maintenance Calls.");
                Console.WriteLine(" * exit = Exits from the console.");
                string operationOption = Console.ReadLine();

                switch (operationOption.ToLowerInvariant())
                {
                    case "equip":
                        EquipmentControl();
                        break;

                    case "maint":
                        MaintenanceCallControl();
                        break;

                    case "exit":
                        return;
                }
                Console.ReadLine();
            }

        }
    }
}
