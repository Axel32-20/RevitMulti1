#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#endregion

namespace RevitMulti1
{
    [Transaction(TransactionMode.Manual)]

    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Mensaje según versión
#if REVIT2024_OR_EARLIER
                            //TaskDialog.Show("Command", "Running in Revit 2024 or earlier (.NET 4.8)");
#elif REVIT2025_OR_LATER
                   // TaskDialog.Show("Command", "Running in Revit 2025 or later (.NET 8)");
#endif
            //get all elements
            var allFInstance = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance)).OfCategory(BuiltInCategory.OST_PipeFitting).Where(e => e.Name.Contains("UTU_Bote")).ToList();
            
            if (allFInstance == null)
            {
                return Result.Cancelled;
            }
            else
            {
                foreach(var element in allFInstance)

                { 
                }
                 

            }

            //get boundary of columns




            // Modificación dentro de una transacción (aunque no hace nada acá)
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Transaction Name");

                tx.Commit();
            }

            return Result.Succeeded;
        }

    }

}
