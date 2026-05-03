using Draft;
using System;
using System.Collections.Generic;
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
        // INICIAR
        // ─────────────────────────────────────────────────────────────
        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            // Verifica se a partida já está ativa antes de tentar iniciar
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
                    AbrirTabuleiro();
                    IniciarModoAutonomo("🔁 Partida já em andamento. Entrando no modo autônomo...");
                    return;
                }
            }

            // Inicia a partida
            string retorno = Jogo.Iniciar(meuId, minhaSenha);
            if (VerificarErroSilencioso(retorno))
            {
                // Outro jogador pode ter iniciado — tenta entrar
                retornoVerif = Jogo.VerificarPartida(idPartidaSelecionada);
                if (!string.IsNullOrEmpty(retornoVerif) && !retornoVerif.StartsWith("ERRO"))
                {
                    string[] dadosVerif = retornoVerif.Replace("\r", "").Trim().Split(',');
                    if (dadosVerif.Length >= 5)
                    {
                        int.TryParse(dadosVerif[1].Trim(), out turnoAtual);
                        idJogadorComDado = Convert.ToInt32(dadosVerif[3].Trim());
                        faceDadoAtual = dadosVerif[4].Trim();
                        AbrirTabuleiro();
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
            AbrirTabuleiro();

            IniciarModoAutonomo("✅ Partida iniciada com sucesso!");
        }

        private void AbrirTabuleiro()
        {
            Form4 f = (Form4)Application.OpenForms["Form4"];
            if (f == null)
            {
                f = new Form4();
                f.Name = "Form4";
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
            f.AtualizarMapa(meuId, minhaSenha);
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

            // PASSO 1: VerificarPartida — estado geral da partida
            string retorno = Jogo.VerificarPartida(idPartidaSelecionada);
            if (string.IsNullOrEmpty(retorno) || retorno.StartsWith("ERRO"))
            {
                Log($"  ⚠ VerificarPartida: {retorno}");
                return;
            }

            string[] dados = retorno.Replace("\r", "").Trim().Split(',');
            if (dados.Length < 5) { Log($"  ⚠ Retorno incompleto: \"{retorno}\""); return; }

            // Formato: StatusPartida, Turno, StatusTurno, IdJogadorComDado, FaceDado
            string statusPartida = dados[0].Trim(); // J = jogando, E = encerrada
            int novoTurno;
            if (!int.TryParse(dados[1].Trim(), out novoTurno)) return;

            string statusTurno = dados[2].Trim();   // A = aberto, F = fechado
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
            Log($"  Condição  : {nomeFace} {(euTenhoDado ? "★ (eu tenho — jogo livre)" : "")}");

            lblTurnoInfo.Text = $"Turno: {turnoAtual} | Dado: {nomeDono}{(euTenhoDado ? " ★" : "")} | {nomeFace} | {(partidaAtiva ? "Em andamento" : "Encerrada")}";
            AtualizarJogadores();

            if (Application.OpenForms["Form4"] is Form4 f4)
                f4.AtualizarMapa(meuId, minhaSenha);

            if (!partidaAtiva)
            {
                tmrPrincipal.Stop();
                Log("");
                Log("🏁 PARTIDA ENCERRADA!");
                LogTabuleiro();
                btnIniciar.Enabled = true;
                return;
            }

            // PASSO 2: VerificarTurno — checa se EU já joguei neste turno
            // Retorno: StatusTurno, IdJogadorComDado, FaceDado, [IdJogador, CodDino, CodCercado, ...]
            string retornoTurno = Jogo.VerificarTurno(idPartidaSelecionada, turnoAtual);
            Log($"  VerificarTurno raw: \"{retornoTurno?.Trim()}\"");

            bool euJaJoguei = EuJaJogueiNesTurno(retornoTurno);
            Log($"  Eu já joguei : {(euJaJoguei ? "✅ SIM — aguardando outros" : "❌ NÃO — preciso jogar")}");

            if (euJaJoguei)
            {
                Log("  ⏳ Aguardando outros jogadores...");
                LogTabuleiro();
                Log("");
                return;
            }

            // PASSO 3: Minha vez — busca informações e joga
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

            // PASSO 4: Decisão
            string codDino = null;
            string cercado = null;
            EscolherMelhorJogada(mao, tabuleiro, out codDino, out cercado);

            string nomeD = nomesDinos.ContainsKey(codDino) ? nomesDinos[codDino] : codDino;
            string nomeC = nomesCercados.ContainsKey(cercado) ? nomesCercados[cercado] : cercado;
            Log($"  Decisão: {nomeD} → {nomeC}");

            // PASSO 5: Jogar
            string resultado = Jogo.Jogar(meuId, minhaSenha, codDino, cercado);
            Log($"  Resultado: \"{resultado?.Trim()}\"");

            if (!string.IsNullOrEmpty(resultado) && !resultado.StartsWith("ERRO"))
            {
                lblTurnoInfo.Text = $"🤖 Turno {turnoAtual}: {nomeD} → {nomeC}";
                Log($"  ✅ Jogada registrada! Aguardando outros concluírem o turno {turnoAtual}...");
                LogTabuleiro();

                if (Application.OpenForms["Form4"] is Form4 f4b)
                    f4b.AtualizarMapa(meuId, minhaSenha);
            }
            else
            {
                Log($"  ❌ Erro: {resultado?.Trim()} — tentará no próximo tick.");
            }

            Log("");
            tmrPrincipal.Start();
        }

        // ─────────────────────────────────────────────────────────────
        // Verifica na lista de jogadas do turno se meu ID já aparece
        // Retorno do VerificarTurno:
        //   linha 1: StatusTurno, IdComDado, FaceDado
        //   linhas seguintes: IdJogador, CodDino, CodCercado
        // ─────────────────────────────────────────────────────────────
        private bool EuJaJogueiNesTurno(string retornoTurno)
        {
            if (string.IsNullOrEmpty(retornoTurno) || retornoTurno.StartsWith("ERRO"))
                return false; // se não conseguiu verificar, tenta jogar

            string[] linhas = retornoTurno.Replace("\r", "").Trim().Split('\n');

            // A partir da segunda linha vêm as jogadas: IdJogador,CodDino,CodCercado
            for (int i = 1; i < linhas.Length; i++)
            {
                string linha = linhas[i].Trim();
                if (string.IsNullOrEmpty(linha)) continue;

                string[] partes = linha.Split(',');
                if (partes.Length < 1) continue;

                int idNaLinha;
                if (int.TryParse(partes[0].Trim(), out idNaLinha) && idNaLinha == meuId)
                    return true; // meu ID está na lista de jogadas — já joguei
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
                default: return true;
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
        private void btnVerificarTurno_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.VerificarPartida(idPartidaSelecionada);
            if (VerificarErro(retorno)) return;
            string[] dados = retorno.Replace("\r", "").Trim().Split(',');
            idJogadorComDado = Convert.ToInt32(dados[3].Trim());
            faceDadoAtual = dados[4].Trim();
            string nomeJogador = BuscarNomeJogador(idJogadorComDado);
            string nomeFace = nomesFaces.ContainsKey(faceDadoAtual) ? nomesFaces[faceDadoAtual] : faceDadoAtual;
            lblTurnoInfo.Text = $"Turno: {dados[1].Trim()} | Dado: {nomeJogador} | {nomeFace}";
        }

        private void btnVerMao_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.ExibirMao(meuId, minhaSenha);
            if (VerificarErro(retorno)) return;
            lstMao.Items.Clear();
            foreach (string d in retorno.Replace("\r", "").Trim().Split('\n'))
            {
                if (string.IsNullOrEmpty(d)) continue;
                string[] partes = d.Trim().Split(',');
                if (partes.Length < 2) continue;
                string codigo = partes[0].Trim();
                string nome = nomesDinos.ContainsKey(codigo) ? nomesDinos[codigo] : codigo;
                int qtd;
                if (!int.TryParse(partes[1].Trim(), out qtd)) continue;
                lstMao.Items.Add($"{codigo} : {nome} (x{qtd})");
            }
        }

        private void btnCarregarMao_Click(object sender, EventArgs e) { }
        private void btnCarregarMao_Click_1(object sender, EventArgs e) { }
        private void btnJogar_Click(object sender, EventArgs e) { }
        private void btnJogar_Click_1(object sender, EventArgs e) { }

        private void btnVerTabuleiro_Click(object sender, EventArgs e)
        {
            Form4 f = (Form4)Application.OpenForms["Form4"];
            if (f == null) { f = new Form4(); f.Name = "Form4"; f.Show(); }
            else f.BringToFront();
            f.AtualizarMapa(meuId, minhaSenha);
        }

        private void btnAtualizarJogadores_Click(object sender, EventArgs e) => AtualizarJogadores();

        private void button1_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.ListarPartidas("T");
            if (VerificarErro(retorno)) return;
            list.Items.Clear();
            foreach (string partida in retorno.Replace("\r", "").Trim().Split('\n'))
            {
                if (string.IsNullOrEmpty(partida)) continue;
                string[] dados = partida.Split(',');
                if (dados.Length >= 4)
                {
                    string status = dados[3].Trim() == "J" ? "Jogando"
                                  : dados[3].Trim() == "E" ? "Encerrada" : "Aberta";
                    list.Items.Add($"[{dados[0].Trim()}] {dados[1].Trim()} — {dados[2].Trim()} ({status})");
                }
            }
        }

        private void listBoxPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list.SelectedItem == null) return;
            string item = list.SelectedItem.ToString();
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
            listPlayers.Items.Clear();
            foreach (string j in retornoJog.Replace("\r", "").Trim().Split('\n'))
                if (!string.IsNullOrEmpty(j)) listPlayers.Items.Add(j.Trim());
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
                default: return true;
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
            listPlayers.Items.Clear();
            foreach (string j in retorno.Replace("\r", "").Trim().Split('\n'))
            {
                if (string.IsNullOrEmpty(j)) continue;
                string[] dados = j.Split(',');
                string st = (dados.Length > 2 && dados[2].Trim() == "J") ? "✅" : "⏳";
                listPlayers.Items.Add($"{st} {dados[1].Trim()}");
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

      
    }
}
