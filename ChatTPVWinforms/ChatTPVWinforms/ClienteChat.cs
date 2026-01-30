using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ChatTPVWinforms
{
    public class BezeroaChat
    {
        private TcpClient bezeroa;
        private StreamReader irakurlea;
        private StreamWriter idazlea;
        private Thread entzuteHilo;
        private string erabiltzaileIzena;
        private bool konektatuta = false;

        public event Action<string> MezuaJasoDa;

        public BezeroaChat(string host, int portua, string erabiltzaileIzena)
        {
            this.erabiltzaileIzena = erabiltzaileIzena;

            try
            {
                bezeroa = new TcpClient(host, portua);
                irakurlea = new StreamReader(bezeroa.GetStream());
                idazlea = new StreamWriter(bezeroa.GetStream()) { AutoFlush = true };
                konektatuta = true;

                entzuteHilo = new Thread(Entzun);
                entzuteHilo.IsBackground = true;
                entzuteHilo.Start();

                Console.WriteLine("Zerbitzariarenarekin konektatuta: " + host + ":" + portua);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ezin izan da zerbitzarira konektatu: " + ex.Message, "Errorea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Entzun()
        {
            try
            {
                string mezua;
                while (konektatuta && (mezua = irakurlea.ReadLine()) != null)
                {
                    Console.WriteLine("Bezeroak jasotako mezua: " + mezua);
                    MezuaJasoDa?.Invoke(mezua);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Entzuteko hiloan errorea: " + ex.Message);
            }
        }

        public void BidaliMezua(string mezua)
        {
            if (!konektatuta)
            {
                MessageBox.Show("Ez dago zerbitzariarekin konexiorik.", "Abisua", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string osoa = erabiltzaileIzena + ": " + mezua;
                idazlea.WriteLine(osoa);
                Console.WriteLine("Bidalitako mezua: " + osoa);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ezin izan da mezua bidali: " + ex.Message, "Errorea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Itxi()
        {
            try
            {
                konektatuta = false;
                bezeroa?.Close();
                Console.WriteLine("Konexioa itxita.");
            }
            catch { }
        }
    }
}
