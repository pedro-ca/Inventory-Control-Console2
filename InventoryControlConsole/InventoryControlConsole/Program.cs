using InventoryControlModel;
using System;


namespace InventoryControlConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryMenu menu = new InventoryMenu();
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                menu.ShowMainMenuHeader();

                string operationOption = Console.ReadLine();

                switch (operationOption.ToLowerInvariant())
                {
                    case "equip":
                        menu.EquipmentMenu();
                        break;

                    case "maint":
                        menu.MaintenanceCallMenu();
                        break;

                    case "exit":
                        return;
                }
                Console.ReadLine();
            }

        }

        
    }
}
