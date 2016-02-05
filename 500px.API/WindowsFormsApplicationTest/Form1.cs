using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OAuth;


namespace WindowsFormsApplicationTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           ags.Tokens.TokenStore.CreateDB("test.db");
            var tok = new OAuthBroker.OAuthToken();
            tok.Token = "aaaaa";
            tok.Secret = "dddddd";
            ags.Tokens.TokenStore.SaveToken(tok);
           
        }
    }
}
