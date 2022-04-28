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
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
            MessageBox.Show(ConexaoBanco.iniciarConexao());
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ConexaoBanco.validaUsuario(tbLogin.Text, tbSenha.Text))
            {
                MessageBox.Show("Login e senha confirmados");
                TelaJogo telaJogo = new TelaJogo();
                telaJogo.Show();
                this.Hide();
                return;
            }
            MessageBox.Show("Login ou senha não cadastrados");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblCriarUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TelaCadastro telaCadastro = new TelaCadastro();
            telaCadastro.Show();
            this.Hide();
        }
    }
}
