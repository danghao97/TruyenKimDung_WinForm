namespace BTLDotNet.View
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.view1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.view2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.view3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liststory = new System.Windows.Forms.ListBox();
            this.listchap = new System.Windows.Forms.ListBox();
            this.contentchap = new System.Windows.Forms.RichTextBox();
            this.lbStoryName = new System.Windows.Forms.Label();
            this.lbChapName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1054, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.view1ToolStripMenuItem,
            this.view2ToolStripMenuItem,
            this.view3ToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // view1ToolStripMenuItem
            // 
            this.view1ToolStripMenuItem.Name = "view1ToolStripMenuItem";
            this.view1ToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.view1ToolStripMenuItem.Text = "View1";
            // 
            // view2ToolStripMenuItem
            // 
            this.view2ToolStripMenuItem.Name = "view2ToolStripMenuItem";
            this.view2ToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.view2ToolStripMenuItem.Text = "View2";
            // 
            // view3ToolStripMenuItem
            // 
            this.view3ToolStripMenuItem.Name = "view3ToolStripMenuItem";
            this.view3ToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.view3ToolStripMenuItem.Text = "View 3";
            // 
            // liststory
            // 
            this.liststory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liststory.FormattingEnabled = true;
            this.liststory.HorizontalScrollbar = true;
            this.liststory.ItemHeight = 29;
            this.liststory.Items.AddRange(new object[] {
            "liststory"});
            this.liststory.Location = new System.Drawing.Point(12, 100);
            this.liststory.Name = "liststory";
            this.liststory.Size = new System.Drawing.Size(189, 526);
            this.liststory.TabIndex = 1;
            this.liststory.SelectedValueChanged += new System.EventHandler(this.liststory_SelectedValueChanged);
            // 
            // listchap
            // 
            this.listchap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listchap.FormattingEnabled = true;
            this.listchap.ItemHeight = 29;
            this.listchap.Location = new System.Drawing.Point(833, 114);
            this.listchap.Name = "listchap";
            this.listchap.Size = new System.Drawing.Size(181, 526);
            this.listchap.TabIndex = 2;
            this.listchap.SelectedIndexChanged += new System.EventHandler(this.listchap_SelectedIndexChanged);
            // 
            // contentchap
            // 
            this.contentchap.BackColor = System.Drawing.Color.White;
            this.contentchap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contentchap.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentchap.Location = new System.Drawing.Point(223, 122);
            this.contentchap.Name = "contentchap";
            this.contentchap.ReadOnly = true;
            this.contentchap.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.contentchap.Size = new System.Drawing.Size(572, 452);
            this.contentchap.TabIndex = 3;
            this.contentchap.Text = "";
            this.contentchap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.contentchap_MouseDown);
            this.contentchap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.contentchap_MouseMove);
            // 
            // lbStoryName
            // 
            this.lbStoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStoryName.ForeColor = System.Drawing.Color.White;
            this.lbStoryName.Location = new System.Drawing.Point(363, 28);
            this.lbStoryName.Name = "lbStoryName";
            this.lbStoryName.Size = new System.Drawing.Size(268, 41);
            this.lbStoryName.TabIndex = 4;
            this.lbStoryName.Text = "Tên truyện";
            this.lbStoryName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbChapName
            // 
            this.lbChapName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChapName.ForeColor = System.Drawing.Color.White;
            this.lbChapName.Location = new System.Drawing.Point(217, 69);
            this.lbChapName.Name = "lbChapName";
            this.lbChapName.Size = new System.Drawing.Size(252, 31);
            this.lbChapName.TabIndex = 5;
            this.lbChapName.Text = "Tên Hồi";
            this.lbChapName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(874, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "Thêm dữ liệu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(674, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 7;
            this.button2.Text = "Tìm kiếm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(1054, 658);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lbChapName);
            this.Controls.Add(this.lbStoryName);
            this.Controls.Add(this.contentchap);
            this.Controls.Add(this.listchap);
            this.Controls.Add(this.liststory);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.Resize += new System.EventHandler(this.HomePage_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ListBox liststory;
        private System.Windows.Forms.ListBox listchap;
        private System.Windows.Forms.RichTextBox contentchap;
        private System.Windows.Forms.Label lbStoryName;
        private System.Windows.Forms.Label lbChapName;
        private System.Windows.Forms.ToolStripMenuItem view1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem view2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem view3ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button2;
    }
}