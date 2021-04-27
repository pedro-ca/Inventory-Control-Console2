using InventoryControlModel;
using System;


namespace InventoryControlConsole
{
    class Program
    {
        static InventoryManager inventoryManager = new InventoryManager();

        private static void ShowErrorText(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.ReadLine();
        }

        private static void ShowSucessText(string sucessMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sucessMessage);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        private static void EquipmentMenu()
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
                    Console.WriteLine(inventoryManager.ViewEquipments());
                    break;

                case "regis":
                    Console.WriteLine(inventoryManager.RegisterEquipment());
                    break;

                case "edit":
                    Console.WriteLine(inventoryManager.ViewEquipments());
                    Console.WriteLine("-Enter the index of the Equipment to edit. Must be an integer.");
                    indexString = Console.ReadLine();
                    if (int.TryParse(indexString, out index))
                    {
                        Console.WriteLine(inventoryManager.EditEquiment(index));
                    }
                    else
                    {
                        ShowErrorText("Operation error: Index must be a valid integer number.");
                    }

                    break;

                case "delet":
                    Console.WriteLine(inventoryManager.ViewEquipments());
                    Console.WriteLine("-Enter the index of the Equipment to delete. Must be an integer.");
                    indexString = Console.ReadLine();
                    if(int.TryParse(indexString, out  index))
                    {
                        Console.WriteLine(inventoryManager.DeleteEquipment(index));
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

        private static void MaintenanceCallMenu()
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
                    Console.WriteLine(inventoryManager.ViewMaintenanceCalls());
                    break;

                case "regis":
                    Console.WriteLine(inventoryManager.RegisterMaintenanceCall());
                    break;

                case "edit":
                    Console.WriteLine(inventoryManager.ViewMaintenanceCalls());
                    Console.WriteLine("-Enter the index of the Maintenance to edit. Must be an integer.");
                    indexString = Console.ReadLine();
                    if (int.TryParse(indexString, out index))
                    {
                        Console.WriteLine(inventoryManager.EditMaintenanceCall(index));
                    }
                    else
                    {
                        ShowErrorText("Operation error: Index must be a valid integer number.");
                    }

                    break;

                case "delet":
                    Console.WriteLine(inventoryManager.ViewMaintenanceCalls());
                    Console.WriteLine("-Enter the index of the Equipment to delete. Must be an integer.");
                    indexString = Console.ReadLine();
                    if (int.TryParse(indexString, out index))
                    {
                        Console.WriteLine(inventoryManager.DeleteMaintenanceCall(index));
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
                        EquipmentMenu();
                        break;

                    case "maint":
                        MaintenanceCallMenu();
                        break;

                    case "exit":
                        return;
                }
                Console.ReadLine();
            }

        }
    }
}
