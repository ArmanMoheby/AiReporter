using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json;

namespace AiReporter
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "AIzaSyDdG3eewfkI9Drz2BJILfTHu9zdbNgOUSA"; // کلید API
        private WebView2 _webView;
        string generatedText;

        public Form1()
        {
            InitializeComponent();

            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(5)
            };

            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            _webView = new WebView2
            {
                Dock = DockStyle.Fill
            };

            await _webView.EnsureCoreWebView2Async();
            panelHtmlPreview.Controls.Add(_webView); // اضافه به پنل نه فرم
        }

        private async void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                var inputText = txt1.Text.Trim();
                if (string.IsNullOrWhiteSpace(inputText))
                {
                    MessageBox.Show("لطفاً متن اولیه Claim را وارد کنید.");
                    return;
                }

                label3.Invoke(() => label3.Text = "در حال پردازش... لطفاً صبر کنید...");

                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new { text = "شما یک متخصص قراردادهای EPC هستید.\n\nلطفاً متن زیر را به زبان فارسی، به صورت رسمی، ویرایش و بازنویسی کنید. سپس آن را با HTML تمیز، دارای استایل و رنگ، برای نمایش وب آماده نمایید.\n\nفقط خروجی HTML نهایی را بدون هیچ توضیحی بازگردانید." },
                                new { text = inputText },
                               new{ text = "نام شرکت پترو سازه مبین است در متن پیشنهادی اگر نیاز بود لحاظ کنن"}
                            }
                        }
                    }
                };

                var jsonRequestBody = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

                var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_apiKey}";
                var response = await _httpClient.PostAsync(url, content).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    //  txt2.Invoke(() => txt2.Text = errorContent);
                    MessageBox.Show($"خطا در ارتباط با هوش مصنوعی: {errorContent}");
                    return;
                }

                var result = await response.Content.ReadAsStringAsync();
                dynamic jsonResponse = JsonConvert.DeserializeObject(result);

                generatedText = jsonResponse?.candidates?[0]?.content?.parts?[0]?.text?.ToString();
                generatedText = generatedText.Replace("```", "");
                generatedText = generatedText.Replace("HTML", "");
                generatedText = generatedText.Replace("html", "");
                generatedText = generatedText.Replace("< lang=\"fa\">\r\n", "");
                generatedText = generatedText.Replace("< lang=\"fa\">", "");
                generatedText = generatedText.Replace("< lang=\"fa\" dir=\"rtl\">\r\n", "");

                if (string.IsNullOrWhiteSpace(generatedText))
                {
                    label3.Invoke(() => label3.Text = "پاسخی دریافت نشد.");
                    return;
                }

                label3.Invoke(() => label3.Text = "پردازش تکمیل شد");
                label4.Invoke(() => label4.Visible = true);

                // نمایش HTML در WebView2
                _webView.Invoke(() => _webView.NavigateToString(generatedText));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در پردازش: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new helpfrm();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new about();
            frm.ShowDialog();
        }
    }

    public static class ControlExtensions
    {
        public static void Invoke(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
}
