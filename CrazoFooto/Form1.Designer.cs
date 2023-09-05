namespace CrazoFooto
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
            this.playersDataGridView = new System.Windows.Forms.DataGridView();
            this.dirPathInput = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.statsBox = new System.Windows.Forms.TextBox();
            this.changeClubButton = new System.Windows.Forms.Button();
            this.clubsDataGridView = new System.Windows.Forms.DataGridView();
            this.removeButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.randomizeAllButton = new System.Windows.Forms.Button();
            this.randomzieButton = new System.Windows.Forms.Button();
            this.impAttrButton = new System.Windows.Forms.Button();
            this.impImpButton = new System.Windows.Forms.Button();
            this.degAttrButton = new System.Windows.Forms.Button();
            this.degImpButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.backPocketButton = new System.Windows.Forms.Button();
            this.allBackPocketButton = new System.Windows.Forms.Button();
            this.allGenericPotentialButton = new System.Windows.Forms.Button();
            this.allYearOlderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clubsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // playersDataGridView
            // 
            this.playersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playersDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.playersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersDataGridView.Location = new System.Drawing.Point(12, 78);
            this.playersDataGridView.MultiSelect = false;
            this.playersDataGridView.Name = "playersDataGridView";
            this.playersDataGridView.Size = new System.Drawing.Size(1082, 289);
            this.playersDataGridView.TabIndex = 0;
            this.playersDataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.playersDataGridView_ColumnHeaderMouseClick);
            // 
            // dirPathInput
            // 
            this.dirPathInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dirPathInput.Location = new System.Drawing.Point(12, 52);
            this.dirPathInput.Name = "dirPathInput";
            this.dirPathInput.Size = new System.Drawing.Size(984, 20);
            this.dirPathInput.TabIndex = 1;
            this.dirPathInput.TextChanged += new System.EventHandler(this.dirPathInput_TextChanged);
            // 
            // findButton
            // 
            this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findButton.Location = new System.Drawing.Point(1002, 49);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(90, 23);
            this.findButton.TabIndex = 2;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateButton.Location = new System.Drawing.Point(1004, 373);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(90, 23);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // statsBox
            // 
            this.statsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statsBox.Location = new System.Drawing.Point(14, 565);
            this.statsBox.Multiline = true;
            this.statsBox.Name = "statsBox";
            this.statsBox.Size = new System.Drawing.Size(1080, 65);
            this.statsBox.TabIndex = 4;
            // 
            // changeClubButton
            // 
            this.changeClubButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.changeClubButton.Location = new System.Drawing.Point(252, 373);
            this.changeClubButton.Name = "changeClubButton";
            this.changeClubButton.Size = new System.Drawing.Size(90, 23);
            this.changeClubButton.TabIndex = 5;
            this.changeClubButton.Text = "Change Club";
            this.changeClubButton.UseVisualStyleBackColor = true;
            this.changeClubButton.Click += new System.EventHandler(this.changeClubButton_Click);
            // 
            // clubsDataGridView
            // 
            this.clubsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clubsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.clubsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clubsDataGridView.Location = new System.Drawing.Point(12, 431);
            this.clubsDataGridView.Name = "clubsDataGridView";
            this.clubsDataGridView.Size = new System.Drawing.Size(1082, 128);
            this.clubsDataGridView.TabIndex = 6;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeButton.Location = new System.Drawing.Point(156, 373);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(90, 23);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createButton.Location = new System.Drawing.Point(14, 373);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(90, 23);
            this.createButton.TabIndex = 8;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // randomizeAllButton
            // 
            this.randomizeAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.randomizeAllButton.Location = new System.Drawing.Point(908, 373);
            this.randomizeAllButton.Name = "randomizeAllButton";
            this.randomizeAllButton.Size = new System.Drawing.Size(90, 23);
            this.randomizeAllButton.TabIndex = 9;
            this.randomizeAllButton.Text = "Randomize All";
            this.randomizeAllButton.UseVisualStyleBackColor = true;
            this.randomizeAllButton.Click += new System.EventHandler(this.randomizeAllButton_Click);
            // 
            // randomzieButton
            // 
            this.randomzieButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.randomzieButton.Location = new System.Drawing.Point(348, 373);
            this.randomzieButton.Name = "randomzieButton";
            this.randomzieButton.Size = new System.Drawing.Size(90, 23);
            this.randomzieButton.TabIndex = 10;
            this.randomzieButton.Text = "Randomize";
            this.randomzieButton.UseVisualStyleBackColor = true;
            this.randomzieButton.Click += new System.EventHandler(this.randomzieButton_Click);
            // 
            // impAttrButton
            // 
            this.impAttrButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.impAttrButton.Location = new System.Drawing.Point(473, 373);
            this.impAttrButton.Name = "impAttrButton";
            this.impAttrButton.Size = new System.Drawing.Size(90, 23);
            this.impAttrButton.TabIndex = 11;
            this.impAttrButton.Text = "+ Attr";
            this.impAttrButton.UseVisualStyleBackColor = true;
            this.impAttrButton.Click += new System.EventHandler(this.impAttrButton_Click);
            // 
            // impImpButton
            // 
            this.impImpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.impImpButton.Location = new System.Drawing.Point(665, 373);
            this.impImpButton.Name = "impImpButton";
            this.impImpButton.Size = new System.Drawing.Size(90, 23);
            this.impImpButton.TabIndex = 12;
            this.impImpButton.Text = "+ Imp";
            this.impImpButton.UseVisualStyleBackColor = true;
            this.impImpButton.Click += new System.EventHandler(this.impImpButton_Click);
            // 
            // degAttrButton
            // 
            this.degAttrButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.degAttrButton.Location = new System.Drawing.Point(569, 373);
            this.degAttrButton.Name = "degAttrButton";
            this.degAttrButton.Size = new System.Drawing.Size(90, 23);
            this.degAttrButton.TabIndex = 13;
            this.degAttrButton.Text = "- Attr";
            this.degAttrButton.UseVisualStyleBackColor = true;
            this.degAttrButton.Click += new System.EventHandler(this.degAttrButton_Click);
            // 
            // degImpButton
            // 
            this.degImpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.degImpButton.Location = new System.Drawing.Point(761, 373);
            this.degImpButton.Name = "degImpButton";
            this.degImpButton.Size = new System.Drawing.Size(90, 23);
            this.degImpButton.TabIndex = 14;
            this.degImpButton.Text = "- Imp";
            this.degImpButton.UseVisualStyleBackColor = true;
            this.degImpButton.Click += new System.EventHandler(this.degImpButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Location = new System.Drawing.Point(1004, 402);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(90, 23);
            this.exportButton.TabIndex = 15;
            this.exportButton.Text = "Export Team";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Location = new System.Drawing.Point(908, 402);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(90, 23);
            this.importButton.TabIndex = 16;
            this.importButton.Text = "Import Team";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(801, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Export All Teams";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // instructionLabel
            // 
            this.instructionLabel.Location = new System.Drawing.Point(13, 13);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(1079, 33);
            this.instructionLabel.TabIndex = 18;
            this.instructionLabel.Text = "Instructions will populate here.";
            // 
            // backPocketButton
            // 
            this.backPocketButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backPocketButton.Location = new System.Drawing.Point(473, 402);
            this.backPocketButton.Name = "backPocketButton";
            this.backPocketButton.Size = new System.Drawing.Size(90, 23);
            this.backPocketButton.TabIndex = 19;
            this.backPocketButton.Text = "BackPocket";
            this.backPocketButton.UseVisualStyleBackColor = true;
            this.backPocketButton.Click += new System.EventHandler(this.backPocketButton_Click);
            // 
            // allBackPocketButton
            // 
            this.allBackPocketButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.allBackPocketButton.Location = new System.Drawing.Point(348, 402);
            this.allBackPocketButton.Name = "allBackPocketButton";
            this.allBackPocketButton.Size = new System.Drawing.Size(90, 23);
            this.allBackPocketButton.TabIndex = 20;
            this.allBackPocketButton.Text = "AllBackPocket";
            this.allBackPocketButton.UseVisualStyleBackColor = true;
            this.allBackPocketButton.Click += new System.EventHandler(this.allBackPocketButton_Click);
            // 
            // allGenericPotentialButton
            // 
            this.allGenericPotentialButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.allGenericPotentialButton.Location = new System.Drawing.Point(156, 402);
            this.allGenericPotentialButton.Name = "allGenericPotentialButton";
            this.allGenericPotentialButton.Size = new System.Drawing.Size(186, 23);
            this.allGenericPotentialButton.TabIndex = 21;
            this.allGenericPotentialButton.Text = "All Generic Potential";
            this.allGenericPotentialButton.UseVisualStyleBackColor = true;
            this.allGenericPotentialButton.Click += new System.EventHandler(this.allGenericPotentialButton_Click);
            // 
            // allYearOlderButton
            // 
            this.allYearOlderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.allYearOlderButton.Location = new System.Drawing.Point(569, 402);
            this.allYearOlderButton.Name = "allYearOlderButton";
            this.allYearOlderButton.Size = new System.Drawing.Size(90, 23);
            this.allYearOlderButton.TabIndex = 22;
            this.allYearOlderButton.Text = "All Year Older";
            this.allYearOlderButton.UseVisualStyleBackColor = true;
            this.allYearOlderButton.Click += new System.EventHandler(this.allYearOlderButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 642);
            this.Controls.Add(this.allYearOlderButton);
            this.Controls.Add(this.allGenericPotentialButton);
            this.Controls.Add(this.allBackPocketButton);
            this.Controls.Add(this.backPocketButton);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.degImpButton);
            this.Controls.Add(this.degAttrButton);
            this.Controls.Add(this.impImpButton);
            this.Controls.Add(this.impAttrButton);
            this.Controls.Add(this.randomzieButton);
            this.Controls.Add(this.randomizeAllButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.clubsDataGridView);
            this.Controls.Add(this.changeClubButton);
            this.Controls.Add(this.statsBox);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.dirPathInput);
            this.Controls.Add(this.playersDataGridView);
            this.MinimumSize = new System.Drawing.Size(1093, 595);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clubsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView playersDataGridView;
        private System.Windows.Forms.TextBox dirPathInput;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox statsBox;
        private System.Windows.Forms.Button changeClubButton;
        private System.Windows.Forms.DataGridView clubsDataGridView;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button randomizeAllButton;
        private System.Windows.Forms.Button randomzieButton;
        private System.Windows.Forms.Button impAttrButton;
        private System.Windows.Forms.Button impImpButton;
        private System.Windows.Forms.Button degAttrButton;
        private System.Windows.Forms.Button degImpButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.Button backPocketButton;
        private System.Windows.Forms.Button allBackPocketButton;
        private System.Windows.Forms.Button allGenericPotentialButton;
        private System.Windows.Forms.Button allYearOlderButton;
    }
}

