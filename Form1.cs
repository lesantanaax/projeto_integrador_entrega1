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
        private int turnoAtual = 1;
        private int ultimoTurnoJogado = -1; // controla para não jogar duas vezes no mesmo turno

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

            // FIX: timer não estava conectado no Designer
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

        // ===================== JOGO =====================

        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            string retorno = Jogo.Iniciar(meuId, minhaSenha);
            if (VerificarErro(retorno)) return;

            string[] dados = retorno.Replace("\r", "").Trim().Split(',');
            idJogadorComDado = Convert.ToInt32(dados[0]);
            faceDadoAtual = dados[1].Trim();
            turnoAtual = 1;
            ultimoTurnoJogado = -1; // reseta o controle de turno

            string nomeJogador = BuscarNomeJogador(idJogadorComDado);
            string nomeFace = nomesFaces.ContainsKey(faceDadoAtual) ? nomesFaces[faceDadoAtual] : faceDadoAtual;
            string livreOuNao = idJogadorComDado == meuId
                ? "Você lançou o dado — pode colocar em qualquer cercado!"
                : $"Siga a condição: {nomeFace}";

            MessageBox.Show(
                $"Partida Iniciada!\n\nTurno: 1\nJogador com o dado: {nomeJogador}\nDado: {nomeFace}\n\n{livreOuNao}",
                "Draftosaurus", MessageBoxButtons.OK, MessageBoxIcon.Information
            );

            lblTurnoInfo.Text = $"Turno 1 | Dado com: {nomeJogador} | Condição: {nomeFace}";
            AtualizarJogadores();
            tmrPrincipal.Start();
        }

        private void btnVerificarTurno_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.VerificarPartida(idPartidaSelecionada);
            if (VerificarErro(retorno)) return;

            string[] dados = retorno.Replace("\r", "").Trim().Split(',');
            int numeroTurno = Convert.ToInt32(dados[1].Trim());
            string statusTurno = dados[2].Trim();
            idJogadorComDado = Convert.ToInt32(dados[3].Trim());
            faceDadoAtual = dados[4].Trim();

            string nomeJogador = BuscarNomeJogador(idJogadorComDado);
            string nomeFace = nomesFaces.ContainsKey(faceDadoAtual) ? nomesFaces[faceDadoAtual] : faceDadoAtual;
            string nomeTurno = statusTurno == "A" ? "Em andamento" : "Finalizado";
            string voceTemDado = idJogadorComDado == meuId ? " ★ Você tem o dado!" : "";

            lblTurnoInfo.Text = $"Turno: {numeroTurno} | Dado com: {nomeJogador}{voceTemDado} | Condição: {nomeFace} | {nomeTurno}";
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

        private void btnCarregarMao_Click(object sender, EventArgs e)
        {
            string retornoMao = Jogo.ExibirMao(meuId, minhaSenha);
            if (VerificarErro(retornoMao)) return;

            cmbDino.Items.Clear();
            foreach (string d in retornoMao.Replace("\r", "").Trim().Split('\n'))
            {
                if (string.IsNullOrEmpty(d)) continue;
                string[] partes = d.Trim().Split(',');
                if (partes.Length < 2) continue;
                string codigo = partes[0].Trim();
                int qtd;
                if (!int.TryParse(partes[1].Trim(), out qtd)) continue;
                string nome = nomesDinos.ContainsKey(codigo) ? nomesDinos[codigo] : codigo;
                if (qtd > 0) cmbDino.Items.Add($"{codigo} - {nome} (x{qtd})");
            }

            bool temDado = idJogadorComDado == meuId;

            cmbCercado.Items.Clear();
            foreach (var c in nomesCercados)
            {
                if (c.Key == "RI")
                {
                    cmbCercado.Items.Add($"{c.Key} - {c.Value} (sempre permitido)");
                    continue;
                }
                if (temDado || CercadoPermitidoPeloDado(c.Key))
                    cmbCercado.Items.Add($"{c.Key} - {c.Value}");
            }

            if (cmbDino.Items.Count > 0) cmbDino.SelectedIndex = 0;
            if (cmbCercado.Items.Count > 0) cmbCercado.SelectedIndex = 0;
        }

        private void btnCarregarMao_Click_1(object sender, EventArgs e)
        {
            btnCarregarMao_Click(sender, e);
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            if (cmbDino.SelectedItem == null || cmbCercado.SelectedItem == null)
            {
                MessageBox.Show("Selecione um dinossauro e um cercado.", "Aviso");
                return;
            }

            string codDino = cmbDino.SelectedItem.ToString().Split('-')[0].Trim();
            string codCercado = cmbCercado.SelectedItem.ToString().Split('-')[0].Trim();

            bool temDado = idJogadorComDado == meuId;
            if (codCercado != "RI" && !temDado && !JogadaValida(codCercado))
            {
                string nomeFace = nomesFaces.ContainsKey(faceDadoAtual) ? nomesFaces[faceDadoAtual] : faceDadoAtual;
                MessageBox.Show(
                    $"Jogada inválida!\n\nCondição do dado '{nomeFace}' não permite este cercado.\n\nDica: você sempre pode jogar no Rio!",
                    "Jogada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string retorno = Jogo.Jogar(meuId, minhaSenha, codDino, codCercado);
            if (VerificarErro(retorno)) return;

            // Marca o turno como jogado manualmente também
            ultimoTurnoJogado = turnoAtual;

            Form4 f = (Form4)Application.OpenForms["Form4"];
            if (f != null) f.AtualizarMapa(meuId, minhaSenha);

            int novoTurno = Convert.ToInt32(retorno.Trim());

            if (novoTurno > turnoAtual)
            {
                turnoAtual = novoTurno;

                string retornoPartida = Jogo.VerificarPartida(idPartidaSelecionada);
                if (!string.IsNullOrEmpty(retornoPartida) && !retornoPartida.StartsWith("ERRO"))
                {
                    string[] dados = retornoPartida.Replace("\r", "").Trim().Split(',');
                    idJogadorComDado = Convert.ToInt32(dados[3].Trim());
                    faceDadoAtual = dados[4].Trim();

                    string nomeJogador = BuscarNomeJogador(idJogadorComDado);
                    string nomeFace = nomesFaces.ContainsKey(faceDadoAtual) ? nomesFaces[faceDadoAtual] : faceDadoAtual;
                    string voceTemDado = idJogadorComDado == meuId
                        ? "\n★ Você tem o dado — pode jogar em qualquer cercado!"
                        : $"\nSiga a condição: {nomeFace}";

                    lblTurnoInfo.Text = $"Turno: {turnoAtual} | Dado com: {nomeJogador} | Condição: {nomeFace}";
                    AtualizarJogadores();

                    MessageBox.Show(
                        $"Turno {turnoAtual} começou!\nJogador com dado: {nomeJogador}\nCondição: {nomeFace}{voceTemDado}",
                        "Novo Turno", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );
                }
            }
            else
            {
                MessageBox.Show("Jogada realizada!", "Sucesso");
            }

            btnCarregarMao_Click(null, null);
            MostrarTabuleiro();
        }

        private void btnJogar_Click_1(object sender, EventArgs e)
        {
            btnJogar_Click(sender, e);
        }

        private void btnVerTabuleiro_Click(object sender, EventArgs e)
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

        private void btnAtualizarJogadores_Click(object sender, EventArgs e) => AtualizarJogadores();

        // ===================== LISTAGEM DE PARTIDAS =====================

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
                                  : dados[3].Trim() == "E" ? "Encerrada"
                                  : "Aberta";
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
            string status = dataStatus.Contains("(")
                              ? dataStatus.Split('(')[1].Replace(")", "").Trim()
                              : "";

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

        // ===================== AUXILIARES =====================

        private void MostrarTabuleiro()
        {
            string retorno = Jogo.ExibirTabuleiro(meuId, minhaSenha);
            if (VerificarErro(retorno)) return;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== Meu Tabuleiro ===");
            foreach (string linha in retorno.Replace("\r", "").Trim().Split('\n'))
            {
                if (string.IsNullOrEmpty(linha)) continue;
                string[] partes = linha.Trim().Split(',');
                if (partes.Length >= 3)
                {
                    string codCercado = partes[0].Trim();
                    string codDino = partes[1].Trim();
                    int qtd = Convert.ToInt32(partes[2].Trim());
                    string nomeCercado = nomesCercados.ContainsKey(codCercado) ? nomesCercados[codCercado] : codCercado;
                    string nomeDino = nomesDinos.ContainsKey(codDino) ? nomesDinos[codDino] : codDino;
                    sb.AppendLine($"{nomeCercado}: {nomeDino} x{qtd}");
                }
            }
            txtTabuleiro.Text = sb.ToString();
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
                if (!tabuleiro.ContainsKey(cercado))
                    tabuleiro[cercado] = new List<string>();
                for (int i = 0; i < qtd; i++)
                    tabuleiro[cercado].Add(dino);
            }
            return tabuleiro;
        }

        private bool CercadoAceitaDino(string cercado, string dino, Dictionary<string, List<string>> tab)
        {
            var conteudo = tab.ContainsKey(cercado) ? tab[cercado] : new List<string>();
            switch (cercado)
            {
                case "IS": return conteudo.Count == 0;
                case "RS": return conteudo.Count == 0;
                case "MT": return conteudo.Count < 3;
                case "FI": return conteudo.Count == 0 || conteudo.TrueForAll(d => d == dino);
                case "CD": return !conteudo.Contains(dino);
                case "PA": return true;
                case "RI": return true;
                default: return true;
            }
        }

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
                default:
                    return true;
            }
        }

        private bool JogadaValida(string codCercado)
        {
            return CercadoPermitidoPeloDado(codCercado);
        }

        private bool CercadoSemTRex(string codCercado)
        {
            string tabuleiro = Jogo.ExibirTabuleiro(meuId, minhaSenha);
            foreach (string linha in tabuleiro.Replace("\r", "").Trim().Split('\n'))
            {
                string[] p = linha.Trim().Split(',');
                if (p.Length >= 3 && p[0].Trim() == codCercado
                    && p[1].Trim() == "Ti" && Convert.ToInt32(p[2].Trim()) > 0)
                    return false;
            }
            return true;
        }

        private bool CercadoVazio(string codCercado)
        {
            string tabuleiro = Jogo.ExibirTabuleiro(meuId, minhaSenha);
            foreach (string linha in tabuleiro.Replace("\r", "").Trim().Split('\n'))
            {
                string[] p = linha.Trim().Split(',');
                if (p.Length >= 3 && p[0].Trim() == codCercado
                    && Convert.ToInt32(p[2].Trim()) > 0)
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
            return "Jogador " + idJogador;
        }

        private void AtualizarJogadores()
        {
            string retorno = Jogo.ListarJogadores(idPartidaSelecionada);
            if (retorno.StartsWith("ERRO")) return;

            listBoxJogadores.Items.Clear();
            foreach (string j in retorno.Replace("\r", "").Trim().Split('\n'))
            {
                if (string.IsNullOrEmpty(j)) continue;
                string[] dados = j.Split(',');
                string statusTexto = (dados.Length > 2 && dados[2].Trim() == "J") ? "✅" : "⏳";
                listBoxJogadores.Items.Add($"{statusTexto} {dados[1].Trim()}");
            }
        }

        private bool VerificarErro(string retorno)
        {
            if (string.IsNullOrEmpty(retorno)) return true;
            if (retorno.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(retorno, "Erro do Servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        // Eventos vazios necessários
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void lblMeuId_Click(object sender, EventArgs e) { }
        private void lblMinhaSenha_Click(object sender, EventArgs e) { }
        private void label11_Click_1(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbDino_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbCercado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblNomePartida_Click(object sender, EventArgs e) { }

        // ===================== MOTOR DE AUTOMAÇÃO (TIMER) =====================

        private void tmrPrincipal_Tick(object sender, EventArgs e)
        {
            string retorno = Jogo.VerificarPartida(idPartidaSelecionada);

            // Diagnóstico — remova após confirmar funcionamento
            txtTabuleiro.Text = $"[TICK] raw: \"{retorno}\"\nmeuId={meuId} | comDado={idJogadorComDado} | face={faceDadoAtual} | ultimoTurnoJogado={ultimoTurnoJogado}";

            if (string.IsNullOrEmpty(retorno) || retorno.StartsWith("ERRO")) return;

            string[] dados = retorno.Replace("\r", "").Trim().Split(',');
            if (dados.Length < 5) return;

            // Formato: idPartida, turno, status, idJogadorComDado, faceDado
            string statusPartida = dados[2].Trim();
            int novoTurno;
            if (!int.TryParse(dados[1].Trim(), out novoTurno)) return;

            idJogadorComDado = Convert.ToInt32(dados[3].Trim());
            faceDadoAtual = dados[4].Trim();
            turnoAtual = novoTurno;

            AtualizarJogadores();
            if (Application.OpenForms["Form4"] is Form4 f4)
                f4.AtualizarMapa(meuId, minhaSenha);

            string nomeJog = BuscarNomeJogador(idJogadorComDado);
            string nomeFaceAtual = nomesFaces.ContainsKey(faceDadoAtual) ? nomesFaces[faceDadoAtual] : faceDadoAtual;
            bool ehMinhaVez = idJogadorComDado == meuId;
            bool partidaAtiva = statusPartida != "E";

            lblTurnoInfo.Text = $"Turno: {turnoAtual} | Dado: {nomeJog}{(ehMinhaVez ? " ★ MEU DADO" : "")} | {nomeFaceAtual} | {(partidaAtiva ? "Em andamento" : "Encerrada")}";

            // FIX: só joga se for minha vez E se ainda não joguei neste turno
            if (partidaAtiva && ehMinhaVez && turnoAtual != ultimoTurnoJogado)
            {
                tmrPrincipal.Stop();
                RealizarJogadaAutomatica();
                tmrPrincipal.Start();
            }
        }

        // ===================== LÓGICA DE AUTOMAÇÃO =====================

        private void RealizarJogadaAutomatica()
        {
            string maoRaw = Jogo.ExibirMao(meuId, minhaSenha);
            txtTabuleiro.Text += $"\n\n[AUTO] mão: \"{maoRaw}\"";

            if (string.IsNullOrEmpty(maoRaw) || maoRaw.StartsWith("ERRO")) return;

            var mao = new List<string>();
            foreach (string linha in maoRaw.Replace("\r", "").Trim().Split('\n'))
            {
                if (string.IsNullOrEmpty(linha)) continue;
                string[] p = linha.Trim().Split(',');
                if (p.Length < 2) continue;
                int qtd;
                if (!int.TryParse(p[1].Trim(), out qtd) || qtd <= 0) continue;
                mao.Add(p[0].Trim());
            }

            txtTabuleiro.Text += $"\ndinos: [{string.Join(", ", mao)}]";
            if (mao.Count == 0) return;

            var tabuleiro = CarregarTabuleiro();

            string codDino = null;
            string cercado = null;
            EscolherMelhorJogada(mao, tabuleiro, out codDino, out cercado);

            txtTabuleiro.Text += $"\ndecisão: {codDino} → {cercado}";
            if (codDino == null || cercado == null) return;

            string resultado = Jogo.Jogar(meuId, minhaSenha, codDino, cercado);
            txtTabuleiro.Text += $"\nresultado: \"{resultado}\"";

            // Só marca como jogado se não deu ERRO
            if (string.IsNullOrEmpty(resultado) || resultado.StartsWith("ERRO")) return;

            // FIX: marca o turno atual como jogado para não jogar de novo
            ultimoTurnoJogado = turnoAtual;

            string nomeDino = nomesDinos.ContainsKey(codDino) ? nomesDinos[codDino] : codDino;
            string nomeCerc = nomesCercados.ContainsKey(cercado) ? nomesCercados[cercado] : cercado;
            lblTurnoInfo.Text = $"🤖 Turno {turnoAtual}: {nomeDino} → {nomeCerc}";

            if (Application.OpenForms["Form4"] is Form4 f4)
                f4.AtualizarMapa(meuId, minhaSenha);

            btnCarregarMao_Click(null, null);
        }

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

            // Fallback seguro
            if (melhorDino == null)
            {
                melhorDino = mao[0];
                melhorCercado = "RI";
            }
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

            // Rio é sempre o fallback final
            candidatos.Add("RI");
            return candidatos;
        }

        private int AvaliarJogada(string dino, string cercado, Dictionary<string, List<string>> tab)
        {
            var cont = tab.ContainsKey(cercado) ? tab[cercado] : new List<string>();

            switch (cercado)
            {
                case "IS": return 7;

                case "RS": return 6;

                case "FI":
                    if (cont.Count == 0) return 3;
                    if (cont[0] == dino) return 4 + cont.Count;
                    return -99;

                case "CD":
                    return 3 + cont.Count;

                case "PA":
                    int iguais = 0;
                    foreach (string d in cont) if (d == dino) iguais++;
                    return iguais % 2 == 1 ? 8 : 3;

                case "MT":
                    return dino == "Ti" ? 5 : 3;

                case "RI":
                    return 1;

                default:
                    return 1;
            }
        }
    }
}