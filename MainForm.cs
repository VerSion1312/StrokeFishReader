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
            //��label��parent����Ϊ�����������޷����������¼�
            lb_text.Parent = this;
            //���㵱ǰ��ʾ����
            currentShowLength = CalcLabelContentLength();

            //��ȡ�û����ݣ��������򴴽��ļ�
            if (!File.Exists("./userDatas.vdf"))
            {
                File.Create("./userDatas.vdf");
            }
            else
            {
                #region ��ȡ�û����ݲ���Ⱦ
                //�����û���ʷ���ô��壬�������쳣������Ϊ��ʼ״̬������
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

                    //����ɫ
                    BackColor = ColorTranslator.FromHtml(settings.BackgroundColor);
                    //������ɫ
                    lb_text.ForeColor = ColorTranslator.FromHtml(settings.FontColor);
                    //��͸����
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
                    //������
                    Width = settings.UserWidth;
                    lb_text.Width = Width;
                    //����߶�
                    Height = settings.UserHeight;
                    lb_text.Height = Height;
                    //����λ��
                    Top = settings.TopLocation;
                    Left = settings.LeftLocation;
                    //��ǰ����ʾ
                    rcm_keepTop.Checked = !rcm_keepTop.Checked;
                    settings.TopMostFlag = rcm_keepTop.Checked;
                    TopMost = settings.TopMostFlag;
                    //�̶�λ��
                    rcm_fixPosition.Checked = settings.FixedFlag;
                    ControlBox = !settings.FixedFlag;
                    FormBorderStyle = rcm_fixPosition.Checked ? FormBorderStyle.None : FormBorderStyle.Sizable;
                    //����
                    lb_text.Font = new Font(settings.FontName, settings.FontSize);
                    //��ݼ�
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
                    MessageBox.Show("�����û�������Ⱦ�����쳣����������������");
                    if (!File.Exists("./userDatas.vdf"))
                    {
                        File.Delete("./userDatas.vdf");
                    }
                    Application.Exit();
                }

                //��ȡ�Ķ���ʷ
                if (File.Exists(settings.FilePath))
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    var encode = Encoding.GetEncoding("gb2312");
                    textContent = File.ReadAllText(settings.FilePath, encode).Replace("\r\n", "\t");

                    //���ɹ���ȡ�ļ�����λ���ϴ��Ķ���λ��
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

        //˫��������ͼ���
        private void ni_logo_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.TopMost = false;
        }

        //�̶�����
        private void rcm_fixPosition_Click(object sender, EventArgs e)
        {
            rcm_fixPosition.Checked = !rcm_fixPosition.Checked;
            settings.FixedFlag = rcm_fixPosition.Checked;
            ControlBox = !settings.FixedFlag;
            FormBorderStyle = rcm_fixPosition.Checked ? FormBorderStyle.None : FormBorderStyle.Sizable;
        }

        //������ǰ
        private void rcm_keepTop_Click(object sender, EventArgs e)
        {
            rcm_keepTop.Checked = !rcm_keepTop.Checked;
            settings.TopMostFlag = rcm_keepTop.Checked;
            TopMost = settings.TopMostFlag;
        }

        //�˳�
        private void rcm_exit_Click(object sender, EventArgs e)
        {
            var confirmRst = MessageBox.Show("���Ҫ�˳���", "���ٹ���һ������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmRst == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //���ļ�
        private void rcm_opeFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "�ı��ļ� (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                //����
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var encode = Encoding.GetEncoding("gb2312");

                //��ȡ
                textContent = File.ReadAllText(fileName, encode).Replace("\r\n", "\t");
                settings.ReadPosition = 0;
                currentShowLength = CalcLabelContentLength();
                //��ʾ
                lb_text.Text = textContent.Substring(settings.ReadPosition, currentShowLength);
                //�ɹ��򿪺󣬼�¼·��
                settings.FilePath = fileName;
            }
        }

        //�����ߴ�
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

        //��͸���ȵ���ȷ���¼�
        private void tb_opacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //���»س�����
            if (e.KeyChar == (char)Keys.Enter)
            {
                //��¼ԭ��͸����
                int opacity = (int)Opacity;
                //���Խ���������ת��Ϊ��ֵ
                int newOpacity = 100;
                if (Int32.TryParse(tb_opacity.Text.Trim(), out newOpacity))
                {
                    //����100�ı�100
                    if (newOpacity > 100)
                    {
                        tb_opacity.Text = "100";
                        settings.Opacity = 100;
                        this.Opacity = 1;
                    }
                    //����10�ı�10
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


        //���ݿ�ȼ������ʾ���ַ���
        private int CalcLabelContentLength()
        {
            Font font = lb_text.Font;
            Size size = lb_text.ClientSize;

            //��������ݵĳ���Ϊ�ı��Ŀ��(1px=0.75pt)
            return (int)Math.Floor(size.Width / (font.Size / 0.75)) - 1;
        }

        //��ť�����¼�
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((char)e.KeyCode == settings.HideFormKey)
            {
                this.Hide();
                return;
            }
            if (!string.IsNullOrEmpty(textContent))
            {
                //��һҳ
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
                //��һҳ
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
            //����ر�ʱд����
            using (StreamWriter settingFile = new StreamWriter("./userDatas.vdf"))
            {
                await settingFile.WriteLineAsync(JsonSerializer.Serialize(settings));
            }
        }

        //�����ƶ�ʱ��¼λ��
        private void MainForm_Move(object sender, EventArgs e)
        {
            settings.TopLocation = Top;
            settings.LeftLocation = Left;
        }

        //������ɫ����
        private void rcm_backColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                BackColor = colorDialog.Color;
                settings.BackgroundColor = "#" + colorDialog.Color.R.ToString("X2") + colorDialog.Color.G.ToString("X2") + colorDialog.Color.B.ToString("X2");
            }
        }

        //������ɫ����
        private void rcm_fontColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lb_text.ForeColor = colorDialog.Color;
                settings.FontColor = "#" + colorDialog.Color.R.ToString("X2") + colorDialog.Color.G.ToString("X2") + colorDialog.Color.B.ToString("X2");
            }
        }

        //��ʽ����
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
            //�޸���������¼������ʾ����
            currentShowLength = CalcLabelContentLength();
            lb_text.Text = textContent.Substring(settings.ReadPosition, currentShowLength);
        }

        private void rcm_aboutVerSion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("��ǰ����汾��v1.0\r\n���ߣ�VerSion\r\n��Ŀ��ַ��https://github.com/VerSion1312/StrokeFishReader\r\n���ȷ����ť���Դ�������Ŷ��",
                "��������", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://www.version-carol.cn/wx-reward/",
                    UseShellExecute = true
                });
            }
        }

        //��������
        private void rcm_fontSet_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                // ��ȡ�û�ѡ�������
                Font selectedFont = fontDialog.Font;
                // ��������
                lb_text.Font = selectedFont;
                settings.FontName = selectedFont.Name;
                settings.FontSize = selectedFont.Size;
                //�޸���������¼������ʾ����
                currentShowLength = CalcLabelContentLength();
                lb_text.Text = textContent.Substring(settings.ReadPosition, currentShowLength);
            }

        }

        //�󶨿�ݼ�
        private void tb_nextPage_KeyDown(object sender, KeyEventArgs e)
        {
            tb_nextPage.Text = e.KeyCode.ToString();
            settings.NextPageKey = (char)e.KeyCode;
            //��ֹ����
            e.SuppressKeyPress = true;
        }

        private void tb_lastPage_KeyDown(object sender, KeyEventArgs e)
        {
            tb_lastPage.Text = e.KeyCode.ToString();
            settings.LastPageKey = (char)e.KeyCode;
            //��ֹ����
            e.SuppressKeyPress = true;
        }

        private void tb_hideForm_KeyDown(object sender, KeyEventArgs e)
        {
            tb_hideForm.Text = e.KeyCode.ToString();
            settings.HideFormKey = (char)e.KeyCode;
            //��ֹ����
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