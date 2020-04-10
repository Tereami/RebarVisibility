#region License
/*Данный код опубликован под лицензией Creative Commons Attribution-ShareAlike.
Разрешено использовать, распространять, изменять и брать данный код за основу для производных в коммерческих и
некоммерческих целях, при условии указания авторства и если производные лицензируются на тех же условиях.
Код поставляется "как есть". Автор не несет ответственности за возможные последствия использования.
Зуев Александр, 2020, все права защищены.
This code is listed under the Creative Commons Attribution-ShareAlike license.
You may use, redistribute, remix, tweak, and build upon this work non-commercially and commercially,
as long as you credit the author by linking back and license your new creations under the same terms.
This code is provided 'as is'. Author disclaims any implied warranty.
Zuev Aleksandr, 2020, all rigths reserved.*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.IO;


namespace RebarVisibility
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]

    public class App : IExternalApplication
    {
        public static string assemblyPath = "";
        public static string iconsPath = "";
        public static string username = "";

        public Result OnStartup(UIControlledApplication application)
        {
            assemblyPath = typeof(App).Assembly.Location;
            iconsPath = Path.GetDirectoryName(assemblyPath);

            string tabName = "Weandrevit";
            try { application.CreateRibbonTab(tabName); }
            catch { }

            RibbonPanel panel = null;
            List<RibbonPanel> panels = application.GetRibbonPanels(tabName)
                .Where(i => i.Name == "Армирование")
                .ToList();
            if (panels.Count == 1)
            {
                panel = panels.First();
            }
            else
            {
                panel = application.CreateRibbonPanel(tabName, "Армирование");
            }


            PushButton btnAllRebarAsBody = panel.AddItem(new PushButtonData(
                "AllRebarAsBody",
                "Все\nкак тело",
                assemblyPath,
                "RebarVisibility.Command")
                ) as PushButton;

            return Result.Succeeded;

        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

    }
}
