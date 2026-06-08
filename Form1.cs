using Draft;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace projeto_integrador_entrega1
{
    public partial class Form1 : Form
    {
        // CAMPOS

        private int meuId;
        private string minhaSenha;
        private int idPartidaSelecionada;
        private string faceDadoAtual = "";
        private int idJogadorComDado = 0;
        private int turnoAtual = 0;
        private int tickCount = 0;
        private bool processandoTick = false;
        private string ultimaJustificativaJogada = "";
        private int ultimoTurnoComPlacarExibido = 0;

        private readonly int[] pontosCD = { 0, 1, 3, 6, 10, 15, 21 };
        private readonly int[] pontosFI = { 0, 2, 4, 8, 12, 18, 24 };

        private readonly Dictionary<string, FlowLayoutPanel> cercadosVisuais = new Dictionary<string, FlowLayoutPanel>();
        private readonly Dictionary<string, Image> imagensDinos = new Dictionary<string, Image>();

        private readonly Dictionary<string, string> nomesFaces = new Dictionary<string, string>
        {
            { "AL", "Praça de Alimentação" },
            { "FL", "Floresta" },
            { "PR", "Pradaria" },
            { "TI", "Cuidado com o T-Rex" },
            { "VZ", "Cercado Vazio" },
            { "WC", "Banheiros" }
        };

        private readonly Dictionary<string, string> nomesCercados = new Dictionary<string, string>
        {
            { "CD", "Campina da Diferença" },
            { "FI", "Floresta da Igualdade" },
            { "IS", "Ilha Solitária" },
            { "MT", "Mata Tripla" },
            { "PA", "Pradaria do Amor" },
            { "RI", "Rio" },
            { "RS", "Rei da Selva" }
        };

        private readonly Dictionary<string, string> nomesDinos = new Dictionary<string, string>
        {
            { "Br", "Braquiossauro" },
            { "Ep", "Espinossauro" },
            { "Et", "Estegossauro" },
            { "Pa", "Parasaurolófo" },
            { "Ti", "Tiranossauro" },
            { "Tr", "Tricerátops" }
        };



        private Dictionary<string, string> imagensFacesDado = new Dictionary<string, string>
{
            { "AL", "AL.png" },
            { "FL", "FL.png" },
            { "PR", "PR.png" },
            { "TI", "TI.png" },
            { "VZ", "VZ.png" },
            { "WC", "WC.png" }
};
        // MODELOS

        private class EstadoPartida
        {
            public string StatusPartida { get; set; }
            public int Turno { get; set; }
            public string StatusTurno { get; set; }
            public int IdJogadorComDado { get; set; }
            public string FaceDado { get; set; }
        }

        private class JogadorInfo
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Status { get; set; }
        }

        private class JogadaAvaliada
        {
            public string Dino { get; set; }
            public string Cercado { get; set; }
            public int Score { get; set; }
            public int PontosAntes { get; set; }
            public int PontosDepois { get; set; }
            public string Motivo { get; set; }
        }

        private class PlacarJogador
        {
            public int IdJogador { get; set; }
            public string Nome { get; set; }
            public int CD { get; set; }
            public int FI { get; set; }
            public int IS { get; set; }
            public int MT { get; set; }
            public int PA { get; set; }
            public int RI { get; set; }
            public int RS { get; set; }
            public int BonusTRex { get; set; }
            public int TotalTRex { get; set; }
            public int Total { get; set; }
        }

        private class MaoVisualItem
        {
            public string CodDino { get; set; }
            public string NomeDino { get; set; }
            public int Quantidade { get; set; }
            public Image Imagem { get; set; }

            public override string ToString()
            {
                return NomeDino + " x" + Quantidade;
            }
        }

        // CONSTRUTORES

        public Form1()
        {
            InitializeComponent();

            ConfigurarListaMaoSimples();

            label3.Text = Jogo.versao;

            tmrPrincipal.Interval = 5000;
            tmrPrincipal.Tick -= tmrPrincipal_Tick;
            tmrPrincipal.Tick += tmrPrincipal_Tick;

            CriarFieldsMapa();
        }

        public Form1(int id, string senha, int idPartida) : this()
        {
            meuId = id;
            minhaSenha = senha;
            idPartidaSelecionada = idPartida;

            lblMeuId.Text = "Meu ID: " + meuId;
            lblMinhaSenha.Text = "Minha Senha: " + minhaSenha;
        }

        // MAPA

        private void CriarFieldsMapa()
        {
            var config = new Dictionary<string, (Point Pos, Size Tam)>
            {
                { "CD", (new Point(395, 257), new Size(195, 134)) },
                { "FI", (new Point(43, 40), new Size(195, 134)) },
                { "IS", (new Point(481, 422), new Size(123, 113)) },
                { "MT", (new Point(43, 233), new Size(147, 147)) },
                { "PA", (new Point(79, 439), new Size(147, 147)) },
                { "RI", (new Point(304, 532), new Size(127, 84)) },
                { "RS", (new Point(425, 61), new Size(86, 73)) }
            };

            foreach (var kv in config)
            {
                string cod = kv.Key;

                FlowLayoutPanel field = new FlowLayoutPanel
                {
                    Name = "field_" + cod,
                    Location = kv.Value.Pos,
                    Size = kv.Value.Tam,
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.Transparent,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = true,
                    Padding = new Padding(2)
                };

                pbMapa.Controls.Add(field);
                field.BringToFront();

                cercadosVisuais[cod] = field;
            }
        }

        private void AtualizarMapa()
        {
            AtualizarMapa(CarregarTabuleiro());
        }

        private void AtualizarMapa(Dictionary<string, List<string>> tabuleiro)
        {
            LimparMapa();

            foreach (var kv in tabuleiro)
            {
                string codCercado = kv.Key;

                if (!cercadosVisuais.ContainsKey(codCercado))
                    continue;

                foreach (string codDino in kv.Value)
                {
                    PictureBox pb = new PictureBox
                    {
                        Size = new Size(50, 40),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Margin = new Padding(1),
                        BackColor = Color.Transparent
                    };

                    Image imagem = ObterImagemDino(codDino);

                    if (imagem != null)
                        pb.Image = imagem;
                    else
                        pb.BackColor = Color.Red;

                    cercadosVisuais[codCercado].Controls.Add(pb);
                }
            }
        }

        private void LimparMapa()
        {
            foreach (var field in cercadosVisuais.Values)
            {
                for (int i = field.Controls.Count - 1; i >= 0; i--)
                {
                    PictureBox pb = field.Controls[i] as PictureBox;

                    if (pb == null)
                        continue;

                    pb.Image = null;
                    field.Controls.RemoveAt(i);
                    pb.Dispose();
                }
            }
        }

        private Image ObterImagemDino(string cod)
        {
            if (imagensDinos.ContainsKey(cod))
                return imagensDinos[cod];

            string caminho = ObterCaminhoDino(cod);

            if (string.IsNullOrEmpty(caminho) || !File.Exists(caminho))
            {
                imagensDinos[cod] = null;
                return null;
            }

            try
            {
                imagensDinos[cod] = Image.FromFile(caminho);
                return imagensDinos[cod];
            }
            catch
            {
                imagensDinos[cod] = null;
                return null;
            }
        }

        private string ObterCaminhoDino(string cod)
        {
            string pasta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");

            switch (cod)
            {
                case "Br": return Path.Combine(pasta, "braquiossauro.png");
                case "Ep": return Path.Combine(pasta, "espinossauro.png");
                case "Et": return Path.Combine(pasta, "estegossauro.png");
                case "Pa": return Path.Combine(pasta, "parassaurolofo.png");
                case "Ti": return Path.Combine(pasta, "tiranossauro.png");
                case "Tr": return Path.Combine(pasta, "triceratops.png");
                default: return "";
            }
        }

        private PictureBox ObterPictureBoxDado()
        {
            Control[] controles = this.Controls.Find("pbFaceDado", true);

            if (controles.Length == 0)
                controles = this.Controls.Find("pbfacedado", true);

            if (controles.Length == 0)
                return null;

            return controles[0] as PictureBox;
        }

        private Label ObterLabelDado()
        {
            Control[] controles = this.Controls.Find("lblFaceDado", true);

            if (controles.Length == 0)
                controles = this.Controls.Find("lblfacedado", true);

            if (controles.Length == 0)
                return null;

            return controles[0] as Label;
        }

        private void AtualizarImagemDado()
        {
            PictureBox pictureBoxDado = ObterPictureBoxDado();
            Label labelDado = ObterLabelDado();

            if (pictureBoxDado == null || labelDado == null)
                return;

            if (string.IsNullOrEmpty(faceDadoAtual))
            {
                labelDado.Text = "Dado";

                Image imagemAtual = pictureBoxDado.Image;
                pictureBoxDado.Image = null;

                if (imagemAtual != null)
                    imagemAtual.Dispose();

                return;
            }

            string nomeFace = nomesFaces.ContainsKey(faceDadoAtual)
                ? nomesFaces[faceDadoAtual]
                : faceDadoAtual;

            labelDado.Text = "Dado: " + nomeFace;

            string pasta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
            string arquivo = imagensFacesDado.ContainsKey(faceDadoAtual) ? imagensFacesDado[faceDadoAtual] : "";
            string caminho = Path.Combine(pasta, arquivo);

            Image novaImagem = null;

            if (!string.IsNullOrEmpty(arquivo) && File.Exists(caminho))
                novaImagem = Image.FromFile(caminho);
            else
                novaImagem = CriarImagemDadoFallback(faceDadoAtual);

            Image imagemAntiga = pictureBoxDado.Image;

            pictureBoxDado.Image = novaImagem;
            pictureBoxDado.SizeMode = PictureBoxSizeMode.StretchImage;

            if (imagemAntiga != null)
                imagemAntiga.Dispose();
        }

        private Image CriarImagemDadoFallback(string texto)
        {
            Bitmap bmp = new Bitmap(90, 90);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Font fonte = new Font("Segoe UI", 22, FontStyle.Bold))
            using (Brush fundo = new SolidBrush(Color.White))
            using (Brush textoBrush = new SolidBrush(Color.Black))
            using (Pen borda = new Pen(Color.Black, 3))
            {
                g.FillRectangle(fundo, 0, 0, 90, 90);
                g.DrawRectangle(borda, 4, 4, 82, 82);

                SizeF tam = g.MeasureString(texto, fonte);
                g.DrawString(texto, fonte, textoBrush, (90 - tam.Width) / 2, (90 - tam.Height) / 2);
            }
            return bmp;
        }

        // INICIAR

        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            EstadoPartida estado;

            string retornoVerif = Jogo.VerificarPartida(idPartidaSelecionada);

            if (TryParseEstadoPartida(retornoVerif, out estado) && estado.StatusPartida != "E")
            {
                AplicarEstadoPartida(estado);
                IniciarModoAutonomo("Partida já em andamento. Entrando no modo autônomo.");
                return;
            }

            string retorno = Jogo.Iniciar(meuId, minhaSenha);

            if (VerificarErroSilencioso(retorno))
            {
                retornoVerif = Jogo.VerificarPartida(idPartidaSelecionada);

                if (TryParseEstadoPartida(retornoVerif, out estado) && estado.StatusPartida != "E")
                {
                    AplicarEstadoPartida(estado);
                    IniciarModoAutonomo("Outro jogador iniciou. Entrando no modo autônomo.");
                    return;
                }

                LogErroTick("INICIAR", "Erro ao iniciar: " + retorno);
                return;
            }

            string[] dados = SepararCsv(retorno);

            if (dados.Length >= 2)
            {
                int idDado;

                if (int.TryParse(dados[0].Trim(), out idDado))
                    idJogadorComDado = idDado;

                faceDadoAtual = dados[1].Trim();
            }

            turnoAtual = 1;

            IniciarModoAutonomo("Partida iniciada com sucesso.");
        }

        private void IniciarModoAutonomo(string mensagem)
        {
            txtTabuleiro.Clear();
            lstMao.Items.Clear();
            tickCount = 0;
            processandoTick = false;
            ultimoTurnoComPlacarExibido = 0;

            LogSeparadorPrincipal();
            Log("COLOSSAIS — Sistema Autônomo");
            Log("Meu ID  : " + meuId);
            Log("Partida : " + idPartidaSelecionada);
            Log(mensagem);
            Log("Intervalo de consulta: 5 segundos");
            LogSeparadorPrincipal();
            Log("Cercados disponíveis:");
            Log(Jogo.ListarCercados());
            Log("Faces do dado:");
            Log(Jogo.ListarFacesDado());
            LogSeparadorPrincipal();

            btnIniciar.Enabled = false;
            tmrPrincipal.Start();
        }

        // TIMER

        private void tmrPrincipal_Tick(object sender, EventArgs e)
        {
            if (processandoTick)
                return;

            processandoTick = true;
            tmrPrincipal.Stop();

            bool continuar = true;

            try
            {
                continuar = ProcessarTick();
            }
            catch (Exception ex)
            {
                LogErroTick("ERRO GERAL", ex.Message);
            }
            finally
            {
                processandoTick = false;

                if (continuar)
                    tmrPrincipal.Start();
            }
        }

        private bool ProcessarTick()
        {
            tickCount++;

            LogInicioTick("consultando partida e estado do turno");

            EstadoPartida estado;
            string retorno = Jogo.VerificarPartida(idPartidaSelecionada);

            if (!TryParseEstadoPartida(retorno, out estado))
            {
                LogErroTick("VERIFICAR PARTIDA", "Retorno inválido: " + retorno);
                LogFimTick("aguardando próximo tick para tentar consultar novamente");
                return true;
            }

            int turnoAnterior = turnoAtual;
            bool turnoMudou = turnoAnterior > 0 && estado.Turno != turnoAnterior;

            if (turnoMudou)
                LogInfoTick("TURNO", "Turno avançou de " + turnoAnterior + " para " + estado.Turno + ".");

            AplicarEstadoPartida(estado);
            AtualizarImagemDado();

            List<JogadorInfo> jogadores = CarregarJogadores();
            string nomeDono = BuscarNomeJogador(idJogadorComDado, jogadores);
            string nomeFace = nomesFaces.ContainsKey(faceDadoAtual) ? nomesFaces[faceDadoAtual] : faceDadoAtual;
            bool euTenhoDado = idJogadorComDado == meuId;
            bool partidaAtiva = estado.StatusPartida != "E";

            Dictionary<string, List<string>> tabuleiro = CarregarTabuleiro();
            Dictionary<int, Dictionary<string, List<string>>> tabuleirosAdversarios = CarregarTabuleirosAdversarios(jogadores);
            PlacarJogador meuPlacarAtual = CalcularMeuPlacarSeguro(jogadores, tabuleiro, tabuleirosAdversarios);

            AtualizarResumoTurnoLabel(nomeDono, nomeFace, partidaAtiva, meuPlacarAtual);
            AtualizarJogadores(jogadores);
            AtualizarMapa(tabuleiro);

            LogResumoEstado(estado, nomeDono, nomeFace, euTenhoDado, partidaAtiva, meuPlacarAtual, tabuleirosAdversarios, jogadores);

            if (turnoMudou && ultimoTurnoComPlacarExibido != turnoAnterior)
            {
                ExibirPlacarParcial(jogadores, tabuleiro, tabuleirosAdversarios, "fim do turno " + turnoAnterior);
                ultimoTurnoComPlacarExibido = turnoAnterior;
            }

            if (!partidaAtiva)
            {
                LogSeparadorTick();
                LogInfoTick("FIM", "Partida encerrada.");
                LogTabuleiro(tabuleiro);
                ExibirPlacarParcial(jogadores, tabuleiro, tabuleirosAdversarios, "final da partida");
                btnIniciar.Enabled = true;
                LogFimTick("timer parado porque a partida foi encerrada");
                return false;
            }

            string retornoTurno = Jogo.VerificarTurno(idPartidaSelecionada, turnoAtual);
            bool euJaJoguei = EuJaJogueiNesseTurno(retornoTurno);

            LogInfoTick("TURNO", euJaJoguei ? "Eu já joguei neste turno. Aguardando os outros jogadores." : "Ainda não joguei neste turno. Preparando decisão automática.");

            if (euJaJoguei)
            {
                LogFimTick("aguardando os outros jogadores finalizarem o turno");
                return true;
            }

            LogInfoTick("JOGADA", euTenhoDado ? "Estou com o dado, então posso jogar em qualquer cercado válido." : "Vou respeitar a face do dado: " + nomeFace + ".");

            string maoRaw = Jogo.ExibirMao(meuId, minhaSenha);
            Dictionary<string, int> mao = ParsearMaoDetalhada(maoRaw);

            AtualizarMaoVisualSimples(mao);

            LogInfoTick("MÃO", FormatarMao(mao));

            if (mao.Count == 0)
            {
                LogInfoTick("MÃO", "Mão vazia ou não carregada. Nenhuma jogada será enviada neste tick.");
                LogFimTick("aguardando próximo tick");
                return true;
            }

            string codDino;
            string cercado;

            EscolherMelhorJogada(mao, tabuleiro, tabuleirosAdversarios, out codDino, out cercado);

            string nomeD = nomesDinos.ContainsKey(codDino) ? nomesDinos[codDino] : codDino;
            string nomeC = nomesCercados.ContainsKey(cercado) ? nomesCercados[cercado] : cercado;

            LogInfoTick("DECISÃO", nomeD + " → " + nomeC);

            if (!string.IsNullOrWhiteSpace(ultimaJustificativaJogada))
                LogInfoTick("ESTRATÉGIA", ultimaJustificativaJogada);

            string resultado = Jogo.Jogar(meuId, minhaSenha, codDino, cercado);

            LogInfoTick("RETORNO", resultado == null ? "sem retorno" : resultado.Trim());

            if (!string.IsNullOrEmpty(resultado) && !resultado.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
            {
                Dictionary<string, List<string>> tabuleiroAtualizado = CarregarTabuleiro();
                PlacarJogador placarDepois = CalcularMeuPlacarSeguro(jogadores, tabuleiroAtualizado, tabuleirosAdversarios);

                AtualizarResumoTurnoLabel(nomeDono, nomeFace, partidaAtiva, placarDepois);

                LogInfoTick("SUCESSO", "Jogada registrada. Agora estou aguardando os outros jogadores.");
                LogTabuleiro(tabuleiroAtualizado);
                AtualizarMapa(tabuleiroAtualizado);
                ExibirPlacarParcial(jogadores, tabuleiroAtualizado, tabuleirosAdversarios, "após minha jogada");
            }
            else
            {
                LogErroTick("JOGADA", "Não foi possível registrar a jogada. O client tentará novamente no próximo tick.");
            }

            LogFimTick("tick finalizado, aguardando próxima consulta");
            return true;
        }

        // PARSING

        private bool TryParseEstadoPartida(string retorno, out EstadoPartida estado)
        {
            estado = null;

            if (string.IsNullOrWhiteSpace(retorno))
                return false;

            if (retorno.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
                return false;

            string[] dados = SepararCsv(retorno);

            if (dados.Length < 5)
                return false;

            int turno;
            int idDado;

            if (!int.TryParse(dados[1].Trim(), out turno))
                return false;

            if (!int.TryParse(dados[3].Trim(), out idDado))
                return false;

            estado = new EstadoPartida
            {
                StatusPartida = dados[0].Trim(),
                Turno = turno,
                StatusTurno = dados[2].Trim(),
                IdJogadorComDado = idDado,
                FaceDado = dados[4].Trim(),
            };

            return true;
        }

        private string[] SepararCsv(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return new string[0];

            return texto.Replace("\r", "").Trim().Split(',');
        }

        private string[] SepararLinhas(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return new string[0];

            return texto.Replace("\r", "").Trim().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void AplicarEstadoPartida(EstadoPartida estado)
        {
            if (estado == null)
                return;

            turnoAtual = estado.Turno;
            idJogadorComDado = estado.IdJogadorComDado;
            faceDadoAtual = estado.FaceDado;
        }

        // TURNO

        private bool EuJaJogueiNesseTurno(string retornoTurno)
        {
            if (string.IsNullOrWhiteSpace(retornoTurno))
                return false;

            if (retornoTurno.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
                return false;

            string[] linhas = SepararLinhas(retornoTurno);

            for (int i = 1; i < linhas.Length; i++)
            {
                string[] partes = SepararCsv(linhas[i]);

                if (partes.Length == 0)
                    continue;

                int idNaLinha;

                if (int.TryParse(partes[0].Trim(), out idNaLinha) && idNaLinha == meuId)
                    return true;
            }

            return false;
        }

        // JOGADORES

        private List<JogadorInfo> CarregarJogadores()
        {
            var jogadores = new List<JogadorInfo>();

            string retorno = Jogo.ListarJogadores(idPartidaSelecionada);

            if (string.IsNullOrWhiteSpace(retorno))
                return jogadores;

            if (retorno.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
                return jogadores;

            foreach (string linha in SepararLinhas(retorno))
            {
                string[] dados = SepararCsv(linha);

                if (dados.Length < 2)
                    continue;

                int id;

                if (!int.TryParse(dados[0].Trim(), out id))
                    continue;

                jogadores.Add(new JogadorInfo
                {
                    Id = id,
                    Nome = dados[1].Trim(),
                    Status = dados.Length > 2 ? dados[2].Trim() : ""
                });
            }

            return jogadores;
        }

        private string BuscarNomeJogador(int idJogador, List<JogadorInfo> jogadores)
        {
            foreach (JogadorInfo jogador in jogadores)
            {
                if (jogador.Id == idJogador)
                    return jogador.Nome;
            }

            return "ID " + idJogador;
        }

        private void AtualizarJogadores()
        {
            AtualizarJogadores(CarregarJogadores());
        }

        private void AtualizarJogadores(List<JogadorInfo> jogadores)
        {
            listBoxJogadores.Items.Clear();

            foreach (JogadorInfo jogador in jogadores)
            {
                string st = jogador.Status == "J" ? "✓" : "...";
                listBoxJogadores.Items.Add(st + " " + jogador.Nome);
            }
        }

        // TABULEIRO

        private Dictionary<string, List<string>> CarregarTabuleiro()
        {
            try
            {
                string raw = Jogo.ExibirTabuleiro(meuId, minhaSenha);
                return ParsearTabuleiroRaw(raw);
            }
            catch
            {
                return new Dictionary<string, List<string>>();
            }
        }

        private Dictionary<string, List<string>> ParsearTabuleiroRaw(string raw)
        {
            var tabuleiro = new Dictionary<string, List<string>>();

            if (string.IsNullOrWhiteSpace(raw))
                return tabuleiro;

            if (raw.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
                return tabuleiro;

            foreach (string linha in SepararLinhas(raw))
            {
                string[] p = SepararCsv(linha);

                if (p.Length < 3)
                    continue;

                string cercado = p[0].Trim();
                string dino = p[1].Trim();

                int qtd;

                if (!int.TryParse(p[2].Trim(), out qtd) || qtd <= 0)
                    continue;

                if (!tabuleiro.ContainsKey(cercado))
                    tabuleiro[cercado] = new List<string>();

                for (int i = 0; i < qtd; i++)
                    tabuleiro[cercado].Add(dino);
            }

            return tabuleiro;
        }

        // ADVERSÁRIOS

        private Dictionary<int, Dictionary<string, List<string>>> CarregarTabuleirosAdversarios(List<JogadorInfo> jogadores)
        {
            var tabuleiros = new Dictionary<int, Dictionary<string, List<string>>>();

            if (jogadores == null || jogadores.Count == 0)
                return tabuleiros;

            foreach (JogadorInfo jogador in jogadores)
            {
                if (jogador.Id == meuId)
                    continue;

                Dictionary<string, List<string>> tabuleiroAdversario;

                if (TryCarregarTabuleiroJogador(jogador.Id, out tabuleiroAdversario))
                    tabuleiros[jogador.Id] = tabuleiroAdversario;
            }

            return tabuleiros;
        }

        private bool TryCarregarTabuleiroJogador(int idJogador, out Dictionary<string, List<string>> tabuleiro)
        {
            tabuleiro = new Dictionary<string, List<string>>();

            try
            {
                string raw = Jogo.ExibirTabuleiro(idJogador, minhaSenha);

                if (string.IsNullOrWhiteSpace(raw) || raw.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
                    raw = Jogo.ExibirTabuleiro(idJogador, "");

                if (string.IsNullOrWhiteSpace(raw) || raw.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
                    return false;

                tabuleiro = ParsearTabuleiroRaw(raw);
                return true;
            }
            catch
            {
                tabuleiro = new Dictionary<string, List<string>>();
                return false;
            }
        }

        // MÃO

        private Dictionary<string, int> ParsearMaoDetalhada(string maoRaw)
        {
            var mao = new Dictionary<string, int>();

            if (string.IsNullOrWhiteSpace(maoRaw))
                return mao;

            if (maoRaw.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
                return mao;

            foreach (string linha in SepararLinhas(maoRaw))
            {
                string[] p = SepararCsv(linha);

                if (p.Length < 2)
                    continue;

                string dino = p[0].Trim();

                int qtd;

                if (!int.TryParse(p[1].Trim(), out qtd) || qtd <= 0)
                    continue;

                if (!mao.ContainsKey(dino))
                    mao[dino] = 0;

                mao[dino] += qtd;
            }

            return mao;
        }

        private List<string> ParsearMao(string maoRaw)
        {
            var maoDetalhada = ParsearMaoDetalhada(maoRaw);
            var mao = new List<string>();

            foreach (var item in maoDetalhada)
                mao.Add(item.Key);

            return mao;
        }

        private string FormatarMao(Dictionary<string, int> mao)
        {
            if (mao == null || mao.Count == 0)
                return "sem dinossauros carregados";

            var partes = new List<string>();

            foreach (var item in mao)
            {
                string nome = nomesDinos.ContainsKey(item.Key) ? nomesDinos[item.Key] : item.Key;
                partes.Add(nome + " x" + item.Value);
            }

            return string.Join(", ", partes);
        }


        private void ConfigurarListaMaoSimples()
        {
            lstMao.DrawMode = DrawMode.OwnerDrawFixed;
            lstMao.ItemHeight = 44;
            lstMao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lstMao.BackColor = Color.FromArgb(238, 235, 220);
            lstMao.ForeColor = Color.FromArgb(30, 35, 30);
            lstMao.BorderStyle = BorderStyle.FixedSingle;

            lstMao.DrawItem -= lstMao_DrawItem;
            lstMao.DrawItem += lstMao_DrawItem;
        }

        private void AtualizarMaoVisualSimples(Dictionary<string, int> mao)
        {
            lstMao.BeginUpdate();

            try
            {
                lstMao.Items.Clear();

                if (mao == null || mao.Count == 0)
                {
                    lstMao.Items.Add(new MaoVisualItem
                    {
                        CodDino = "",
                        NomeDino = "Sem dinossauros",
                        Quantidade = 0,
                        Imagem = null
                    });

                    return;
                }

                foreach (var item in mao)
                {
                    string codDino = item.Key;
                    string nomeDino = nomesDinos.ContainsKey(codDino) ? nomesDinos[codDino] : codDino;

                    lstMao.Items.Add(new MaoVisualItem
                    {
                        CodDino = codDino,
                        NomeDino = nomeDino,
                        Quantidade = item.Value,
                        Imagem = ObterImagemDino(codDino)
                    });
                }
            }
            finally
            {
                lstMao.EndUpdate();
            }
        }

        private void lstMao_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            MaoVisualItem item = lstMao.Items[e.Index] as MaoVisualItem;

            if (item == null)
                return;

            bool selecionado = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color corFundo = selecionado ? Color.FromArgb(44, 117, 72) : lstMao.BackColor;
            Color corTexto = selecionado ? Color.FromArgb(245, 238, 213) : Color.FromArgb(30, 35, 30);

            using (SolidBrush fundo = new SolidBrush(corFundo))
                e.Graphics.FillRectangle(fundo, e.Bounds);

            int margem = 6;
            int tamanhoImagem = 30;
            int xImagem = e.Bounds.Left + margem;
            int yImagem = e.Bounds.Top + 7;

            if (item.Imagem != null)
            {
                e.Graphics.DrawImage(item.Imagem, new Rectangle(xImagem, yImagem, tamanhoImagem, tamanhoImagem));
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(210, 210, 200)))
                using (Pen pen = new Pen(Color.FromArgb(80, 80, 70)))
                {
                    Rectangle ret = new Rectangle(xImagem, yImagem, tamanhoImagem, tamanhoImagem);
                    e.Graphics.FillRectangle(brush, ret);
                    e.Graphics.DrawRectangle(pen, ret);
                }
            }

            int xTexto = xImagem + tamanhoImagem + 10;
            int yTexto = e.Bounds.Top + 12;

            string texto = item.Quantidade > 0
                ? item.NomeDino + " x" + item.Quantidade
                : item.NomeDino;

            using (SolidBrush textoBrush = new SolidBrush(corTexto))
                e.Graphics.DrawString(texto, lstMao.Font, textoBrush, xTexto, yTexto);

            e.DrawFocusRectangle();
        }

        // LOG

        private void LogInicioTick(string objetivo)
        {
            string hora = DateTime.Now.ToString("HH:mm:ss");
            Log("");
            Log("╔══════════════════════════════════════════════════════");
            Log("║ TICK #" + tickCount + " | " + hora);
            Log("║ Objetivo: " + objetivo);
            Log("╚══════════════════════════════════════════════════════");
        }

        private void LogFimTick(string aguardando)
        {
            Log("  [AGUARDANDO] " + aguardando);
            Log("──────────────────────────────────────────────────────");
        }

        private void LogInfoTick(string etapa, string mensagem)
        {
            Log("  [" + etapa + "] " + mensagem);
        }

        private void LogErroTick(string etapa, string mensagem)
        {
            Log("  [ERRO - " + etapa + "] " + mensagem);
        }

        private void LogSeparadorTick()
        {
            Log("  ----------------------------------------------------");
        }

        private void LogSeparadorPrincipal()
        {
            Log("══════════════════════════════════════════════════════");
        }

        private void LogResumoEstado(EstadoPartida estado, string nomeDono, string nomeFace, bool euTenhoDado, bool partidaAtiva, PlacarJogador meuPlacarAtual, Dictionary<int, Dictionary<string, List<string>>> tabuleirosAdversarios, List<JogadorInfo> jogadores)
        {
            int totalAdversarios = 0;

            if (jogadores != null)
            {
                foreach (JogadorInfo jogador in jogadores)
                {
                    if (jogador.Id != meuId)
                        totalAdversarios++;
                }
            }

            int adversariosCarregados = tabuleirosAdversarios == null ? 0 : tabuleirosAdversarios.Count;
            string statusTurno = estado.StatusTurno == "A" ? "aberto" : "fechado";
            string statusPartida = partidaAtiva ? "em andamento" : "encerrada";
            string placar = meuPlacarAtual == null ? "não calculado" : meuPlacarAtual.Total + " pts | T-Rex: " + meuPlacarAtual.TotalTRex;

            LogInfoTick("PARTIDA", "status " + statusPartida + " | turno " + turnoAtual + " " + statusTurno);
            LogInfoTick("DADO", "com " + nomeDono + " (ID " + idJogadorComDado + ") | face " + nomeFace + (euTenhoDado ? " | jogo livre" : ""));
            LogInfoTick("PLACAR", "meu placar parcial: " + placar);
            LogInfoTick("ADVERSÁRIOS", adversariosCarregados + " de " + totalAdversarios + " tabuleiro(s) carregado(s) para Rei da Selva/placar");
        }

        private void LogTabuleiro()
        {
            LogTabuleiro(CarregarTabuleiro());
        }

        private void LogTabuleiro(Dictionary<string, List<string>> tab)
        {
            if (tab == null || tab.Count == 0)
                return;

            LogInfoTick("TABULEIRO", "situação atual do meu zoo:");

            foreach (var kv in tab)
            {
                if (kv.Value.Count == 0)
                    continue;

                string nomeCerc = nomesCercados.ContainsKey(kv.Key) ? nomesCercados[kv.Key] : kv.Key;
                var cont = new Dictionary<string, int>();

                foreach (string d in kv.Value)
                {
                    if (!cont.ContainsKey(d))
                        cont[d] = 0;

                    cont[d]++;
                }

                foreach (var dc in cont)
                {
                    string nd = nomesDinos.ContainsKey(dc.Key) ? nomesDinos[dc.Key] : dc.Key;
                    Log("    " + nomeCerc + ": " + nd + " x" + dc.Value);
                }
            }
        }

        private void Log(string msg)
        {
            txtTabuleiro.AppendText(msg + Environment.NewLine);
            txtTabuleiro.SelectionStart = txtTabuleiro.Text.Length;
            txtTabuleiro.ScrollToCaret();
        }

        // LABEL

        private void AtualizarResumoTurnoLabel(string nomeDono, string nomeFace, bool partidaAtiva, PlacarJogador placar)
        {
            string status = partidaAtiva ? "Em andamento" : "Encerrada";
            string dado = nomeDono + (idJogadorComDado == meuId ? " ★" : "");
            string pontos = placar == null ? "Pts: --" : "Pts: " + placar.Total + " | T-Rex: " + placar.TotalTRex;

            lblTurnoInfo.Text = "Turno: " + turnoAtual + " | Dado: " + dado + " | " + nomeFace + " | " + status + " | " + pontos;
        }

        // HEURÍSTICA

        private void EscolherMelhorJogada(Dictionary<string, int> mao, Dictionary<string, List<string>> tabuleiro, Dictionary<int, Dictionary<string, List<string>>> tabuleirosAdversarios, out string melhorDino, out string melhorCercado)
        {
            melhorDino = null;
            melhorCercado = null;
            ultimaJustificativaJogada = "";

            JogadaAvaliada melhorJogada = null;

            foreach (var itemMao in mao)
            {
                string dino = itemMao.Key;

                foreach (string cercado in ObterCercadosCandidatos(dino, tabuleiro))
                {
                    if (!CercadoAceitaDino(cercado, dino, tabuleiro))
                        continue;

                    JogadaAvaliada jogada = AvaliarJogadaHeuristica(dino, cercado, tabuleiro, mao, tabuleirosAdversarios);

                    if (melhorJogada == null || jogada.Score > melhorJogada.Score)
                        melhorJogada = jogada;
                }
            }

            if (melhorJogada == null)
            {
                foreach (var itemMao in mao)
                {
                    melhorDino = itemMao.Key;
                    melhorCercado = "RI";
                    ultimaJustificativaJogada = "Nenhum cercado válido encontrado. Rio usado como descarte seguro.";
                    return;
                }
            }

            melhorDino = melhorJogada.Dino;
            melhorCercado = melhorJogada.Cercado;
            ultimaJustificativaJogada = melhorJogada.Motivo;
        }

        private List<string> ObterCercadosCandidatos(string dino, Dictionary<string, List<string>> tab)
        {
            string[] todosCercados = { "FI", "MT", "PA", "RS", "CD", "IS" };
            var candidatos = new List<string>();
            bool temDado = idJogadorComDado == meuId;

            foreach (string cercado in todosCercados)
            {
                if (!temDado && !CercadoPermitidoPeloDadoComTab(cercado, tab))
                    continue;

                candidatos.Add(cercado);
            }

            candidatos.Add("RI");

            return candidatos;
        }

        private bool CercadoAceitaDino(string cercado, string dino, Dictionary<string, List<string>> tab)
        {
            List<string> cont = ObterDinosCercado(tab, cercado);

            switch (cercado)
            {
                case "IS":
                    return cont.Count == 0;

                case "RS":
                    return cont.Count == 0;

                case "MT":
                    return cont.Count < 3;

                case "FI":
                    return cont.Count < 6 && (cont.Count == 0 || cont.TrueForAll(d => d == dino));

                case "CD":
                    return cont.Count < 6 && !cont.Contains(dino);

                case "PA":
                    return true;

                case "RI":
                    return true;

                default:
                    return false;
            }
        }

        private bool CercadoPermitidoPeloDadoComTab(string codCercado, Dictionary<string, List<string>> tab)
        {
            if (string.IsNullOrEmpty(faceDadoAtual))
                return true;

            if (codCercado == "RI")
                return true;

            switch (faceDadoAtual)
            {
                case "AL":
                    return codCercado == "FI" || codCercado == "MT" || codCercado == "PA";

                case "WC":
                    return codCercado == "RS" || codCercado == "CD" || codCercado == "IS";

                case "FL":
                    return codCercado == "FI" || codCercado == "MT" || codCercado == "RS";

                case "PR":
                    return codCercado == "PA" || codCercado == "CD" || codCercado == "IS";

                case "TI":
                    return !ObterDinosCercado(tab, codCercado).Contains("Ti");

                case "VZ":
                    return ObterDinosCercado(tab, codCercado).Count == 0;

                default:
                    return true;
            }
        }

        private JogadaAvaliada AvaliarJogadaHeuristica(string dino, string cercado, Dictionary<string, List<string>> tabuleiro, Dictionary<string, int> mao, Dictionary<int, Dictionary<string, List<string>>> tabuleirosAdversarios)
        {
            // A heurística não escolhe por cercado fixo.
            // Ela simula a jogada, calcula a pontuação antes e depois, e usa o ganho real como base.

            Dictionary<int, Dictionary<string, List<string>>> todosAntes = MontarTabuleirosParaPontuacao(tabuleiro, tabuleirosAdversarios);
            PlacarJogador placarAntes = CalcularPlacarJogador(meuId, "Eu", todosAntes);

            Dictionary<string, List<string>> tabuleiroDepois = ClonarTabuleiro(tabuleiro);

            if (!tabuleiroDepois.ContainsKey(cercado))
                tabuleiroDepois[cercado] = new List<string>();

            tabuleiroDepois[cercado].Add(dino);

            Dictionary<int, Dictionary<string, List<string>>> todosDepois = MontarTabuleirosParaPontuacao(tabuleiroDepois, tabuleirosAdversarios);
            PlacarJogador placarDepois = CalcularPlacarJogador(meuId, "Eu", todosDepois);

            int ganhoReal = placarDepois.Total - placarAntes.Total;
            int score = ganhoReal * 10;

            var motivos = new List<string>();
            motivos.Add("ganho real de " + ganhoReal + " ponto(s)");

            AplicarBonusEstrategicos(dino, cercado, tabuleiro, tabuleiroDepois, mao, tabuleirosAdversarios, ref score, motivos);

            return new JogadaAvaliada
            {
                Dino = dino,
                Cercado = cercado,
                Score = score,
                PontosAntes = placarAntes.Total,
                PontosDepois = placarDepois.Total,
                Motivo = "score " + score + "; " + string.Join("; ", motivos)
            };
        }

        private void AplicarBonusEstrategicos(string dino, string cercado, Dictionary<string, List<string>> tabuleiroAntes, Dictionary<string, List<string>> tabuleiroDepois, Dictionary<string, int> mao, Dictionary<int, Dictionary<string, List<string>>> tabuleirosAdversarios, ref int score, List<string> motivos)
        {
            // O ganho real de pontos é a base.
            // Estes bônus servem para desempatar e favorecer jogadas com potencial futuro.

            List<string> antes = ObterDinosCercado(tabuleiroAntes, cercado);
            List<string> depois = ObterDinosCercado(tabuleiroDepois, cercado);

            // Rio dá apenas 1 ponto por dinossauro e não conta como cercado para bônus de T-Rex.
            // Por isso ele recebe uma penalidade forte e fica como opção de descarte.
            if (cercado == "RI")
            {
                score -= 80;
                motivos.Add("Rio penalizado por ser zona de descarte");
                return;
            }

            // T-Rex vale +1 por cercado que tenha pelo menos um T-Rex.
            // A melhor estratégia é espalhar T-Rex em cercados diferentes.
            if (dino == "Ti" && !antes.Contains("Ti"))
            {
                score += 25;
                motivos.Add("T-Rex colocado em cercado que ainda não tinha T-Rex");
            }

            if (dino == "Ti" && antes.Contains("Ti"))
            {
                score -= 20;
                motivos.Add("T-Rex repetido no mesmo cercado sem gerar novo bônus");
            }

            switch (cercado)
            {
                case "MT":
                    // Mata Tripla só pontua quando fecha exatamente 3 dinossauros.
                    // Então completar o terceiro espaço é uma jogada muito forte.
                    if (antes.Count == 2 && depois.Count == 3)
                    {
                        score += 35;
                        motivos.Add("completou Mata Tripla com 3 dinossauros");
                    }
                    else if (depois.Count < 3)
                    {
                        score += 8;
                        motivos.Add("preparou Mata Tripla para pontuar depois");
                    }
                    break;

                case "PA":
                    // Pradaria do Amor pontua por pares da mesma espécie.
                    // Formar casal imediatamente é priorizado.
                    {
                        int antesQtd = ContarDinoNoCercado(tabuleiroAntes, "PA", dino);
                        int depoisQtd = ContarDinoNoCercado(tabuleiroDepois, "PA", dino);

                        int paresAntes = antesQtd / 2;
                        int paresDepois = depoisQtd / 2;

                        if (paresDepois > paresAntes)
                        {
                            score += 35;
                            motivos.Add("formou casal na Pradaria do Amor");
                        }
                        else if (mao.ContainsKey(dino) && mao[dino] > 1)
                        {
                            score += 10;
                            motivos.Add("preparou futuro casal porque ainda há repetição na mão");
                        }

                        break;
                    }

                case "CD":
                    // Campina da Diferença melhora conforme ganha espécies diferentes.
                    // Quanto mais cheia, maior o ganho marginal.
                    {
                        int qtdDepois = ContarEspeciesDiferentes(depois);
                        score += qtdDepois * 5;
                        motivos.Add("Campina da Diferença avançou para " + qtdDepois + " espécie(s)");
                        break;
                    }

                case "FI":
                    // Floresta da Igualdade depende de acumular a mesma espécie.
                    // A heurística valoriza continuar uma floresta já iniciada.
                    {
                        int qtdDepois = depois.Count;

                        if (qtdDepois >= 3)
                        {
                            score += 20;
                            motivos.Add("fortaleceu Floresta da Igualdade com volume bom");
                        }
                        else if (qtdDepois == 1 && mao.ContainsKey(dino) && mao[dino] > 1)
                        {
                            score += 10;
                            motivos.Add("iniciou Floresta com espécie repetida na mão");
                        }
                        else if (qtdDepois == 1)
                        {
                            score += 3;
                            motivos.Add("iniciou Floresta da Igualdade");
                        }

                        break;
                    }

                case "IS":
                    // Ilha Solitária só vale 7 se aquele dinossauro for único no zoo inteiro.
                    // Se a espécie já existe em outro lugar, a jogada perde muito valor.
                    {
                        int totalEspecieDepois = ContarDinoNoZoo(tabuleiroDepois, dino);

                        if (totalEspecieDepois == 1)
                        {
                            score += 40;
                            motivos.Add("Ilha Solitária pontua porque a espécie ficou única no zoo");
                        }
                        else
                        {
                            score -= 60;
                            motivos.Add("Ilha Solitária não pontua porque a espécie já existe no zoo");
                        }

                        break;
                    }

                case "RS":
                    // Rei da Selva é o único cercado que depende dos adversários.
                    // Se conseguir carregar tabuleiros adversários, compara de verdade.
                    // Se não conseguir, usa uma estimativa local para não travar a jogada.
                    {
                        bool temAdversarios = tabuleirosAdversarios != null && tabuleirosAdversarios.Count > 0;

                        if (temAdversarios)
                        {
                            int meuTotal = ContarDinoNoZoo(tabuleiroDepois, dino);
                            int maiorAdversario = ObterMaiorQuantidadeAdversaria(dino, tabuleirosAdversarios);

                            if (meuTotal >= maiorAdversario)
                            {
                                score += 45;
                                motivos.Add("Rei da Selva forte: meu total " + meuTotal + " contra maior adversário " + maiorAdversario);
                            }
                            else
                            {
                                score -= 50;
                                motivos.Add("Rei da Selva fraco: meu total " + meuTotal + " contra maior adversário " + maiorAdversario);
                            }
                        }
                        else
                        {
                            int meuTotal = ContarDinoNoZoo(tabuleiroDepois, dino);

                            if (meuTotal >= 3)
                            {
                                score += 25;
                                motivos.Add("Rei da Selva estimado forte sem dados dos adversários");
                            }
                            else if (meuTotal == 2)
                            {
                                score += 10;
                                motivos.Add("Rei da Selva estimado médio sem dados dos adversários");
                            }
                            else
                            {
                                score -= 15;
                                motivos.Add("Rei da Selva estimado fraco sem dados dos adversários");
                            }
                        }

                        break;
                    }
            }

            if (JogadaComBaixoGanhoSemPotencial(cercado, dino, tabuleiroAntes, tabuleiroDepois, mao))
            {
                score -= 15;
                motivos.Add("jogada com baixo ganho imediato e pouco potencial futuro");
            }
        }

        private bool JogadaComBaixoGanhoSemPotencial(string cercado, string dino, Dictionary<string, List<string>> antes, Dictionary<string, List<string>> depois, Dictionary<string, int> mao)
        {
            if (cercado == "RI")
                return false;

            if (dino == "Ti")
                return false;

            if (cercado == "PA" && mao.ContainsKey(dino) && mao[dino] > 1)
                return false;

            if (cercado == "MT" && ObterDinosCercado(depois, "MT").Count >= 2)
                return false;

            if (cercado == "CD")
                return false;

            if (cercado == "FI" && ObterDinosCercado(depois, "FI").Count >= 2)
                return false;

            return true;
        }

        // PONTUAÇÃO

        private PlacarJogador CalcularMeuPlacarSeguro(List<JogadorInfo> jogadores, Dictionary<string, List<string>> meuTabuleiro, Dictionary<int, Dictionary<string, List<string>>> tabuleirosAdversarios)
        {
            try
            {
                Dictionary<int, Dictionary<string, List<string>>> todos = MontarTabuleirosParaPontuacao(meuTabuleiro, tabuleirosAdversarios);
                return CalcularPlacarJogador(meuId, "Eu", todos);
            }
            catch
            {
                return null;
            }
        }

        private void ExibirPlacarParcial(List<JogadorInfo> jogadores, Dictionary<string, List<string>> meuTabuleiro, Dictionary<int, Dictionary<string, List<string>>> tabuleirosAdversarios, string contexto)
        {
            try
            {
                Dictionary<int, Dictionary<string, List<string>>> todos = MontarTabuleirosParaPontuacao(meuTabuleiro, tabuleirosAdversarios);
                var placares = new List<PlacarJogador>();

                foreach (JogadorInfo jogador in jogadores)
                {
                    if (!todos.ContainsKey(jogador.Id))
                        continue;

                    placares.Add(CalcularPlacarJogador(jogador.Id, jogador.Nome, todos));
                }

                placares.Sort((a, b) =>
                {
                    int total = b.Total.CompareTo(a.Total);

                    if (total != 0)
                        return total;

                    return a.TotalTRex.CompareTo(b.TotalTRex);
                });

                LogSeparadorTick();
                LogInfoTick("PLACAR", "placar parcial - " + contexto);

                foreach (PlacarJogador p in placares)
                {
                    Log("    " + p.Nome + " (ID " + p.IdJogador + ") → Total: " + p.Total + " | T-Rex: " + p.TotalTRex);
                    Log("      CD:" + p.CD + " FI:" + p.FI + " IS:" + p.IS + " MT:" + p.MT + " PA:" + p.PA + " RI:" + p.RI + " RS:" + p.RS + " Bônus T-Rex:" + p.BonusTRex);
                }

                int qtdEsperadaAdversarios = 0;

                foreach (JogadorInfo jogador in jogadores)
                {
                    if (jogador.Id != meuId)
                        qtdEsperadaAdversarios++;
                }

                int qtdCarregadaAdversarios = tabuleirosAdversarios == null ? 0 : tabuleirosAdversarios.Count;

                if (qtdCarregadaAdversarios < qtdEsperadaAdversarios)
                    LogInfoTick("PLACAR", "alguns adversários não foram carregados; Rei da Selva pode estar estimado");

                LogSeparadorTick();
            }
            catch (Exception ex)
            {
                LogErroTick("PLACAR", "Não foi possível calcular placar parcial: " + ex.Message);
            }
        }

        private Dictionary<int, Dictionary<string, List<string>>> MontarTabuleirosParaPontuacao(Dictionary<string, List<string>> meuTabuleiro, Dictionary<int, Dictionary<string, List<string>>> tabuleirosAdversarios)
        {
            var todos = new Dictionary<int, Dictionary<string, List<string>>>();

            todos[meuId] = ClonarTabuleiro(meuTabuleiro);

            if (tabuleirosAdversarios != null)
            {
                foreach (var adv in tabuleirosAdversarios)
                    todos[adv.Key] = ClonarTabuleiro(adv.Value);
            }

            return todos;
        }

        private PlacarJogador CalcularPlacarJogador(int idJogador, string nome, Dictionary<int, Dictionary<string, List<string>>> todosTabuleiros)
        {
            Dictionary<string, List<string>> tabuleiro = todosTabuleiros.ContainsKey(idJogador)
                ? todosTabuleiros[idJogador]
                : new Dictionary<string, List<string>>();

            var placar = new PlacarJogador
            {
                IdJogador = idJogador,
                Nome = nome
            };

            placar.CD = CalcularCD(tabuleiro);
            placar.FI = CalcularFI(tabuleiro);
            placar.IS = CalcularIS(tabuleiro);
            placar.MT = CalcularMT(tabuleiro);
            placar.PA = CalcularPA(tabuleiro);
            placar.RI = CalcularRI(tabuleiro);
            placar.RS = CalcularRS(idJogador, tabuleiro, todosTabuleiros);
            placar.BonusTRex = CalcularBonusTRex(tabuleiro);
            placar.TotalTRex = ContarDinoNoZoo(tabuleiro, "Ti");

            placar.Total = placar.CD
                         + placar.FI
                         + placar.IS
                         + placar.MT
                         + placar.PA
                         + placar.RI
                         + placar.RS
                         + placar.BonusTRex;

            return placar;
        }

        private int CalcularCD(Dictionary<string, List<string>> tabuleiro)
        {
            int qtd = ContarEspeciesDiferentes(ObterDinosCercado(tabuleiro, "CD"));

            if (qtd < 0)
                qtd = 0;

            if (qtd > 6)
                qtd = 6;

            return pontosCD[qtd];
        }

        private int CalcularFI(Dictionary<string, List<string>> tabuleiro)
        {
            int qtd = ObterDinosCercado(tabuleiro, "FI").Count;

            if (qtd < 0)
                qtd = 0;

            if (qtd > 6)
                qtd = 6;

            return pontosFI[qtd];
        }

        private int CalcularIS(Dictionary<string, List<string>> tabuleiro)
        {
            List<string> ilha = ObterDinosCercado(tabuleiro, "IS");

            if (ilha.Count != 1)
                return 0;

            string dino = ilha[0];

            return ContarDinoNoZoo(tabuleiro, dino) == 1 ? 7 : 0;
        }

        private int CalcularMT(Dictionary<string, List<string>> tabuleiro)
        {
            return ObterDinosCercado(tabuleiro, "MT").Count == 3 ? 7 : 0;
        }

        private int CalcularPA(Dictionary<string, List<string>> tabuleiro)
        {
            List<string> pradaria = ObterDinosCercado(tabuleiro, "PA");
            var contagem = new Dictionary<string, int>();

            foreach (string dino in pradaria)
            {
                if (!contagem.ContainsKey(dino))
                    contagem[dino] = 0;

                contagem[dino]++;
            }

            int pontos = 0;

            foreach (var item in contagem)
                pontos += (item.Value / 2) * 5;

            return pontos;
        }

        private int CalcularRI(Dictionary<string, List<string>> tabuleiro)
        {
            return ObterDinosCercado(tabuleiro, "RI").Count;
        }

        private int CalcularRS(int idJogador, Dictionary<string, List<string>> tabuleiro, Dictionary<int, Dictionary<string, List<string>>> todosTabuleiros)
        {
            List<string> rei = ObterDinosCercado(tabuleiro, "RS");

            if (rei.Count != 1)
                return 0;

            string dino = rei[0];
            int meuTotal = ContarDinoNoZoo(tabuleiro, dino);
            bool temAdversarios = todosTabuleiros.Count > 1;

            if (!temAdversarios)
            {
                if (meuTotal >= 3)
                    return 7;

                if (meuTotal == 2)
                    return 4;

                return 0;
            }

            foreach (var item in todosTabuleiros)
            {
                if (item.Key == idJogador)
                    continue;

                int totalAdversario = ContarDinoNoZoo(item.Value, dino);

                if (meuTotal < totalAdversario)
                    return 0;
            }

            return 7;
        }

        private int CalcularBonusTRex(Dictionary<string, List<string>> tabuleiro)
        {
            int bonus = 0;

            foreach (var item in tabuleiro)
            {
                if (item.Key == "RI")
                    continue;

                if (item.Value.Contains("Ti"))
                    bonus++;
            }

            return bonus;
        }

        // AUXILIARES DA HEURÍSTICA

        private Dictionary<string, List<string>> ClonarTabuleiro(Dictionary<string, List<string>> tabuleiro)
        {
            var clone = new Dictionary<string, List<string>>();

            if (tabuleiro == null)
                return clone;

            foreach (var item in tabuleiro)
                clone[item.Key] = new List<string>(item.Value);

            return clone;
        }

        private List<string> ObterDinosCercado(Dictionary<string, List<string>> tabuleiro, string cercado)
        {
            if (tabuleiro == null)
                return new List<string>();

            if (!tabuleiro.ContainsKey(cercado))
                return new List<string>();

            return tabuleiro[cercado];
        }

        private int ContarDinoNoCercado(Dictionary<string, List<string>> tabuleiro, string cercado, string dino)
        {
            int total = 0;

            foreach (string item in ObterDinosCercado(tabuleiro, cercado))
            {
                if (item == dino)
                    total++;
            }

            return total;
        }

        private int ContarDinoNoZoo(Dictionary<string, List<string>> tabuleiro, string dino)
        {
            int total = 0;

            if (tabuleiro == null)
                return total;

            foreach (var cercado in tabuleiro)
            {
                foreach (string item in cercado.Value)
                {
                    if (item == dino)
                        total++;
                }
            }

            return total;
        }

        private int ContarEspeciesDiferentes(List<string> dinos)
        {
            var especies = new HashSet<string>();

            foreach (string dino in dinos)
                especies.Add(dino);

            return especies.Count;
        }

        private int ObterMaiorQuantidadeAdversaria(string dino, Dictionary<int, Dictionary<string, List<string>>> tabuleirosAdversarios)
        {
            int maior = 0;

            if (tabuleirosAdversarios == null)
                return maior;

            foreach (var adv in tabuleirosAdversarios)
            {
                int qtd = ContarDinoNoZoo(adv.Value, dino);

                if (qtd > maior)
                    maior = qtd;
            }

            return maior;
        }

        // BOTÕES

        private void btnVerificarTurno_Click(object sender, EventArgs e)
        {
        }

        private void btnVerMao_Click(object sender, EventArgs e)
        {
        }

        private void btnAtualizarJogadores_Click(object sender, EventArgs e)
        {
            AtualizarJogadores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.ListarPartidas("T");

            if (VerificarErro(retorno))
                return;

            listBoxPartidas.Items.Clear();

            foreach (string partida in SepararLinhas(retorno))
            {
                string[] dados = SepararCsv(partida);

                if (dados.Length < 4)
                    continue;

                string status = dados[3].Trim() == "J" ? "Jogando"
                              : dados[3].Trim() == "E" ? "Encerrada"
                              : "Aberta";

                listBoxPartidas.Items.Add("[" + dados[0].Trim() + "] " + dados[1].Trim() + " — " + dados[2].Trim() + " (" + status + ")");
            }
        }

        private void listBoxPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPartidas.SelectedItem == null)
                return;

            string item = listBoxPartidas.SelectedItem.ToString();
            string[] partes = item.Split(']');

            if (partes.Length < 2)
                return;

            string idTexto = partes[0].Replace("[", "").Trim();

            int idPartida;

            if (!int.TryParse(idTexto, out idPartida))
                return;

            idPartidaSelecionada = idPartida;

            string resto = partes[1].Trim();
            string[] splits = resto.Split('—');

            if (splits.Length < 2)
                return;

            string nome = splits[0].Trim();
            string dataStatus = splits[1].Trim();
            string data = dataStatus.Split('(')[0].Trim();
            string status = dataStatus.Contains("(") ? dataStatus.Split('(')[1].Replace(")", "").Trim() : "";

            lblNomePartida.Text = "Nome: " + nome;
            lblDataPartida.Text = "Data: " + data;
            lblStatusPartida.Text = "Status: " + status;

            AtualizarJogadores();
        }

        private void btnAdicionarJogador_Click(object sender, EventArgs e)
        {
            using (Form2 telaLogin = new Form2(idPartidaSelecionada))
            {
                if (telaLogin.ShowDialog() != DialogResult.OK)
                    return;

                string[] dados = SepararCsv(telaLogin.Tag == null ? "" : telaLogin.Tag.ToString());

                if (dados.Length < 3)
                    return;

                int id;
                int idPartida;

                if (!int.TryParse(dados[0].Trim(), out id))
                    return;

                if (!int.TryParse(dados[2].Trim(), out idPartida))
                    return;

                meuId = id;
                minhaSenha = dados[1];
                idPartidaSelecionada = idPartida;

                lblMeuId.Text = "Meu ID: " + meuId;
                lblMinhaSenha.Text = "Minha Senha: " + minhaSenha;

                AtualizarJogadores();

                MessageBox.Show("Logado com sucesso!");
            }
        }

        // ERROS

        private bool VerificarErro(string retorno)
        {
            if (string.IsNullOrEmpty(retorno))
                return true;

            if (retorno.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }

        private bool VerificarErroSilencioso(string retorno)
        {
            if (string.IsNullOrEmpty(retorno))
                return true;

            return retorno.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase);
        }

        // ENCERRAMENTO

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            foreach (Image imagem in imagensDinos.Values)
            {
                if (imagem != null)
                    imagem.Dispose();
            }

            imagensDinos.Clear();

            base.OnFormClosed(e);
        }

        // DESIGNER

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblMeuId_Click(object sender, EventArgs e)
        {
        }

        private void lblMinhaSenha_Click(object sender, EventArgs e)
        {
        }

        private void label11_Click_1(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lblNomePartida_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void lblTurnoInfo_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void lblinfot_Click(object sender, EventArgs e)
        {

        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblFaceDado_Click(object sender, EventArgs e)
        {

        }
    }
}
