using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubePlaylists
{
    public class DynamicControls
    {
        public static List<T> CreateDynamicControls<T>(Control containerControl, string name, int number, int verticleSpacing, int horizontalSpacing, int controlTop, int controlLeft, int controlHeight, int controlWidth) where T : Control, new()
        {
            List<T> dynamicControls = new List<T>();

            //Type controlType = control.GetType();

            for (int i = 0; i < number; i++)
            {
                T newControl = new T();
                newControl.Name = name + (i + 1).ToString();
                newControl.Top = (verticleSpacing * i) + controlTop;
                newControl.Left = (horizontalSpacing * i) + controlLeft;
                newControl.Height = controlHeight;
                newControl.Width = controlWidth;
                newControl.Tag = i;
                dynamicControls.Add(newControl);
                containerControl.Controls.Add(newControl);
            }

            return dynamicControls;
        }
    }
}
