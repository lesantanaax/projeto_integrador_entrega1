using Draft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_integrador_entrega1
{
    public partial class Form1 : Form
    {
        private int meuId;
        private string minhaSenha;
        private int idPartidaSelecionada;

        public Form1()
        {
            InitializeComponent();
            label4.Text = Jogo.versao;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.ListarPartidas("T");
            textBox1.Text = retorno;

            retorno = retorno.Replace("\r", "");
            retorno = retorno.Substring(0, retorno.Length - 1);
            string[] partidas = retorno.Split('\n');

            listBox1.Items.Clear();
            for (int i = 0; i < partidas.Length - 1; i++)
            {
               listBox1.Items.Add(partidas[i]);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string partida = listBox1.SelectedItem.ToString();
            string[] dadosPartida = partida.Split(',');
            label1.Text = partida;

            int idPartida = Convert.ToInt32(dadosPartida[0]);
            string nomePartida = dadosPartida[1];
            string data = dadosPartida[2];

            label1.Text = idPartida.ToString();
            label2.Text = nomePartida;
            label3.Text = data;

            string retorno = Jogo.ListarJogadores(idPartida);
            //if(retorno.Substring(0, 4) == "ERRO")
            //{
            //    MessageBox.Show("Ocorreu um erro: " + retorno, "PI - III", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            retorno = retorno.Replace("\r", "");
            string[] jogadores = retorno.Split('\n');


            listBox2.Items.Clear();
            for (int i = 0; i < jogadores.Length; i++)
            {
                listBox2.Items.Add(jogadores[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nome = textBox2.Text;
            string senha = textBox3.Text;
            string grupo = textBox4.Text;

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Informe o nome da partida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string retorno = Jogo.CriarPartida(nome, senha, grupo);
            retorno = retorno.Replace("\r", "");


            if (retorno == null)
            {
                MessageBox.Show("Resposta inválida do servidor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (retorno.StartsWith("ERRO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Ocorreu um erro: " + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Partida criada: " + retorno, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button1_Click(null, null); 

            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }


        // Entrar na Partida
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // Pega o ID da partida selecionada na lista, o nome do seu jogador e a senha da partida
            string retorno = Jogo.Entrar(idPartidaSelecionada, txtNomeJogador.Text, textBox3.Text);

            if (VerificarErro(retorno)) return;

            // O retorno é "idJogador,senhaJogador"
            string[] dados = retorno.Split(',');
            meuId = Convert.ToInt32(dados[0]);
            minhaSenha = dados[1];

            lblMeuId.Text = "Meu ID: " + meuId.ToString();
            lblMinhaSenha.Text = "Minha Senha: " + minhaSenha;

            MessageBox.Show("Você entrou na partida!", "Sucesso");
            AtualizarJogadores();
        }

        // Iniciar a Partida
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.Iniciar(meuId, minhaSenha);

            if (VerificarErro(retorno)) return;

            MessageBox.Show("Partida Iniciada! Quem começa: " + retorno, "Draftsauros");
        }

        // Exibir a Mão (Dinossauros)
        private void btnVerMao_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.ExibirMao(meuId, minhaSenha);

            if (VerificarErro(retorno)) return;

            textBox1.Text = retorno; // Mostra o bruto no textbox grande

            string[] dinos = retorno.Replace("\r", "").Trim().Split('\n');
            lstMao.Items.Clear();
            foreach (string d in dinos)
            {
                lstMao.Items.Add(d);
            }
        }

        // Função auxiliar para atualizar a lista de jogadores (ListBox2)
        private void AtualizarJogadores()
        {
            string retorno = Jogo.ListarJogadores(idPartidaSelecionada);
            if (retorno.StartsWith("ERRO")) return;

            listBox2.Items.Clear();
            string[] jogadores = retorno.Replace("\r", "").Trim().Split('\n');
            foreach (string j in jogadores)
            {
                if (!string.IsNullOrEmpty(j)) listBox2.Items.Add(j);
            }
        }

        // Função para centralizar o tratamento de erros e exibir em tela (Requisito da Entrega)
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
