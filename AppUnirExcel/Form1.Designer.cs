
namespace AppUnirExcel
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnExportarCsvSql = new System.Windows.Forms.Button();
            this.btnEliminarRegistrosSql = new System.Windows.Forms.Button();
            this.btnProcesarResultados = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.chCIFIN = new System.Windows.Forms.CheckBox();
            this.chDATACREDITO = new System.Windows.Forms.CheckBox();
            this.chLICENCIAS = new System.Windows.Forms.CheckBox();
            this.chPICO_PLACA = new System.Windows.Forms.CheckBox();
            this.chREGISTRO_BICI = new System.Windows.Forms.CheckBox();
            this.chRUES = new System.Windows.Forms.CheckBox();
            this.chRUNT = new System.Windows.Forms.CheckBox();
            this.chSHD = new System.Windows.Forms.CheckBox();
            this.chTIGLOBAL = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pctProcesamiento = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctProcesamiento)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportarCsvSql
            // 
            this.btnExportarCsvSql.Location = new System.Drawing.Point(177, 49);
            this.btnExportarCsvSql.Name = "btnExportarCsvSql";
            this.btnExportarCsvSql.Size = new System.Drawing.Size(71, 23);
            this.btnExportarCsvSql.TabIndex = 3;
            this.btnExportarCsvSql.Text = "Procesar";
            this.btnExportarCsvSql.UseVisualStyleBackColor = true;
            this.btnExportarCsvSql.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEliminarRegistrosSql
            // 
            this.btnEliminarRegistrosSql.Location = new System.Drawing.Point(177, 87);
            this.btnEliminarRegistrosSql.Name = "btnEliminarRegistrosSql";
            this.btnEliminarRegistrosSql.Size = new System.Drawing.Size(71, 23);
            this.btnEliminarRegistrosSql.TabIndex = 5;
            this.btnEliminarRegistrosSql.Text = "Procesar";
            this.btnEliminarRegistrosSql.UseVisualStyleBackColor = true;
            this.btnEliminarRegistrosSql.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnProcesarResultados
            // 
            this.btnProcesarResultados.Location = new System.Drawing.Point(177, 120);
            this.btnProcesarResultados.Name = "btnProcesarResultados";
            this.btnProcesarResultados.Size = new System.Drawing.Size(71, 23);
            this.btnProcesarResultados.TabIndex = 8;
            this.btnProcesarResultados.Text = "Procesar";
            this.btnProcesarResultados.UseVisualStyleBackColor = true;
            this.btnProcesarResultados.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(116, 305);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 9;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // chCIFIN
            // 
            this.chCIFIN.AutoSize = true;
            this.chCIFIN.Location = new System.Drawing.Point(15, 195);
            this.chCIFIN.Name = "chCIFIN";
            this.chCIFIN.Size = new System.Drawing.Size(53, 17);
            this.chCIFIN.TabIndex = 10;
            this.chCIFIN.Text = "CIFIN";
            this.chCIFIN.UseVisualStyleBackColor = true;
            // 
            // chDATACREDITO
            // 
            this.chDATACREDITO.AutoSize = true;
            this.chDATACREDITO.Location = new System.Drawing.Point(113, 195);
            this.chDATACREDITO.Name = "chDATACREDITO";
            this.chDATACREDITO.Size = new System.Drawing.Size(103, 17);
            this.chDATACREDITO.TabIndex = 11;
            this.chDATACREDITO.Text = "DATACREDITO";
            this.chDATACREDITO.UseVisualStyleBackColor = true;
            // 
            // chLICENCIAS
            // 
            this.chLICENCIAS.AutoSize = true;
            this.chLICENCIAS.Location = new System.Drawing.Point(225, 195);
            this.chLICENCIAS.Name = "chLICENCIAS";
            this.chLICENCIAS.Size = new System.Drawing.Size(81, 17);
            this.chLICENCIAS.TabIndex = 12;
            this.chLICENCIAS.Text = "LICENCIAS";
            this.chLICENCIAS.UseVisualStyleBackColor = true;
            // 
            // chPICO_PLACA
            // 
            this.chPICO_PLACA.AutoSize = true;
            this.chPICO_PLACA.Location = new System.Drawing.Point(15, 230);
            this.chPICO_PLACA.Name = "chPICO_PLACA";
            this.chPICO_PLACA.Size = new System.Drawing.Size(91, 17);
            this.chPICO_PLACA.TabIndex = 13;
            this.chPICO_PLACA.Text = "PICO_PLACA";
            this.chPICO_PLACA.UseVisualStyleBackColor = true;
            // 
            // chREGISTRO_BICI
            // 
            this.chREGISTRO_BICI.AutoSize = true;
            this.chREGISTRO_BICI.Location = new System.Drawing.Point(113, 230);
            this.chREGISTRO_BICI.Name = "chREGISTRO_BICI";
            this.chREGISTRO_BICI.Size = new System.Drawing.Size(108, 17);
            this.chREGISTRO_BICI.TabIndex = 14;
            this.chREGISTRO_BICI.Text = "REGISTRO_BICI";
            this.chREGISTRO_BICI.UseVisualStyleBackColor = true;
            // 
            // chRUES
            // 
            this.chRUES.AutoSize = true;
            this.chRUES.Location = new System.Drawing.Point(225, 230);
            this.chRUES.Name = "chRUES";
            this.chRUES.Size = new System.Drawing.Size(56, 17);
            this.chRUES.TabIndex = 15;
            this.chRUES.Text = "RUES";
            this.chRUES.UseVisualStyleBackColor = true;
            // 
            // chRUNT
            // 
            this.chRUNT.AutoSize = true;
            this.chRUNT.Location = new System.Drawing.Point(15, 265);
            this.chRUNT.Name = "chRUNT";
            this.chRUNT.Size = new System.Drawing.Size(57, 17);
            this.chRUNT.TabIndex = 16;
            this.chRUNT.Text = "RUNT";
            this.chRUNT.UseVisualStyleBackColor = true;
            // 
            // chSHD
            // 
            this.chSHD.AutoSize = true;
            this.chSHD.Location = new System.Drawing.Point(113, 265);
            this.chSHD.Name = "chSHD";
            this.chSHD.Size = new System.Drawing.Size(49, 17);
            this.chSHD.TabIndex = 17;
            this.chSHD.Text = "SHD";
            this.chSHD.UseVisualStyleBackColor = true;
            // 
            // chTIGLOBAL
            // 
            this.chTIGLOBAL.AutoSize = true;
            this.chTIGLOBAL.Location = new System.Drawing.Point(225, 265);
            this.chTIGLOBAL.Name = "chTIGLOBAL";
            this.chTIGLOBAL.Size = new System.Drawing.Size(78, 17);
            this.chTIGLOBAL.TabIndex = 18;
            this.chTIGLOBAL.Text = "TIGLOBAL";
            this.chTIGLOBAL.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filtro de datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Exportar Csv a Sql Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Eliminar registros en Sql Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Procesar Informacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "Procesamiento de datos";
            // 
            // pctProcesamiento
            // 
            this.pctProcesamiento.Image = global::AppUnirExcel.Properties.Resources.ajax_loader_gray_256;
            this.pctProcesamiento.Location = new System.Drawing.Point(369, 305);
            this.pctProcesamiento.Name = "pctProcesamiento";
            this.pctProcesamiento.Size = new System.Drawing.Size(60, 58);
            this.pctProcesamiento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctProcesamiento.TabIndex = 24;
            this.pctProcesamiento.TabStop = false;
            this.pctProcesamiento.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 375);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pctProcesamiento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chTIGLOBAL);
            this.Controls.Add(this.chSHD);
            this.Controls.Add(this.chRUNT);
            this.Controls.Add(this.chRUES);
            this.Controls.Add(this.chREGISTRO_BICI);
            this.Controls.Add(this.chPICO_PLACA);
            this.Controls.Add(this.chLICENCIAS);
            this.Controls.Add(this.chDATACREDITO);
            this.Controls.Add(this.chCIFIN);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnProcesarResultados);
            this.Controls.Add(this.btnEliminarRegistrosSql);
            this.Controls.Add(this.btnExportarCsvSql);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "App";
            ((System.ComponentModel.ISupportInitialize)(this.pctProcesamiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnExportarCsvSql;
        private System.Windows.Forms.Button btnEliminarRegistrosSql;
        private System.Windows.Forms.Button btnProcesarResultados;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.CheckBox chCIFIN;
        private System.Windows.Forms.CheckBox chDATACREDITO;
        private System.Windows.Forms.CheckBox chLICENCIAS;
        private System.Windows.Forms.CheckBox chPICO_PLACA;
        private System.Windows.Forms.CheckBox chREGISTRO_BICI;
        private System.Windows.Forms.CheckBox chRUES;
        private System.Windows.Forms.CheckBox chRUNT;
        private System.Windows.Forms.CheckBox chSHD;
        private System.Windows.Forms.CheckBox chTIGLOBAL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pctProcesamiento;
        private System.Windows.Forms.Button button1;
    }
}

