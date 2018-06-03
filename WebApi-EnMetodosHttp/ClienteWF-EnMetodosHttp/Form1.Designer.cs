namespace ClienteWF_EnMetodosHttp
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbNombre = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbIntensidad = new System.Windows.Forms.TextBox();
            this.lbIntensidad = new System.Windows.Forms.Label();
            this.tbTipo = new System.Windows.Forms.TextBox();
            this.lbTipo = new System.Windows.Forms.Label();
            this.cbEsBrilloso = new System.Windows.Forms.CheckBox();
            this.lbEsBrilloso = new System.Windows.Forms.Label();
            this.colorDg = new System.Windows.Forms.ColorDialog();
            this.btnSelecColor = new System.Windows.Forms.Button();
            this.tbColorSeleccionado = new System.Windows.Forms.TextBox();
            this.lbInfoApi = new System.Windows.Forms.Label();
            this.tbInfoUri = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.lbId = new System.Windows.Forms.Label();
            this.btnGET = new System.Windows.Forms.Button();
            this.btnPOST = new System.Windows.Forms.Button();
            this.btnPUT = new System.Windows.Forms.Button();
            this.btnDELETE = new System.Windows.Forms.Button();
            this.lbTipoApi = new System.Windows.Forms.Label();
            this.cbTipoApi = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(115, 111);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(44, 13);
            this.lbNombre.TabIndex = 0;
            this.lbNombre.Text = "Nombre";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(218, 108);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(161, 20);
            this.tbNombre.TabIndex = 1;
            // 
            // tbIntensidad
            // 
            this.tbIntensidad.Location = new System.Drawing.Point(218, 139);
            this.tbIntensidad.Name = "tbIntensidad";
            this.tbIntensidad.Size = new System.Drawing.Size(161, 20);
            this.tbIntensidad.TabIndex = 3;
            // 
            // lbIntensidad
            // 
            this.lbIntensidad.AutoSize = true;
            this.lbIntensidad.Location = new System.Drawing.Point(103, 142);
            this.lbIntensidad.Name = "lbIntensidad";
            this.lbIntensidad.Size = new System.Drawing.Size(56, 13);
            this.lbIntensidad.TabIndex = 2;
            this.lbIntensidad.Text = "Intensidad";
            // 
            // tbTipo
            // 
            this.tbTipo.Location = new System.Drawing.Point(218, 168);
            this.tbTipo.Name = "tbTipo";
            this.tbTipo.Size = new System.Drawing.Size(161, 20);
            this.tbTipo.TabIndex = 5;
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Location = new System.Drawing.Point(131, 171);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(28, 13);
            this.lbTipo.TabIndex = 4;
            this.lbTipo.Text = "Tipo";
            // 
            // cbEsBrilloso
            // 
            this.cbEsBrilloso.AutoSize = true;
            this.cbEsBrilloso.Location = new System.Drawing.Point(218, 201);
            this.cbEsBrilloso.Name = "cbEsBrilloso";
            this.cbEsBrilloso.Size = new System.Drawing.Size(15, 14);
            this.cbEsBrilloso.TabIndex = 7;
            this.cbEsBrilloso.UseVisualStyleBackColor = true;
            // 
            // lbEsBrilloso
            // 
            this.lbEsBrilloso.AutoSize = true;
            this.lbEsBrilloso.Location = new System.Drawing.Point(105, 201);
            this.lbEsBrilloso.Name = "lbEsBrilloso";
            this.lbEsBrilloso.Size = new System.Drawing.Size(54, 13);
            this.lbEsBrilloso.TabIndex = 8;
            this.lbEsBrilloso.Text = "Es brilloso";
            // 
            // btnSelecColor
            // 
            this.btnSelecColor.Location = new System.Drawing.Point(47, 224);
            this.btnSelecColor.Name = "btnSelecColor";
            this.btnSelecColor.Size = new System.Drawing.Size(112, 23);
            this.btnSelecColor.TabIndex = 9;
            this.btnSelecColor.Text = "Selecciona color";
            this.btnSelecColor.UseVisualStyleBackColor = true;
            this.btnSelecColor.Click += new System.EventHandler(this.btnSelecColor_Click);
            // 
            // tbColorSeleccionado
            // 
            this.tbColorSeleccionado.BackColor = System.Drawing.SystemColors.Window;
            this.tbColorSeleccionado.Location = new System.Drawing.Point(218, 227);
            this.tbColorSeleccionado.Name = "tbColorSeleccionado";
            this.tbColorSeleccionado.ReadOnly = true;
            this.tbColorSeleccionado.Size = new System.Drawing.Size(161, 20);
            this.tbColorSeleccionado.TabIndex = 10;
            // 
            // lbInfoApi
            // 
            this.lbInfoApi.AutoSize = true;
            this.lbInfoApi.Location = new System.Drawing.Point(13, 19);
            this.lbInfoApi.Name = "lbInfoApi";
            this.lbInfoApi.Size = new System.Drawing.Size(148, 13);
            this.lbInfoApi.TabIndex = 11;
            this.lbInfoApi.Text = "URI de API WEB configurada";
            // 
            // tbInfoUri
            // 
            this.tbInfoUri.Location = new System.Drawing.Point(218, 16);
            this.tbInfoUri.Name = "tbInfoUri";
            this.tbInfoUri.ReadOnly = true;
            this.tbInfoUri.Size = new System.Drawing.Size(161, 20);
            this.tbInfoUri.TabIndex = 12;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(218, 77);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(161, 20);
            this.tbId.TabIndex = 14;
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(143, 80);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(16, 13);
            this.lbId.TabIndex = 13;
            this.lbId.Text = "Id";
            // 
            // btnGET
            // 
            this.btnGET.BackColor = System.Drawing.Color.Chartreuse;
            this.btnGET.Location = new System.Drawing.Point(71, 262);
            this.btnGET.Name = "btnGET";
            this.btnGET.Size = new System.Drawing.Size(45, 23);
            this.btnGET.TabIndex = 15;
            this.btnGET.Text = "GET";
            this.btnGET.UseVisualStyleBackColor = false;
            this.btnGET.Click += new System.EventHandler(this.btnGET_Click);
            // 
            // btnPOST
            // 
            this.btnPOST.BackColor = System.Drawing.Color.Chartreuse;
            this.btnPOST.Location = new System.Drawing.Point(134, 262);
            this.btnPOST.Name = "btnPOST";
            this.btnPOST.Size = new System.Drawing.Size(45, 23);
            this.btnPOST.TabIndex = 16;
            this.btnPOST.Text = "POST";
            this.btnPOST.UseVisualStyleBackColor = false;
            this.btnPOST.Click += new System.EventHandler(this.btnPOST_Click);
            // 
            // btnPUT
            // 
            this.btnPUT.BackColor = System.Drawing.Color.Chartreuse;
            this.btnPUT.Location = new System.Drawing.Point(201, 262);
            this.btnPUT.Name = "btnPUT";
            this.btnPUT.Size = new System.Drawing.Size(45, 23);
            this.btnPUT.TabIndex = 17;
            this.btnPUT.Text = "PUT";
            this.btnPUT.UseVisualStyleBackColor = false;
            this.btnPUT.Click += new System.EventHandler(this.btnPUT_Click);
            // 
            // btnDELETE
            // 
            this.btnDELETE.BackColor = System.Drawing.Color.Chartreuse;
            this.btnDELETE.Location = new System.Drawing.Point(262, 262);
            this.btnDELETE.Name = "btnDELETE";
            this.btnDELETE.Size = new System.Drawing.Size(58, 23);
            this.btnDELETE.TabIndex = 18;
            this.btnDELETE.Text = "DELETE";
            this.btnDELETE.UseVisualStyleBackColor = false;
            this.btnDELETE.Click += new System.EventHandler(this.btnDELETE_Click);
            // 
            // lbTipoApi
            // 
            this.lbTipoApi.AutoSize = true;
            this.lbTipoApi.Location = new System.Drawing.Point(53, 48);
            this.lbTipoApi.Name = "lbTipoApi";
            this.lbTipoApi.Size = new System.Drawing.Size(108, 13);
            this.lbTipoApi.TabIndex = 19;
            this.lbTipoApi.Text = "Tipo de Enrutamiento";
            // 
            // cbTipoApi
            // 
            this.cbTipoApi.FormattingEnabled = true;
            this.cbTipoApi.Items.AddRange(new object[] {
            "Métodos HTTP",
            "Nombres de Acciones",
            "Atributo"});
            this.cbTipoApi.Location = new System.Drawing.Point(218, 45);
            this.cbTipoApi.Name = "cbTipoApi";
            this.cbTipoApi.Size = new System.Drawing.Size(161, 21);
            this.cbTipoApi.TabIndex = 20;
            this.cbTipoApi.SelectedIndexChanged += new System.EventHandler(this.cbTipoApi_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(391, 288);
            this.Controls.Add(this.cbTipoApi);
            this.Controls.Add(this.lbTipoApi);
            this.Controls.Add(this.btnDELETE);
            this.Controls.Add(this.btnPUT);
            this.Controls.Add(this.btnPOST);
            this.Controls.Add(this.btnGET);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.lbId);
            this.Controls.Add(this.tbInfoUri);
            this.Controls.Add(this.lbInfoApi);
            this.Controls.Add(this.tbColorSeleccionado);
            this.Controls.Add(this.btnSelecColor);
            this.Controls.Add(this.lbEsBrilloso);
            this.Controls.Add(this.cbEsBrilloso);
            this.Controls.Add(this.tbTipo);
            this.Controls.Add(this.lbTipo);
            this.Controls.Add(this.tbIntensidad);
            this.Controls.Add(this.lbIntensidad);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lbNombre);
            this.Name = "Form1";
            this.Text = "Administrador de colores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbIntensidad;
        private System.Windows.Forms.Label lbIntensidad;
        private System.Windows.Forms.TextBox tbTipo;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.CheckBox cbEsBrilloso;
        private System.Windows.Forms.Label lbEsBrilloso;
        private System.Windows.Forms.ColorDialog colorDg;
        private System.Windows.Forms.Button btnSelecColor;
        private System.Windows.Forms.TextBox tbColorSeleccionado;
        private System.Windows.Forms.Label lbInfoApi;
        private System.Windows.Forms.TextBox tbInfoUri;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Button btnGET;
        private System.Windows.Forms.Button btnPOST;
        private System.Windows.Forms.Button btnPUT;
        private System.Windows.Forms.Button btnDELETE;
        private System.Windows.Forms.Label lbTipoApi;
        private System.Windows.Forms.ComboBox cbTipoApi;
    }
}

