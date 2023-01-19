using System.Diagnostics;
using System.Media;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace _2pacalypse
{
    public partial class Form1 : Form
    {
        private SoundPlayer _soundPlayer;

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rng = new Random();
            label5.Text += rng.Next(15, 75);
            label6.Visible = false;
            label6.Refresh();
            Application.DoEvents();
            Rectangle screenRectangle = RectangleToScreen(ClientRectangle);
            int titleHeight = screenRectangle.Top - Top;
            int Right = screenRectangle.Left - Left;
            Bitmap bmp = new Bitmap(Width, Height);
            DrawToBitmap(bmp, new Rectangle(0, 0, Width, Height));
            Bitmap bmpImage = new Bitmap(bmp);
            bmp = bmpImage.Clone(new Rectangle(label6.Location.X + Right, label6.Location.Y + titleHeight, label6.Width, label6.Height), bmpImage.PixelFormat);
            label6.BackgroundImage = bmp;
            label6.Visible = true;

            System.IO.Stream _2pacstream = Properties.Resources.keygen;

            _soundPlayer = new SoundPlayer(_2pacstream);
            _soundPlayer.PlayLooping();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Ping pingSender = new Ping();
            Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            MatchCollection result = ip.Matches(textBox1.Text);
            int port;
            if (!int.TryParse(textBox2.Text, out port) || port < 1 || port > 65536)
            {
                MessageBox.Show("yoyo that no valid port bruh", "2pacalypse 2.4", MessageBoxButtons.OK);
                return;
            }

            if (result.Count != 1)
            {
                MessageBox.Show("yoyo chill invalid ip homie", "2pacalypse 2.4", MessageBoxButtons.OK);
                return;
            }

            var ipWithPort = string.Format("{0}:{1}", result[0].ToString(), port);

            await Task.Run(() =>
            {
                while (true)
                {
                    var fucker = pingSender.Send(result[0].ToString());
                    label8.BeginInvoke(
                        delegate
                        {
                            var statusText = "";
                            if (fucker.Status == IPStatus.Success)
                            {
                                statusText = string.Format("/bin/cmd.exe $ status: {0} roundtrip time: {1} time 2 live: {2} size: {3}\n", fucker.Status, fucker.RoundtripTime, fucker.Options.Ttl, fucker.Buffer.Length);
                            }
                            else
                            {
                                statusText = string.Format("/bin/cmd.exe $ status: {0} host: {1}\n", fucker.Status, ipWithPort);
                            }
                            var newText = label8.Text + statusText;
                            label8.Text = newText.Length <= 1337 ? newText : statusText;
                        });
                }
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // pause homie
            _soundPlayer.Stop();
            button3.Visible = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _soundPlayer.PlayLooping();
            button2.Visible = false;
            button3.Visible = true;
        }
    }
}