using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmBusinessLogic.Attributes
{
    public class ColumnAttribute : Attribute
    {
       public ColumnAttribute(string title = "", bool visible = true, int width = 0,
       GridViewAutoSize gridViewAutoSize = GridViewAutoSize.None, string dateFormat = null)
        {
            Title = title;
            Visible = visible;
            Width = width;
            GridViewAutoSize = gridViewAutoSize;
            this.dateFormat = dateFormat;
        }
        public string Title { get; private set; }
        public bool Visible { get; private set; }
        public int Width { get; private set; }
        public GridViewAutoSize GridViewAutoSize { get; private set; }
        public string dateFormat { get; private set; }
    }

}
