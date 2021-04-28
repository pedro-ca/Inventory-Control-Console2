using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlConsole
{
    class InventoryMenu
    {
        private InventoryManager manager = new InventoryManager();

       

        private void ShowEquipmentHeader()
        {
            Console.WriteLine("-+-+-+-+- EQUIPMENTS -+-+-+-+-");
            Console.WriteLine("-Enter the desired operation. Commands:");
            Console.WriteLine(" * show = Show all registered equipments and atributes.");
            Console.WriteLine(" * regis = Register a new equipment.");
            Console.WriteLine(" * edit = Edit an existing equipment.");
            Console.WriteLine(" * delet = Delete an existing equipment.");
            Console.WriteLine("Equipment");
        }
        private void ShowMaintenanceCallHeader()
        {
            Console.WriteLine("-+-+-+-+- MAINTENANCE CALLS -+-+-+-+-");
            Console.WriteLine("-Enter the desired operation. Commands:");
            Console.WriteLine(" * show = Show all registered maintenances and atributes.");
            Console.WriteLine(" * regis = Register a new maintenances.");
            Console.WriteLine(" * edit = Edit an existing maintenances.");
            Console.WriteLine(" * delet = Delete an existing maintenances.");
            Console.WriteLine("Equipment");
        }

        public void ShowMainMenuHeader()
        {
            Console.WriteLine("-+-+-+-+- INVENTORY CONTROL CONSOLE -+-+-+-+-");
            Console.WriteLine("-Do you want to administrate Equipments or Maintenance Calls? Commands:");
            Console.WriteLine(" * equip = Show, Register, Edit and Delete Equipments.");
            Console.WriteLine(" * maint = Show, Register, Edit and Delete Maintenance Calls.");
            Console.WriteLine(" * exit = Exits from the console.");
        }

        private void ShowErrorText(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public void EquipmentMenu()
        {
            ShowEquipmentHeader();
            string operationOption = Console.ReadLine();

            string indexString;
            int index;

            switch (operationOption.ToLowerInvariant())
            {
                case "show":
                    Console.WriteLine(manager.ViewEquipments());
                    break;

                case "regis":
                    Console.WriteLine(manager.RegisterEquipment());
                    break;

                case "edit":
                    Console.WriteLine(manager.ViewEquipments());
                    Console.WriteLine("-Enter the index of the Equipment to edit. Must be an integer.");
                    indexString = Console.ReadLine();
                    if (int.TryParse(indexString, out index))
                    {
                        Console.WriteLine(manager.EditEquiment(index));
                    }
                    else
                    {
                        ShowErrorText("Operation error: Index must be a valid integer number.");
                    }

                    break;

                case "delet":
                    Console.WriteLine(manager.ViewEquipments());
                    Console.WriteLine("-Enter the index of the Equipment to delete. Must be an integer.");
                    indexString = Console.ReadLine();
                    if (int.TryParse(indexString, out index))
                    {
                        Console.WriteLine(manager.DeleteEquipment(index));
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
        public void MaintenanceCallMenu()
        {
            ShowMaintenanceCallHeader();
            string operationOption = Console.ReadLine();

            string indexString;
            int index;

            switch (operationOption.ToLowerInvariant())
            {
                case "show":
                    Console.WriteLine(manager.ViewMaintenanceCalls());
                    break;

                case "regis":
                    Console.WriteLine(manager.RegisterMaintenanceCall());
                    break;

                case "edit":
                    Console.WriteLine(manager.ViewMaintenanceCalls());
                    Console.WriteLine("-Enter the index of the Maintenance to edit. Must be an integer.");
                    indexString = Console.ReadLine();
                    if (int.TryParse(indexString, out index))
                    {
                        Console.WriteLine(manager.EditMaintenanceCall(index));
                    }
                    else
                    {
                        ShowErrorText("Operation error: Index must be a valid integer number.");
                    }

                    break;

                case "delet":
                    Console.WriteLine(manager.ViewMaintenanceCalls());
                    Console.WriteLine("-Enter the index of the Equipment to delete. Must be an integer.");
                    indexString = Console.ReadLine();
                    if (int.TryParse(indexString, out index))
                    {
                        Console.WriteLine(manager.DeleteMaintenanceCall(index));
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
    }
}
