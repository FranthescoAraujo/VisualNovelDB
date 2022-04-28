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
    public partial class TelaJogo : Form
    {
        public TelaJogo()
        {
            InitializeComponent();
            lblPagina.Text = ConexaoBanco.telaUsuario.ToString();
            lblTexto.Text = ConexaoBanco.buscarTelaBanco();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (ConexaoBanco.telaUsuario >= 1)
            {
                ConexaoBanco.telaUsuario -= 1;
                lblPagina.Text = ConexaoBanco.telaUsuario.ToString();
                lblTexto.Text = ConexaoBanco.buscarTelaBanco();
                ConexaoBanco.salvaTelaBanco();
                return;
            }
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.Show();
            this.Hide();
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            if (ConexaoBanco.telaUsuario >= 25)
            {
                ConexaoBanco.telaUsuario = 0;
                lblPagina.Text = ConexaoBanco.telaUsuario.ToString();
                lblTexto.Text = ConexaoBanco.buscarTelaBanco();
                ConexaoBanco.salvaTelaBanco();
                return;
            }
            ConexaoBanco.telaUsuario += 1;
            lblPagina.Text = ConexaoBanco.telaUsuario.ToString();
            lblTexto.Text = ConexaoBanco.buscarTelaBanco();
            ConexaoBanco.salvaTelaBanco();
        }
    }
}
