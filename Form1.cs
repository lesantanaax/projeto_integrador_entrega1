using Draft;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace projeto_integrador_entrega1
{
    public partial class Form1 : Form
    {
        private int meuId;
        private string minhaSenha;
        private int idPartidaSelecionada;
        private string faceDadoAtual = "";
        private int idJogadorComDado = 0;
        private int turnoAtual = 0;
        private int tickCount = 0;

        // ── Mapa embutido (antes era Form4) ──────────────────────────
        private Dictionary<string, FlowLayoutPanel> cercadosVisuais = new Dictionary<string, FlowLayoutPanel>();
        private string pastaResources = @"C:\Users\bruno\source\repos\projeto_integrador_entrega1\Resources\";

        private Dictionary<string, string> nomesFaces = new Dictionary<string, string>
        {
            { "AL", "Praça de Alimentação" },
            { "FL", "Floresta" },
            { "PR", "Pradaria" },
            { "TI", "Cuidado com o T-Rex" },
            { "VZ", "Cercado Vazio" },
            { "WC", "Banheiros" }
        };

        private Dictionary<string, string> nomesCercados = new Dictionary<string, string>
        {
            { "CD", "Campina da Diferença" },
            { "FI", "Floresta da Igualdade" },
            { "IS", "Ilha Solitária" },
            { "MT", "Mata Tripla" },
            { "PA", "Pradaria do Amor" },
            { "RI", "Rio" },
            { "RS", "Rei da Selva" }
        };

        private Dictionary<string, string> nomesDinos = new Dictionary<string, string>
        {
            { "Br", "Braquiossauro" },
            { "Ep", "Espinossauro" },
            { "Et", "Estegossauro" },
            { "Pa", "Parasaurolófo" },
            { "Ti", "Tiranossauro" },
            { "Tr", "Tricerátops" }
        };

        public Form1()
        {
            InitializeComponent();
            label4.Text = Jogo.versao;

            tmrPrincipal.Interval = 5000;
            tmrPrincipal.Tick += new System.EventHandler(tmrPrincipal_Tick);

            // Cria os fields do mapa sobre a picturebox do tabuleiro
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

        // ─────────────────────────────────────────────────────────────
        // MAPA EMBUTIDO — lógica do Form4 trazida para cá
        // Os FlowLayoutPanels são criados sobre a picturebox (pbMapa)
        // Ajuste as coordenadas conforme sua imagem de fundo
        // ─────────────────────────────────────────────────────────────
        private void CriarFieldsMapa()
        {
            // Posição relativa à pbMapa (picturebox do tabuleiro no Form1)
            // Ajuste os valores de Point e Size conforme seu layout
            var config = new Dictionary<string, (Point Pos, Size Tam)>
            {
                { "CD", (new Point(395, 257), new Size(195, 134)) },
                { "FI", (new Point(43,  40),  new Size(195, 134)) },
                { "IS", (new Point(481, 422), new Size(123, 113)) },
                { "MT", (new Point(43,  233), new Size(147, 147)) },
                { "PA", (new Point(79,  439), new Size(147, 147)) },
                { "RI", (new Point(304, 532), new Size(127, 84))  },
                { "RS", (new Point(425, 61),  new Size(86,  73))  }
            };

            foreach (var kv in config)
            {
                string cod = kv.Key;

                FlowLayoutPanel field = new FlowLayoutPanel
                {
                    Name         = "field_" + cod,
                    Location     = kv.Value.Pos,
                    Size         = kv.Value.Tam,
                    BorderStyle  = BorderStyle.FixedSingle,
                    BackColor    = Color.FromArgb(60, Color.Green),
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = true
                };

                // Label de identificação (útil para ajuste visual)
                Label lbl = new Label { Text = cod, AutoSize = true, BackColor = Color.Yellow };
                field.Controls.Add(lbl);

                // Adiciona sobre a picturebox pbMapa
                pbMapa.Controls.Add(field);
                field.BringToFront();

                cercadosVisuais.Add(cod, field);
            }
        }

        private void AtualizarMapa()
        {
            string retorno = Jogo.ExibirTabuleiro(meuId, minhaSenha);
            if (string.IsNullOrEmpty(retorno) || retorno.StartsWith("ERRO")) return;

            // Limpa apenas as PictureBoxes (mantém os Labels de identificação)
            foreach (var field in cercadosVisuais.Values)
            {
                for (int i = field.Controls.Count - 1; i >= 0; i--)
                    if (field.Controls[i] is PictureBox)
                        field.Controls[i].Dispose();
            }

            foreach (string linha in retorno.Replace("\r", "").Trim().Split('\n'))
            {
                string[] p = linha.Split(',');
                if (p.Length < 3) continue;

                string codCercado = p[0].Trim();
                string codDino    = p[1].Trim();
                int qtd;
                if (!int.TryParse(p[2].Trim(), out qtd)) continue;

                if (!cercadosVisuais.ContainsKey(codCercado)) continue;

                for (int i = 0; i < qtd; i++)
                {
                    string caminho = ObterCaminhoDino(codDino);
                    if (string.IsNullOrEmpty(caminho)) continue;

                    PictureBox pb = new PictureBox
                    {
                        Size     = new Size(30, 30),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    try { pb.Image = Image.FromFile(caminho); }
                    catch { pb.BackColor = Color.Red; } // fallback se imagem não existir

                    cercadosVisuais[codCercado].Controls.Add(pb);
                }
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

        // ─────────────────────────────────────────────────────────────
        // INICIAR
        // ─────────────────────────────────────────────────────────────
        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            string retornoVerif = Jogo.VerificarPartida(idPartidaSelecionada);
            bool partidaJaAtiva = !string.IsNullOrEmpty(retornoVerif)
                                  && !retornoVerif.StartsWith("ERRO")
                                  && retornoVerif.Contains(",");

            if (partidaJaAtiva)
            {
                string[] dadosVerif = retornoVerif.Replace("\r", "").Trim().Split(',');
                if (dadosVerif.Length >= 5 && dadosVerif[2].Trim() != "E")
                {
                    int.TryParse(dadosVerif[1].Trim(), out turnoAtual);
                    idJogadorComDado = Convert.ToInt32(dadosVerif[3].Trim());
                    faceDadoAtual = dadosVerif[4].Trim();
                    IniciarModoAutonomo("🔁 Partida já em andamento. Entrando no modo autônomo...");
                    return;
                }
            }

            string retorno = Jogo.Iniciar(meuId, minhaSenha);
            if (VerificarErroSilencioso(retorno))
            {
                retornoVerif = Jogo.VerificarPartida(idPartidaSelecionada);
                if (!string.IsNullOrEmpty(retornoVerif) && !retornoVerif.StartsWith("ERRO"))
                {
                    string[] dadosVerif = retornoVerif.Replace("\r", "").Trim().Split(',');
                    if (dadosVerif.Length >= 5)
                    {
                        int.TryParse(dadosVerif[1].Trim(), out turnoAtual);
                        idJogadorComDado = Convert.ToInt32(dadosVerif[3].Trim());
                        faceDadoAtual = dadosVerif[4].Trim();
                        IniciarModoAutonomo("🔁 Outro jogador iniciou. Entrando no modo autônomo...");
                        return;
                    }
                }
                Log($"❌ Erro ao iniciar: {retorno}");
                return;
            }

            string[] dados = retorno.Replace("\r", "").Trim().Split(',');
            if (dados.Length >= 2)
            {
                idJogadorComDado = Convert.ToInt32(dados[0]);
                faceDadoAtual = dados[1].Trim();
            }
            turnoAtual = 1;

            IniciarModoAutonomo("✅ Partida iniciada com sucesso!");
        }

        private void IniciarModoAutonomo(string mensagem)
        {
            txtTabuleiro.Clear();
            tickCount = 0;

            Log("═══════════════════════════════════════");
            Log("  COLOSSAIS — Sistema Autônomo");
            Log($"  Meu ID  : {meuId}");
            Log($"  Partida : {idPartidaSelecionada}");
            Log("═══════════════════════════════════════");
            Log(mensagem);
            Log("  Intervalo: 5s | Aguardando primeiro tick...");
            Log("");

            btnIniciar.Enabled = false;
            btnCarregarMao.Enabled = false;
            btnJogar.Enabled = false;

            tmrPrincipal.Start();
        }

        // ─────────────────────────────────────────────────────────────
        // TIMER
        // ─────────────────────────────────────────────────────────────
        private void tmrPrincipal_Tick(object sender, EventArgs e)
        {
            tickCount++;
            string hora = DateTime.Now.ToString("HH:mm:ss");
            Log($"── TICK #{tickCount} [{hora}] ──────────────────────");

            string retorno = Jogo.VerificarPartida(idPartidaSelecionada);
            if (string.IsNullOrEmpty(retorno) || retorno.StartsWith("ERRO"))
            {
                Log($"  ⚠ VerificarPartida: {retorno}");
                return;
            }

            string[] dados = retorno.Replace("\r", "").Trim().Split(',');
            if (dados.Length < 5) { Log($"  ⚠ Retorno incompleto: \"{retorno}\""); return; }

            string statusPartida = dados[0].Trim();
            int novoTurno;
            if (!int.TryParse(dados[1].Trim(), out novoTurno)) return;

            string statusTurno = dados[2].Trim();
            idJogadorComDado = Convert.ToInt32(dados[3].Trim());
            faceDadoAtual = dados[4].Trim();

            if (novoTurno != turnoAtual)
            {
                Log($"  🔄 Turno avançou: {turnoAtual} → {novoTurno}");
                turnoAtual = novoTurno;
            }

            string nomeDono = BuscarNomeJogador(idJogadorComDado);
            string nomeFace = nomesFaces.ContainsKey(faceDadoAtual) ? nomesFaces[faceDadoAtual] : faceDadoAtual;
            bool euTenhoDado = idJogadorComDado == meuId;
            bool partidaAtiva = statusPartida != "E";

            Log($"  Turno     : {turnoAtual} ({(statusTurno == "A" ? "aberto" : "fechado")})");
            Log($"  Status    : {(partidaAtiva ? "Em andamento" : "ENCERRADA")}");
            Log($"  Meu ID    : {meuId}");
            Log($"  Dado com  : {nomeDono} (ID {idJogadorComDado})");
            Log($"  Condição  : {nomeFace}{(euTenhoDado ? " ★ (eu tenho — jogo livre)" : "")}");

            lblTurnoInfo.Text = $"Turno: {turnoAtual} | Dado: {nomeDono}{(euTenhoDado ? " ★" : "")} | {nomeFace} | {(partidaAtiva ? "Em andamento" : "Encerrada")}";
            AtualizarJogadores();
            AtualizarMapa(); // atualiza o mapa embutido a cada tick

            if (!partidaAtiva)
            {
                tmrPrincipal.Stop();
                Log("");
                Log("🏁 PARTIDA ENCERRADA!");
                LogTabuleiro();
                btnIniciar.Enabled = true;
                return;
            }

            // Verifica se já joguei neste turno via VerificarTurno
            string retornoTurno = Jogo.VerificarTurno(idPartidaSelecionada, turnoAtual);
            Log($"  VerificarTurno raw: \"{retornoTurno?.Trim()}\"");

            bool euJaJoguei = EuJaJogueiNesTurno(retornoTurno);
            Log($"  Eu já joguei : {(euJaJoguei ? "✅ SIM — aguardando outros" : "❌ NÃO — preciso jogar")}");

            if (euJaJoguei)
            {
                Log("  ⏳ Aguardando outros jogadores...");
                Log("");
                return;
            }

            // Minha vez de jogar
            tmrPrincipal.Stop();

            Log($"  ★ JOGANDO! {(euTenhoDado ? "Livre (tenho o dado)" : $"Condição: {nomeFace}")}");

            string maoRaw = Jogo.ExibirMao(meuId, minhaSenha);
            var mao = ParsearMao(maoRaw);
            var tabuleiro = CarregarTabuleiro();

            Log($"  Mão: [{string.Join(", ", mao)}]");

            if (mao.Count == 0)
            {
                Log("  ⚠ Mão vazia.");
                tmrPrincipal.Start();
                return;
            }

            string codDino = null;
            string cercado = null;
            EscolherMelhorJogada(mao, tabuleiro, out codDino, out cercado);

            string nomeD = nomesDinos.ContainsKey(codDino) ? nomesDinos[codDino] : codDino;
            string nomeC = nomesCercados.ContainsKey(cercado) ? nomesCercados[cercado] : cercado;
            Log($"  Decisão: {nomeD} → {nomeC}");

            string resultado = Jogo.Jogar(meuId, minhaSenha, codDino, cercado);
            Log($"  Resultado: \"{resultado?.Trim()}\"");

            if (!string.IsNullOrEmpty(resultado) && !resultado.StartsWith("ERRO"))
            {
                lblTurnoInfo.Text = $"🤖 Turno {turnoAtual}: {nomeD} → {nomeC}";
                Log($"  ✅ Jogada registrada! Aguardando outros concluírem o turno {turnoAtual}...");
                LogTabuleiro();
                AtualizarMapa();
            }
            else
            {
                Log($"  ❌ Erro: {resultado?.Trim()} — tentará no próximo tick.");
            }

            Log("");
            tmrPrincipal.Start();
        }

        // ─────────────────────────────────────────────────────────────
        // EuJaJogueiNesTurno — lê lista de jogadas do VerificarTurno
        // ─────────────────────────────────────────────────────────────
        private bool EuJaJogueiNesTurno(string retornoTurno)
        {
            if (string.IsNullOrEmpty(retornoTurno) || retornoTurno.StartsWith("ERRO"))
                return false;

            string[] linhas = retornoTurno.Replace("\r", "").Trim().Split('\n');

            // Linha 0: StatusTurno, IdComDado, FaceDado
            // Linhas 1+: IdJogador, CodDino, CodCercado
            for (int i = 1; i < linhas.Length; i++)
            {
                string linha = linhas[i].Trim();
                if (string.IsNullOrEmpty(linha)) continue;
                string[] partes = linha.Split(',');
                int idNaLinha;
                if (int.TryParse(partes[0].Trim(), out idNaLinha) && idNaLinha == meuId)
                    return true;
            }
            return false;
        }

        // ─────────────────────────────────────────────────────────────
        // LOG
        // ─────────────────────────────────────────────────────────────
        private void LogTabuleiro()
        {
            var tab = CarregarTabuleiro();
            if (tab.Count == 0) return;
            Log("  Tabuleiro:");
            foreach (var kv in tab)
            {
                if (kv.Value.Count == 0) continue;
                string nomeCerc = nomesCercados.ContainsKey(kv.Key) ? nomesCercados[kv.Key] : kv.Key;
                var cont = new Dictionary<string, int>();
                foreach (string d in kv.Value) { if (!cont.ContainsKey(d)) cont[d] = 0; cont[d]++; }
                foreach (var dc in cont)
                {
                    string nd = nomesDinos.ContainsKey(dc.Key) ? nomesDinos[dc.Key] : dc.Key;
                    Log($"    {nomeCerc}: {nd} x{dc.Value}");
                }
            }
        }

        private void Log(string msg)
        {
            txtTabuleiro.AppendText(msg + Environment.NewLine);
            txtTabuleiro.SelectionStart = txtTabuleiro.Text.Length;
            txtTabuleiro.ScrollToCaret();
        }

        // ─────────────────────────────────────────────────────────────
        // AUXILIARES DO MOTOR
        // ─────────────────────────────────────────────────────────────
        private List<string> ParsearMao(string maoRaw)
        {
            var mao = new List<string>();
            if (string.IsNullOrEmpty(maoRaw) || maoRaw.StartsWith("ERRO")) return mao;
            foreach (string linha in maoRaw.Replace("\r", "").Trim().Split('\n'))
            {
                if (string.IsNullOrEmpty(linha)) continue;
                string[] p = linha.Trim().Split(',');
                if (p.Length < 2) continue;
                int qtd;
                if (!int.TryParse(p[1].Trim(), out qtd) || qtd <= 0) continue;
                mao.Add(p[0].Trim());
            }
            return mao;
        }

        private Dictionary<string, List<string>> CarregarTabuleiro()
        {
            var tabuleiro = new Dictionary<string, List<string>>();
            string raw = Jogo.ExibirTabuleiro(meuId, minhaSenha);
            if (string.IsNullOrEmpty(raw) || raw.StartsWith("ERRO")) return tabuleiro;
            foreach (string linha in raw.Replace("\r", "").Trim().Split('\n'))
            {
                string[] p = linha.Trim().Split(',');
                if (p.Length < 3) continue;
                string cercado = p[0].Trim();
                string dino = p[1].Trim();
                int qtd;
                if (!int.TryParse(p[2].Trim(), out qtd)) continue;
                if (!tabuleiro.ContainsKey(cercado)) tabuleiro[cercado] = new List<string>();
                for (int i = 0; i < qtd; i++) tabuleiro[cercado].Add(dino);
            }
            return tabuleiro;
        }

        // ─────────────────────────────────────────────────────────────
        // HEURÍSTICA
        // ─────────────────────────────────────────────────────────────
        private void EscolherMelhorJogada(List<string> mao, Dictionary<string, List<string>> tabuleiro,
                                           out string melhorDino, out string melhorCercado)
        {
            melhorDino = null;
            melhorCercado = null;
            int melhorScore = int.MinValue;
            bool temDado = idJogadorComDado == meuId;

            foreach (string dino in mao)
            {
                foreach (string cercado in ObterCercadosCandidatos(dino, tabuleiro, temDado))
                {
                    int score = AvaliarJogada(dino, cercado, tabuleiro);
                    if (score > melhorScore)
                    {
                        melhorScore = score;
                        melhorDino = dino;
                        melhorCercado = cercado;
                    }
                }
            }

            if (melhorDino == null) { melhorDino = mao[0]; melhorCercado = "RI"; }
        }

        private List<string> ObterCercadosCandidatos(string dino, Dictionary<string, List<string>> tab, bool temDado)
        {
            string[] todos = { "IS", "RS", "MT", "FI", "CD", "PA" };
            var candidatos = new List<string>();
            foreach (string c in todos)
            {
                if (!temDado && !CercadoPermitidoPeloDadoComTab(c, tab)) continue;
                if (!CercadoAceitaDino(c, dino, tab)) continue;
                candidatos.Add(c);
            }
            candidatos.Add("RI");
            return candidatos;
        }

        private bool CercadoAceitaDino(string cercado, string dino, Dictionary<string, List<string>> tab)
        {
            var cont = tab.ContainsKey(cercado) ? tab[cercado] : new List<string>();
            switch (cercado)
            {
                case "IS": return cont.Count == 0;
                case "RS": return cont.Count == 0;
                case "MT": return cont.Count < 3;
                case "FI": return cont.Count == 0 || cont.TrueForAll(d => d == dino);
                case "CD": return !cont.Contains(dino);
                case "PA": return true;
                case "RI": return true;
                default:   return true;
            }
        }

        private bool CercadoPermitidoPeloDadoComTab(string codCercado, Dictionary<string, List<string>> tab)
        {
            if (string.IsNullOrEmpty(faceDadoAtual)) return true;
            if (codCercado == "RI") return true;
            switch (faceDadoAtual)
            {
                case "AL": return codCercado == "IS";
                case "FL": return codCercado == "FI" || codCercado == "MT";
                case "PR": return codCercado == "PA" || codCercado == "CD";
                case "WC": return codCercado == "RS";
                case "TI":
                    var contTI = tab.ContainsKey(codCercado) ? tab[codCercado] : new List<string>();
                    return !contTI.Contains("Ti");
                case "VZ":
                    var contVZ = tab.ContainsKey(codCercado) ? tab[codCercado] : new List<string>();
                    return contVZ.Count == 0;
                default: return true;
            }
        }

        private int AvaliarJogada(string dino, string cercado, Dictionary<string, List<string>> tab)
        {
            var cont = tab.ContainsKey(cercado) ? tab[cercado] : new List<string>();
            switch (cercado)
            {
                case "IS": return 7;
                case "RS": return 6;
                case "PA":
                    int iguais = 0;
                    foreach (string d in cont) if (d == dino) iguais++;
                    return iguais % 2 == 1 ? 8 : 3;
                case "FI":
                    if (cont.Count == 0) return 3;
                    if (cont[0] == dino) return 4 + cont.Count;
                    return -99;
                case "CD":
                    return 3 + cont.Count;
                case "MT":
                    return dino == "Ti" ? 5 : 3;
                case "RI":
                    return 1;
                default:
                    return 1;
            }
        }

        // ─────────────────────────────────────────────────────────────
        // BOTÕES — mantidos para o Designer compilar
        // ─────────────────────────────────────────────────────────────
        private void btnVerificarTurno_Click(object sender, EventArgs e) { }
        private void btnVerMao_Click(object sender, EventArgs e) { }
        private void btnCarregarMao_Click(object sender, EventArgs e) { }
        private void btnCarregarMao_Click_1(object sender, EventArgs e) { }
        private void btnJogar_Click(object sender, EventArgs e) { }
        private void btnJogar_Click_1(object sender, EventArgs e) { }
        private void btnVerTabuleiro_Click(object sender, EventArgs e) { }
        private void btnAtualizarJogadores_Click(object sender, EventArgs e) => AtualizarJogadores();

        private void button1_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.ListarPartidas("T");
            if (VerificarErro(retorno)) return;
            listBoxPartidas.Items.Clear();
            foreach (string partida in retorno.Replace("\r", "").Trim().Split('\n'))
            {
                if (string.IsNullOrEmpty(partida)) continue;
                string[] dados = partida.Split(',');
                if (dados.Length >= 4)
                {
                    string status = dados[3].Trim() == "J" ? "Jogando"
                                  : dados[3].Trim() == "E" ? "Encerrada" : "Aberta";
                    listBoxPartidas.Items.Add($"[{dados[0].Trim()}] {dados[1].Trim()} — {dados[2].Trim()} ({status})");
                }
            }
        }

        private void listBoxPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPartidas.SelectedItem == null) return;
            string item = listBoxPartidas.SelectedItem.ToString();
            string[] partes = item.Split(']');
            if (partes.Length < 2) return;
            string resto = partes[1].Trim();
            string[] splits = resto.Split('—');
            if (splits.Length < 2) return;
            string nome = splits[0].Trim();
            string dataStatus = splits[1].Trim();
            string data = dataStatus.Split('(')[0].Trim();
            string status = dataStatus.Contains("(") ? dataStatus.Split('(')[1].Replace(")", "").Trim() : "";
            lblNomePartida.Text = "Nome: " + nome;
            lblDataPartida.Text = "Data: " + data;
            lblStatusPartida.Text = "Status: " + status;
            string id = item.Split(']')[0].Replace("[", "").Trim();
            string retornoJog = Jogo.ListarJogadores(Convert.ToInt32(id));
            if (string.IsNullOrEmpty(retornoJog) || retornoJog.StartsWith("ERRO")) return;
            listBoxJogadores.Items.Clear();
            foreach (string j in retornoJog.Replace("\r", "").Trim().Split('\n'))
                if (!string.IsNullOrEmpty(j)) listBoxJogadores.Items.Add(j.Trim());
        }

        private void btnAdicionarJogador_Click(object sender, EventArgs e)
        {
            using (Form2 telaLogin = new Form2(idPartidaSelecionada))
            {
                if (telaLogin.ShowDialog() == DialogResult.OK)
                {
                    string[] dados = telaLogin.Tag.ToString().Split(',');
                    this.meuId = Convert.ToInt32(dados[0]);
                    this.minhaSenha = dados[1];
                    this.idPartidaSelecionada = Convert.ToInt32(dados[2]);
                    lblMeuId.Text = "Meu ID: " + meuId;
                    lblMinhaSenha.Text = "Minha Senha: " + minhaSenha;
                    AtualizarJogadores();
                    MessageBox.Show("Logado com sucesso!");
                }
            }
        }

        // ─────────────────────────────────────────────────────────────
        // AUXILIARES GERAIS
        // ─────────────────────────────────────────────────────────────
        private bool CercadoPermitidoPeloDado(string codCercado)
        {
            if (string.IsNullOrEmpty(faceDadoAtual)) return true;
            if (codCercado == "RI") return true;
            switch (faceDadoAtual)
            {
                case "AL": return codCercado == "IS";
                case "FL": return codCercado == "FI" || codCercado == "MT";
                case "PR": return codCercado == "PA" || codCercado == "CD";
                case "WC": return codCercado == "RS";
                case "TI": return CercadoSemTRex(codCercado);
                case "VZ": return CercadoVazio(codCercado);
                default:   return true;
            }
        }

        private bool CercadoSemTRex(string codCercado)
        {
            string raw = Jogo.ExibirTabuleiro(meuId, minhaSenha);
            foreach (string linha in raw.Replace("\r", "").Trim().Split('\n'))
            {
                string[] p = linha.Trim().Split(',');
                if (p.Length >= 3 && p[0].Trim() == codCercado && p[1].Trim() == "Ti" && Convert.ToInt32(p[2].Trim()) > 0)
                    return false;
            }
            return true;
        }

        private bool CercadoVazio(string codCercado)
        {
            string raw = Jogo.ExibirTabuleiro(meuId, minhaSenha);
            foreach (string linha in raw.Replace("\r", "").Trim().Split('\n'))
            {
                string[] p = linha.Trim().Split(',');
                if (p.Length >= 3 && p[0].Trim() == codCercado && Convert.ToInt32(p[2].Trim()) > 0)
                    return false;
            }
            return true;
        }

        private string BuscarNomeJogador(int idJogador)
        {
            string retorno = Jogo.ListarJogadores(idPartidaSelecionada);
            foreach (string j in retorno.Replace("\r", "").Trim().Split('\n'))
            {
                string[] p = j.Trim().Split(',');
                if (p.Length >= 2 && Convert.ToInt32(p[0].Trim()) == idJogador)
                    return p[1].Trim();
            }
            return "ID " + idJogador;
        }

        private void AtualizarJogadores()
        {
            string retorno = Jogo.ListarJogadores(idPartidaSelecionada);
            if (string.IsNullOrEmpty(retorno) || retorno.StartsWith("ERRO")) return;
            listBoxJogadores.Items.Clear();
            foreach (string j in retorno.Replace("\r", "").Trim().Split('\n'))
            {
                if (string.IsNullOrEmpty(j)) continue;
                string[] dados = j.Split(',');
                string st = (dados.Length > 2 && dados[2].Trim() == "J") ? "✅" : "⏳";
                listBoxJogadores.Items.Add($"{st} {dados[1].Trim()}");
            }
        }

        private bool VerificarErro(string retorno)
        {
            if (string.IsNullOrEmpty(retorno)) return true;
            if (retorno.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private bool VerificarErroSilencioso(string retorno)
        {
            if (string.IsNullOrEmpty(retorno)) return true;
            return retorno.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase);
        }

        // Eventos vazios para o Designer
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void lblMeuId_Click(object sender, EventArgs e) { }
        private void lblMinhaSenha_Click(object sender, EventArgs e) { }
        private void label11_Click_1(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbDino_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbCercado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblNomePartida_Click(object sender, EventArgs e) { }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void lblTurnoInfo_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}