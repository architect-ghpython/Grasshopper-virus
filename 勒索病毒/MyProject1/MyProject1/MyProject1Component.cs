using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows.Forms;
// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace MyProject1
{
    public class MyProject1Component : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public MyProject1Component()
          : base("XmyProject1", "Nickname",
              "Description",
              "Maths", "Util")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("1", "1", "1", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddIntegerParameter("2", "2", "2", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            int s=0;
            DA.GetData(0, ref s);
            s += 100;
            DA.SetData(0, s);

        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }




        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalMenuItems(menu);
            ToolStripMenuItem item = Menu_AppendItem(menu, "Absolute", Menu_AbsoluteClicked,true);
            // Specifically assign a tooltip text to the menu item.
            item.ToolTipText = "When checked, values are made absolute prior to sorting.";
        }

        private void Menu_AbsoluteClicked(object sender, EventArgs e)
        {
            MessageBox.Show("oo");
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("249f80e0-e72a-4c2c-86af-47891a18f4e4"); }
        }
    }
}
