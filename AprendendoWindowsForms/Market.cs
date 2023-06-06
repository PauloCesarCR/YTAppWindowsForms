using Microsoft.Web.WebView2.WinForms;

namespace AprendendoWindowsForms
{
    public partial class Market : Form
    {

        private WebView2 webView;

        public Market()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica se os campos de entrada estão vazios
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Por favor, insira o link do Youtube.");
                return;
            }
            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            this.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async(null);
            webView.BringToFront();
            FormBorderStyle = FormBorderStyle.None;

            Screen desiredScreen = GetMonitorByIndex(1);

            Location = desiredScreen.Bounds.Location;

            Width = desiredScreen.Bounds.Width;
            Height = desiredScreen.Bounds.Height;

            WindowState = FormWindowState.Maximized;

            webView.Source = new Uri(textBox1.Text);
        }

        private Screen GetMonitorByIndex(int index)
        {
            Screen[] screens = Screen.AllScreens;

            if (index >= 0 && index < screens.Length)
            {
                return screens[index];
            }

            return Screen.PrimaryScreen;
        }
    }
}