namespace DDOOCP_Assignment
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.no_acc_text = new System.Windows.Forms.Label();
            this.psw = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.page_name = new System.Windows.Forms.Label();
            this.nav_panel = new System.Windows.Forms.Panel();
            this.form_close_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Login_btn = new Guna.UI2.WinForms.Guna2Button();
            this.psw_input = new Guna.UI2.WinForms.Guna2TextBox();
            this.name_input = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.register_link = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.nav_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // no_acc_text
            // 
            this.no_acc_text.AutoSize = true;
            this.no_acc_text.ForeColor = System.Drawing.Color.White;
            this.no_acc_text.Location = new System.Drawing.Point(207, 507);
            this.no_acc_text.Name = "no_acc_text";
            this.no_acc_text.Size = new System.Drawing.Size(149, 16);
            this.no_acc_text.TabIndex = 7;
            this.no_acc_text.Text = "Don\'t have an account ?";
            // 
            // psw
            // 
            this.psw.AutoSize = true;
            this.psw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.psw.ForeColor = System.Drawing.Color.White;
            this.psw.Location = new System.Drawing.Point(55, 391);
            this.psw.Name = "psw";
            this.psw.Size = new System.Drawing.Size(117, 25);
            this.psw.TabIndex = 2;
            this.psw.Text = "Passwords";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.White;
            this.name.Location = new System.Drawing.Point(53, 309);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(119, 25);
            this.name.TabIndex = 5;
            this.name.Text = "User Name";
            // 
            // page_name
            // 
            this.page_name.AutoSize = true;
            this.page_name.Dock = System.Windows.Forms.DockStyle.Left;
            this.page_name.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.page_name.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.page_name.Location = new System.Drawing.Point(0, 0);
            this.page_name.Name = "page_name";
            this.page_name.Size = new System.Drawing.Size(134, 27);
            this.page_name.TabIndex = 2;
            this.page_name.Text = "Ready to Fight";
            // 
            // nav_panel
            // 
            this.nav_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(65)))), ((int)(((byte)(14)))));
            this.nav_panel.Controls.Add(this.form_close_btn);
            this.nav_panel.Controls.Add(this.page_name);
            this.nav_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nav_panel.Location = new System.Drawing.Point(0, 0);
            this.nav_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nav_panel.Name = "nav_panel";
            this.nav_panel.Size = new System.Drawing.Size(1000, 31);
            this.nav_panel.TabIndex = 2;
            // 
            // form_close_btn
            // 
            this.form_close_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("form_close_btn.BackgroundImage")));
            this.form_close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.form_close_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.form_close_btn.FlatAppearance.BorderSize = 0;
            this.form_close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.form_close_btn.Location = new System.Drawing.Point(967, 0);
            this.form_close_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.form_close_btn.Name = "form_close_btn";
            this.form_close_btn.Size = new System.Drawing.Size(33, 31);
            this.form_close_btn.TabIndex = 3;
            this.form_close_btn.UseVisualStyleBackColor = true;
            this.form_close_btn.Click += new System.EventHandler(this.form_close_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.Login_btn);
            this.panel1.Controls.Add(this.psw_input);
            this.panel1.Controls.Add(this.name_input);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.register_link);
            this.panel1.Controls.Add(this.no_acc_text);
            this.panel1.Controls.Add(this.psw);
            this.panel1.Controls.Add(this.name);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(381, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 539);
            this.panel1.TabIndex = 3;
            // 
            // Login_btn
            // 
            this.Login_btn.Animated = true;
            this.Login_btn.BorderRadius = 15;
            this.Login_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Login_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Login_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Login_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Login_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(65)))), ((int)(((byte)(14)))));
            this.Login_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_btn.ForeColor = System.Drawing.Color.Black;
            this.Login_btn.Location = new System.Drawing.Point(245, 452);
            this.Login_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.Size = new System.Drawing.Size(180, 46);
            this.Login_btn.TabIndex = 15;
            this.Login_btn.Text = "Login";
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // psw_input
            // 
            this.psw_input.Animated = true;
            this.psw_input.AutoRoundedCorners = true;
            this.psw_input.BorderRadius = 23;
            this.psw_input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.psw_input.DefaultText = "";
            this.psw_input.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.psw_input.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.psw_input.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.psw_input.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.psw_input.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.psw_input.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.psw_input.ForeColor = System.Drawing.Color.Black;
            this.psw_input.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.psw_input.IconRight = ((System.Drawing.Image)(resources.GetObject("psw_input.IconRight")));
            this.psw_input.IconRightSize = new System.Drawing.Size(40, 40);
            this.psw_input.Location = new System.Drawing.Point(197, 382);
            this.psw_input.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.psw_input.Name = "psw_input";
            this.psw_input.PasswordChar = 'X';
            this.psw_input.PlaceholderText = "";
            this.psw_input.SelectedText = "";
            this.psw_input.Size = new System.Drawing.Size(337, 48);
            this.psw_input.TabIndex = 14;
            this.psw_input.TextChanged += new System.EventHandler(this.psw_input_TextChanged);
            // 
            // name_input
            // 
            this.name_input.Animated = true;
            this.name_input.AutoRoundedCorners = true;
            this.name_input.BorderRadius = 23;
            this.name_input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.name_input.DefaultText = "";
            this.name_input.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.name_input.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.name_input.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.name_input.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.name_input.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.name_input.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.name_input.ForeColor = System.Drawing.Color.Black;
            this.name_input.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.name_input.IconRight = ((System.Drawing.Image)(resources.GetObject("name_input.IconRight")));
            this.name_input.IconRightSize = new System.Drawing.Size(50, 50);
            this.name_input.Location = new System.Drawing.Point(197, 299);
            this.name_input.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.name_input.Name = "name_input";
            this.name_input.PasswordChar = '\0';
            this.name_input.PlaceholderText = "";
            this.name_input.SelectedText = "";
            this.name_input.Size = new System.Drawing.Size(337, 48);
            this.name_input.TabIndex = 13;
            this.name_input.TextChanged += new System.EventHandler(this.name_input_TextChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(104, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(427, 263);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // register_link
            // 
            this.register_link.ActiveLinkColor = System.Drawing.Color.Black;
            this.register_link.AutoSize = true;
            this.register_link.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_link.ForeColor = System.Drawing.Color.White;
            this.register_link.LinkColor = System.Drawing.Color.White;
            this.register_link.Location = new System.Drawing.Point(363, 507);
            this.register_link.Name = "register_link";
            this.register_link.Size = new System.Drawing.Size(97, 16);
            this.register_link.TabIndex = 9;
            this.register_link.TabStop = true;
            this.register_link.Text = "Register now";
            this.register_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.register_link_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(65)))), ((int)(((byte)(14)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 570);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 31);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fitness is not a destination, it\'s a journey.";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(-21, 2);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(416, 582);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(58)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1000, 601);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.nav_panel);
            this.Controls.Add(this.pictureBox4);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Login_Form";
            this.nav_panel.ResumeLayout(false);
            this.nav_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label page_name;
        private System.Windows.Forms.Label psw;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label no_acc_text;
        private System.Windows.Forms.Panel nav_panel;
        private System.Windows.Forms.Button form_close_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel register_link;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Guna.UI2.WinForms.Guna2TextBox psw_input;
        private Guna.UI2.WinForms.Guna2TextBox name_input;
        private Guna.UI2.WinForms.Guna2Button Login_btn;
    }
}

