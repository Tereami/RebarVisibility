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
#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Structure;
#endregion

namespace RebarVisibility
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Debug.Listeners.Clear();
            Debug.Listeners.Add(new RbsLogger.Logger("RebarVisibility"));
            Debug.WriteLine("Start");

            FormDialog form = new FormDialog();
            form.ShowDialog();
            if (form.DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                Debug.WriteLine("Cancelled");
                return Result.Cancelled;
            }
            if (!form.rebarAsBodyActivate && !form.rebarOverlayActivate)
            {
                Debug.WriteLine("No selected checkboxes");
                return Result.Cancelled;
            }

            if(form.rebarAsBodyActivate)
            {
                Autodesk.Revit.ApplicationServices.Application app =
                    commandData.Application.Application;
                int version = int.Parse(app.VersionNumber);
                if(version >= 2023)
                {
                    TaskDialog.Show(MyStrings.Warning, MyStrings.RebarBodyRevit2023);
                }
            }

            Document doc = commandData.Application.ActiveUIDocument.Document;
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;

            string username = commandData.Application.Application.Username;

            View view = uiDoc.ActiveView;
            if (view == null)
            {
                Debug.WriteLine("No active view");
                throw new Exception("Unable to get ActiveVIew");
            }
            List<Rebar> rebars = new FilteredElementCollector(doc, view.Id)
                .WhereElementIsNotElementType()
                .OfClass(typeof(Rebar))
                .Cast<Rebar>()
                .ToList();
            Debug.WriteLine("Rebars found: " + rebars.Count);

            List<RebarInSystem> rebars2 = new FilteredElementCollector(doc, view.Id)
                .WhereElementIsNotElementType()
                .OfClass(typeof(RebarInSystem))
                .Cast<RebarInSystem>()
                .ToList();
            Debug.WriteLine("RebarsInSystem found: " + rebars2.Count);

            List<MyBar> myrebars = rebars.Select(i => new MyBar(i)).ToList();
            myrebars.AddRange(rebars2.Select(i => new MyBar(i)));

            int rebarNotEditableCount = 0;

            using (Transaction t = new Transaction(doc))
            {
                t.Start(MyStrings.TransactionRebarVIsibility);

                if (form.rebarAsBodyActivate)
                {
                    Debug.WriteLine("Start rebar as body");
                    View3D view3d = view as View3D;
                    if (view == null)
                    {
                        Debug.WriteLine("View is not View3D");
                        TaskDialog.Show(MyStrings.Error, MyStrings.ErrorOpen3dView);
                        return Result.Failed;
                    }

                    foreach (MyBar bar in myrebars)
                    {
                        Debug.WriteLine("Current rebar id: " + bar.RevitBar.Id.IntegerValue);
                        if (!IsEditable(bar.RevitBar, username))
                        {
                            Debug.WriteLine("Rebar is not editable");
                            rebarNotEditableCount++;
                            continue;
                        }

                        try
                        {
                            bar.SetSolidInView(view3d, form.rebarAsbodyOn);
                            Debug.WriteLine("Set solid success");
                        }
                        catch (Exception ex)
                        {
                            string msg = MyStrings.ErrorUnableSetBody
                                + bar.RevitBar.Id.IntegerValue.ToString() + MyStrings.ErrorViewName + view.Name
                                + MyStrings.ErrorExceprionMessage + ex.Message;
                            message = msg;
                            Debug.WriteLine(msg);
                            return Result.Failed;
                        }
                    }
                    if (view.DetailLevel != ViewDetailLevel.Fine)
                    {
                        try
                        {
                            view.DetailLevel = ViewDetailLevel.Fine;
                            Debug.WriteLine("Detail level set to fine");
                        }
                        catch
                        {
                            Debug.WriteLine("Unable to set fine detail level");
                            TaskDialog.Show(MyStrings.Warning, MyStrings.ErrorUnableToSetFineDetailLevel);
                        }
                    }
                }

                if (form.rebarOverlayActivate)
                {
                    Debug.WriteLine("Start rebar Unobscured");
                    foreach (MyBar bar in myrebars)
                    {
                        Debug.WriteLine("Current rebar id:" + bar.RevitBar.Id.IntegerValue);
                        if (!IsEditable(bar.RevitBar, username))
                        {
                            rebarNotEditableCount++;
                            Debug.WriteLine("Rebar is not editable");
                            continue;
                        }
                        try
                        {
                            bar.SetUnobscuredInView(view, form.rebarIsUnobsqured);
                            Debug.WriteLine("Set Unobscured success");
                        }
                        catch (Exception ex)
                        {
                            string msg = MyStrings.ErrorUnableSetUnobscured
                                + bar.RevitBar.Id.IntegerValue.ToString() + MyStrings.ErrorViewName + view.Name
                                + MyStrings.ErrorExceprionMessage + ex.Message;
                            message = msg;
                            Debug.WriteLine(msg);
                            return Result.Failed;
                        }
                    }
                }

                t.Commit();
            }
            Debug.WriteLine("Error bars count: " + rebarNotEditableCount);
            if (rebarNotEditableCount > 0)
            {
                string msg = MyStrings.ErrorRebarsAreEditable + rebarNotEditableCount.ToString();
                TaskDialog.Show(MyStrings.Warning, msg);
            }
            Debug.WriteLine("Success");
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
