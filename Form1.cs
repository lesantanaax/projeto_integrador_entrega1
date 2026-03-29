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
        private int idJogadorComDado = 0; // ← quem tem o dado é livre
        private int turnoAtual = 1;

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

            string nomeJogador = BuscarNomeJogador(idJogadorComDado);
            string nomeFace = nomesFaces.ContainsKey(faceDadoAtual) ? nomesFaces[faceDadoAtual] : faceDadoAtual;
            string livreOuNao = idJogadorComDado == meuId ? "Você lançou o dado — pode colocar em qualquer cercado!" : $"Siga a condição: {nomeFace}";

            MessageBox.Show(
                $"Partida Iniciada!\n\nTurno: 1\nJogador com o dado: {nomeJogador}\nDado: {nomeFace}\n\n{livreOuNao}",
                "Draftosaurus", MessageBoxButtons.OK, MessageBoxIcon.Information
            );

            lblTurnoInfo.Text = $"Turno 1 | Dado com: {nomeJogador} | Condição: {nomeFace}";
            AtualizarJogadores();
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
                lstMao.Items.Add($"{codigo} : {nome}(x{qtd})");

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

            // Carrega cercados respeitando as regras do dado
            // Se o jogador TEM o dado → pode colocar em qualquer lugar
            bool temDado = idJogadorComDado == meuId;

            cmbCercado.Items.Clear();
            foreach (var c in nomesCercados)
            {
                // Rio é SEMPRE permitido (regra do manual)
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

        // Versão para o _Click_1 gerado pelo Designer
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

            // Rio é sempre permitido — só valida se não for Rio
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

            int novoTurno = Convert.ToInt32(retorno.Trim());

            // Atualiza se o turno avançou
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
                    string voceTemDado = idJogadorComDado == meuId ? "\n★ Você tem o dado — pode jogar em qualquer cercado!" : $"\nSiga a condição: {nomeFace}";

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
                MessageBox.Show($"Jogada realizada!", "Sucesso");
            }

            btnCarregarMao_Click(null, null);
            MostrarTabuleiro();
        }

        private void btnJogar_Click_1(object sender, EventArgs e)
        {
            btnJogar_Click(sender, e);
        }

        private void btnVerTabuleiro_Click(object sender, EventArgs e) => MostrarTabuleiro();
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

            // Mostra jogadores da partida selecionada
            string id = item.Split(']')[0].Replace("[", "").Trim();
            string retornoJog = Jogo.ListarJogadores(Convert.ToInt32(id));
            if (string.IsNullOrEmpty(retornoJog) || retornoJog.StartsWith("ERRO")) return;

            listBoxJogadores.Items.Clear();
            foreach (string j in retornoJog.Replace("\r", "").Trim().Split('\n'))
                if (!string.IsNullOrEmpty(j)) listBoxJogadores.Items.Add(j.Trim());
        }

        private void btnAdicionarJogador_Click(object sender, EventArgs e)
        {
            Form2 novoJogador = new Form2(idPartidaSelecionada);
            novoJogador.Show();
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

        // ✅ Verifica se o cercado é permitido pela face do dado
        // Regra: quem TEM o dado é livre. Rio é sempre permitido.
        private bool CercadoPermitidoPeloDado(string codCercado)
        {
            if (string.IsNullOrEmpty(faceDadoAtual)) return true;
            if (codCercado == "RI") return true; // Rio sempre permitido

            switch (faceDadoAtual)
            {
                case "AL": return codCercado == "IS"; // Praça de Alimentação: Ilha Solitária
                case "FL": return codCercado == "FI" || codCercado == "MT"; // Floresta
                case "PR": return codCercado == "PA" || codCercado == "CD"; // Pradaria
                case "WC": return codCercado == "RS"; // Banheiros
                case "TI": return CercadoSemTRex(codCercado); // Sem T-Rex
                case "VZ": return CercadoVazio(codCercado);   // Vazio
                default: return true;
            }
        }

        // Mantido para compatibilidade
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
                if (!string.IsNullOrEmpty(j)) listBoxJogadores.Items.Add(j);
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

    }
}

