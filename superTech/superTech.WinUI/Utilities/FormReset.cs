using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace superTech.WinUI.Utilities
{
    public class FormReset
    {
        public static void ResetAllControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }
                if (control is CheckedListBox)
                {
                    CheckedListBox checkListBox = (CheckedListBox)control;
                    checkListBox.ClearSelected();

                }
                if (control is PictureBox)
                {
                    PictureBox pictureBox = (PictureBox)control;
                    pictureBox.Image = null;
                }
                if (control is MaskedTextBox)
                {
                    MaskedTextBox maskedBox = (MaskedTextBox)control;
                    maskedBox.Text = null;
                }
                if (control is RichTextBox)
                {
                    RichTextBox richTextBox = (RichTextBox)control;
                    richTextBox.Text = null;
                }
            }
        }
    }
}
