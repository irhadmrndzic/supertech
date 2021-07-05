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

                if (control is GroupBox)
                {
                    foreach (Control ctrl in control.Controls)
                    {
                        if (ctrl is TextBox)
                        {
                            TextBox textBox = (TextBox)ctrl;
                            textBox.Text = null;
                        }

                        //if (control is ComboBox)
                        //{
                        //    ComboBox comboBox = (ComboBox)control;
                        //    if (comboBox.Items.Count > 0)
                        //        comboBox.SelectedIndex = 0;
                        //}

                        if (ctrl is CheckBox)
                        {
                            CheckBox checkBox = (CheckBox)ctrl;
                            checkBox.Checked = false;
                        }

                        if (ctrl is ListBox)
                        {
                            ListBox listBox = (ListBox)ctrl;
                            listBox.ClearSelected();
                        }

                        if (ctrl is CheckBox)
                        {
                            CheckBox checkBox = (CheckBox)ctrl;
                            checkBox.Checked = false;
                        }
                        if (ctrl is CheckedListBox)
                        {
                            CheckedListBox checkListBox = (CheckedListBox)ctrl;
                            checkListBox.ClearSelected();

                        }
                        if (ctrl is PictureBox)
                        {
                            PictureBox pictureBox = (PictureBox)ctrl;
                            pictureBox.Image = null;
                        }
                        if (ctrl is MaskedTextBox)
                        {
                            MaskedTextBox maskedBox = (MaskedTextBox)ctrl;
                            maskedBox.Text = null;
                        }
                        if (ctrl is RichTextBox)
                        {
                            RichTextBox richTextBox = (RichTextBox)ctrl;
                            richTextBox.Text = null;
                        }

                        if (ctrl is NumericUpDown)
                        {
                            NumericUpDown numericUpDown = (NumericUpDown)ctrl;
                            numericUpDown.Value = 0;
                        }

                        if (ctrl is DateTimePicker)
                        {
                            DateTimePicker dp = (DateTimePicker)ctrl;
                            dp.Value = DateTime.Today;
                        }
                    }
                }
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                //if (control is ComboBox)
                //{
                //    ComboBox comboBox = (ComboBox)control;
                //    if (comboBox.Items.Count > 0)
                //        comboBox.SelectedIndex = 0;
                //}

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

                if (control is NumericUpDown)
                {
                    NumericUpDown numericUpDown = (NumericUpDown)control;
                    numericUpDown.Value = 0;
                }

                if (control is DateTimePicker)
                {
                    DateTimePicker dp = (DateTimePicker)control;
                    dp.Value = DateTime.Today;
                }
            }
        }
    }
}
