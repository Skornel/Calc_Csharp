using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public class Journal
    {
        List<(string mathExpression, string numberResult)> pages;
        int coordY, coordX;
        Panel panel;
        int pageIndex;
        int labelIndex;
        public Journal(Panel panel)
        {
            this.panel = panel;
            panel.Controls.Clear();
            pages = new List<(string mathExpression, string numberResult)>();
            pageIndex = 0;
            labelIndex = 0;
            coordY = 10;
            coordX = 10;
        }
        public void Update(string mathExpression, string numberResult)
        {
            WritePage(mathExpression, numberResult);
            DrawPage();
        }
        private void WritePage(string mathExpression, string numberResult)
        {
            pages.Add((mathExpression, numberResult));
        }
        private void DrawPage()
        {
            panel.Controls.Add(new Label());
            ((Label)panel.Controls[labelIndex]).Text = pages[pageIndex].mathExpression;
            ((Label)panel.Controls[labelIndex]).Font = new Font("Univers Else", 8);
            ((Label)panel.Controls[labelIndex]).ForeColor = Color.Gray;
            ((Label)panel.Controls[labelIndex]).Location = new Point(coordX, coordY - panel.VerticalScroll.Value);
            ((Label)panel.Controls[labelIndex]).AutoSize = true;
            coordY += 18;
            labelIndex++;
            panel.Controls.Add(new Label());
            ((Label)panel.Controls[labelIndex]).Text = pages[pageIndex].numberResult;
            ((Label)panel.Controls[labelIndex]).Font = new Font("Univers Else", 12, FontStyle.Bold);
            ((Label)panel.Controls[labelIndex]).ForeColor = Color.Black;
            ((Label)panel.Controls[labelIndex]).Location = new Point(coordX, coordY - panel.VerticalScroll.Value);
            ((Label)panel.Controls[labelIndex]).AutoSize = true;
            coordY += 30;
            labelIndex++;
            pageIndex++;
            panel.AutoScrollPosition = new Point(0, coordY);
        }
    }
}
