using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GD.Extensions
{
    public static class ControlExtensions
    {
        public static List<T> CreateDynamicControls<T>(this Control containerControl, string name, int number, int verticleSpacing, int horizontalSpacing, Rectangle  rectangle) where T : Control, new()
        {
            return CreateDynamicControls<T>(containerControl, name, number, verticleSpacing, horizontalSpacing, rectangle.Y, rectangle.X, rectangle.Height, rectangle.Width);
        }


        public static List<T> CreateDynamicControls<T>(this Control containerControl, string name, int number, int verticleSpacing, int horizontalSpacing, int controlTop, int controlLeft, int controlHeight, int controlWidth) where T : Control, new()
        {
            List<T> dynamicControls = new List<T>();

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
