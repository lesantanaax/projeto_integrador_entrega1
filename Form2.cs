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
            // Se o formulário já abrir recebendo um ID, preenche o campo na tela
            if (idPartida > 0)
            {
                txtiddapartida.Text = idPartida.ToString();
            }
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

            // Define o ID da partida criada
            idPartidaSelecionada = Convert.ToInt32(retornoCriacao.Trim());

            // Atualiza o novo campo na tela para o usuário ver o ID da partida que acabou de criar
            txtiddapartida.Text = idPartidaSelecionada.ToString();

            // Entra na partida criada automaticamente
            string retornoEntrar = Jogo.Entrar(idPartidaSelecionada, nomeJogador, senha);

            if (retornoEntrar.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(retornoEntrar, "Erro ao entrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] dados = retornoEntrar.Split(',');
            meuId = Convert.ToInt32(dados[0]);
            minhaSenha = dados[1].Trim();

            FinalizarLogin();
        }

        // ===================== ENTRAR NA PARTIDA =====================
        private void Btnentrar_Click_1(object sender, EventArgs e)
        {
            string nomeJogador = txtnome.Text;
            string senha = txtsenha.Text;

            // 1. Validação dos campos de texto obrigatórios para o jogador
            if (string.IsNullOrEmpty(nomeJogador) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha seu Nome e a Senha da partida para entrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Leitura direta do novo campo txtiddapartida
            if (!string.IsNullOrEmpty(txtiddapartida.Text))
            {
                if (!int.TryParse(txtiddapartida.Text, out idPartidaSelecionada))
                {
                    MessageBox.Show("O campo ID da partida deve conter apenas números.", "Erro de Digitação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 3. Validação de segurança caso o campo esteja vazio ou zerado
            if (idPartidaSelecionada <= 0)
            {
                MessageBox.Show("Digite o ID da partida (ou selecione uma na lista) para poder entrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Executa o comando de entrada na DLL utilizando estritamente o ID garantido
            string retorno = Jogo.Entrar(idPartidaSelecionada, nomeJogador, senha);

            if (retorno.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(retorno, "Erro ao entrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5. Armazena os dados do jogador retornados pela DLL
            string[] dados = retorno.Split(',');
            meuId = Convert.ToInt32(dados[0]);
            minhaSenha = dados[1].Trim();

            FinalizarLogin();
        }

        // Método auxiliar para finalização e retorno de dados para o Form principal
        private void FinalizarLogin()
        {
            this.Tag = $"{meuId},{minhaSenha},{idPartidaSelecionada}";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Método antigo deixado aqui apenas por compatibilidade, mas não é mais usado no fluxo principal
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}