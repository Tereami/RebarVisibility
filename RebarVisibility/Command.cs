#region License
/*Данный код опубликован под лицензией Creative Commons Attribution-NonCommercial-ShareAlike.
Разрешено использовать, распространять, изменять и брать данный код за основу для производных в некоммерческих целях,
при условии указания авторства и если производные лицензируются на тех же условиях.
Код поставляется "как есть". Автор не несет ответственности за возможные последствия использования.
Зуев Александр, 2020, все права защищены.
This code is listed under the Creative Commons Attribution-NonCommercial-ShareAlike license.
You may use, redistribute, remix, tweak, and build upon this work non-commercially,
as long as you credit the author by linking back and license your new creations under the same terms.
This code is provided 'as is'. Author disclaims any implied warranty.
Zuev Aleksandr, 2020, all rigths reserved.*/
#endregion
#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Structure;
#endregion

namespace RebarVisibility
{
    class CommandSetAllRebarAsBody : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            FormDialog form = new FormDialog();
            form.ShowDialog();
            if (form.DialogResult != System.Windows.Forms.DialogResult.OK) return Result.Cancelled;
            if (!form.rebarAsBodyActivate && !form.rebarOverlayActivate) return Result.Cancelled;


            Document doc = commandData.Application.ActiveUIDocument.Document;
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;

            string username = commandData.Application.Application.Username;

            View view = uiDoc.ActiveView;
            if (view == null) throw new Exception("Unable to get ActiveVIew");
            List<Rebar> rebars = new FilteredElementCollector(doc, view.Id)
                .WhereElementIsNotElementType()
                .OfClass(typeof(Rebar))
                .Where(r => IsEditable(r, username))
                .Cast<Rebar>()
                .ToList();

            List<RebarInSystem> rebars2 = new FilteredElementCollector(doc, view.Id)
                .WhereElementIsNotElementType()
                .OfClass(typeof(RebarInSystem))
                .Where(r => IsEditable(r, username))
                .Cast<RebarInSystem>()
                .ToList();

            List<MyBar> myrebars = rebars.Select(i => new MyBar(i)).ToList();
            myrebars.AddRange(rebars2.Select(i => new MyBar(i)));

            using (Transaction t = new Transaction(doc))
            {
                t.Start("Видимость арматуры");

                if (form.rebarAsBodyActivate)
                {
                    View3D view3d = view as View3D;
                    if (view == null)
                    {
                        TaskDialog.Show("Ошибка", "Перейдите на 3D-вид");
                        return Result.Failed;
                    }


                    foreach (MyBar bar in myrebars)
                    {
                        try
                        {
                            bar.SetSolidInView(view3d, form.rebarAsbodyOn);
                        }
                        catch(Exception ex)
                        {
                            string msg = "Unable to set RebasAsBody. Rebar id: ";
                            msg += bar.RevitBar.Id.IntegerValue.ToString() + ", view name: " + view.Name;
                            msg += ". Exception message: " + ex.Message;
                            message = msg;
                            return Result.Failed;
                        }
                    }
                    if (view.DetailLevel != ViewDetailLevel.Fine)
                    {
                        try
                        {
                            view.DetailLevel = ViewDetailLevel.Fine;
                        }
                        catch
                        {
                            TaskDialog.Show("Внимание!", "Не удалось назначить Высокий уровень детализации для вида. Сделайте это вручную.");
                        }
                    }
                }

                if (form.rebarOverlayActivate)
                {
                    foreach (MyBar bar in myrebars)
                    {
                        try
                        {
                            bar.SetUnobscuredInView(view, form.rebarIsUnobsqured);
                        }
                        catch(Exception ex)
                        {
                            string msg = "Unable to set RebasIsUnobsqured. Rebar id: ";
                            msg += bar.RevitBar.Id.IntegerValue.ToString() + ", view name: " + view.Name;
                            msg += ". Exception message: " + ex.Message;
                            message = msg;
                            return Result.Failed;
                        }
                    }
                }

                t.Commit();
            }

            return Result.Succeeded;
        }


        private bool IsEditable(Element elem, string username)
        {
            string editor = elem.get_Parameter(BuiltInParameter.EDITED_BY).AsString();
            if (string.IsNullOrEmpty(editor)) return true;
            if (editor.Equals(username)) return true;
            return false;
        }
    }
}
