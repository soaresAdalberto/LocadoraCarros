using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora.Telas.Parâmetros
{
    public partial class Suporte : Form
    {
        public Suporte()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //Vídeo de referência: https://www.youtube.com/watch?v=OGuQu13OiZk

            //Instanciando na classe de envio de email:
            MailMessage mail = new MailMessage();

            //Email que irá enviar (o meu):
            mail.From = new MailAddress("eng.adalbertosoares@gmail.com");

            //Email que irá receber:
            mail.To.Add("adalberto.soares@unimed144.coop.br");

            string nome = txtNome.Text;
            string texto = Problema.Text;

            //Assunto:
            mail.Subject = "Suporte - " + nome;

            //Corpo do texto:
            mail.Body = "Responder o e-mail para: " + txtEmail.Text + "\n\n" + Problema.Text;

            //Configurando o SMTP:
            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("eng.adalbertosoares@gmail.com", "ryukoxaxfzzctnwg");

                try
                {
                    smtp.Send(mail);

                    MessageBox.Show("Solicitação recebida. Em breve você irá receber um e-mail com a resolução do seu problema!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Houve um erro no envio do e-mail, favor validar.");
                }
            }

            txtNome.Clear();
            txtEmail.Clear();
            Problema.Clear();
        }
    }
}
