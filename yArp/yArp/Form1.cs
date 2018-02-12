using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yArp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Devices.MouseClick += Devices_MouseClick;      

            string[] rows = { "test", "test2", "test3" };
            var listViewItem = new ListViewItem(rows);
            Devices.Items.Add(listViewItem);
        }

        private void Devices_MouseClick(object sender, MouseEventArgs e)
        {
           
           foreach(ListViewItem I in Devices.Items)
            {
                SelectDeselect(I, !I.Checked);
            } 
        }

        private void Devices_SelectedIndexChanged(object sender, EventArgs e)
        {   
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem I in Devices.Items)
            {
                I.Checked = true;
                SelectDeselect(I, true);
            }
        }

        private void DeselectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem I in Devices.Items)
            {
                I.Checked = false;
                SelectDeselect(I, false);
            }
        }

        private void SelectDeselect(ListViewItem I, bool select)
        {
           
            if (select)
            {
                I.BackColor = SystemColors.MenuHighlight;
            }
            else
            {
                I.BackColor = SystemColors.Window;
            }
        }
    }
}
