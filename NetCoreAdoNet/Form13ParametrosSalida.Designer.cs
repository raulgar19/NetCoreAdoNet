namespace NetCoreAdoNet
{
    partial class Form13ParametrosSalida
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
            label1 = new Label();
            cmbDepartamentos = new ComboBox();
            lstEmpleados = new ListBox();
            label2 = new Label();
            btnMostrar = new Button();
            label3 = new Label();
            txtSuma = new TextBox();
            txtMedia = new TextBox();
            label4 = new Label();
            txtPersonas = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Departamentos";
            // 
            // cmbDepartamentos
            // 
            cmbDepartamentos.FormattingEnabled = true;
            cmbDepartamentos.Location = new Point(12, 27);
            cmbDepartamentos.Name = "cmbDepartamentos";
            cmbDepartamentos.Size = new Size(121, 23);
            cmbDepartamentos.TabIndex = 1;
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(157, 27);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(120, 229);
            lstEmpleados.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(157, 9);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 3;
            label2.Text = "Empleados";
            // 
            // btnMostrar
            // 
            btnMostrar.Location = new Point(12, 66);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(121, 23);
            btnMostrar.TabIndex = 4;
            btnMostrar.Text = "Mostrar datos";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 105);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 5;
            label3.Text = "Suma salarial";
            // 
            // txtSuma
            // 
            txtSuma.Location = new Point(12, 123);
            txtSuma.Name = "txtSuma";
            txtSuma.Size = new Size(121, 23);
            txtSuma.TabIndex = 6;
            // 
            // txtMedia
            // 
            txtMedia.Location = new Point(12, 173);
            txtMedia.Name = "txtMedia";
            txtMedia.Size = new Size(121, 23);
            txtMedia.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 155);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 7;
            label4.Text = "Media salarial";
            // 
            // txtPersonas
            // 
            txtPersonas.Location = new Point(12, 222);
            txtPersonas.Name = "txtPersonas";
            txtPersonas.Size = new Size(121, 23);
            txtPersonas.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 204);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 9;
            label5.Text = "Personas";
            // 
            // Form13ParametrosSalida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(311, 284);
            Controls.Add(txtPersonas);
            Controls.Add(label5);
            Controls.Add(txtMedia);
            Controls.Add(label4);
            Controls.Add(txtSuma);
            Controls.Add(label3);
            Controls.Add(btnMostrar);
            Controls.Add(label2);
            Controls.Add(lstEmpleados);
            Controls.Add(cmbDepartamentos);
            Controls.Add(label1);
            Name = "Form13ParametrosSalida";
            Text = "Form13ParametrosSalida";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbDepartamentos;
        private ListBox lstEmpleados;
        private Label label2;
        private Button btnMostrar;
        private Label label3;
        private TextBox txtSuma;
        private TextBox txtMedia;
        private Label label4;
        private TextBox txtPersonas;
        private Label label5;
    }
}