﻿namespace GitUIPluginInterfaces.UserControls
{
    public partial class CredentialsControl : UserControl
    {
        public CredentialsControl(string? userNameLabelText = null, string? passwordLabelText = null)
        {
            InitializeComponent();

            ChangeLabelText(userNameLabelText, passwordLabelText);
        }

        public string UserName
        {
            get => userNameTextBox.Text;

            set => userNameTextBox.Text = value;
        }

        public string Password
        {
            get => passwordTextBox.Text;

            set => passwordTextBox.Text = value;
        }

        /// <summary>
        /// Change UI Mode
        /// </summary>
        /// <param name="isShowUserName">Is show the `User name` text box</param>
        /// <param name="passwordLabelText">The `Password` lable's text</param>
        /// <param name="userNameLabelText">The `User name` lable's text</param>
        public void ChangeUIMode(bool isShowUserName, string? passwordLabelText = null, string? userNameLabelText = null)
        {
            ChangeLabelText(userNameLabelText, passwordLabelText);

            if (isShowUserName)
            {
                userNameLabel.Show();
                userNameTextBox.Show();
                mainTableLayoutPanel.ColumnStyles[0].Width = mainTableLayoutPanel.ColumnStyles[2].Width;
                mainTableLayoutPanel.ColumnStyles[1].Width = mainTableLayoutPanel.ColumnStyles[3].Width;
            }
            else
            {
                userNameLabel.Hide();
                userNameTextBox.Hide();
                mainTableLayoutPanel.ColumnStyles[0].Width = 0;
                mainTableLayoutPanel.ColumnStyles[1].Width = 0;
            }
        }

        private void ChangeLabelText(string? userNameLabelText = null, string? passwordLabelText = null)
        {
            if (!string.IsNullOrWhiteSpace(userNameLabelText))
            {
                userNameLabel.Text = userNameLabelText;
            }

            if (!string.IsNullOrWhiteSpace(passwordLabelText))
            {
                passwordLabel.Text = passwordLabelText;
            }
        }

        private void CredentialsControl_Load(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = true;
        }
    }
}
