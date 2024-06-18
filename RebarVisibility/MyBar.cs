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
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;

namespace RebarVisibility
{
    public class MyBar
    {
        public Element RevitBar;

        public MyBar(Element bar)
        {
            RevitBar = bar;
        }

        public void SetSolidInView(View3D v, bool AsBody)
        {
#if R2017 || R2018 || R2019 || R2020 || R2021 || R2022
            if (RevitBar is Rebar)
            {
                Rebar bar = RevitBar as Rebar;
                bar.SetSolidInView(v, AsBody);
            }
            if (RevitBar is RebarInSystem)
            {
                RebarInSystem bar = RevitBar as RebarInSystem;
                bar.SetSolidInView(v, AsBody);
            }
#endif
        }

        public void SetUnobscuredInView(View v, bool IsUnobsqured)
        {
            if (RevitBar is Rebar)
            {
                Rebar bar = RevitBar as Rebar;
                bar.SetUnobscuredInView(v, IsUnobsqured);
            }
            if (RevitBar is RebarInSystem)
            {
                RebarInSystem bar = RevitBar as RebarInSystem;
                bar.SetUnobscuredInView(v, IsUnobsqured);
            }
        }

    }
}
