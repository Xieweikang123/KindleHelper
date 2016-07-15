﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libZhuishu;
using System.Diagnostics;

namespace KindleHelper
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }


        private void btn_search_Click(object sender, EventArgs e)
        {
            FormSearchResult form_result = new FormSearchResult();
            var results = LibZhuiShu.fuzzySearch(textbox_search.Text, 0, 100);
            if (results == null || results.Length < 1) {
                MessageBox.Show("没有找到:" + textbox_search.Text);
                return;
            }
            form_result.ShowResult(results);
        }

        private void textbox_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textbox_search.Text)) return;
            listbox_autocomplate.Items.Clear();
            var words = LibZhuiShu.autoComplate(textbox_search.Text);
            if (words != null && words.Length > 0) {
                listbox_autocomplate.Items.AddRange(words);
                listbox_autocomplate.Visible = true;
            } else {
                listbox_autocomplate.Visible = false;
            }
        }

        private void listbox_autocomplate_SelectedValueChanged(object sender, EventArgs e)
        {
            textbox_search.Text = listbox_autocomplate.SelectedItem.ToString();
            listbox_autocomplate.Visible = false;
            btn_search_Click(sender,e);
        }
    }
}