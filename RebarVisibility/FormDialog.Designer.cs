namespace RebarVisibility
{
    partial class FormDialog
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxBody = new System.Windows.Forms.CheckBox();
            this.checkBoxOverlay = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonAsBodyOn = new System.Windows.Forms.RadioButton();
            this.radioButtonAsBodyOff = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonOverlayOn = new System.Windows.Forms.RadioButton();
            this.radioButtonOverlayOff = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(70, 308);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(98, 39);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "ОК";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(174, 308);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(98, 39);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxBody
            // 
            this.checkBoxBody.AutoSize = true;
            this.checkBoxBody.Checked = true;
            this.checkBoxBody.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBody.Location = new System.Drawing.Point(6, 25);
            this.checkBoxBody.Name = "checkBoxBody";
            this.checkBoxBody.Size = new System.Drawing.Size(205, 24);
            this.checkBoxBody.TabIndex = 2;
            this.checkBoxBody.Text = "Активировать модуль";
            this.checkBoxBody.UseVisualStyleBackColor = true;
            this.checkBoxBody.CheckedChanged += new System.EventHandler(this.checkBoxBody_CheckedChanged);
            // 
            // checkBoxOverlay
            // 
            this.checkBoxOverlay.AutoSize = true;
            this.checkBoxOverlay.Location = new System.Drawing.Point(6, 25);
            this.checkBoxOverlay.Name = "checkBoxOverlay";
            this.checkBoxOverlay.Size = new System.Drawing.Size(205, 24);
            this.checkBoxOverlay.TabIndex = 4;
            this.checkBoxOverlay.Text = "Активировать модуль";
            this.checkBoxOverlay.UseVisualStyleBackColor = true;
            this.checkBoxOverlay.CheckedChanged += new System.EventHandler(this.checkBoxOverlay_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonAsBodyOff);
            this.groupBox1.Controls.Add(this.radioButtonAsBodyOn);
            this.groupBox1.Controls.Add(this.checkBoxBody);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 131);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Арматура как тело";
            // 
            // radioButtonAsBodyOn
            // 
            this.radioButtonAsBodyOn.AutoSize = true;
            this.radioButtonAsBodyOn.Checked = true;
            this.radioButtonAsBodyOn.Location = new System.Drawing.Point(27, 55);
            this.radioButtonAsBodyOn.Name = "radioButtonAsBodyOn";
            this.radioButtonAsBodyOn.Size = new System.Drawing.Size(107, 24);
            this.radioButtonAsBodyOn.TabIndex = 7;
            this.radioButtonAsBodyOn.TabStop = true;
            this.radioButtonAsBodyOn.Text = "В объеме";
            this.radioButtonAsBodyOn.UseVisualStyleBackColor = true;
            // 
            // radioButtonAsBodyOff
            // 
            this.radioButtonAsBodyOff.AutoSize = true;
            this.radioButtonAsBodyOff.Location = new System.Drawing.Point(27, 85);
            this.radioButtonAsBodyOff.Name = "radioButtonAsBodyOff";
            this.radioButtonAsBodyOff.Size = new System.Drawing.Size(102, 24);
            this.radioButtonAsBodyOff.TabIndex = 7;
            this.radioButtonAsBodyOff.Text = "В линиях";
            this.radioButtonAsBodyOff.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonOverlayOff);
            this.groupBox2.Controls.Add(this.radioButtonOverlayOn);
            this.groupBox2.Controls.Add(this.checkBoxOverlay);
            this.groupBox2.Location = new System.Drawing.Point(12, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 126);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отображать неперекрытой";
            // 
            // radioButtonOverlayOn
            // 
            this.radioButtonOverlayOn.AutoSize = true;
            this.radioButtonOverlayOn.Enabled = false;
            this.radioButtonOverlayOn.Location = new System.Drawing.Point(27, 85);
            this.radioButtonOverlayOn.Name = "radioButtonOverlayOn";
            this.radioButtonOverlayOn.Size = new System.Drawing.Size(215, 24);
            this.radioButtonOverlayOn.TabIndex = 5;
            this.radioButtonOverlayOn.Text = "Сделать неперекрытой";
            this.radioButtonOverlayOn.UseVisualStyleBackColor = true;
            // 
            // radioButtonOverlayOff
            // 
            this.radioButtonOverlayOff.AutoSize = true;
            this.radioButtonOverlayOff.Checked = true;
            this.radioButtonOverlayOff.Enabled = false;
            this.radioButtonOverlayOff.Location = new System.Drawing.Point(27, 55);
            this.radioButtonOverlayOff.Name = "radioButtonOverlayOff";
            this.radioButtonOverlayOff.Size = new System.Drawing.Size(169, 24);
            this.radioButtonOverlayOff.TabIndex = 6;
            this.radioButtonOverlayOff.TabStop = true;
            this.radioButtonOverlayOff.Text = "Сделать скрытой";
            this.radioButtonOverlayOff.UseVisualStyleBackColor = true;
            // 
            // FormRebarAsBody
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 359);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormRebarAsBody";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxBody;
        private System.Windows.Forms.CheckBox checkBoxOverlay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonAsBodyOff;
        private System.Windows.Forms.RadioButton radioButtonAsBodyOn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonOverlayOff;
        private System.Windows.Forms.RadioButton radioButtonOverlayOn;

    }
}