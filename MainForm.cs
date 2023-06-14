using System.Text;
using System.Text.Json;

namespace CovertReader
{
    public partial class MainForm : Form
    {
        private string textContent = string.Empty;
        private int currentShowLength = 0;
        private UserSettings settings = new UserSettings();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //将label的parent设置为容器，否则无法触发按键事件
            lb_text.Parent = this;
            //计算当前显示长度
            currentShowLength = CalcLabelContentLength();

            //获取用户数据，不存在则创建文件
            if (!File.Exists("./userDatas.vdf"))
            {
                File.Create("./userDatas.vdf");
            }
            else
            {
                #region 读取用户数据并渲染
                //根据用户历史设置窗体，若设置异常则重置为初始状态并重启
                try
                {
                    using (StreamReader settingFile = new StreamReader("./userDatas.vdf"))
                    {
                        var settingLine = settingFile.ReadToEnd();
                        if (string.IsNullOrEmpty(settingLine))
                        {
                            return;
                        }
                        settings = JsonSerializer.Deserialize<UserSettings>(settingLine) ?? new UserSettings();
                    }

                    //背景色
                    BackColor = ColorTranslator.FromHtml(settings.BackgroundColor);
                    //字体颜色
                    lb_text.ForeColor = ColorTranslator.FromHtml(settings.FontColor);
                    //不透明度
                    if (settings.Opacity > 100)
                    {
                        tb_opacity.Text = "100";
                        settings.Opacity = 100;
                        this.Opacity = 1;
                    }
                    else if (settings.Opacity < 10)
                    {
                        tb_opacity.Text = "10";
                        settings.Opacity = 10;
                        this.Opacity = 0.1;
                    }
                    else
                    {
                        this.Opacity = settings.Opacity / 100.00;
                    }
                    //窗体宽度
                    Width = settings.UserWidth;
                    lb_text.Width = Width;
                    //窗体高度
                    Height = settings.UserHeight;
                    lb_text.Height = Height;
                    //窗体位置
                    Top = settings.TopLocation;
                    Left = settings.LeftLocation;
                    //最前端显示
                    rcm_keepTop.Checked = !rcm_keepTop.Checked;
                    settings.TopMostFlag = rcm_keepTop.Checked;
                    TopMost = settings.TopMostFlag;
                    //固定位置
                    rcm_fixPosition.Checked = settings.FixedFlag;
                    ControlBox = !settings.FixedFlag;
                    FormBorderStyle = rcm_fixPosition.Checked ? FormBorderStyle.None : FormBorderStyle.Sizable;
                    //字体
                    lb_text.Font = new Font(settings.FontName, settings.FontSize);
                    //快捷键
                    tb_nextPage.Text = Keys.GetName((Keys)settings.NextPageKey);
                    tb_lastPage.Text = Keys.GetName((Keys)settings.LastPageKey);
                    tb_hideForm.Text = Keys.GetName((Keys)settings.HideFormKey);
                }
                catch
                {
                    settings.BackgroundColor = "#38393c";
                    settings.FontColor = "#ffffff";
                    settings.Opacity = 100;
                    settings.UserWidth = 300;
                    settings.UserHeight = 24;
                    settings.TopLocation = 0;
                    settings.LeftLocation = 0;
                    settings.TopMostFlag = false;
                    settings.FixedFlag = false;
                    settings.FontName = "Microsoft YaHei UI";
                    settings.FontSize = 9;
                    settings.LastPageKey = (char)Keys.Q;
                    settings.NextPageKey = (char)Keys.W;
                    settings.HideFormKey = (char)Keys.Oemtilde;
                    MessageBox.Show("根据用户配置渲染窗口异常！请重新启动程序");
                    if (!File.Exists("./userDatas.vdf"))
                    {
                        File.Delete("./userDatas.vdf");
                    }
                    Application.Exit();
                }

                //读取阅读历史
                if (File.Exists(settings.FilePath))
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    var encode = Encoding.GetEncoding("gb2312");
                    textContent = File.ReadAllText(settings.FilePath, encode).Replace("\r\n", "\t");

                    //若成功读取文件，则定位到上次阅读的位置
                    if (settings.ReadPosition < 0)
                    {
                        settings.ReadPosition = 0;
                    }
                    else if (settings.ReadPosition > textContent.Length || (settings.ReadPosition + currentShowLength) > textContent.Length)
                    {
                        settings.ReadPosition = textContent.Length - currentShowLength;
                    }
                    lb_text.Text = textContent.Substring(settings.ReadPosition, currentShowLength);
                }
                #endregion

            }
        }

        //双击任务栏图标打开
        private void ni_logo_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.TopMost = false;
        }

        //固定窗口
        private void rcm_fixPosition_Click(object sender, EventArgs e)
        {
            rcm_fixPosition.Checked = !rcm_fixPosition.Checked;
            settings.FixedFlag = rcm_fixPosition.Checked;
            ControlBox = !settings.FixedFlag;
            FormBorderStyle = rcm_fixPosition.Checked ? FormBorderStyle.None : FormBorderStyle.Sizable;
        }

        //保持最前
        private void rcm_keepTop_Click(object sender, EventArgs e)
        {
            rcm_keepTop.Checked = !rcm_keepTop.Checked;
            settings.TopMostFlag = rcm_keepTop.Checked;
            TopMost = settings.TopMostFlag;
        }

        //退出
        private void rcm_exit_Click(object sender, EventArgs e)
        {
            var confirmRst = MessageBox.Show("真的要退出吗？", "不再工作一会了吗？", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmRst == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //打开文件
        private void rcm_opeFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "文本文件 (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                //编码
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var encode = Encoding.GetEncoding("gb2312");

                //读取
                textContent = File.ReadAllText(fileName, encode).Replace("\r\n", "\t");
                settings.ReadPosition = 0;
                currentShowLength = CalcLabelContentLength();
                //显示
                lb_text.Text = textContent.Substring(settings.ReadPosition, currentShowLength);
                //成功打开后，记录路径
                settings.FilePath = fileName;
            }
        }

        //调整尺寸
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                lb_text.Width = Width;
                lb_text.Height = Height;
                currentShowLength = CalcLabelContentLength();
                settings.UserWidth = Width;
                settings.UserHeight = Height;

                if (!string.IsNullOrEmpty(textContent))
                {
                    lb_text.Text = textContent.Substring(settings.ReadPosition, currentShowLength);
                }
            }
        }

        //不透明度调整确认事件
        private void tb_opacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按下回车触发
            if (e.KeyChar == (char)Keys.Enter)
            {
                //记录原不透明度
                int opacity = (int)Opacity;
                //尝试将输入内容转换为数值
                int newOpacity = 100;
                if (Int32.TryParse(tb_opacity.Text.Trim(), out newOpacity))
                {
                    //超过100的变100
                    if (newOpacity > 100)
                    {
                        tb_opacity.Text = "100";
                        settings.Opacity = 100;
                        this.Opacity = 1;
                    }
                    //不足10的变10
                    else if (newOpacity < 10)
                    {
                        tb_opacity.Text = "10";
                        settings.Opacity = 10;
                        this.Opacity = 0.1;
                    }
                    else
                    {
                        settings.Opacity = newOpacity;
                        this.Opacity = newOpacity / 100.00;
                    }
                }
                else
                {
                    tb_opacity.Text = (opacity * 100).ToString();
                    settings.Opacity = opacity * 100;
                }
            }
        }


        //根据宽度计算可显示的字符数
        private int CalcLabelContentLength()
        {
            Font font = lb_text.Font;
            Size size = lb_text.ClientSize;

            //可填充内容的长度为文本的宽度(1px=0.75pt)
            return (int)Math.Floor(size.Width / (font.Size / 0.75)) - 1;
        }

        //按钮按下事件
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((char)e.KeyCode == settings.HideFormKey)
            {
                this.Hide();
                return;
            }
            if (!string.IsNullOrEmpty(textContent))
            {
                //下一页
                if ((new char[] { (char)Keys.Right, (char)Keys.Down, (char)Keys.PageDown, settings.NextPageKey }).Contains((char)e.KeyCode))
                {
                    settings.ReadPosition += currentShowLength;
                    if (settings.ReadPosition > textContent.Length || (settings.ReadPosition + currentShowLength) > textContent.Length)
                    {
                        settings.ReadPosition = textContent.Length - currentShowLength;
                    }
                    lb_text.Text = textContent.Substring(settings.ReadPosition, currentShowLength);
                    return;
                }
                //上一页
                if ((new char[] { (char)Keys.Left, (char)Keys.Up, (char)Keys.PageUp, settings.LastPageKey }).Contains((char)e.KeyCode))
                {
                    settings.ReadPosition -= currentShowLength;
                    if (settings.ReadPosition < 0)
                    {
                        settings.ReadPosition = 0;
                    }
                    lb_text.Text = textContent.Substring(settings.ReadPosition, currentShowLength);
                    return;
                }
            }
        }

        private async void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //窗体关闭时写配置
            using (StreamWriter settingFile = new StreamWriter("./userDatas.vdf"))
            {
                await settingFile.WriteLineAsync(JsonSerializer.Serialize(settings));
            }
        }

        //窗体移动时记录位置
        private void MainForm_Move(object sender, EventArgs e)
        {
            settings.TopLocation = Top;
            settings.LeftLocation = Left;
        }

        //背景颜色设置
        private void rcm_backColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                BackColor = colorDialog.Color;
                settings.BackgroundColor = "#" + colorDialog.Color.R.ToString("X2") + colorDialog.Color.G.ToString("X2") + colorDialog.Color.B.ToString("X2");
            }
        }

        //文字颜色设置
        private void rcm_fontColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lb_text.ForeColor = colorDialog.Color;
                settings.FontColor = "#" + colorDialog.Color.R.ToString("X2") + colorDialog.Color.G.ToString("X2") + colorDialog.Color.B.ToString("X2");
            }
        }

        //样式重置
        private void rcm_resetStyle_Click(object sender, EventArgs e)
        {
            settings.BackgroundColor = "#38393c";
            settings.FontColor = "#ffffff";
            settings.Opacity = 100;
            BackColor = ColorTranslator.FromHtml(settings.BackgroundColor);
            lb_text.ForeColor = ColorTranslator.FromHtml(settings.FontColor);
            Opacity = 1;
            settings.FontName = "Microsoft YaHei UI";
            settings.FontSize = 9;
            lb_text.Font = new Font(settings.FontName, settings.FontSize);
            //修改字体后重新计算可显示字数
            currentShowLength = CalcLabelContentLength();
            lb_text.Text = textContent.Substring(settings.ReadPosition, currentShowLength);
        }

        private void rcm_aboutVerSion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("当前程序版本：v1.0\r\n作者：VerSion\r\n项目地址：https://github.com/VerSion1312/StrokeFishReader\r\n点击确定按钮可以打赏作者哦！",
                "你来啦！", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://www.version-carol.cn/wx-reward/",
                    UseShellExecute = true
                });
            }
        }

        //字体设置
        private void rcm_fontSet_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                // 获取用户选择的字体
                Font selectedFont = fontDialog.Font;
                // 设置字体
                lb_text.Font = selectedFont;
                settings.FontName = selectedFont.Name;
                settings.FontSize = selectedFont.Size;
                //修改字体后重新计算可显示字数
                currentShowLength = CalcLabelContentLength();
                lb_text.Text = textContent.Substring(settings.ReadPosition, currentShowLength);
            }

        }

        //绑定快捷键
        private void tb_nextPage_KeyDown(object sender, KeyEventArgs e)
        {
            tb_nextPage.Text = e.KeyCode.ToString();
            settings.NextPageKey = (char)e.KeyCode;
            //阻止输入
            e.SuppressKeyPress = true;
        }

        private void tb_lastPage_KeyDown(object sender, KeyEventArgs e)
        {
            tb_lastPage.Text = e.KeyCode.ToString();
            settings.LastPageKey = (char)e.KeyCode;
            //阻止输入
            e.SuppressKeyPress = true;
        }

        private void tb_hideForm_KeyDown(object sender, KeyEventArgs e)
        {
            tb_hideForm.Text = e.KeyCode.ToString();
            settings.HideFormKey = (char)e.KeyCode;
            //阻止输入
            e.SuppressKeyPress = true;
        }
    }

    public class UserSettings
    {
        public string FilePath { get; set; } = string.Empty;
        public int ReadPosition { get; set; } = 0;
        public string BackgroundColor { get; set; } = "#38393c";
        public string FontColor { get; set; } = "#ffffff";
        public int Opacity { get; set; } = 100;
        public int UserWidth { get; set; } = 300;
        public int UserHeight { get; set; } = 24;
        public int TopLocation { get; set; } = 0;
        public int LeftLocation { get; set; } = 0;
        public bool TopMostFlag { get; set; } = false;
        public bool FixedFlag { get; set; } = false;
        public string FontName { get; set; } = "Microsoft YaHei UI";
        public float FontSize { get; set; } = 9;
        public char LastPageKey { get; set; } = (char)Keys.Q;
        public char NextPageKey { get; set; } = (char)Keys.W;
        public char HideFormKey { get; set; } = (char)Keys.Oemtilde;
    }
}