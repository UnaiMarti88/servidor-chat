using System;
using System.Windows.Forms;

namespace ChatTPVWinforms
{
    public partial class Form1 : Form
    {
        private ClienteChat chat;
        private string nombreUsuario;

        public Form1()
        {
            InitializeComponent();

            nombreUsuario = Microsoft.VisualBasic.Interaction.InputBox("Nombre de usuario:", "Chat TPV", "Cliente1");


            try
            {
                // Cambiamos el puerto a 5556 para que coincida con el servidor
                chat = new ClienteChat("127.0.0.1", 5556, nombreUsuario);
                chat.MensajeRecibido += Chat_MensajeRecibido;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar al servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnEnviar.Click += BtnEnviar_Click;
            txtMensajes.KeyDown += TxtMensajes_KeyDown;
        }

        private void Chat_MensajeRecibido(string mensaje)
        {
            if (lstMensajes.InvokeRequired)
                lstMensajes.Invoke(new Action(() => lstMensajes.Items.Add(mensaje)));
            else
                lstMensajes.Items.Add(mensaje);
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            EnviarMensaje();
        }

        private void TxtMensajes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnviarMensaje();
                e.SuppressKeyPress = true;
            }
        }

        private void EnviarMensaje()
        {
            string texto = txtMensajes.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
            {
                chat?.EnviarMensaje(texto); // Protección por si no hay conexión
                txtMensajes.Clear();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            chat?.Cerrar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
