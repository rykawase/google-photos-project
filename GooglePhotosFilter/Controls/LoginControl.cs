using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GooglePhotosFilter.Classes;

namespace GooglePhotosFilter.Controls
{
    public partial class LoginControl : UserControl
    {
        private const string MESSAGE_ENTER_CLIENT_ID = "Enter your Client Id here...";
        private const string MESSAGE_ENTER_CLIENT_SECRET = "Enter your Client Secret here...";
        GoogleLogin googleLogin;

        public LoginControl()
        {
            InitializeComponent();

            googleLogin = new GoogleLogin();

            this.txtClientId.Text = MESSAGE_ENTER_CLIENT_ID;
            this.txtClientId.GotFocus += txtClient_GotFocus;
            this.txtClientId.LostFocus += txtClient_LostFocus;
            
            this.txtClientSecret.Text = MESSAGE_ENTER_CLIENT_SECRET;
            this.txtClientSecret.GotFocus += txtClient_GotFocus;
            this.txtClientSecret.LostFocus += txtClient_LostFocus;

            string currentToken = GooglePhotosInterface.Instance.GetToken();

            if (currentToken != string.Empty)
                SetTextToken(currentToken);
        }

        void txtClient_GotFocus(object sender, EventArgs e)
        {
            TextBox txtClient = (TextBox)sender;
            
            if(txtClient.Name == "txtClientId")
            {
                if (txtClient.Text == MESSAGE_ENTER_CLIENT_ID)
                    txtClient.Text = string.Empty;
            }
            else
            {
                if (txtClientSecret.Text == MESSAGE_ENTER_CLIENT_SECRET)
                    txtClient.Text = string.Empty;
            }            

        }

        void txtClient_LostFocus(object sender, EventArgs e)
        {
            TextBox txtClient = (TextBox)sender;

            if (txtClient.Name == "txtClientId")
            {
                if (string.IsNullOrWhiteSpace(txtClient.Text))
                    txtClient.Text = MESSAGE_ENTER_CLIENT_ID;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtClientSecret.Text))
                    txtClient.Text = MESSAGE_ENTER_CLIENT_SECRET;
            }   
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string token = googleLogin.Login(this.txtClientId.Text,
                                             this.txtClientSecret.Text);

            if (token != string.Empty)
            {
                MessageBox.Show(this, "Token created successfully!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GooglePhotosInterface.Instance.SetToken(token);
                SetTextToken(token);
            }
            else
            {
                MessageBox.Show(this, "Error creating token", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                
        }

        private void SetTextToken(string token)
        {
            this.lblToken.Text = string.Format("Access Token: {0}", token);
        }
    }
}
