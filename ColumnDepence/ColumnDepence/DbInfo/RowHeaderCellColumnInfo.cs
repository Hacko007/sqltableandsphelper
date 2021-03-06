﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace hackovic.DbInfo.DbInfo
{
    [Flags]
    public enum ColumnRefType
    {
        None = 0,
        PrimaryKey = 1,
        ForegnKey = 2,
        Unique = 4,
        Index = 8
    }

    public class RowHeaderCellColumnInfo : DataGridViewRowHeaderCell
    {
        public ColumnRefType ColumnRefType { get; set; }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates cellState, object value, object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            var str = "";
            var strToolTip = "";

            if (Has(ColumnRefType.PrimaryKey))
            {
                str = "Pk ";
                strToolTip = "Primary key ,";
            }

            if (Has(ColumnRefType.ForegnKey))
            {
                str += "Fk ";
                strToolTip += "Foregn key ,";
            }

            if (Has(ColumnRefType.Unique))
            {
                str += "U ";
                strToolTip += "Unique ,";
            }

            if (Has(ColumnRefType.Index))
            {
                str += "I ";
                strToolTip += "Index ,";
            }
            cellBounds.Width += ((int)graphics.MeasureString(str, SystemFonts.CaptionFont).Width) + 5;
            if (strToolTip.Length > 0)
            {
                ToolTipText = strToolTip.Remove(strToolTip.Length - 1);
            }

            value = str;

            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle,
                advancedBorderStyle, paintParts);

            var iconBounds = cellBounds;
            iconBounds.X += 10;
            iconBounds.Y += 5;

            if (Has(ColumnRefType.PrimaryKey))
            {
                graphics.DrawString("Pk", SystemFonts.CaptionFont, Brushes.Green, iconBounds.Location);
                iconBounds.X += ((int)graphics.MeasureString("Pk", SystemFonts.CaptionFont).Width);
            }

            if (Has(ColumnRefType.ForegnKey))
            {
                graphics.DrawString("Fk", SystemFonts.CaptionFont, Brushes.Blue, iconBounds.Location);
                iconBounds.X += ((int)graphics.MeasureString("Fk", SystemFonts.CaptionFont).Width);
            }

            if (Has(ColumnRefType.Unique))
            {
                graphics.DrawString("U", SystemFonts.CaptionFont, Brushes.Gray, iconBounds.Location);
                iconBounds.X += ((int)graphics.MeasureString("U", SystemFonts.CaptionFont).Width);
            }

            if (Has(ColumnRefType.Index))
            {
                graphics.DrawString("I", SystemFonts.CaptionFont, Brushes.Goldenrod, iconBounds.Location);
            }
        }

        /// <summary>
        ///     Returns boolean representing existans of
        ///     <paramref name="searchFlag" /> in <paramref name="searchFlag" />
        /// </summary>
        /// <param name="searchFlag"></param>
        /// <returns>
        ///     Returns true if <paramref name="searchFlag" />
        ///     is containd in <paramref name="searchFlag" />
        /// </returns>
        private bool Has(ColumnRefType searchFlag)
        {
            return (ColumnRefType & searchFlag) == searchFlag;
        }
    }
}