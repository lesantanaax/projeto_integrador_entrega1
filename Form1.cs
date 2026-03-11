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

       
    }
}
