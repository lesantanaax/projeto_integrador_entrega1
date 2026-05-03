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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.list = new System.Windows.Forms.ListBox();
            this.lblNomePartida = new System.Windows.Forms.Label();
            this.lblDataPartida = new System.Windows.Forms.Label();
            this.lblStatusPartida = new System.Windows.Forms.Label();
            this.listPlayers = new System.Windows.Forms.ListBox();
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
            this.btnVerTabuleiro = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnAdicionarJogador = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTabuleiro = new System.Windows.Forms.TextBox();
            this.tmrPrincipal = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(235, 463);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(207, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Listar Partidas";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Window;
            this.list.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.FormattingEnabled = true;
            this.list.ItemHeight = 20;
            this.list.Location = new System.Drawing.Point(235, 175);
            this.list.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(207, 284);
            this.list.TabIndex = 2;
            this.list.Click += new System.EventHandler(this.listBoxPartidas_SelectedIndexChanged);
            this.list.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblNomePartida
            // 
            this.lblNomePartida.AutoSize = true;
            this.lblNomePartida.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.lblNomePartida.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomePartida.Location = new System.Drawing.Point(476, 209);
            this.lblNomePartida.Name = "lblNomePartida";
            this.lblNomePartida.Size = new System.Drawing.Size(15, 20);
            this.lblNomePartida.TabIndex = 3;
            this.lblNomePartida.Text = "-";
            this.lblNomePartida.Click += new System.EventHandler(this.lblNomePartida_Click);
            // 
            // lblDataPartida
            // 
            this.lblDataPartida.AutoSize = true;
            this.lblDataPartida.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.lblDataPartida.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataPartida.Location = new System.Drawing.Point(476, 295);
            this.lblDataPartida.Name = "lblDataPartida";
            this.lblDataPartida.Size = new System.Drawing.Size(15, 20);
            this.lblDataPartida.TabIndex = 4;
            this.lblDataPartida.Text = "-";
            // 
            // lblStatusPartida
            // 
            this.lblStatusPartida.AutoSize = true;
            this.lblStatusPartida.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.lblStatusPartida.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusPartida.Location = new System.Drawing.Point(476, 376);
            this.lblStatusPartida.Name = "lblStatusPartida";
            this.lblStatusPartida.Size = new System.Drawing.Size(15, 20);
            this.lblStatusPartida.TabIndex = 5;
            this.lblStatusPartida.Text = "-";
            // 
            // listPlayers
            // 
            this.listPlayers.BackColor = System.Drawing.SystemColors.Window;
            this.listPlayers.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlayers.FormattingEnabled = true;
            this.listPlayers.ItemHeight = 20;
            this.listPlayers.Location = new System.Drawing.Point(767, 175);
            this.listPlayers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listPlayers.Name = "listPlayers";
            this.listPlayers.Size = new System.Drawing.Size(207, 284);
            this.listPlayers.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 7;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Emoji", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(283, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 31);
            this.label6.TabIndex = 9;
            this.label6.Text = "Partidas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Emoji", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(805, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 31);
            this.label7.TabIndex = 10;
            this.label7.Text = "Jogadores";
            // 
            // btnVerMao
            // 
            this.btnVerMao.Location = new System.Drawing.Point(1388, 387);
            this.btnVerMao.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerMao.Name = "btnVerMao";
            this.btnVerMao.Size = new System.Drawing.Size(100, 28);
            this.btnVerMao.TabIndex = 21;
            this.btnVerMao.Text = "Ver Mão";
            this.btnVerMao.UseVisualStyleBackColor = true;
            this.btnVerMao.Click += new System.EventHandler(this.btnVerMao_Click);
            // 
            // lblMeuId
            // 
            this.lblMeuId.AutoSize = true;
            this.lblMeuId.Location = new System.Drawing.Point(1014, 212);
            this.lblMeuId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMeuId.Name = "lblMeuId";
            this.lblMeuId.Size = new System.Drawing.Size(11, 16);
            this.lblMeuId.TabIndex = 22;
            this.lblMeuId.Text = "-";
            this.lblMeuId.Click += new System.EventHandler(this.lblMeuId_Click);
            // 
            // lblMinhaSenha
            // 
            this.lblMinhaSenha.AutoSize = true;
            this.lblMinhaSenha.Location = new System.Drawing.Point(1014, 299);
            this.lblMinhaSenha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinhaSenha.Name = "lblMinhaSenha";
            this.lblMinhaSenha.Size = new System.Drawing.Size(11, 16);
            this.lblMinhaSenha.TabIndex = 23;
            this.lblMinhaSenha.Text = "-";
            this.lblMinhaSenha.Click += new System.EventHandler(this.lblMinhaSenha_Click);
            // 
            // lstMao
            // 
            this.lstMao.FormattingEnabled = true;
            this.lstMao.ItemHeight = 16;
            this.lstMao.Location = new System.Drawing.Point(520, 526);
            this.lstMao.Margin = new System.Windows.Forms.Padding(4);
            this.lstMao.Name = "lstMao";
            this.lstMao.Size = new System.Drawing.Size(267, 100);
            this.lstMao.TabIndex = 24;
            // 
            // lblinfot
            // 
            this.lblinfot.AutoSize = true;
            this.lblinfot.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfot.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblinfot.Location = new System.Drawing.Point(1369, 439);
            this.lblinfot.Name = "lblinfot";
            this.lblinfot.Size = new System.Drawing.Size(175, 20);
            this.lblinfot.TabIndex = 26;
            this.lblinfot.Text = "Informações do turno";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(571, 486);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 20);
            this.label11.TabIndex = 27;
            this.label11.Text = "Mão do Jogador";
            this.label11.Click += new System.EventHandler(this.label11_Click_1);
            // 
            // lblTurnoInfo
            // 
            this.lblTurnoInfo.AutoSize = true;
            this.lblTurnoInfo.Location = new System.Drawing.Point(1522, 493);
            this.lblTurnoInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTurnoInfo.Name = "lblTurnoInfo";
            this.lblTurnoInfo.Size = new System.Drawing.Size(36, 16);
            this.lblTurnoInfo.TabIndex = 28;
            this.lblTurnoInfo.Text = "turno";
            // 
            // cmbDino
            // 
            this.cmbDino.FormattingEnabled = true;
            this.cmbDino.Location = new System.Drawing.Point(1418, 117);
            this.cmbDino.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDino.Name = "cmbDino";
            this.cmbDino.Size = new System.Drawing.Size(160, 24);
            this.cmbDino.TabIndex = 29;
            this.cmbDino.Text = "Dinossauro";
            this.cmbDino.SelectedIndexChanged += new System.EventHandler(this.cmbDino_SelectedIndexChanged);
            // 
            // btnVerificarTurno
            // 
            this.btnVerificarTurno.Location = new System.Drawing.Point(1361, 471);
            this.btnVerificarTurno.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerificarTurno.Name = "btnVerificarTurno";
            this.btnVerificarTurno.Size = new System.Drawing.Size(153, 38);
            this.btnVerificarTurno.TabIndex = 30;
            this.btnVerificarTurno.Text = "Verificar Turno";
            this.btnVerificarTurno.UseVisualStyleBackColor = true;
            // 
            // cmbCercado
            // 
            this.cmbCercado.FormattingEnabled = true;
            this.cmbCercado.Location = new System.Drawing.Point(1429, 181);
            this.cmbCercado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCercado.Name = "cmbCercado";
            this.cmbCercado.Size = new System.Drawing.Size(160, 24);
            this.cmbCercado.TabIndex = 31;
            this.cmbCercado.Text = "Cercado";
            this.cmbCercado.SelectedIndexChanged += new System.EventHandler(this.cmbCercado_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1473, 89);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 32;
            this.label8.Text = "Dinossauro";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1473, 145);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 33;
            this.label9.Text = "Cercado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(944, 11);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 16);
            this.label10.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(1445, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 40);
            this.label12.TabIndex = 35;
            this.label12.Text = "Realizar Jogada\r\n\r\n";
            // 
            // btnCarregarMao
            // 
            this.btnCarregarMao.Location = new System.Drawing.Point(1361, 272);
            this.btnCarregarMao.Margin = new System.Windows.Forms.Padding(4);
            this.btnCarregarMao.Name = "btnCarregarMao";
            this.btnCarregarMao.Size = new System.Drawing.Size(127, 31);
            this.btnCarregarMao.TabIndex = 36;
            this.btnCarregarMao.Text = "Carregar Mão";
            this.btnCarregarMao.UseVisualStyleBackColor = true;
            this.btnCarregarMao.Click += new System.EventHandler(this.btnCarregarMao_Click);
            // 
            // btnJogar
            // 
            this.btnJogar.Location = new System.Drawing.Point(1496, 272);
            this.btnJogar.Margin = new System.Windows.Forms.Padding(4);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(127, 31);
            this.btnJogar.TabIndex = 37;
            this.btnJogar.Text = "Jogar";
            this.btnJogar.UseVisualStyleBackColor = true;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(585, 364);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 16);
            this.label13.TabIndex = 39;
            // 
            // btnVerTabuleiro
            // 
            this.btnVerTabuleiro.Location = new System.Drawing.Point(1417, 639);
            this.btnVerTabuleiro.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerTabuleiro.Name = "btnVerTabuleiro";
            this.btnVerTabuleiro.Size = new System.Drawing.Size(127, 31);
            this.btnVerTabuleiro.TabIndex = 41;
            this.btnVerTabuleiro.Text = "Ver Tabuleiro";
            this.btnVerTabuleiro.UseVisualStyleBackColor = true;
            this.btnVerTabuleiro.Click += new System.EventHandler(this.btnVerTabuleiro_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.SystemColors.Window;
            this.btnIniciar.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.Color.Green;
            this.btnIniciar.Location = new System.Drawing.Point(705, 653);
            this.btnIniciar.Margin = new System.Windows.Forms.Padding(4);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(211, 50);
            this.btnIniciar.TabIndex = 42;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click_1);
            // 
            // btnAdicionarJogador
            // 
            this.btnAdicionarJogador.BackColor = System.Drawing.SystemColors.Window;
            this.btnAdicionarJogador.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarJogador.ForeColor = System.Drawing.Color.Green;
            this.btnAdicionarJogador.Location = new System.Drawing.Point(367, 653);
            this.btnAdicionarJogador.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdicionarJogador.Name = "btnAdicionarJogador";
            this.btnAdicionarJogador.Size = new System.Drawing.Size(208, 50);
            this.btnAdicionarJogador.TabIndex = 43;
            this.btnAdicionarJogador.Text = "Adicionar Jogador";
            this.btnAdicionarJogador.UseVisualStyleBackColor = false;
            this.btnAdicionarJogador.Click += new System.EventHandler(this.btnAdicionarJogador_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(487, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 47);
            this.label1.TabIndex = 44;
            this.label1.Text = "Colossais";
            // 
            // txtTabuleiro
            // 
            this.txtTabuleiro.Location = new System.Drawing.Point(1343, 561);
            this.txtTabuleiro.Margin = new System.Windows.Forms.Padding(4);
            this.txtTabuleiro.Multiline = true;
            this.txtTabuleiro.Name = "txtTabuleiro";
            this.txtTabuleiro.Size = new System.Drawing.Size(235, 130);
            this.txtTabuleiro.TabIndex = 38;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(1142, 771);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdicionarJogador);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnVerTabuleiro);
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
            this.Controls.Add(this.listPlayers);
            this.Controls.Add(this.lblStatusPartida);
            this.Controls.Add(this.lblDataPartida);
            this.Controls.Add(this.lblNomePartida);
            this.Controls.Add(this.list);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox list;
        private System.Windows.Forms.Label lblNomePartida;
        private System.Windows.Forms.Label lblDataPartida;
        private System.Windows.Forms.Label lblStatusPartida;
        private System.Windows.Forms.ListBox listPlayers;
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
        private System.Windows.Forms.Button btnVerTabuleiro;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnAdicionarJogador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTabuleiro;
        private System.Windows.Forms.Timer tmrPrincipal;
    }
}

