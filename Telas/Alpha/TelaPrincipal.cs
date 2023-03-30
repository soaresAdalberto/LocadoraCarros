using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Locadora.Telas.Usuários;
using Locadora.Telas.Estoque;
using Locadora.Telas.Locações;
using Locadora.Telas.Parâmetros;
using Locadora.Telas.Clientes;

namespace Locadora
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
            customizeDesign();
            this.MaximizeBox = false;
        }

        //Método para esconder os menus:
        private void customizeDesign()
        {
            pnlMenuUsuarios.Visible = false;
            pnlMenuEstoque.Visible = false;
            pnlMenuLocacoes.Visible = false;
            pnlMenuParametros.Visible = false;
            pnlClientes.Visible = false;
        }

        //Método para esconder o sub menu:
        private void esconderSubMenu()
        {
            if(pnlMenuUsuarios.Visible == true)
                pnlMenuUsuarios.Visible = false;

            if(pnlMenuEstoque.Visible == true)
                pnlMenuEstoque.Visible = false;

            if(pnlMenuLocacoes.Visible == true)
                pnlMenuLocacoes.Visible = false;

            if(pnlMenuParametros.Visible == true)
                pnlMenuParametros.Visible = false;

            if (pnlClientes.Visible == true)
                pnlClientes.Visible = false;

        }

        //Método para mostrar o sub menu:
        private void mostraSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                esconderSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        //Método para abrir o Child Form:

        private Form activeForm = null;
        private void abrirChildForm(Form childForm)
        {
            if(activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        /*--------------------------- AÇÕES PARA MANUSEAR OS CAMPOS DE USUÁRIOS ---------------------------*/
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            mostraSubMenu(pnlMenuUsuarios);
        }

        private void btnVisuUser_Click(object sender, EventArgs e)
        {
            abrirChildForm(new BuscarUsuarios());
            esconderSubMenu();
        }

        private void btnCriarUser_Click(object sender, EventArgs e)
        {
            abrirChildForm(new CriarUsuarios());
            esconderSubMenu();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            abrirChildForm(new EditarUsuarios());
            esconderSubMenu();
        }

        private void btnRemoUser_Click(object sender, EventArgs e)
        {
            abrirChildForm(new RemoverUsuarios());
            esconderSubMenu();
        }

        /*--------------------------- AÇÕES PARA MANUSEAR OS CAMPOS DE ESTOQUE ---------------------------*/
        private void lblEstoque_Click(object sender, EventArgs e)
        {
            mostraSubMenu(pnlMenuEstoque);
        }

        private void btnVisuEstoque_Click(object sender, EventArgs e)
        {
            abrirChildForm(new VisualizarEstoque());
            esconderSubMenu();
        }

        private void btnAddVeiculo_Click(object sender, EventArgs e)
        {
            abrirChildForm(new AdicionarVeiculo());
            esconderSubMenu();
        }

        private void btnEditVeiculo_Click(object sender, EventArgs e)
        {
            abrirChildForm(new EditarVeiculo());
            esconderSubMenu();
        }

        private void btnRemoVeiculo_Click(object sender, EventArgs e)
        {
            abrirChildForm(new RemoverVeiculos());
            esconderSubMenu();
        }

        /*--------------------------- AÇÕES PARA MANUSEAR OS CAMPOS DE LOCAÇÕES ---------------------------*/
        private void lblLocacoes_Click(object sender, EventArgs e)
        {
            mostraSubMenu(pnlMenuLocacoes);
        }

        private void btnRealizar_Click(object sender, EventArgs e)
        {
            abrirChildForm(new RealizarLocacao());
            esconderSubMenu();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            abrirChildForm(new HistLocacao());
            esconderSubMenu();
        }

        private void btnRetoOrcamento_Click(object sender, EventArgs e)
        {
            abrirChildForm(new RetOrcamento());
            esconderSubMenu();
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            abrirChildForm(new DevLocacao());
            esconderSubMenu();
        }

        /*--------------------------- AÇÕES PARA MANUSEAR OS CAMPOS DE PARÂMETROS ---------------------------*/
        private void lblParametros_Click(object sender, EventArgs e)
        {
            mostraSubMenu(pnlMenuParametros);
        }

        private void btnMetas_Click(object sender, EventArgs e)
        {
            abrirChildForm(new Metas());
            esconderSubMenu();
        }

        private void btnSuporte_Click(object sender, EventArgs e)
        {
            abrirChildForm(new Suporte());
            esconderSubMenu();
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            abrirChildForm(new Relatorios());
            esconderSubMenu();
        }

        private void btnDivulgacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Site abrindo no seu navegador...");

            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.linkedin.com/in/adalberto-soares-a1284a230");
            Process.Start(sInfo);

            esconderSubMenu();
        }


        /*--------------------------- AÇÕES PARA MANUSEAR OS CLIENTES ---------------------------*/

        private void btnClientes_Click(object sender, EventArgs e)
        {
            mostraSubMenu(pnlClientes);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            abrirChildForm(new BuscarClientes());
            esconderSubMenu();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            abrirChildForm(new AdicionarClientes());
            esconderSubMenu();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            abrirChildForm(new EditarClientes());
            esconderSubMenu();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            abrirChildForm(new RemoverClientes());
            esconderSubMenu();
        }

        /*--------------------------- TRATAMENTO DE EXCEÇÕES ---------------------------*/
        private void TelaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Size iconSize = new Size(32, 32);
            Rectangle R = new Rectangle(this.Location, iconSize);
            if (R.Contains(Cursor.Position) && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void picSair_Click(object sender, EventArgs e)
        {
            this.Hide();

            TelaLogin tp = new TelaLogin();
            tp.Closed += (s, args) => this.Close();
            tp.Show();
        }

        private void picUser_Click(object sender, EventArgs e)
        {
            abrirChildForm(new MeuUsuario());
        }
    }
}