using Draft;
using System;
using System.Windows.Forms;

namespace projeto_integrador_entrega1
{
    public partial class Form2 : Form
    {
        private int meuId;
        private string minhaSenha;
        private int idPartidaSelecionada;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(int idPartida) : this()
        {
            idPartidaSelecionada = idPartida;
        }

        // ===================== CRIAR PARTIDA =====================
        private void btncriar_Click(object sender, EventArgs e)
        {
            string nomeJogador = txtnome.Text;
            string nomePartida = txtnomedapartida.Text;
            string senha = txtsenha.Text;
            string grupo = "Colossais";

            if (string.IsNullOrEmpty(nomeJogador) || string.IsNullOrEmpty(nomePartida)
             || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(grupo))
            {
                MessageBox.Show("Preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string retornoCriacao = Jogo.CriarPartida(nomePartida, senha, grupo);

            if (retornoCriacao.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(retornoCriacao, "Erro ao criar partida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            idPartidaSelecionada = Convert.ToInt32(retornoCriacao.Trim());

            string retornoEntrar = Jogo.Entrar(idPartidaSelecionada, nomeJogador, senha);

            if (retornoEntrar.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(retornoEntrar, "Erro ao entrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] dados = retornoEntrar.Split(',');
            meuId = Convert.ToInt32(dados[0]);
            minhaSenha = dados[1].Trim();

            // ALTERAÇÃO AQUI: Em vez de criar Form1, devolvemos os dados
            FinalizarLogin();
        }

        // ===================== ENTRAR NA PARTIDA =====================
        private void Btnentrar_Click_1(object sender, EventArgs e)
        {
            string nomeJogador = txtnome.Text;
            string senha = txtsenha.Text;
            string grupo = "Colossais";

            if (string.IsNullOrEmpty(nomeJogador) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(grupo))
            {
                MessageBox.Show("Preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idPartidaSelecionada == 0)
                idPartidaSelecionada = BuscarIdPartidaPorGrupo(grupo);

            if (idPartidaSelecionada == 0 || idPartidaSelecionada == -1)
            {
                DialogResult resposta = MessageBox.Show(
                    "Nenhuma partida aberta encontrada.\nDeseja criar uma nova partida?",
                    "Partida não encontrada",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resposta == DialogResult.Yes)
                    btncriar_Click(sender, e);

                return;
            }

            string retorno = Jogo.Entrar(idPartidaSelecionada, nomeJogador, senha);

            if (retorno.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] dados = retorno.Split(',');
            meuId = Convert.ToInt32(dados[0]);
            minhaSenha = dados[1].Trim();

            // ALTERAÇÃO AQUI: Em vez de criar Form1, devolvemos os dados
            FinalizarLogin();
        }

        // Método auxiliar para evitar repetição de código
        private void FinalizarLogin()
        {
            this.Tag = $"{meuId},{minhaSenha},{idPartidaSelecionada}";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ===================== AUXILIAR =====================
        private int BuscarIdPartidaPorGrupo(string grupo)
        {
            string retorno = Jogo.ListarPartidas("A");
            if (string.IsNullOrEmpty(retorno) || retorno.StartsWith("ERRO")) return -1;

            foreach (string partida in retorno.Replace("\r", "").Trim().Split('\n'))
            {
                if (string.IsNullOrEmpty(partida)) continue;
                string[] dados = partida.Split(',');
                if (dados.Length >= 2 && dados[1].Trim().IndexOf(grupo, StringComparison.OrdinalIgnoreCase) >= 0)
                    return Convert.ToInt32(dados[0].Trim());
            }
            return -1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
    }
}