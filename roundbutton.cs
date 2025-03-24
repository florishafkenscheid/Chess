using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ChessApp
{
    public class RoundButton : Button
    {
        // Property to define the corner radius
        public int CornerRadius { get; set; } = 40;

        // Property to set the border color (default to transparent)
        public Color BorderColor { get; set; } = Color.Transparent;

        protected override void OnPaint(PaintEventArgs e)
        {
            // Create a GraphicsPath for rounded rectangle with the specified corner radius
            var graphicsPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
            graphicsPath.AddArc(rect.X, rect.Y, CornerRadius, CornerRadius, 180, 90);  // Top-left corner
            graphicsPath.AddArc(rect.X + rect.Width - CornerRadius, rect.Y, CornerRadius, CornerRadius, 270, 90);  // Top-right corner
            graphicsPath.AddArc(rect.X + rect.Width - CornerRadius, rect.Y + rect.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);  // Bottom-right corner
            graphicsPath.AddArc(rect.X, rect.Y + rect.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);  // Bottom-left corner
            graphicsPath.CloseFigure();

            // Set the region of the button to the rounded rectangle path
            this.Region = new Region(graphicsPath);

            // Create a brush for the button's background color
            using (Brush brush = new SolidBrush(this.BackColor))
            {
                // Fill the button with the background color
                e.Graphics.FillPath(brush, graphicsPath);
            }

            // If the border color is not transparent, draw the border
            if (BorderColor != Color.Transparent)
            {
                using (Pen pen = new Pen(BorderColor))
                {
                    // Draw the border around the button
                    e.Graphics.DrawPath(pen, graphicsPath);
                }
            }

            // Call the base OnPaint method to perform default painting (draw text)
            base.OnPaint(e);
        }
    }
}
