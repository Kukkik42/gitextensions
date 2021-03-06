﻿using System;
using GitCommands.Remote;

namespace GitUI.UserControls
{
    public partial class RemotesComboboxControl : GitModuleControl
    {
        public RemotesComboboxControl()
        {
            InitializeComponent();
            Translate();
            AllowMultiselect = false;
        }

        public string SelectedRemote { get { return comboBoxRemotes.Text; } set { comboBoxRemotes.Text = value; } }

        bool _allowMultiselect;
        public bool AllowMultiselect
        {
            get { return _allowMultiselect; }
            set
            {
                _allowMultiselect = value;
                buttonSelectMultipleRemotes.Visible = _allowMultiselect;
                if (_allowMultiselect)
                {
                    throw new NotImplementedException();
                }
            }
        }

        private void RemotesComboboxControl_Load(object sender, EventArgs e)
        {
            if (Site != null && Site.DesignMode)
            {
                return;
            }

            var remoteManager = new GitRemoteManager(Module);
            comboBoxRemotes.DataSource = remoteManager.LoadRemotes(false);
        }
    }
}
