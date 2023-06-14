namespace CovertReader
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rcm_fixPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.rcm_keepTop = new System.Windows.Forms.ToolStripMenuItem();
            this.样式设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rcm_backColor = new System.Windows.Forms.ToolStripMenuItem();
            this.rcm_fontColor = new System.Windows.Forms.ToolStripMenuItem();
            this.rcm_opacity = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_opacity = new System.Windows.Forms.ToolStripTextBox();
            this.rcm_fontSet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.rcm_resetStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.快捷键设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下一页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_nextPage = new System.Windows.Forms.ToolStripTextBox();
            this.上一页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_lastPage = new System.Windows.Forms.ToolStripTextBox();
            this.隐藏界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_hideForm = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.rcm_opeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rcm_aboutVerSion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.rcm_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ni_logo = new System.Windows.Forms.NotifyIcon(this.components);
            this.lb_text = new System.Windows.Forms.Label();
            this.rightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rcm_fixPosition,
            this.rcm_keepTop,
            this.样式设置ToolStripMenuItem,
            this.快捷键设置ToolStripMenuItem,
            this.toolStripSeparator2,
            this.rcm_opeFile,
            this.toolStripSeparator1,
            this.rcm_aboutVerSion,
            this.toolStripSeparator3,
            this.rcm_exit});
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.Size = new System.Drawing.Size(181, 198);
            // 
            // rcm_fixPosition
            // 
            this.rcm_fixPosition.Name = "rcm_fixPosition";
            this.rcm_fixPosition.Size = new System.Drawing.Size(180, 22);
            this.rcm_fixPosition.Text = "锁定窗口";
            this.rcm_fixPosition.Click += new System.EventHandler(this.rcm_fixPosition_Click);
            // 
            // rcm_keepTop
            // 
            this.rcm_keepTop.Name = "rcm_keepTop";
            this.rcm_keepTop.Size = new System.Drawing.Size(180, 22);
            this.rcm_keepTop.Text = "置顶窗口";
            this.rcm_keepTop.Click += new System.EventHandler(this.rcm_keepTop_Click);
            // 
            // 样式设置ToolStripMenuItem
            // 
            this.样式设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rcm_backColor,
            this.rcm_fontColor,
            this.rcm_opacity,
            this.rcm_fontSet,
            this.toolStripSeparator4,
            this.rcm_resetStyle});
            this.样式设置ToolStripMenuItem.Name = "样式设置ToolStripMenuItem";
            this.样式设置ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.样式设置ToolStripMenuItem.Text = "样式设置";
            // 
            // rcm_backColor
            // 
            this.rcm_backColor.Name = "rcm_backColor";
            this.rcm_backColor.Size = new System.Drawing.Size(148, 22);
            this.rcm_backColor.Text = "背景颜色";
            this.rcm_backColor.Click += new System.EventHandler(this.rcm_backColor_Click);
            // 
            // rcm_fontColor
            // 
            this.rcm_fontColor.Name = "rcm_fontColor";
            this.rcm_fontColor.Size = new System.Drawing.Size(148, 22);
            this.rcm_fontColor.Text = "字体颜色";
            this.rcm_fontColor.Click += new System.EventHandler(this.rcm_fontColor_Click);
            // 
            // rcm_opacity
            // 
            this.rcm_opacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tb_opacity});
            this.rcm_opacity.Name = "rcm_opacity";
            this.rcm_opacity.Size = new System.Drawing.Size(148, 22);
            this.rcm_opacity.Text = "不透明度";
            // 
            // tb_opacity
            // 
            this.tb_opacity.AutoToolTip = true;
            this.tb_opacity.MaxLength = 3;
            this.tb_opacity.Name = "tb_opacity";
            this.tb_opacity.Size = new System.Drawing.Size(100, 23);
            this.tb_opacity.Text = "100";
            this.tb_opacity.ToolTipText = "取值范围10~100(回车键确认)";
            // 
            // rcm_fontSet
            // 
            this.rcm_fontSet.Name = "rcm_fontSet";
            this.rcm_fontSet.Size = new System.Drawing.Size(148, 22);
            this.rcm_fontSet.Text = "字体设置";
            this.rcm_fontSet.Click += new System.EventHandler(this.rcm_fontSet_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // rcm_resetStyle
            // 
            this.rcm_resetStyle.Name = "rcm_resetStyle";
            this.rcm_resetStyle.Size = new System.Drawing.Size(148, 22);
            this.rcm_resetStyle.Text = "恢复初始样式";
            this.rcm_resetStyle.Click += new System.EventHandler(this.rcm_resetStyle_Click);
            // 
            // 快捷键设置ToolStripMenuItem
            // 
            this.快捷键设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下一页ToolStripMenuItem,
            this.上一页ToolStripMenuItem,
            this.隐藏界面ToolStripMenuItem});
            this.快捷键设置ToolStripMenuItem.Name = "快捷键设置ToolStripMenuItem";
            this.快捷键设置ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.快捷键设置ToolStripMenuItem.Text = "快捷键设置";
            // 
            // 下一页ToolStripMenuItem
            // 
            this.下一页ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tb_nextPage});
            this.下一页ToolStripMenuItem.Name = "下一页ToolStripMenuItem";
            this.下一页ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.下一页ToolStripMenuItem.Text = "下一页";
            // 
            // tb_nextPage
            // 
            this.tb_nextPage.AutoToolTip = true;
            this.tb_nextPage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_nextPage.Name = "tb_nextPage";
            this.tb_nextPage.Size = new System.Drawing.Size(100, 23);
            this.tb_nextPage.Text = "W";
            this.tb_nextPage.ToolTipText = "按下需要绑定的按键";
            this.tb_nextPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_nextPage_KeyDown);
            // 
            // 上一页ToolStripMenuItem
            // 
            this.上一页ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tb_lastPage});
            this.上一页ToolStripMenuItem.Name = "上一页ToolStripMenuItem";
            this.上一页ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.上一页ToolStripMenuItem.Text = "上一页";
            // 
            // tb_lastPage
            // 
            this.tb_lastPage.Name = "tb_lastPage";
            this.tb_lastPage.Size = new System.Drawing.Size(100, 23);
            this.tb_lastPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_lastPage_KeyDown);
            // 
            // 隐藏界面ToolStripMenuItem
            // 
            this.隐藏界面ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tb_hideForm});
            this.隐藏界面ToolStripMenuItem.Name = "隐藏界面ToolStripMenuItem";
            this.隐藏界面ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.隐藏界面ToolStripMenuItem.Text = "隐藏界面";
            // 
            // tb_hideForm
            // 
            this.tb_hideForm.Name = "tb_hideForm";
            this.tb_hideForm.Size = new System.Drawing.Size(100, 23);
            this.tb_hideForm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_hideForm_KeyDown);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // rcm_opeFile
            // 
            this.rcm_opeFile.Name = "rcm_opeFile";
            this.rcm_opeFile.Size = new System.Drawing.Size(180, 22);
            this.rcm_opeFile.Text = "打开文件";
            this.rcm_opeFile.Click += new System.EventHandler(this.rcm_opeFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // rcm_aboutVerSion
            // 
            this.rcm_aboutVerSion.Name = "rcm_aboutVerSion";
            this.rcm_aboutVerSion.Size = new System.Drawing.Size(180, 22);
            this.rcm_aboutVerSion.Text = "关于作者";
            this.rcm_aboutVerSion.Click += new System.EventHandler(this.rcm_aboutVerSion_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // rcm_exit
            // 
            this.rcm_exit.Name = "rcm_exit";
            this.rcm_exit.Size = new System.Drawing.Size(180, 22);
            this.rcm_exit.Text = "完全退出";
            this.rcm_exit.Click += new System.EventHandler(this.rcm_exit_Click);
            // 
            // ni_logo
            // 
            this.ni_logo.ContextMenuStrip = this.rightClickMenu;
            this.ni_logo.Icon = ((System.Drawing.Icon)(resources.GetObject("ni_logo.Icon")));
            this.ni_logo.Text = "工作效率提升插件";
            this.ni_logo.Visible = true;
            this.ni_logo.Click += new System.EventHandler(this.ni_logo_DoubleClick);
            this.ni_logo.DoubleClick += new System.EventHandler(this.ni_logo_DoubleClick);
            // 
            // lb_text
            // 
            this.lb_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lb_text.Location = new System.Drawing.Point(0, 0);
            this.lb_text.Name = "lb_text";
            this.lb_text.Size = new System.Drawing.Size(279, 24);
            this.lb_text.TabIndex = 0;
            this.lb_text.Text = "还未选择文件~";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(57)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(279, 24);
            this.ContextMenuStrip = this.rightClickMenu;
            this.Controls.Add(this.lb_text);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.rightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenuStrip rightClickMenu;
        private ToolStripMenuItem rcm_fixPosition;
        private NotifyIcon ni_logo;
        private ToolStripMenuItem rcm_keepTop;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem rcm_exit;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem rcm_opeFile;
        private Label lb_text;
        private ToolStripMenuItem 样式设置ToolStripMenuItem;
        private ToolStripMenuItem rcm_backColor;
        private ToolStripMenuItem rcm_fontColor;
        private ToolStripMenuItem rcm_opacity;
        private ToolStripTextBox tb_opacity;
        private ToolStripMenuItem rcm_aboutVerSion;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem rcm_resetStyle;
        private ToolStripMenuItem rcm_fontSet;
        private ToolStripMenuItem 快捷键设置ToolStripMenuItem;
        private ToolStripMenuItem 下一页ToolStripMenuItem;
        private ToolStripTextBox tb_nextPage;
        private ToolStripMenuItem 上一页ToolStripMenuItem;
        private ToolStripTextBox tb_lastPage;
        private ToolStripMenuItem 隐藏界面ToolStripMenuItem;
        private ToolStripTextBox tb_hideForm;
    }
}