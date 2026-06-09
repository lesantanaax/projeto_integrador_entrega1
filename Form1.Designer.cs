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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxPartidas = new System.Windows.Forms.ListBox();
            this.lblNomePartida = new System.Windows.Forms.Label();
            this.lblDataPartida = new System.Windows.Forms.Label();
            this.lblStatusPartida = new System.Windows.Forms.Label();
            this.listBoxJogadores = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMeuId = new System.Windows.Forms.Label();
            this.lblMinhaSenha = new System.Windows.Forms.Label();
            this.lstMao = new System.Windows.Forms.ListBox();
            this.lblinfot = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTurnoInfo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnAdicionarJogador = new System.Windows.Forms.Button();
            this.txtTabuleiro = new System.Windows.Forms.TextBox();
            this.tmrPrincipal = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelMap = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblFaceDado = new System.Windows.Forms.Label();
            this.pbFaceDado = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelMap.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFaceDado)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(117)))), ((int)(((byte)(72)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(157)))), ((int)(((byte)(93)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(78)))), ((int)(((byte)(58)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(145)))), ((int)(((byte)(88)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.button1.Location = new System.Drawing.Point(205, 364);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Listar Partidas";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxPartidas
            // 
            this.listBoxPartidas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(64)))), ((int)(((byte)(48)))));
            this.listBoxPartidas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxPartidas.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPartidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.listBoxPartidas.FormattingEnabled = true;
            this.listBoxPartidas.Location = new System.Drawing.Point(2, 216);
            this.listBoxPartidas.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxPartidas.Name = "listBoxPartidas";
            this.listBoxPartidas.Size = new System.Drawing.Size(194, 184);
            this.listBoxPartidas.TabIndex = 2;
            this.listBoxPartidas.Click += new System.EventHandler(this.listBoxPartidas_SelectedIndexChanged);
            this.listBoxPartidas.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblNomePartida
            // 
            this.lblNomePartida.AutoSize = true;
            this.lblNomePartida.BackColor = System.Drawing.Color.Transparent;
            this.lblNomePartida.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomePartida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.lblNomePartida.Location = new System.Drawing.Point(202, 216);
            this.lblNomePartida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNomePartida.Name = "lblNomePartida";
            this.lblNomePartida.Size = new System.Drawing.Size(80, 15);
            this.lblNomePartida.TabIndex = 3;
            this.lblNomePartida.Text = "NomePartida";
            this.lblNomePartida.Click += new System.EventHandler(this.lblNomePartida_Click);
            // 
            // lblDataPartida
            // 
            this.lblDataPartida.AutoSize = true;
            this.lblDataPartida.BackColor = System.Drawing.Color.Transparent;
            this.lblDataPartida.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataPartida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.lblDataPartida.Location = new System.Drawing.Point(202, 240);
            this.lblDataPartida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataPartida.Name = "lblDataPartida";
            this.lblDataPartida.Size = new System.Drawing.Size(72, 15);
            this.lblDataPartida.TabIndex = 4;
            this.lblDataPartida.Text = "DataPartida";
            // 
            // lblStatusPartida
            // 
            this.lblStatusPartida.AutoSize = true;
            this.lblStatusPartida.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusPartida.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusPartida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.lblStatusPartida.Location = new System.Drawing.Point(202, 266);
            this.lblStatusPartida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusPartida.Name = "lblStatusPartida";
            this.lblStatusPartida.Size = new System.Drawing.Size(81, 15);
            this.lblStatusPartida.TabIndex = 5;
            this.lblStatusPartida.Text = "StatusPartida";
            // 
            // listBoxJogadores
            // 
            this.listBoxJogadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(64)))), ((int)(((byte)(48)))));
            this.listBoxJogadores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxJogadores.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxJogadores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.listBoxJogadores.FormattingEnabled = true;
            this.listBoxJogadores.Location = new System.Drawing.Point(2, 27);
            this.listBoxJogadores.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxJogadores.Name = "listBoxJogadores";
            this.listBoxJogadores.Size = new System.Drawing.Size(194, 80);
            this.listBoxJogadores.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(194)))), ((int)(((byte)(82)))));
            this.label6.Location = new System.Drawing.Point(7, 200);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Partidas";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(194)))), ((int)(((byte)(82)))));
            this.label7.Location = new System.Drawing.Point(7, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Jogadores";
            // 
            // lblMeuId
            // 
            this.lblMeuId.AutoSize = true;
            this.lblMeuId.BackColor = System.Drawing.Color.Transparent;
            this.lblMeuId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeuId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.lblMeuId.Location = new System.Drawing.Point(202, 38);
            this.lblMeuId.Name = "lblMeuId";
            this.lblMeuId.Size = new System.Drawing.Size(45, 13);
            this.lblMeuId.TabIndex = 22;
            this.lblMeuId.Text = "Meu ID";
            this.lblMeuId.Click += new System.EventHandler(this.lblMeuId_Click);
            // 
            // lblMinhaSenha
            // 
            this.lblMinhaSenha.AutoSize = true;
            this.lblMinhaSenha.BackColor = System.Drawing.Color.Transparent;
            this.lblMinhaSenha.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinhaSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.lblMinhaSenha.Location = new System.Drawing.Point(202, 85);
            this.lblMinhaSenha.Name = "lblMinhaSenha";
            this.lblMinhaSenha.Size = new System.Drawing.Size(76, 13);
            this.lblMinhaSenha.TabIndex = 23;
            this.lblMinhaSenha.Text = "Minha Senha";
            this.lblMinhaSenha.Click += new System.EventHandler(this.lblMinhaSenha_Click);
            // 
            // lstMao
            // 
            this.lstMao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(225)))));
            this.lstMao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstMao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(30)))));
            this.lstMao.FormattingEnabled = true;
            this.lstMao.ItemHeight = 15;
            this.lstMao.Location = new System.Drawing.Point(5, 159);
            this.lstMao.Name = "lstMao";
            this.lstMao.Size = new System.Drawing.Size(250, 287);
            this.lstMao.TabIndex = 24;
            // 
            // lblinfot
            // 
            this.lblinfot.AutoSize = true;
            this.lblinfot.BackColor = System.Drawing.Color.Transparent;
            this.lblinfot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(194)))), ((int)(((byte)(82)))));
            this.lblinfot.Location = new System.Drawing.Point(11, 467);
            this.lblinfot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblinfot.Name = "lblinfot";
            this.lblinfot.Size = new System.Drawing.Size(128, 15);
            this.lblinfot.TabIndex = 26;
            this.lblinfot.Text = "Informações do turno";
            this.lblinfot.Click += new System.EventHandler(this.lblinfot_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(194)))), ((int)(((byte)(82)))));
            this.label11.Location = new System.Drawing.Point(11, 141);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "Mão do Jogador";
            this.label11.Click += new System.EventHandler(this.label11_Click_1);
            // 
            // lblTurnoInfo
            // 
            this.lblTurnoInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(64)))), ((int)(((byte)(48)))));
            this.lblTurnoInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTurnoInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnoInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.lblTurnoInfo.Location = new System.Drawing.Point(5, 482);
            this.lblTurnoInfo.Name = "lblTurnoInfo";
            this.lblTurnoInfo.Size = new System.Drawing.Size(250, 179);
            this.lblTurnoInfo.TabIndex = 28;
            this.lblTurnoInfo.Text = "turno";
            this.lblTurnoInfo.Click += new System.EventHandler(this.lblTurnoInfo_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.label10.Location = new System.Drawing.Point(708, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 15);
            this.label10.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.label13.Location = new System.Drawing.Point(439, 296);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 15);
            this.label13.TabIndex = 39;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(194)))), ((int)(((byte)(82)))));
            this.label14.Location = new System.Drawing.Point(7, 408);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 15);
            this.label14.TabIndex = 40;
            this.label14.Text = "Log da Partida";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(117)))), ((int)(((byte)(72)))));
            this.btnIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(157)))), ((int)(((byte)(93)))));
            this.btnIniciar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(78)))), ((int)(((byte)(58)))));
            this.btnIniciar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(145)))), ((int)(((byte)(88)))));
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.btnIniciar.Location = new System.Drawing.Point(2, 112);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(194, 33);
            this.btnIniciar.TabIndex = 42;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click_1);
            // 
            // btnAdicionarJogador
            // 
            this.btnAdicionarJogador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(117)))), ((int)(((byte)(72)))));
            this.btnAdicionarJogador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarJogador.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(157)))), ((int)(((byte)(93)))));
            this.btnAdicionarJogador.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(78)))), ((int)(((byte)(58)))));
            this.btnAdicionarJogador.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(145)))), ((int)(((byte)(88)))));
            this.btnAdicionarJogador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarJogador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarJogador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.btnAdicionarJogador.Location = new System.Drawing.Point(2, 151);
            this.btnAdicionarJogador.Name = "btnAdicionarJogador";
            this.btnAdicionarJogador.Size = new System.Drawing.Size(194, 32);
            this.btnAdicionarJogador.TabIndex = 43;
            this.btnAdicionarJogador.Text = "Logar em Partida";
            this.btnAdicionarJogador.UseVisualStyleBackColor = false;
            this.btnAdicionarJogador.Click += new System.EventHandler(this.btnAdicionarJogador_Click);
            // 
            // txtTabuleiro
            // 
            this.txtTabuleiro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(220)))));
            this.txtTabuleiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTabuleiro.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTabuleiro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(30)))));
            this.txtTabuleiro.Location = new System.Drawing.Point(2, 426);
            this.txtTabuleiro.Multiline = true;
            this.txtTabuleiro.Name = "txtTabuleiro";
            this.txtTabuleiro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTabuleiro.Size = new System.Drawing.Size(350, 235);
            this.txtTabuleiro.TabIndex = 38;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pbMapa
            // 
            this.pbMapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMapa.Image = ((System.Drawing.Image)(resources.GetObject("pbMapa.Image")));
            this.pbMapa.Location = new System.Drawing.Point(389, 101);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(641, 634);
            this.pbMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapa.TabIndex = 45;
            this.pbMapa.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(194)))), ((int)(((byte)(82)))));
            this.label2.Location = new System.Drawing.Point(21, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 46;
            this.label2.Text = "Mapa";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(78)))), ((int)(((byte)(58)))));
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelHeader.Controls.Add(this.label3);
            this.panelHeader.Controls.Add(this.label5);
            this.panelHeader.Location = new System.Drawing.Point(8, 9);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1304, 57);
            this.panelHeader.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(213)))), ((int)(((byte)(185)))));
            this.label3.Location = new System.Drawing.Point(172, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "version";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 41);
            this.label5.TabIndex = 44;
            this.label5.Text = "COLOSSAIS";
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(78)))), ((int)(((byte)(58)))));
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLeft.Controls.Add(this.label7);
            this.panelLeft.Controls.Add(this.listBoxJogadores);
            this.panelLeft.Controls.Add(this.label14);
            this.panelLeft.Controls.Add(this.txtTabuleiro);
            this.panelLeft.Controls.Add(this.btnAdicionarJogador);
            this.panelLeft.Controls.Add(this.lblMeuId);
            this.panelLeft.Controls.Add(this.btnIniciar);
            this.panelLeft.Controls.Add(this.lblMinhaSenha);
            this.panelLeft.Controls.Add(this.label6);
            this.panelLeft.Controls.Add(this.lblNomePartida);
            this.panelLeft.Controls.Add(this.lblDataPartida);
            this.panelLeft.Controls.Add(this.lblStatusPartida);
            this.panelLeft.Controls.Add(this.button1);
            this.panelLeft.Controls.Add(this.listBoxPartidas);
            this.panelLeft.Location = new System.Drawing.Point(8, 72);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(365, 676);
            this.panelLeft.TabIndex = 48;
            // 
            // panelMap
            // 
            this.panelMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(78)))), ((int)(((byte)(58)))));
            this.panelMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMap.Controls.Add(this.label2);
            this.panelMap.Location = new System.Drawing.Point(379, 72);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(662, 676);
            this.panelMap.TabIndex = 49;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(78)))), ((int)(((byte)(58)))));
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRight.Controls.Add(this.lblFaceDado);
            this.panelRight.Controls.Add(this.pbFaceDado);
            this.panelRight.Controls.Add(this.label11);
            this.panelRight.Controls.Add(this.lstMao);
            this.panelRight.Controls.Add(this.lblinfot);
            this.panelRight.Controls.Add(this.lblTurnoInfo);
            this.panelRight.Location = new System.Drawing.Point(1046, 72);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(266, 676);
            this.panelRight.TabIndex = 50;
            // 
            // lblFaceDado
            // 
            this.lblFaceDado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFaceDado.AutoSize = true;
            this.lblFaceDado.BackColor = System.Drawing.Color.Transparent;
            this.lblFaceDado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaceDado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(194)))), ((int)(((byte)(82)))));
            this.lblFaceDado.Location = new System.Drawing.Point(11, 20);
            this.lblFaceDado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFaceDado.Name = "lblFaceDado";
            this.lblFaceDado.Size = new System.Drawing.Size(36, 15);
            this.lblFaceDado.TabIndex = 30;
            this.lblFaceDado.Text = "Dado";
            this.lblFaceDado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFaceDado.Click += new System.EventHandler(this.lblFaceDado_Click);
            // 
            // pbFaceDado
            // 
            this.pbFaceDado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbFaceDado.Location = new System.Drawing.Point(14, 38);
            this.pbFaceDado.Name = "pbFaceDado";
            this.pbFaceDado.Size = new System.Drawing.Size(90, 90);
            this.pbFaceDado.TabIndex = 29;
            this.pbFaceDado.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(31)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1321, 760);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.pbMapa);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelMap);
            this.Controls.Add(this.panelRight);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "COLOSSAIS";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelMap.ResumeLayout(false);
            this.panelMap.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFaceDado)).EndInit();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMeuId;
        private System.Windows.Forms.Label lblMinhaSenha;
        private System.Windows.Forms.ListBox lstMao;
        private System.Windows.Forms.Label lblinfot;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTurnoInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnAdicionarJogador;
        private System.Windows.Forms.TextBox txtTabuleiro;
        private System.Windows.Forms.Timer tmrPrincipal;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelMap;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblFaceDado;
        private System.Windows.Forms.PictureBox pbFaceDado;
    }
}

