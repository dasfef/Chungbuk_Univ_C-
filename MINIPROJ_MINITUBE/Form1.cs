using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using CefSharp;
using CefSharp.WinForms;
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

namespace MINITUBE
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            string URL = "https://dasfef.github.io";
            ChromiumWebBrowser chrome = new ChromiumWebBrowser(URL);
            panel1.Controls.Add(chrome);
            //chrome.AddressChanged += Chrome_AddressChanged;                                       // 현주소 필요할시 요청

        }

        // ===== 현재 주소 필요할 때 활성화 =====
        private void Chrome_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                //textBox2.Text = e.Address;
                toolStripTextBox1.Text = e.Address;
            }));
        }

        // ===== 유튜브 검색 후 결과 리스트뷰 위치 =====
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDzBgk2gxfcAiOU2whxxOa62fPImBEDVVA",
                ApplicationName = "MiniTube"
            });

            var request = youtube.Search.List("snippet");
            request.Q = textBox1.Text;
            request.MaxResults = 25;

            var result = await request.ExecuteAsync();

            foreach (var item in result.Items)
            {
                if(item.Id.Kind == "youtube#video")
                {
                    listView1.Items.Add(item.Id.VideoId.ToString(), item.Snippet.Title, 0);
                }
            }
        }

        // ===== 리스트뷰 목록 더블클릭시 -> 바로 해당 유튜브 링크로 이동 =====
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                panel1.Controls.Clear();
                string videoId = listView1.SelectedItems[0].Name;
                string youtubeURL = "http://youtube.com/watch?v=" + videoId;

                ChromiumWebBrowser chrome = new ChromiumWebBrowser(youtubeURL);
                panel1.Controls.Add(chrome);
                //ChromiumWebBrowser youtubeUrl = new ChromiumWebBrowser(youtubeURL);
                
                
            }
        }

        // ===== GO 버튼 클릭 시 해당 링크의 주소로 이동 =====
        private void button1_Click(object sender, EventArgs e)
        {
            string text2 = textBox2.Text;
            panel1.Controls.Clear();
            
            ChromiumWebBrowser chrome = new ChromiumWebBrowser(text2);
            panel1.Controls.Add(chrome);
            //chrome.AddressChanged += Chrome_AddressChanged;                                       // 현주소 필요할시 요청
        }


        // ===== 주소창 엔터키 입력시 링크의 주소로 이동 =====
        private void toolStripTextBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            string url = toolStripTextBox1.Text;
            if (e.KeyCode == Keys.Enter)
            {
                panel1.Controls.Clear();

                ChromiumWebBrowser chrome = new ChromiumWebBrowser(url);
                panel1.Controls.Add(chrome);
                chrome.AddressChanged += Chrome_AddressChanged;                                     // 현주소 필요할시 요청
            }
        }

        // ===== 버튼1 에서 엔터 쳤을 때 =====
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            string text2 = textBox2.Text;
            

            if (e.KeyCode == Keys.Enter)
            {
                panel1.Controls.Clear();

                ChromiumWebBrowser chrome = new ChromiumWebBrowser(text2);
                panel1.Controls.Add(chrome);
            }
        }

        // ===== text2 에서 엔터 쳤을 때 =====
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            string text2 = textBox2.Text;


            if (e.KeyCode == Keys.Enter)
            {
                panel1.Controls.Clear();

                ChromiumWebBrowser chrome = new ChromiumWebBrowser(text2);
                panel1.Controls.Add(chrome);
            }
        }

        // ===== 유튜브 검색창에서 엔터키 입력시 =====
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    panel1.Controls.Clear();
                    string videoId = listView1.SelectedItems[0].Name;
                    string youtubeURL = "http://youtube.com/watch?v=" + videoId;

                    ChromiumWebBrowser chrome = new ChromiumWebBrowser(youtubeURL);
                    panel1.Controls.Add(chrome);
                    //ChromiumWebBrowser youtubeUrl = new ChromiumWebBrowser(youtubeURL);

                }
            }
        }
    }
}
