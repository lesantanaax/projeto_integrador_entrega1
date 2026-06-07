namespace projeto_integrador_entrega1
{
    partial class Form2
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
            this.txtnome = new System.Windows.Forms.TextBox();
            this.txtsenha = new System.Windows.Forms.TextBox();
            this.Btnentrar = new System.Windows.Forms.Button();
            this.btncriar = new System.Windows.Forms.Button();
            this.txtnomedapartida = new System.Windows.Forms.TextBox();
            this.lblNomeJogador = new System.Windows.Forms.Label();
            this.nomePartida = new System.Windows.Forms.Label();
            this.senha = new System.Windows.Forms.Label();
            this.lblLobby = new System.Windows.Forms.Label();
            this.idPartida = new System.Windows.Forms.Label();
            this.txtiddapartida = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtnome
            // 
            this.txtnome.Location = new System.Drawing.Point(313, 140);
            this.txtnome.Margin = new System.Windows.Forms.Padding(2);
            this.txtnome.Multiline = true;
            this.txtnome.Name = "txtnome";
            this.txtnome.Size = new System.Drawing.Size(182, 32);
            this.txtnome.TabIndex = 15;
            // 
            // txtsenha
            // 
            this.txtsenha.Location = new System.Drawing.Point(313, 314);
            this.txtsenha.Margin = new System.Windows.Forms.Padding(2);
            this.txtsenha.Multiline = true;
            this.txtsenha.Name = "txtsenha";
            this.txtsenha.Size = new System.Drawing.Size(182, 32);
            this.txtsenha.TabIndex = 19;
            // 
            // Btnentrar
            // 
            this.Btnentrar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Btnentrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnentrar.Location = new System.Drawing.Point(614, 308);
            this.Btnentrar.Name = "Btnentrar";
            this.Btnentrar.Size = new System.Drawing.Size(122, 54);
            this.Btnentrar.TabIndex = 21;
            this.Btnentrar.Text = "ENTRAR";
            this.Btnentrar.UseVisualStyleBackColor = false;
            this.Btnentrar.Click += new System.EventHandler(this.Btnentrar_Click_1);
            // 
            // btncriar
            // 
            this.btncriar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btncriar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncriar.Location = new System.Drawing.Point(614, 372);
            this.btncriar.Name = "btncriar";
            this.btncriar.Size = new System.Drawing.Size(122, 54);
            this.btncriar.TabIndex = 22;
            this.btncriar.Text = "CRIAR PARTIDA";
            this.btncriar.UseVisualStyleBackColor = false;
            this.btncriar.Click += new System.EventHandler(this.btncriar_Click);
            // 
            // txtnomedapartida
            // 
            this.txtnomedapartida.Location = new System.Drawing.Point(313, 260);
            this.txtnomedapartida.Margin = new System.Windows.Forms.Padding(2);
            this.txtnomedapartida.Multiline = true;
            this.txtnomedapartida.Name = "txtnomedapartida";
            this.txtnomedapartida.Size = new System.Drawing.Size(182, 32);
            this.txtnomedapartida.TabIndex = 24;
            // 
            // lblNomeJogador
            // 
            this.lblNomeJogador.AutoSize = true;
            this.lblNomeJogador.BackColor = System.Drawing.SystemColors.Info;
            this.lblNomeJogador.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeJogador.Location = new System.Drawing.Point(45, 147);
            this.lblNomeJogador.Name = "lblNomeJogador";
            this.lblNomeJogador.Size = new System.Drawing.Size(233, 25);
            this.lblNomeJogador.TabIndex = 25;
            this.lblNomeJogador.Text = "NOME DO JOGADOR :";
            // 
            // nomePartida
            // 
            this.nomePartida.AutoSize = true;
            this.nomePartida.BackColor = System.Drawing.SystemColors.Info;
            this.nomePartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomePartida.ForeColor = System.Drawing.SystemColors.WindowText;
            this.nomePartida.Location = new System.Drawing.Point(66, 267);
            this.nomePartida.Name = "nomePartida";
            this.nomePartida.Size = new System.Drawing.Size(212, 25);
            this.nomePartida.TabIndex = 26;
            this.nomePartida.Text = "NOME DA PARTIDA:";
            // 
            // senha
            // 
            this.senha.AutoSize = true;
            this.senha.BackColor = System.Drawing.SystemColors.Info;
            this.senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.senha.Location = new System.Drawing.Point(194, 321);
            this.senha.Name = "senha";
            this.senha.Size = new System.Drawing.Size(84, 25);
            this.senha.TabIndex = 27;
            this.senha.Text = "SENHA";
            // 
            // lblLobby
            // 
            this.lblLobby.AutoSize = true;
            this.lblLobby.BackColor = System.Drawing.SystemColors.Info;
            this.lblLobby.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLobby.Location = new System.Drawing.Point(192, 42);
            this.lblLobby.Name = "lblLobby";
            this.lblLobby.Size = new System.Drawing.Size(418, 37);
            this.lblLobby.TabIndex = 28;
            this.lblLobby.Text = "LOBBY DRAFTOSSAURUS";
            // 
            // idPartida
            // 
            this.idPartida.AutoSize = true;
            this.idPartida.BackColor = System.Drawing.SystemColors.Info;
            this.idPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPartida.Location = new System.Drawing.Point(103, 208);
            this.idPartida.Name = "idPartida";
            this.idPartida.Size = new System.Drawing.Size(175, 25);
            this.idPartida.TabIndex = 29;
            this.idPartida.Text = "ID DA PARTIDA :";
            this.idPartida.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtiddapartida
            // 
            this.txtiddapartida.Location = new System.Drawing.Point(313, 201);
            this.txtiddapartida.Margin = new System.Windows.Forms.Padding(2);
            this.txtiddapartida.Multiline = true;
            this.txtiddapartida.Name = "txtiddapartida";
            this.txtiddapartida.Size = new System.Drawing.Size(182, 32);
            this.txtiddapartida.TabIndex = 30;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.BackgroundImage = global::projeto_integrador_entrega1.Properties.Resources.draftosaurus_spel_koning_van_het_oerwoud;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(805, 438);
            this.Controls.Add(this.txtiddapartida);
            this.Controls.Add(this.idPartida);
            this.Controls.Add(this.lblLobby);
            this.Controls.Add(this.senha);
            this.Controls.Add(this.nomePartida);
            this.Controls.Add(this.lblNomeJogador);
            this.Controls.Add(this.txtnomedapartida);
            this.Controls.Add(this.btncriar);
            this.Controls.Add(this.Btnentrar);
            this.Controls.Add(this.txtsenha);
            this.Controls.Add(this.txtnome);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtnome;
        private System.Windows.Forms.TextBox txtsenha;
        private System.Windows.Forms.Button Btnentrar;
        private System.Windows.Forms.Button btncriar;
        private System.Windows.Forms.TextBox txtnomedapartida;
        private System.Windows.Forms.Label lblNomeJogador;
        private System.Windows.Forms.Label nomePartida;
        private System.Windows.Forms.Label senha;
        private System.Windows.Forms.Label lblLobby;
        private System.Windows.Forms.Label idPartida;
        private System.Windows.Forms.TextBox txtiddapartida;
    }
}