namespace Luigi_s_Circuits_App
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
            this.LQgroupBoxGenerator = new System.Windows.Forms.GroupBox();
            this.LQlabelCircuitType = new System.Windows.Forms.Label();
            this.LQbuttonCircuitType = new System.Windows.Forms.Button();
            this.LQlabelNumResistors = new System.Windows.Forms.Label();
            this.LQtextBoxNumResistors = new System.Windows.Forms.TextBox();
            this.LQbuttonIncrementResistors = new System.Windows.Forms.Button();
            this.LQbuttonDecrementResistors = new System.Windows.Forms.Button();
            this.LQlabelGenerateVolts = new System.Windows.Forms.Label();
            this.LQtextBoxVoltageMin = new System.Windows.Forms.TextBox();
            this.LQtextBoxVoltageMax = new System.Windows.Forms.TextBox();
            this.LQbuttonCycleUnitVolts = new System.Windows.Forms.Button();
            this.LQlabelGenerateAmps = new System.Windows.Forms.Label();
            this.LQtextBoxCurrentMin = new System.Windows.Forms.TextBox();
            this.LQtextBoxCurrentMax = new System.Windows.Forms.TextBox();
            this.LQbuttonCycleUnitAmps = new System.Windows.Forms.Button();
            this.LQlabelGenerateOhms = new System.Windows.Forms.Label();
            this.LQtextBoxResistanceMin = new System.Windows.Forms.TextBox();
            this.LQtextBoxResistanceMax = new System.Windows.Forms.TextBox();
            this.LQbuttonCycleUnitOhms = new System.Windows.Forms.Button();
            this.LQbuttonReset = new System.Windows.Forms.Button();
            this.LQbuttonExperimental = new System.Windows.Forms.Button();
            this.LQbuttonGenerate = new System.Windows.Forms.Button();
            this.LQbuttonCheckAnswers = new System.Windows.Forms.Button();
            this.LQbuttonShowAnswers = new System.Windows.Forms.Button();
            this.LQbuttonToggleDiagram = new System.Windows.Forms.Button();
            this.LQpanelDiagram = new System.Windows.Forms.Panel();
            this.LQpictureBoxBattery = new System.Windows.Forms.PictureBox();
            this.LQpictureBoxDiagram = new System.Windows.Forms.PictureBox();
            this.LQtrackBarMarginError = new System.Windows.Forms.TrackBar();
            this.LQlabelMarginError = new System.Windows.Forms.Label();
            this.LQgroupBoxGenerator.SuspendLayout();
            this.LQpanelDiagram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LQpictureBoxBattery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LQpictureBoxDiagram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LQtrackBarMarginError)).BeginInit();
            this.SuspendLayout();
            // 
            // LQgroupBoxGenerator
            // 
            this.LQgroupBoxGenerator.Controls.Add(this.LQlabelCircuitType);
            this.LQgroupBoxGenerator.Controls.Add(this.LQbuttonCircuitType);
            this.LQgroupBoxGenerator.Controls.Add(this.LQlabelNumResistors);
            this.LQgroupBoxGenerator.Controls.Add(this.LQtextBoxNumResistors);
            this.LQgroupBoxGenerator.Controls.Add(this.LQbuttonIncrementResistors);
            this.LQgroupBoxGenerator.Controls.Add(this.LQbuttonDecrementResistors);
            this.LQgroupBoxGenerator.Controls.Add(this.LQlabelGenerateVolts);
            this.LQgroupBoxGenerator.Controls.Add(this.LQtextBoxVoltageMin);
            this.LQgroupBoxGenerator.Controls.Add(this.LQtextBoxVoltageMax);
            this.LQgroupBoxGenerator.Controls.Add(this.LQbuttonCycleUnitVolts);
            this.LQgroupBoxGenerator.Controls.Add(this.LQlabelGenerateAmps);
            this.LQgroupBoxGenerator.Controls.Add(this.LQtextBoxCurrentMin);
            this.LQgroupBoxGenerator.Controls.Add(this.LQtextBoxCurrentMax);
            this.LQgroupBoxGenerator.Controls.Add(this.LQbuttonCycleUnitAmps);
            this.LQgroupBoxGenerator.Controls.Add(this.LQlabelGenerateOhms);
            this.LQgroupBoxGenerator.Controls.Add(this.LQtextBoxResistanceMin);
            this.LQgroupBoxGenerator.Controls.Add(this.LQtextBoxResistanceMax);
            this.LQgroupBoxGenerator.Controls.Add(this.LQbuttonCycleUnitOhms);
            this.LQgroupBoxGenerator.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQgroupBoxGenerator.Location = new System.Drawing.Point(12, 12);
            this.LQgroupBoxGenerator.Name = "LQgroupBoxGenerator";
            this.LQgroupBoxGenerator.Size = new System.Drawing.Size(407, 146);
            this.LQgroupBoxGenerator.TabIndex = 4;
            this.LQgroupBoxGenerator.TabStop = false;
            this.LQgroupBoxGenerator.Text = "Circuit Generator";
            // 
            // LQlabelCircuitType
            // 
            this.LQlabelCircuitType.AutoSize = true;
            this.LQlabelCircuitType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQlabelCircuitType.Location = new System.Drawing.Point(6, 20);
            this.LQlabelCircuitType.Name = "LQlabelCircuitType";
            this.LQlabelCircuitType.Size = new System.Drawing.Size(85, 17);
            this.LQlabelCircuitType.TabIndex = 0;
            this.LQlabelCircuitType.Text = "Circuit Type:";
            // 
            // LQbuttonCircuitType
            // 
            this.LQbuttonCircuitType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQbuttonCircuitType.Location = new System.Drawing.Point(97, 17);
            this.LQbuttonCircuitType.Name = "LQbuttonCircuitType";
            this.LQbuttonCircuitType.Size = new System.Drawing.Size(69, 25);
            this.LQbuttonCircuitType.TabIndex = 1;
            this.LQbuttonCircuitType.Text = "Parallel";
            this.LQbuttonCircuitType.UseVisualStyleBackColor = true;
            this.LQbuttonCircuitType.Click += new System.EventHandler(this.LQbuttonCircuitType_Click);
            // 
            // LQlabelNumResistors
            // 
            this.LQlabelNumResistors.AutoSize = true;
            this.LQlabelNumResistors.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQlabelNumResistors.Location = new System.Drawing.Point(184, 20);
            this.LQlabelNumResistors.Name = "LQlabelNumResistors";
            this.LQlabelNumResistors.Size = new System.Drawing.Size(79, 17);
            this.LQlabelNumResistors.TabIndex = 2;
            this.LQlabelNumResistors.Text = "# Resistors:";
            // 
            // LQtextBoxNumResistors
            // 
            this.LQtextBoxNumResistors.BackColor = System.Drawing.Color.PaleTurquoise;
            this.LQtextBoxNumResistors.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQtextBoxNumResistors.Location = new System.Drawing.Point(269, 17);
            this.LQtextBoxNumResistors.Name = "LQtextBoxNumResistors";
            this.LQtextBoxNumResistors.Size = new System.Drawing.Size(53, 25);
            this.LQtextBoxNumResistors.TabIndex = 3;
            this.LQtextBoxNumResistors.Text = "3";
            // 
            // LQbuttonIncrementResistors
            // 
            this.LQbuttonIncrementResistors.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQbuttonIncrementResistors.Location = new System.Drawing.Point(328, 17);
            this.LQbuttonIncrementResistors.Name = "LQbuttonIncrementResistors";
            this.LQbuttonIncrementResistors.Size = new System.Drawing.Size(35, 25);
            this.LQbuttonIncrementResistors.TabIndex = 4;
            this.LQbuttonIncrementResistors.Text = "+";
            this.LQbuttonIncrementResistors.UseVisualStyleBackColor = true;
            this.LQbuttonIncrementResistors.Click += new System.EventHandler(this.LQbuttonIncrementResistors_Click);
            // 
            // LQbuttonDecrementResistors
            // 
            this.LQbuttonDecrementResistors.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQbuttonDecrementResistors.Location = new System.Drawing.Point(366, 17);
            this.LQbuttonDecrementResistors.Name = "LQbuttonDecrementResistors";
            this.LQbuttonDecrementResistors.Size = new System.Drawing.Size(35, 25);
            this.LQbuttonDecrementResistors.TabIndex = 5;
            this.LQbuttonDecrementResistors.Text = "-";
            this.LQbuttonDecrementResistors.UseVisualStyleBackColor = true;
            this.LQbuttonDecrementResistors.Click += new System.EventHandler(this.LQbuttonDecrementResistors_Click);
            // 
            // LQlabelGenerateVolts
            // 
            this.LQlabelGenerateVolts.AutoSize = true;
            this.LQlabelGenerateVolts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQlabelGenerateVolts.Location = new System.Drawing.Point(6, 58);
            this.LQlabelGenerateVolts.Name = "LQlabelGenerateVolts";
            this.LQlabelGenerateVolts.Size = new System.Drawing.Size(173, 17);
            this.LQlabelGenerateVolts.TabIndex = 6;
            this.LQlabelGenerateVolts.Text = "Generate voltage between:";
            // 
            // LQtextBoxVoltageMin
            // 
            this.LQtextBoxVoltageMin.BackColor = System.Drawing.Color.PaleTurquoise;
            this.LQtextBoxVoltageMin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQtextBoxVoltageMin.Location = new System.Drawing.Point(200, 55);
            this.LQtextBoxVoltageMin.Name = "LQtextBoxVoltageMin";
            this.LQtextBoxVoltageMin.Size = new System.Drawing.Size(53, 25);
            this.LQtextBoxVoltageMin.TabIndex = 7;
            this.LQtextBoxVoltageMin.Text = "1";
            // 
            // LQtextBoxVoltageMax
            // 
            this.LQtextBoxVoltageMax.BackColor = System.Drawing.Color.PaleTurquoise;
            this.LQtextBoxVoltageMax.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQtextBoxVoltageMax.Location = new System.Drawing.Point(259, 55);
            this.LQtextBoxVoltageMax.Name = "LQtextBoxVoltageMax";
            this.LQtextBoxVoltageMax.Size = new System.Drawing.Size(53, 25);
            this.LQtextBoxVoltageMax.TabIndex = 8;
            this.LQtextBoxVoltageMax.Text = "10";
            // 
            // LQbuttonCycleUnitVolts
            // 
            this.LQbuttonCycleUnitVolts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQbuttonCycleUnitVolts.Location = new System.Drawing.Point(318, 55);
            this.LQbuttonCycleUnitVolts.Name = "LQbuttonCycleUnitVolts";
            this.LQbuttonCycleUnitVolts.Size = new System.Drawing.Size(83, 25);
            this.LQbuttonCycleUnitVolts.TabIndex = 9;
            this.LQbuttonCycleUnitVolts.Text = "Volts";
            this.LQbuttonCycleUnitVolts.UseVisualStyleBackColor = true;
            this.LQbuttonCycleUnitVolts.Click += new System.EventHandler(this.LQbuttonCycleUnitVolts_Click);
            // 
            // LQlabelGenerateAmps
            // 
            this.LQlabelGenerateAmps.AutoSize = true;
            this.LQlabelGenerateAmps.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQlabelGenerateAmps.Location = new System.Drawing.Point(6, 88);
            this.LQlabelGenerateAmps.Name = "LQlabelGenerateAmps";
            this.LQlabelGenerateAmps.Size = new System.Drawing.Size(171, 17);
            this.LQlabelGenerateAmps.TabIndex = 10;
            this.LQlabelGenerateAmps.Text = "Generate current between:";
            // 
            // LQtextBoxCurrentMin
            // 
            this.LQtextBoxCurrentMin.BackColor = System.Drawing.Color.PaleTurquoise;
            this.LQtextBoxCurrentMin.Enabled = false;
            this.LQtextBoxCurrentMin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQtextBoxCurrentMin.Location = new System.Drawing.Point(200, 85);
            this.LQtextBoxCurrentMin.Name = "LQtextBoxCurrentMin";
            this.LQtextBoxCurrentMin.Size = new System.Drawing.Size(53, 25);
            this.LQtextBoxCurrentMin.TabIndex = 11;
            this.LQtextBoxCurrentMin.Text = "1";
            // 
            // LQtextBoxCurrentMax
            // 
            this.LQtextBoxCurrentMax.BackColor = System.Drawing.Color.PaleTurquoise;
            this.LQtextBoxCurrentMax.Enabled = false;
            this.LQtextBoxCurrentMax.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQtextBoxCurrentMax.Location = new System.Drawing.Point(259, 85);
            this.LQtextBoxCurrentMax.Name = "LQtextBoxCurrentMax";
            this.LQtextBoxCurrentMax.Size = new System.Drawing.Size(53, 25);
            this.LQtextBoxCurrentMax.TabIndex = 12;
            this.LQtextBoxCurrentMax.Text = "10";
            // 
            // LQbuttonCycleUnitAmps
            // 
            this.LQbuttonCycleUnitAmps.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQbuttonCycleUnitAmps.Location = new System.Drawing.Point(318, 85);
            this.LQbuttonCycleUnitAmps.Name = "LQbuttonCycleUnitAmps";
            this.LQbuttonCycleUnitAmps.Size = new System.Drawing.Size(83, 25);
            this.LQbuttonCycleUnitAmps.TabIndex = 13;
            this.LQbuttonCycleUnitAmps.Text = "Amps";
            this.LQbuttonCycleUnitAmps.UseVisualStyleBackColor = true;
            this.LQbuttonCycleUnitAmps.Click += new System.EventHandler(this.LQbuttonCycleUnitAmps_Click);
            // 
            // LQlabelGenerateOhms
            // 
            this.LQlabelGenerateOhms.AutoSize = true;
            this.LQlabelGenerateOhms.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQlabelGenerateOhms.Location = new System.Drawing.Point(6, 118);
            this.LQlabelGenerateOhms.Name = "LQlabelGenerateOhms";
            this.LQlabelGenerateOhms.Size = new System.Drawing.Size(188, 17);
            this.LQlabelGenerateOhms.TabIndex = 14;
            this.LQlabelGenerateOhms.Text = "Generate resistance between:";
            // 
            // LQtextBoxResistanceMin
            // 
            this.LQtextBoxResistanceMin.BackColor = System.Drawing.Color.PaleTurquoise;
            this.LQtextBoxResistanceMin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQtextBoxResistanceMin.Location = new System.Drawing.Point(200, 115);
            this.LQtextBoxResistanceMin.Name = "LQtextBoxResistanceMin";
            this.LQtextBoxResistanceMin.Size = new System.Drawing.Size(53, 25);
            this.LQtextBoxResistanceMin.TabIndex = 15;
            this.LQtextBoxResistanceMin.Text = "1";
            // 
            // LQtextBoxResistanceMax
            // 
            this.LQtextBoxResistanceMax.BackColor = System.Drawing.Color.PaleTurquoise;
            this.LQtextBoxResistanceMax.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQtextBoxResistanceMax.Location = new System.Drawing.Point(259, 115);
            this.LQtextBoxResistanceMax.Name = "LQtextBoxResistanceMax";
            this.LQtextBoxResistanceMax.Size = new System.Drawing.Size(53, 25);
            this.LQtextBoxResistanceMax.TabIndex = 16;
            this.LQtextBoxResistanceMax.Text = "10";
            // 
            // LQbuttonCycleUnitOhms
            // 
            this.LQbuttonCycleUnitOhms.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQbuttonCycleUnitOhms.Location = new System.Drawing.Point(318, 115);
            this.LQbuttonCycleUnitOhms.Name = "LQbuttonCycleUnitOhms";
            this.LQbuttonCycleUnitOhms.Size = new System.Drawing.Size(83, 25);
            this.LQbuttonCycleUnitOhms.TabIndex = 17;
            this.LQbuttonCycleUnitOhms.Text = "Ohms";
            this.LQbuttonCycleUnitOhms.UseVisualStyleBackColor = true;
            this.LQbuttonCycleUnitOhms.Click += new System.EventHandler(this.LQbuttonCycleUnitOhms_Click);
            // 
            // LQbuttonReset
            // 
            this.LQbuttonReset.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQbuttonReset.Location = new System.Drawing.Point(330, 159);
            this.LQbuttonReset.Name = "LQbuttonReset";
            this.LQbuttonReset.Size = new System.Drawing.Size(83, 25);
            this.LQbuttonReset.TabIndex = 18;
            this.LQbuttonReset.Text = "Reset";
            this.LQbuttonReset.UseVisualStyleBackColor = true;
            this.LQbuttonReset.Click += new System.EventHandler(this.LQbuttonReset_Click);
            // 
            // LQbuttonExperimental
            // 
            this.LQbuttonExperimental.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQbuttonExperimental.Location = new System.Drawing.Point(425, 12);
            this.LQbuttonExperimental.Name = "LQbuttonExperimental";
            this.LQbuttonExperimental.Size = new System.Drawing.Size(132, 52);
            this.LQbuttonExperimental.TabIndex = 1;
            this.LQbuttonExperimental.Text = "Experimental mode";
            this.LQbuttonExperimental.UseVisualStyleBackColor = true;
            this.LQbuttonExperimental.Click += new System.EventHandler(this.LQbuttonExperimental_Click);
            // 
            // LQbuttonGenerate
            // 
            this.LQbuttonGenerate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQbuttonGenerate.Location = new System.Drawing.Point(425, 70);
            this.LQbuttonGenerate.Name = "LQbuttonGenerate";
            this.LQbuttonGenerate.Size = new System.Drawing.Size(132, 52);
            this.LQbuttonGenerate.TabIndex = 0;
            this.LQbuttonGenerate.Text = "Generate Circuit";
            this.LQbuttonGenerate.UseVisualStyleBackColor = true;
            this.LQbuttonGenerate.Click += new System.EventHandler(this.LQbuttonGenerate_Click);
            // 
            // LQbuttonCheckAnswers
            // 
            this.LQbuttonCheckAnswers.Enabled = false;
            this.LQbuttonCheckAnswers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQbuttonCheckAnswers.Location = new System.Drawing.Point(425, 128);
            this.LQbuttonCheckAnswers.Name = "LQbuttonCheckAnswers";
            this.LQbuttonCheckAnswers.Size = new System.Drawing.Size(132, 52);
            this.LQbuttonCheckAnswers.TabIndex = 6;
            this.LQbuttonCheckAnswers.Text = "Check Answers";
            this.LQbuttonCheckAnswers.UseVisualStyleBackColor = true;
            this.LQbuttonCheckAnswers.Click += new System.EventHandler(this.LQbuttonCheckAnswers_Click);
            // 
            // LQbuttonShowAnswers
            // 
            this.LQbuttonShowAnswers.Enabled = false;
            this.LQbuttonShowAnswers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQbuttonShowAnswers.Location = new System.Drawing.Point(425, 186);
            this.LQbuttonShowAnswers.Name = "LQbuttonShowAnswers";
            this.LQbuttonShowAnswers.Size = new System.Drawing.Size(132, 52);
            this.LQbuttonShowAnswers.TabIndex = 5;
            this.LQbuttonShowAnswers.Text = "Show Answers";
            this.LQbuttonShowAnswers.UseVisualStyleBackColor = true;
            this.LQbuttonShowAnswers.Click += new System.EventHandler(this.LQbuttonShowAnswers_Click);
            // 
            // LQbuttonToggleDiagram
            // 
            this.LQbuttonToggleDiagram.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQbuttonToggleDiagram.Location = new System.Drawing.Point(330, 190);
            this.LQbuttonToggleDiagram.Name = "LQbuttonToggleDiagram";
            this.LQbuttonToggleDiagram.Size = new System.Drawing.Size(83, 48);
            this.LQbuttonToggleDiagram.TabIndex = 19;
            this.LQbuttonToggleDiagram.Text = "Turn Off Diagram";
            this.LQbuttonToggleDiagram.UseVisualStyleBackColor = true;
            this.LQbuttonToggleDiagram.Click += new System.EventHandler(this.LQbuttonToggleDiagram_Click);
            // 
            // LQpanelDiagram
            // 
            this.LQpanelDiagram.AutoScroll = true;
            this.LQpanelDiagram.Controls.Add(this.LQpictureBoxBattery);
            this.LQpanelDiagram.Controls.Add(this.LQpictureBoxDiagram);
            this.LQpanelDiagram.Location = new System.Drawing.Point(12, 244);
            this.LQpanelDiagram.Name = "LQpanelDiagram";
            this.LQpanelDiagram.Size = new System.Drawing.Size(547, 367);
            this.LQpanelDiagram.TabIndex = 20;
            // 
            // LQpictureBoxBattery
            // 
            this.LQpictureBoxBattery.Image = global::Luigi_s_Circuits_App.Properties.Resources.Battery;
            this.LQpictureBoxBattery.Location = new System.Drawing.Point(0, 138);
            this.LQpictureBoxBattery.Name = "LQpictureBoxBattery";
            this.LQpictureBoxBattery.Size = new System.Drawing.Size(55, 61);
            this.LQpictureBoxBattery.TabIndex = 9;
            this.LQpictureBoxBattery.TabStop = false;
            // 
            // LQpictureBoxDiagram
            // 
            this.LQpictureBoxDiagram.Image = global::Luigi_s_Circuits_App.Properties.Resources.Diagram;
            this.LQpictureBoxDiagram.Location = new System.Drawing.Point(0, 0);
            this.LQpictureBoxDiagram.Name = "LQpictureBoxDiagram";
            this.LQpictureBoxDiagram.Size = new System.Drawing.Size(547, 355);
            this.LQpictureBoxDiagram.TabIndex = 8;
            this.LQpictureBoxDiagram.TabStop = false;
            // 
            // LQtrackBarMarginError
            // 
            this.LQtrackBarMarginError.LargeChange = 1;
            this.LQtrackBarMarginError.Location = new System.Drawing.Point(21, 190);
            this.LQtrackBarMarginError.Name = "LQtrackBarMarginError";
            this.LQtrackBarMarginError.Size = new System.Drawing.Size(303, 45);
            this.LQtrackBarMarginError.TabIndex = 21;
            this.LQtrackBarMarginError.TickFrequency = 2;
            this.LQtrackBarMarginError.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.LQtrackBarMarginError.Value = 2;
            this.LQtrackBarMarginError.Scroll += new System.EventHandler(this.LQtrackBarMarginError_Scroll);
            // 
            // LQlabelMarginError
            // 
            this.LQlabelMarginError.AutoSize = true;
            this.LQlabelMarginError.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LQlabelMarginError.Location = new System.Drawing.Point(21, 166);
            this.LQlabelMarginError.Name = "LQlabelMarginError";
            this.LQlabelMarginError.Size = new System.Drawing.Size(135, 17);
            this.LQlabelMarginError.TabIndex = 22;
            this.LQlabelMarginError.Text = "Margin of error (0.2)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(569, 611);
            this.Controls.Add(this.LQlabelMarginError);
            this.Controls.Add(this.LQtrackBarMarginError);
            this.Controls.Add(this.LQpanelDiagram);
            this.Controls.Add(this.LQbuttonReset);
            this.Controls.Add(this.LQbuttonToggleDiagram);
            this.Controls.Add(this.LQbuttonExperimental);
            this.Controls.Add(this.LQgroupBoxGenerator);
            this.Controls.Add(this.LQbuttonShowAnswers);
            this.Controls.Add(this.LQbuttonCheckAnswers);
            this.Controls.Add(this.LQbuttonGenerate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Luigi\'s Circuits Application";
            this.LQgroupBoxGenerator.ResumeLayout(false);
            this.LQgroupBoxGenerator.PerformLayout();
            this.LQpanelDiagram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LQpictureBoxBattery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LQpictureBoxDiagram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LQtrackBarMarginError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LQbuttonGenerate;
        private System.Windows.Forms.Button LQbuttonDecrementResistors;
        private System.Windows.Forms.Button LQbuttonIncrementResistors;
        private System.Windows.Forms.Button LQbuttonCheckAnswers;
        private System.Windows.Forms.Button LQbuttonShowAnswers;
        private System.Windows.Forms.GroupBox LQgroupBoxGenerator;
        private System.Windows.Forms.Button LQbuttonCycleUnitOhms;
        private System.Windows.Forms.Button LQbuttonCycleUnitAmps;
        private System.Windows.Forms.Button LQbuttonCycleUnitVolts;
        private System.Windows.Forms.TextBox LQtextBoxResistanceMax;
        private System.Windows.Forms.TextBox LQtextBoxResistanceMin;
        private System.Windows.Forms.TextBox LQtextBoxCurrentMax;
        private System.Windows.Forms.TextBox LQtextBoxCurrentMin;
        private System.Windows.Forms.TextBox LQtextBoxVoltageMax;
        private System.Windows.Forms.TextBox LQtextBoxVoltageMin;
        private System.Windows.Forms.Label LQlabelGenerateOhms;
        private System.Windows.Forms.Label LQlabelGenerateAmps;
        private System.Windows.Forms.Label LQlabelGenerateVolts;
        private System.Windows.Forms.TextBox LQtextBoxNumResistors;
        private System.Windows.Forms.Button LQbuttonExperimental;
        private System.Windows.Forms.Button LQbuttonCircuitType;
        private System.Windows.Forms.Label LQlabelCircuitType;
        private System.Windows.Forms.Label LQlabelNumResistors;
        private System.Windows.Forms.Button LQbuttonReset;
        private System.Windows.Forms.Button LQbuttonToggleDiagram;
        private System.Windows.Forms.Panel LQpanelDiagram;
        private System.Windows.Forms.PictureBox LQpictureBoxBattery;
        private System.Windows.Forms.PictureBox LQpictureBoxDiagram;
        private System.Windows.Forms.TrackBar LQtrackBarMarginError;
        private System.Windows.Forms.Label LQlabelMarginError;
    }
}

