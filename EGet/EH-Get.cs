using Ivony.Html;
using Ivony.Html.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGet
{
    public partial class EH_Get : Form
    {
        public EH_Get()
        {
            InitializeComponent();
            //取消跨线程检查(重要)
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 存放本子的路径
        /// </summary>
        public string SaveFolder { get; set; }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            //root url https://e-hentai.org 
            this.lblTip.Text = string.Empty;
            string targetUrl = this.txtTargetUrl.Text; //本子根目录
            string targetText = this.txtTargetUrl.Text;//获取本子的标题
            string savePath = this.txtSaveDest.Text;
            if (string.IsNullOrEmpty(savePath)) {
                MessageBox.Show("请先选择本子的存放目录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(targetUrl)) {
                MessageBox.Show("请先选择下载地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                btnDownload.Text = "正在下载";
                btnDownload.Enabled = false;

                var targetObj = new JumonyParser().LoadDocument(targetUrl).Find("#gj");
                if (targetObj != null && targetObj.FirstOrDefault() != null)
                {
                    targetText = targetObj.FirstOrDefault().InnerText();
                }
                RunAsync(() =>
                {
                    GetAllLinkPage(targetUrl, targetText);
                });
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生了我也不想的错误.....:"+ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 获取目标页面要抓取的详细图片地址
        /// </summary>
        /// <param name="targetUrl">本子的目录地址</param>
        /// <param name="targetText">本子名称</param>
        public void GetAllLinkPage(string targetUrl,string targetText)
        {
            int countNum = 0;//页面计数
            List<string> urlToDownLoad = new List<string>();//抓取的地址集合
            urlToDownLoad.Add(targetUrl);
            Dictionary<string, string> dicUrls = new Dictionary<string, string>();
            var target = new JumonyParser().LoadDocument(targetUrl).Find(".gdtm a");
            foreach (var eachUrl in target)
            {
                countNum++;
                if (eachUrl == null || eachUrl.Attribute("href") == null) continue;
                dicUrls.Add(countNum.ToString(), eachUrl.Attribute("href").AttributeValue.ToString());
            }
            //可能有多页
            var pager = new JumonyParser().LoadDocument(targetUrl).Find(".gtb a");
            foreach (var p in pager)
            {
                if (p == null || p.Attribute("href") == null) continue;
                if (p.Attribute("href").AttributeValue.ToString().ToLower().IndexOf("p=") < 0) continue;//说明只有一页
                string newPage = p.Attribute("href").AttributeValue.ToString();
                if (urlToDownLoad.Contains(newPage)) { continue; }
                urlToDownLoad.Add(newPage);
                var nextTarget = new JumonyParser().LoadDocument(newPage).Find(".gdtm a");
                foreach (var eachUrl in nextTarget)
                {
                    countNum++;
                    if (eachUrl == null || eachUrl.Attribute("href") == null) continue;
                    dicUrls.Add(countNum.ToString(), eachUrl.Attribute("href").AttributeValue.ToString());
                }
            }
            DownLoadImg(dicUrls, targetText);
        }

        /// <summary>
        /// 开始下载本子
        /// </summary>
        /// <param name="dicUrls">下载目标</param>
        /// <param name="targetText">下载目录</param>
        public void DownLoadImg(Dictionary<string,string> dicUrls,string targetText) 
        {
            //制定本子的存放目录
            string path = Path.Combine(this.SaveFolder, targetText);
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            WebClient webClient = new WebClient();
            //设置请求头
            webClient.Headers["User-Agent"] = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
            //开始遍历下载
            if (dicUrls.Count > 0)
            {
                int indexPage=0;
                foreach (var eachPage in dicUrls)
                {
                    indexPage++;
                    lblTip.Text = string.Format("正在下载第{0}页，请耐心等待.....", indexPage);
                    try
                    {
                        var targetPage = new JumonyParser().LoadDocument(eachPage.Value).Find("#i3 img");
                        if (targetPage.FirstOrDefault() == null) continue;
                        string imgToDownload = targetPage.FirstOrDefault().Attribute("src").AttributeValue.ToString();
                        string destFileName = Path.Combine(path, eachPage.Key + ".jpg");
                        webClient.DownloadFile(imgToDownload, destFileName);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                btnDownload.Text = "点击下载";
                btnDownload.Enabled = true;
                lblTip.Text = string.Empty;
                MessageBox.Show("下载完成，快去看看吧hentai","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //下载完成，提示
                System.Diagnostics.Process.Start("Explorer.exe", path);
            }
        }

        /// <summary>
        /// 选择存放的文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brnSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.SaveFolder = path.SelectedPath;
            this.txtSaveDest.Text = path.SelectedPath;
        }

        // 异步线程，防止UI假死
        public static void RunAsync(Action action)
        {
            ((Action)(delegate ()
            {
                action.Invoke();
            })).BeginInvoke(null, null);
        }

        public void RunInMainthread(Action action)
        {
            this.BeginInvoke((Action)(delegate ()
            {
                action.Invoke();
            }));
        }
        
    }
}
