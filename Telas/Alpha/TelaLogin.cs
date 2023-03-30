using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Locadora
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }
        
        //Fechar a aplicação:
        private void picFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Limpar os dados digitados no txtUsuario e txtSenha:
        private void picLimpar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtSenha.Clear();
            txtUsuario.Focus();
        }

        //Enviar uma nova senha para o e-mail do usuário:
        private void btnRecSenha_Click(object sender, EventArgs e)
        {
            //Vídeo de referência: https://www.youtube.com/watch?v=OGuQu13OiZk

            //Instanciando na classe de envio de email:
            MailMessage mail = new MailMessage();

            //Email que irá enviar (o meu):
            mail.From = new MailAddress("eng.adalbertosoares@gmail.com");

            //Email que irá receber:
            mail.To.Add("adalberto.soares@unimed144.coop.br");

            //Assunto:
            mail.Subject = "Teste";

            //Corpo do texto:
            mail.Body = "Testando a configuração do SMTP";

            //Configurando o SMTP:
            using (var smtp = new SmtpClient("smtp.gmail.com", 587)) 
            {
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("eng.adalbertosoares@gmail.com", "ryukoxaxfzzctnwg");

                try
                {
                    smtp.Send(mail);

                    MessageBox.Show("Uma nova senha foi enviada e-mail cadastrado nesse usuário.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Houve um erro no envio do e-mail, favor validar.");
                }
            }
        }

        //Confirmar a senha e entrar no sistema:
        private void picConfirmar_Click(object sender, EventArgs e)
        {
            this.Hide();

            TelaPrincipal tp = new TelaPrincipal();
            tp.Closed += (s, args) => this.Close();
            tp.Show();
        }

        //Habilitar o enter como "tab":
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            var a = txtUsuario.Text;

            if (e.KeyCode == Keys.Enter)
            {
                txtUsuario.Text = a;
                Acao();
            }
            */
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (e.KeyCode == Keys.Enter)
            {
                Acao();
            }
            */
        }

        void Acao()
        {
            /*
            if (this.ActiveControl == txtUsuario)
            {
                this.ActiveControl = txtSenha;
            }
            else
            {
                this.Hide();

                TelaPrincipal tp = new TelaPrincipal();
                tp.Closed += (s, args) => this.Close();
                tp.Show();
            }
            */
        }
    }
}
