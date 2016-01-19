using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace QuestDolls
{
    public class NColumnPannel : System.Windows.Controls.Panel
    {
        public static readonly DependencyProperty ColumnCoutnProperty =
            DependencyProperty.Register("ColumnCoutn", typeof(int), typeof(NColumnPannel), new PropertyMetadata(default(int)));

        public int ColumnCoutn
        {
            get { return (int)GetValue(ColumnCoutnProperty); }
            set { SetValue(ColumnCoutnProperty, value); }
        }

        public static readonly DependencyProperty MaxColumnCountProperty =
            DependencyProperty.Register("MaxColumnCount", typeof(int), typeof(NColumnPannel), new PropertyMetadata(default(int)));

        public int MaxColumnCount
        {
            get { return (int)GetValue(MaxColumnCountProperty); }
            set { SetValue(MaxColumnCountProperty, value); }
        }

        List<double> widthColumns = new List<double>();
        List<double> rowHeigh = new List<double>();
        protected override Size MeasureOverride(Size availableSize)
        {
            Size result = new Size();
            try
            {
                widthColumns.Clear();
                rowHeigh.Clear();
                int column = 0;
                int row = 0;
                double maxHeight = 0.0;
                double height = 0.0;
                double maxWidth = 0.0;

                foreach (UIElement child in this.Children)
                    child.Measure(availableSize);

                foreach (UIElement child in this.Children)
                    maxWidth = Math.Max(maxWidth, child.DesiredSize.Width);

                if (availableSize.Width / maxWidth > ColumnCoutn)
                {
                    var count = (int)(availableSize.Width / maxWidth);
                    count = count > MaxColumnCount ? MaxColumnCount : count;
                    widthColumns.AddRange(new double[count]);
                }
                else
                    widthColumns.AddRange(new double[ColumnCoutn]);

                foreach (UIElement child in this.Children)
                {
                    widthColumns[column] = Math.Max(widthColumns[column], child.DesiredSize.Width);
                    maxHeight = Math.Max(maxHeight, child.DesiredSize.Height);
                    column++;

                    if (widthColumns.Count != column)
                        continue;

                    rowHeigh.Add(maxHeight);
                    height += maxHeight;
                    maxHeight = 0.0;
                    column = 0;
                    row++;

                }
                if (column != 0)
                {
                    rowHeigh.Add(maxHeight);
                    height += maxHeight;
                }

                double width = widthColumns.Sum();
                result = new Size(width, height);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return result;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Size result = new Size();
            try
            {
                double width = widthColumns.Sum();
                double height = rowHeigh.Sum();
                if (width > finalSize.Width && width > 0)
                    for (int i = 0; i < widthColumns.Count; i++)
                        widthColumns[i] = widthColumns[i] * finalSize.Width / width;

                double xOffset = 0.0;
                double yOffset = 0.0;
                int row = 0;
                int column = 0;
                foreach (UIElement child in this.Children)
                {
                    if (column > 0)
                        xOffset += widthColumns[column - 1];
                    child.Arrange(new Rect(xOffset, yOffset, widthColumns[column], rowHeigh[row]));
                    column++;
                    if (widthColumns.Count != column)
                        continue;

                    yOffset += rowHeigh[row];
                    row++;
                    column = 0;
                    xOffset = 0;

                }
                result = new Size(width, height);
            }
            catch (Exception ex)
            {

                ex.ToString();
            }

            return result;
        }
    }
}
