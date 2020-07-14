using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows.Forms;
using System.Linq;
using System.Globalization;
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
            pManager.AddBooleanParameter("bool", "bool", "布尔值，如果位true,则执行破解", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("2", "2", "2", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            DA.SetData(0, way);
            //Message = "温和破解模式";

            bool s = false;
            DA.GetData(0, ref s);
            if (s)

                if (Absolute2)
                {
                    {
                        this.Message = "暴力解密成功";

                        GH_Document gH_Document = Grasshopper.Instances.ActiveCanvas.Document;
                        List<IGH_ActiveObject> objList = gH_Document.ActiveObjects();


                        Type type = typeof(Grasshopper.Kernel.Special.GH_Cluster);
                        for (int i = 0; i < objList.Count; i++)
                        {

                            if (objList[i].GetType() == type)
                            {
                                ((Grasshopper.Kernel.Special.GH_Cluster)(objList[i])).ExplodeCluster();
                            }
                        }
                        GH_Document.EnableSolutions = false;// !GH_Document.EnableSolutions;


                     //   DA.SetData(0,  "破解成功");

                    }

                }
                else if(!Absolute2)
                    
                    
                {
                    this.Message = "温和破解成功";
                    GH_Document gH_Document = Grasshopper.Instances.ActiveCanvas.Document;
                    List<IGH_ActiveObject> objList = gH_Document.ActiveObjects();

                    Type type = typeof(Grasshopper.Kernel.Special.GH_Cluster);
                    for (int i = 0; i < objList.Count; i++)
                    {
                        if (objList[i].GetType() == type)
                        {
                            Grasshopper.Kernel.Special.GH_Cluster cluster = (Grasshopper.Kernel.Special.GH_Cluster)objList[i];
                            System.Reflection.FieldInfo[] field = type.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                            field[0].SetValue(cluster, Convert.FromBase64String(""));
                        }
                    }



                }

            else
            {
                  //  DA.SetData(0, way);

                    DA.SetData(0, "未破解");
            }

                

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


        private bool m_absolute = false;
        public bool Absolute2
        {
            get { return m_absolute; }
            set
            {
                m_absolute = value;
                if ((m_absolute))
                {
                    Message = "暴力破解模式";
                }
                else
                {
                    Message = "温和解密模式";
                }
            }
        }


        public override bool Write(GH_IO.Serialization.GH_IWriter writer)
        {
            // First add our own field.
            writer.SetBoolean("Absolute", Absolute2);
            // Then call the base class implementation.
            return base.Write(writer);
        }
        public override bool Read(GH_IO.Serialization.GH_IReader reader)
        {
            // First read our own field.
            Absolute2 = reader.GetBoolean("Absolute");
            // Then call the base class implementation.
            return base.Read(reader);
        }




        private void Menu_AbsoluteClicked2(object sender, EventArgs e)
        {
            RecordUndoEvent("Absolute");
            Absolute2 = !Absolute2;
            ExpireSolution(true);
        }



        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            ToolStripMenuItem item2 = Menu_AppendItem(menu, "暴力解密", Menu_AbsoluteClicked2, true, Absolute2);
            // Specifically assign a tooltip text to the menu item.
            item2.ToolTipText = "暴力破解，针对不能双击的打包电池.";















          //  base.AppendAdditionalMenuItems(menu);
           // ToolStripMenuItem item = Menu_AppendItem(menu, "Absolute", Menu_AbsoluteClicked,true);
            // Specifically assign a tooltip text to the menu item.
           // item.ToolTipText = "When checked, values are made absolute prior to sorting.";


            GH_DocumentObject.Menu_AppendItem(menu, "Feature Type:", new EventHandler(this.FeatureType_Clicked));
            this.tsComboBox = new ToolStripComboBox();
            this.tsComboBox.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.tsComboBox.ComboBox.BindingContext = new BindingContext();
            this.tsComboBox.ComboBox.Width = 230;
            this.tsComboBox.ComboBox.DataSource = this.featureTypes;
            this.tsComboBox.ComboBox.SelectedIndexChanged += this.Feature_SelectedIndexChanged;
            this.tsComboBox.ComboBox.SelectedIndex = this.featureTypes.IndexOf("aerialway");
             menu.Items.Add(this.tsComboBox);

            //       GH_DocumentObject.Menu_AppendItem(menu, "Fuzzy Blobs", new EventHandler(this.Menu_FuzzySpriteClicked), true, this.m_spriteType == 0);
            //         GH_DocumentObject.Menu_AppendItem(menu, "Blurry Blobs", new EventHandler(this.Menu_BlurrySpriteClicked), true, this.m_spriteType == 1);


            



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

        public void FeatureType_Clicked(object sender, EventArgs e)
        {
        }

        private void Feature_SelectedIndexChanged(object sender, EventArgs e)
        {


            string text = this.tsComboBox.SelectedItem as string;
            if (text != this.way)
            {
                this.way = (this.tsComboBox.SelectedItem as string);
                string text2 = string.Empty;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                if (text.Contains("_"))
                {
                    string[] array = text.Split(new char[]
                    {
                        '_'
                    });
                    text2 = textInfo.ToTitleCase(array[0]);
                    text2 += textInfo.ToTitleCase(array[1]);
                }
                else
                {
                    text2 = textInfo.ToTitleCase(this.way);
                }
                this.selectedTypes.Clear();
                Enum.TryParse<FeatureType>(text2, out this.wayFT);
                if (this.wayFT != FeatureType.Building)
                {
                    this.show3dMenuItem.Enabled = false;
                }
                else
                {
                    this.show3dMenuItem.Enabled = true;
                }
                this.ExpireSolution(true);
            }




        }


        private List<string> selectedTypes = new List<string>();
        private string way = "building";
        private List<string> featureTypes= featureKeys.ToList<string>();
        private FeatureType wayFT = FeatureType.Building;



        public static string[] featureKeys = new string[]
       {
            "aerialway",
            "aeroway",
            "amenity",
            "barrier",
            "boundary",
            "building",
            "craft",
            "emergency",
            "geological",
            "highway",
            "historic",
            "landuse",
            "leisure",
            "man_made",
            "military",
            "natural",
            "office",
            "place",
            "power",
            "public_transport",
            "railway",
            "route",
            "shop",
            "sport",
            "tourism",
            "waterway"
       };


        public enum FeatureType
        {
            // Token: 0x0400003F RID: 63
            Aerialway,
            // Token: 0x04000040 RID: 64
            Aeroway,
            // Token: 0x04000041 RID: 65
            Amenity,
            // Token: 0x04000042 RID: 66
            Barrier,
            // Token: 0x04000043 RID: 67
            Boundary,
            // Token: 0x04000044 RID: 68
            Building,
            // Token: 0x04000045 RID: 69
            Craft,
            // Token: 0x04000046 RID: 70
            Emergency,
            // Token: 0x04000047 RID: 71
            Geological,
            // Token: 0x04000048 RID: 72
            Highway,
            // Token: 0x04000049 RID: 73
            Historic,
            // Token: 0x0400004A RID: 74
            Landuse,
            // Token: 0x0400004B RID: 75
            Leisure,
            // Token: 0x0400004C RID: 76
            ManMade,
            // Token: 0x0400004D RID: 77
            Military,
            // Token: 0x0400004E RID: 78
            Natural,
            // Token: 0x0400004F RID: 79
            Office,
            // Token: 0x04000050 RID: 80
            Place,
            // Token: 0x04000051 RID: 81
            Power,
            // Token: 0x04000052 RID: 82
            PublicTransport,
            // Token: 0x04000053 RID: 83
            Railway,
            // Token: 0x04000054 RID: 84
            Route,
            // Token: 0x04000055 RID: 85
            Shop,
            // Token: 0x04000056 RID: 86
            Sport,
            // Token: 0x04000057 RID: 87
            Tourism,
            // Token: 0x04000058 RID: 88
            Waterway
        }



        private ToolStripMenuItem show3dMenuItem = new ToolStripMenuItem();







        private ToolStripComboBox tsComboBox;
    }
}
