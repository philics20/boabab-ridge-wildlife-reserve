namespace boabab_ridge_wildlife_reserve
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
        /// <param name="disposing">
        /// true if managed resources should be disposed; otherwise, false.
        /// </param>
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
            this.txtAnimalId = new System.Windows.Forms.TextBox();
            this.txtAnimalName = new System.Windows.Forms.TextBox();
            this.txtSpecies = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtRecoveryScore = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchId = new System.Windows.Forms.TextBox();
            this.dgvAnimals = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAnimalId
            // 
            this.txtAnimalId.Location = new System.Drawing.Point(54, 48);
            this.txtAnimalId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAnimalId.Name = "txtAnimalId";
            this.txtAnimalId.Size = new System.Drawing.Size(122, 26);
            this.txtAnimalId.TabIndex = 0;
            // 
            // txtAnimalName
            // 
            this.txtAnimalName.Location = new System.Drawing.Point(54, 125);
            this.txtAnimalName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAnimalName.Name = "txtAnimalName";
            this.txtAnimalName.Size = new System.Drawing.Size(122, 26);
            this.txtAnimalName.TabIndex = 1;
            // 
            // txtSpecies
            // 
            this.txtSpecies.Location = new System.Drawing.Point(54, 209);
            this.txtSpecies.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSpecies.Name = "txtSpecies";
            this.txtSpecies.Size = new System.Drawing.Size(122, 26);
            this.txtSpecies.TabIndex = 2;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(54, 284);
            this.txtAge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(122, 26);
            this.txtAge.TabIndex = 3;
            // 
            // txtRecoveryScore
            // 
            this.txtRecoveryScore.Location = new System.Drawing.Point(54, 369);
            this.txtRecoveryScore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRecoveryScore.Name = "txtRecoveryScore";
            this.txtRecoveryScore.Size = new System.Drawing.Size(122, 26);
            this.txtRecoveryScore.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(54, 438);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(123, 49);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add Animal";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Enabled = false;
            this.btnSaveChanges.Location = new System.Drawing.Point(54, 500);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(123, 49);
            this.btnSaveChanges.TabIndex = 6;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(189, 438);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(123, 49);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(189, 500);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(123, 49);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(675, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 31);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchId
            // 
            this.txtSearchId.Location = new System.Drawing.Point(382, 18);
            this.txtSearchId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchId.Name = "txtSearchId";
            this.txtSearchId.Size = new System.Drawing.Size(281, 26);
            this.txtSearchId.TabIndex = 10;
            // 
            // dgvAnimals
            // 
            this.dgvAnimals.AllowUserToAddRows = false;
            this.dgvAnimals.AllowUserToDeleteRows = false;
            this.dgvAnimals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnimals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnimals.Location = new System.Drawing.Point(382, 62);
            this.dgvAnimals.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvAnimals.MultiSelect = false;
            this.dgvAnimals.Name = "dgvAnimals";
            this.dgvAnimals.ReadOnly = true;
            this.dgvAnimals.RowHeadersWidth = 51;
            this.dgvAnimals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnimals.Size = new System.Drawing.Size(495, 542);
            this.dgvAnimals.TabIndex = 11;
            this.dgvAnimals.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnimals_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Animal Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Animal Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Species";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Age";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Recovery Score";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 625);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchId);
            this.Controls.Add(this.txtRecoveryScore);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtSpecies);
            this.Controls.Add(this.txtAnimalName);
            this.Controls.Add(this.txtAnimalId);
            this.Controls.Add(this.dgvAnimals);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAnimalId;
        private System.Windows.Forms.TextBox txtAnimalName;
        private System.Windows.Forms.TextBox txtSpecies;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtRecoveryScore;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;

        private System.Windows.Forms.TextBox txtSearchId;
        private System.Windows.Forms.DataGridView dgvAnimals;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}