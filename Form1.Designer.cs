namespace projeto_integrador_entrega1
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxPartidas = new System.Windows.Forms.ListBox();
            this.lblNomePartida = new System.Windows.Forms.Label();
            this.lblDataPartida = new System.Windows.Forms.Label();
            this.lblStatusPartida = new System.Windows.Forms.Label();
            this.listBoxJogadores = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnVerMao = new System.Windows.Forms.Button();
            this.lblMeuId = new System.Windows.Forms.Label();
            this.lblMinhaSenha = new System.Windows.Forms.Label();
            this.lstMao = new System.Windows.Forms.ListBox();
            this.lblinfot = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTurnoInfo = new System.Windows.Forms.Label();
            this.cmbDino = new System.Windows.Forms.ComboBox();
            this.btnVerificarTurno = new System.Windows.Forms.Button();
            this.cmbCercado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCarregarMao = new System.Windows.Forms.Button();
            this.btnJogar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnVerTabuleiro = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnAdicionarJogador = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTabuleiro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(225, 284);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Listar Partidas";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxPartidas
            // 
            this.listBoxPartidas.BackColor = System.Drawing.Color.PowderBlue;
            this.listBoxPartidas.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPartidas.FormattingEnabled = true;
            this.listBoxPartidas.ItemHeight = 15;
            this.listBoxPartidas.Location = new System.Drawing.Point(10, 280);
            this.listBoxPartidas.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxPartidas.Name = "listBoxPartidas";
            this.listBoxPartidas.Size = new System.Drawing.Size(194, 244);
            this.listBoxPartidas.TabIndex = 2;
            this.listBoxPartidas.Click += new System.EventHandler(this.listBoxPartidas_SelectedIndexChanged);
            this.listBoxPartidas.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblNomePartida
            // 
            this.lblNomePartida.AutoSize = true;
            this.lblNomePartida.BackColor = System.Drawing.Color.Aquamarine;
            this.lblNomePartida.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomePartida.Location = new System.Drawing.Point(244, 360);
            this.lblNomePartida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNomePartida.Name = "lblNomePartida";
            this.lblNomePartida.Size = new System.Drawing.Size(12, 15);
            this.lblNomePartida.TabIndex = 3;
            this.lblNomePartida.Text = "-";
            this.lblNomePartida.Click += new System.EventHandler(this.lblNomePartida_Click);
            // 
            // lblDataPartida
            // 
            this.lblDataPartida.AutoSize = true;
            this.lblDataPartida.BackColor = System.Drawing.Color.Aquamarine;
            this.lblDataPartida.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataPartida.Location = new System.Drawing.Point(244, 389);
            this.lblDataPartida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataPartida.Name = "lblDataPartida";
            this.lblDataPartida.Size = new System.Drawing.Size(12, 15);
            this.lblDataPartida.TabIndex = 4;
            this.lblDataPartida.Text = "-";
            // 
            // lblStatusPartida
            // 
            this.lblStatusPartida.AutoSize = true;
            this.lblStatusPartida.BackColor = System.Drawing.Color.Aquamarine;
            this.lblStatusPartida.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusPartida.Location = new System.Drawing.Point(244, 423);
            this.lblStatusPartida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusPartida.Name = "lblStatusPartida";
            this.lblStatusPartida.Size = new System.Drawing.Size(12, 15);
            this.lblStatusPartida.TabIndex = 5;
            this.lblStatusPartida.Text = "-";
            // 
            // listBoxJogadores
            // 
            this.listBoxJogadores.BackColor = System.Drawing.Color.PowderBlue;
            this.listBoxJogadores.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxJogadores.FormattingEnabled = true;
            this.listBoxJogadores.ItemHeight = 15;
            this.listBoxJogadores.Location = new System.Drawing.Point(10, 130);
            this.listBoxJogadores.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxJogadores.Name = "listBoxJogadores";
            this.listBoxJogadores.Size = new System.Drawing.Size(139, 109);
            this.listBoxJogadores.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 7;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(11, 241);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Partidas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(11, 100);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Jogadores";
            // 
            // btnVerMao
            // 
            this.btnVerMao.Location = new System.Drawing.Point(470, 457);
            this.btnVerMao.Name = "btnVerMao";
            this.btnVerMao.Size = new System.Drawing.Size(75, 23);
            this.btnVerMao.TabIndex = 21;
            this.btnVerMao.Text = "Ver Mão";
            this.btnVerMao.UseVisualStyleBackColor = true;
            this.btnVerMao.Click += new System.EventHandler(this.btnVerMao_Click);
            // 
            // lblMeuId
            // 
            this.lblMeuId.AutoSize = true;
            this.lblMeuId.Location = new System.Drawing.Point(198, 113);
            this.lblMeuId.Name = "lblMeuId";
            this.lblMeuId.Size = new System.Drawing.Size(10, 13);
            this.lblMeuId.TabIndex = 22;
            this.lblMeuId.Text = "-";
            this.lblMeuId.Click += new System.EventHandler(this.lblMeuId_Click);
            // 
            // lblMinhaSenha
            // 
            this.lblMinhaSenha.AutoSize = true;
            this.lblMinhaSenha.Location = new System.Drawing.Point(198, 170);
            this.lblMinhaSenha.Name = "lblMinhaSenha";
            this.lblMinhaSenha.Size = new System.Drawing.Size(10, 13);
            this.lblMinhaSenha.TabIndex = 23;
            this.lblMinhaSenha.Text = "-";
            this.lblMinhaSenha.Click += new System.EventHandler(this.lblMinhaSenha_Click);
            // 
            // lstMao
            // 
            this.lstMao.FormattingEnabled = true;
            this.lstMao.Location = new System.Drawing.Point(331, 360);
            this.lstMao.Name = "lstMao";
            this.lstMao.Size = new System.Drawing.Size(377, 82);
            this.lstMao.TabIndex = 24;
            // 
            // lblinfot
            // 
            this.lblinfot.AutoSize = true;
            this.lblinfot.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfot.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblinfot.Location = new System.Drawing.Point(675, 262);
            this.lblinfot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblinfot.Name = "lblinfot";
            this.lblinfot.Size = new System.Drawing.Size(147, 16);
            this.lblinfot.TabIndex = 26;
            this.lblinfot.Text = "Informações do turno";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(447, 329);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "Mão do Jogador";
            this.label11.Click += new System.EventHandler(this.label11_Click_1);
            // 
            // lblTurnoInfo
            // 
            this.lblTurnoInfo.AutoSize = true;
            this.lblTurnoInfo.Location = new System.Drawing.Point(814, 301);
            this.lblTurnoInfo.Name = "lblTurnoInfo";
            this.lblTurnoInfo.Size = new System.Drawing.Size(31, 13);
            this.lblTurnoInfo.TabIndex = 28;
            this.lblTurnoInfo.Text = "turno";
            // 
            // cmbDino
            // 
            this.cmbDino.FormattingEnabled = true;
            this.cmbDino.Location = new System.Drawing.Point(711, 64);
            this.cmbDino.Name = "cmbDino";
            this.cmbDino.Size = new System.Drawing.Size(121, 21);
            this.cmbDino.TabIndex = 29;
            this.cmbDino.Text = "Dinossauro";
            this.cmbDino.SelectedIndexChanged += new System.EventHandler(this.cmbDino_SelectedIndexChanged);
            // 
            // btnVerificarTurno
            // 
            this.btnVerificarTurno.Location = new System.Drawing.Point(678, 292);
            this.btnVerificarTurno.Name = "btnVerificarTurno";
            this.btnVerificarTurno.Size = new System.Drawing.Size(115, 31);
            this.btnVerificarTurno.TabIndex = 30;
            this.btnVerificarTurno.Text = "Verificar Turno";
            this.btnVerificarTurno.UseVisualStyleBackColor = true;
            // 
            // cmbCercado
            // 
            this.cmbCercado.FormattingEnabled = true;
            this.cmbCercado.Location = new System.Drawing.Point(711, 113);
            this.cmbCercado.Name = "cmbCercado";
            this.cmbCercado.Size = new System.Drawing.Size(121, 21);
            this.cmbCercado.TabIndex = 31;
            this.cmbCercado.Text = "Cercado";
            this.cmbCercado.SelectedIndexChanged += new System.EventHandler(this.cmbCercado_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(708, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Dinossauro";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(708, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Cercado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(708, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(708, 13);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 32);
            this.label12.TabIndex = 35;
            this.label12.Text = "Realizar Jogada\r\n\r\n";
            // 
            // btnCarregarMao
            // 
            this.btnCarregarMao.Location = new System.Drawing.Point(660, 195);
            this.btnCarregarMao.Name = "btnCarregarMao";
            this.btnCarregarMao.Size = new System.Drawing.Size(95, 25);
            this.btnCarregarMao.TabIndex = 36;
            this.btnCarregarMao.Text = "Carregar Mão";
            this.btnCarregarMao.UseVisualStyleBackColor = true;
            this.btnCarregarMao.Click += new System.EventHandler(this.btnCarregarMao_Click);
            // 
            // btnJogar
            // 
            this.btnJogar.Location = new System.Drawing.Point(798, 195);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(95, 25);
            this.btnJogar.TabIndex = 37;
            this.btnJogar.Text = "Jogar";
            this.btnJogar.UseVisualStyleBackColor = true;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(439, 296);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 39;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(438, 58);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 16);
            this.label14.TabIndex = 40;
            this.label14.Text = "Tabuleiro";
            // 
            // btnVerTabuleiro
            // 
            this.btnVerTabuleiro.Location = new System.Drawing.Point(415, 253);
            this.btnVerTabuleiro.Name = "btnVerTabuleiro";
            this.btnVerTabuleiro.Size = new System.Drawing.Size(95, 25);
            this.btnVerTabuleiro.TabIndex = 41;
            this.btnVerTabuleiro.Text = "Ver Tabuleiro";
            this.btnVerTabuleiro.UseVisualStyleBackColor = true;
            this.btnVerTabuleiro.Click += new System.EventHandler(this.btnVerTabuleiro_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(396, 8);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(110, 33);
            this.btnIniciar.TabIndex = 42;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click_1);
            // 
            // btnAdicionarJogador
            // 
            this.btnAdicionarJogador.Location = new System.Drawing.Point(773, 491);
            this.btnAdicionarJogador.Name = "btnAdicionarJogador";
            this.btnAdicionarJogador.Size = new System.Drawing.Size(115, 32);
            this.btnAdicionarJogador.TabIndex = 43;
            this.btnAdicionarJogador.Text = "Adicionar Jogador";
            this.btnAdicionarJogador.UseVisualStyleBackColor = true;
            this.btnAdicionarJogador.Click += new System.EventHandler(this.btnAdicionarJogador_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 31);
            this.label1.TabIndex = 44;
            this.label1.Text = "COLOSSAIS";
            // 
            // txtTabuleiro
            // 
            this.txtTabuleiro.Location = new System.Drawing.Point(316, 79);
            this.txtTabuleiro.Multiline = true;
            this.txtTabuleiro.Name = "txtTabuleiro";
            this.txtTabuleiro.Size = new System.Drawing.Size(293, 168);
            this.txtTabuleiro.TabIndex = 38;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(900, 535);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdicionarJogador);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnVerTabuleiro);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTabuleiro);
            this.Controls.Add(this.btnJogar);
            this.Controls.Add(this.btnCarregarMao);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbCercado);
            this.Controls.Add(this.btnVerificarTurno);
            this.Controls.Add(this.cmbDino);
            this.Controls.Add(this.lblTurnoInfo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblinfot);
            this.Controls.Add(this.lstMao);
            this.Controls.Add(this.lblMinhaSenha);
            this.Controls.Add(this.lblMeuId);
            this.Controls.Add(this.btnVerMao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxJogadores);
            this.Controls.Add(this.lblStatusPartida);
            this.Controls.Add(this.lblDataPartida);
            this.Controls.Add(this.lblNomePartida);
            this.Controls.Add(this.listBoxPartidas);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxPartidas;
        private System.Windows.Forms.Label lblNomePartida;
        private System.Windows.Forms.Label lblDataPartida;
        private System.Windows.Forms.Label lblStatusPartida;
        private System.Windows.Forms.ListBox listBoxJogadores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVerMao;
        private System.Windows.Forms.Label lblMeuId;
        private System.Windows.Forms.Label lblMinhaSenha;
        private System.Windows.Forms.ListBox lstMao;
        private System.Windows.Forms.Label lblinfot;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTurnoInfo;
        private System.Windows.Forms.ComboBox cmbDino;
        private System.Windows.Forms.Button btnVerificarTurno;
        private System.Windows.Forms.ComboBox cmbCercado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCarregarMao;
        private System.Windows.Forms.Button btnJogar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnVerTabuleiro;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnAdicionarJogador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTabuleiro;
    }
}

