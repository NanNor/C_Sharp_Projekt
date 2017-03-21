namespace Lohnabrechnungssystem
    {
    partial class Hauptfenster
        {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hauptfenster));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Suchfunktion = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.Auflistung = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label15 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ausgabeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaultBoyVersteckenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.technischerSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Info = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button10 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.alleAbrechnungenAnzeigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.Suchfunktion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Auflistung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Suchfunktion);
            this.tabControl1.Controls.Add(this.Auflistung);
            this.tabControl1.Location = new System.Drawing.Point(9, 89);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(227, 202);
            this.tabControl1.TabIndex = 38;
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // Suchfunktion
            // 
            this.Suchfunktion.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Suchfunktion.Controls.Add(this.button7);
            this.Suchfunktion.Controls.Add(this.groupBox1);
            this.Suchfunktion.Controls.Add(this.button4);
            this.Suchfunktion.Controls.Add(this.label10);
            this.Suchfunktion.Controls.Add(this.SearchText);
            this.Suchfunktion.Location = new System.Drawing.Point(4, 22);
            this.Suchfunktion.Name = "Suchfunktion";
            this.Suchfunktion.Padding = new System.Windows.Forms.Padding(3);
            this.Suchfunktion.Size = new System.Drawing.Size(219, 176);
            this.Suchfunktion.TabIndex = 0;
            this.Suchfunktion.Text = "Suchfunktion";
            this.Suchfunktion.Click += new System.EventHandler(this.Suchfunktion_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Silver;
            this.button7.Location = new System.Drawing.Point(17, 138);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(163, 32);
            this.button7.TabIndex = 46;
            this.button7.Text = "Auswahl leeren";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(10, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 76);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ausgewählte Mitarbeiter";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.Color.Silver;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(187, 39);
            this.listBox1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.ForeColor = System.Drawing.Color.Silver;
            this.button4.Location = new System.Drawing.Point(139, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "Auswählen";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Silver;
            this.label10.Location = new System.Drawing.Point(6, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Suchfunktion";
            // 
            // SearchText
            // 
            this.SearchText.AutoCompleteCustomSource.AddRange(new string[] {
            "Yusuf Maxi"});
            this.SearchText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SearchText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchText.Location = new System.Drawing.Point(9, 29);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(124, 20);
            this.SearchText.TabIndex = 18;
            this.SearchText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SearchText_MouseClick);
            this.SearchText.TextChanged += new System.EventHandler(this.SearchText_TextChanged);
            // 
            // Auflistung
            // 
            this.Auflistung.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Auflistung.Controls.Add(this.treeView1);
            this.Auflistung.Controls.Add(this.label15);
            this.Auflistung.Location = new System.Drawing.Point(4, 22);
            this.Auflistung.Name = "Auflistung";
            this.Auflistung.Padding = new System.Windows.Forms.Padding(3);
            this.Auflistung.Size = new System.Drawing.Size(219, 176);
            this.Auflistung.TabIndex = 1;
            this.Auflistung.Text = "Auflistung";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.treeView1.ForeColor = System.Drawing.Color.LightGray;
            this.treeView1.LineColor = System.Drawing.Color.Silver;
            this.treeView1.Location = new System.Drawing.Point(7, 31);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(206, 122);
            this.treeView1.TabIndex = 14;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Silver;
            this.label15.Location = new System.Drawing.Point(3, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 16);
            this.label15.TabIndex = 13;
            this.label15.Text = "Mitarbeiter";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.Silver;
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.Location = new System.Drawing.Point(9, 297);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(219, 80);
            this.button9.TabIndex = 39;
            this.button9.Text = "Lohnabrechnung               erstellen";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(266, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 202);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Silver;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.Location = new System.Drawing.Point(222, 297);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(219, 80);
            this.button3.TabIndex = 43;
            this.button3.Text = "Lohnabrechnungen    anzeigen";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(7, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 33);
            this.label1.TabIndex = 34;
            this.label1.Text = "Vault-Tec Lohnabrechnungssoftware";
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(12, 14);
            // 
            // menuStrip3
            // 
            this.menuStrip3.AutoSize = false;
            this.menuStrip3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dToolStripMenuItem});
            this.menuStrip3.Location = new System.Drawing.Point(0, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(456, 18);
            this.menuStrip3.TabIndex = 37;
            this.menuStrip3.Text = "menuStrip3";
            this.menuStrip3.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip3_ItemClicked);
            this.menuStrip3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip3_MouseDown);
            this.menuStrip3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuStrip3_MouseMove);
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateiToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 16);
            this.dateiToolStripMenuItem.Text = "Datei";
            this.dateiToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.beendenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("beendenToolStripMenuItem.Image")));
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.beendenToolStripMenuItem.Text = "Schließen";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // ausgabeToolStripMenuItem
            // 
            this.ausgabeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mediaPlayerToolStripMenuItem});
            this.ausgabeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ausgabeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ausgabeToolStripMenuItem.Name = "ausgabeToolStripMenuItem";
            this.ausgabeToolStripMenuItem.Size = new System.Drawing.Size(71, 16);
            this.ausgabeToolStripMenuItem.Text = "Einrichten";
            this.ausgabeToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // mediaPlayerToolStripMenuItem
            // 
            this.mediaPlayerToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mediaPlayerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mediaPlayerToolStripMenuItem.Image")));
            this.mediaPlayerToolStripMenuItem.Name = "mediaPlayerToolStripMenuItem";
            this.mediaPlayerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mediaPlayerToolStripMenuItem.Text = "MediaPlayer";
            this.mediaPlayerToolStripMenuItem.Click += new System.EventHandler(this.mediaPlayerToolStripMenuItem_Click);
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vaultBoyVersteckenToolStripMenuItem,
            this.alleAbrechnungenAnzeigenToolStripMenuItem});
            this.extrasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extrasToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(49, 16);
            this.extrasToolStripMenuItem.Text = "Extras";
            this.extrasToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // vaultBoyVersteckenToolStripMenuItem
            // 
            this.vaultBoyVersteckenToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.vaultBoyVersteckenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("vaultBoyVersteckenToolStripMenuItem.Image")));
            this.vaultBoyVersteckenToolStripMenuItem.Name = "vaultBoyVersteckenToolStripMenuItem";
            this.vaultBoyVersteckenToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.vaultBoyVersteckenToolStripMenuItem.Text = "Vault Boy verstecken";
            this.vaultBoyVersteckenToolStripMenuItem.Click += new System.EventHandler(this.vaultBoyVersteckenToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.technischerSupportToolStripMenuItem,
            this.Info});
            this.hilfeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hilfeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(43, 16);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            this.hilfeToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // technischerSupportToolStripMenuItem
            // 
            this.technischerSupportToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.technischerSupportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("technischerSupportToolStripMenuItem.Image")));
            this.technischerSupportToolStripMenuItem.Name = "technischerSupportToolStripMenuItem";
            this.technischerSupportToolStripMenuItem.Size = new System.Drawing.Size(337, 22);
            this.technischerSupportToolStripMenuItem.Text = "Technischer Support";
            this.technischerSupportToolStripMenuItem.Click += new System.EventHandler(this.technischerSupportToolStripMenuItem_Click);
            // 
            // Info
            // 
            this.Info.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Info.Image = ((System.Drawing.Image)(resources.GetObject("Info.Image")));
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(337, 22);
            this.Info.Text = "Info über Lohnabrechnungsprogramm von Norbert";
            this.Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.ausgabeToolStripMenuItem,
            this.extrasToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 18);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(456, 20);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            this.menuStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseMove);
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            this.button10.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button10.Location = new System.Drawing.Point(406, -8);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(59, 35);
            this.button10.TabIndex = 36;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(382, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 27);
            this.button2.TabIndex = 42;
            this.button2.Text = "___";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Silver;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.Location = new System.Drawing.Point(222, 376);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(219, 81);
            this.button5.TabIndex = 44;
            this.button5.Text = "Administrativer \r\nBereich";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Silver;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.Location = new System.Drawing.Point(9, 376);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(214, 81);
            this.button6.TabIndex = 45;
            this.button6.Text = "Mitarbeiter    \r\nverwalten";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // alleAbrechnungenAnzeigenToolStripMenuItem
            // 
            this.alleAbrechnungenAnzeigenToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.alleAbrechnungenAnzeigenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alleAbrechnungenAnzeigenToolStripMenuItem.Image")));
            this.alleAbrechnungenAnzeigenToolStripMenuItem.Name = "alleAbrechnungenAnzeigenToolStripMenuItem";
            this.alleAbrechnungenAnzeigenToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.alleAbrechnungenAnzeigenToolStripMenuItem.Text = "Alle Abrechnungen anzeigen";
            this.alleAbrechnungenAnzeigenToolStripMenuItem.Click += new System.EventHandler(this.alleAbrechnungenAnzeigenToolStripMenuItem_Click);
            // 
            // Hauptfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(456, 473);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Hauptfenster";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Hauptfenster_Load);
            this.Shown += new System.EventHandler(this.Hauptfenster_Shown);
            this.tabControl1.ResumeLayout(false);
            this.Suchfunktion.ResumeLayout(false);
            this.Suchfunktion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.Auflistung.ResumeLayout(false);
            this.Auflistung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Suchfunktion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.TabPage Auflistung;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ausgabeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediaPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vaultBoyVersteckenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem technischerSupportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Info;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem alleAbrechnungenAnzeigenToolStripMenuItem;
    }
    }

