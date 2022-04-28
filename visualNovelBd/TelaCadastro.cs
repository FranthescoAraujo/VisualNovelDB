using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visualNovel
{
    public partial class TelaCadastro : Form
    {
        public TelaCadastro()
        {
            InitializeComponent();
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.Show();
            this.Hide();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text == "")
            {
                MessageBox.Show("Login não pode ser nulo");
                return;
            }
            if (tbEmail.Text == "")
            {
                MessageBox.Show("E-mail não pode ser nulo");
                return;
            }
            if (tbSenha.Text == "")
            {
                MessageBox.Show("Senha não pode ser nulo");
                return;
            }
            if (tbConfirmarSenha.Text == "")
            {
                MessageBox.Show("Confirmar senha não pode ser nulo");
                return;
            }
            if (tbSenha.Text != tbConfirmarSenha.Text)
            {
                MessageBox.Show("Digite corretamento a confirmação da senha");
                return;
            }
            MessageBox.Show(ConexaoBanco.cadastrarUsuario(tbLogin.Text, tbSenha.Text, tbEmail.Text));
        }
    }
}
