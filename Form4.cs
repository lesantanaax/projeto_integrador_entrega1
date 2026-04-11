using Draft;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace projeto_integrador_entrega1
{
    public partial class Form4 : Form
    {
        // Dicionário para guardar os Panels dos cercados
        private Dictionary<string, FlowLayoutPanel> cercadosVisuais = new Dictionary<string, FlowLayoutPanel>();

        public Form4()
        {
            InitializeComponent();
            this.Text = "Tabuleiro Draftosaurus";
            CriarFields(); // Cria as áreas visíveis
        }

        private void CriarFields()
        {
            // Lista de códigos dos cercados
            string[] codigos = { "CD", "FI", "IS", "MT", "PA", "RI", "RS" };

            int xInicial = 50; // Posição temporária
            int yInicial = 50;

            foreach (string cod in codigos)
            {
                // Criamos um FlowLayoutPanel para cada cercado
                // Ele organiza os dinossauros automaticamente um ao lado do outro
                FlowLayoutPanel field = new FlowLayoutPanel();
                field.Name = "field_" + cod;
                field.Size = new Size(150, 100); // Tamanho da área do cercado
                field.Location = new Point(xInicial, yInicial);
                field.BorderStyle = BorderStyle.FixedSingle; // BORDA PARA ENXERGAR
                field.BackColor = Color.FromArgb(100, Color.White); // Fundo semi-transparente
                field.AutoScroll = false;

                // Label para identificar o cercado enquanto você mapeia
                Label lbl = new Label { Text = cod, AutoSize = true, BackColor = Color.Yellow };
                field.Controls.Add(lbl);

                this.Controls.Add(field);
                cercadosVisuais.Add(cod, field);

                // Move a posição do próximo field para não ficarem um em cima do outro no início
                xInicial += 160;
                if (xInicial > 800) { xInicial = 50; yInicial += 110; }
            }
        }

        public void AtualizarMapa(int meuId, string minhaSenha)
        {
            string retorno = Jogo.ExibirTabuleiro(meuId, minhaSenha);
            if (retorno.StartsWith("ERRO")) return;

            // Limpar todos os dinossauros (PictureBoxes) antes de redesenhar
            foreach (var field in cercadosVisuais.Values)
            {
                // Remove apenas as PictureBoxes (mantém o Label de identificação)
                for (int i = field.Controls.Count - 1; i >= 0; i--)
                {
                    if (field.Controls[i] is PictureBox) field.Controls[i].Dispose();
                }
            }

            string[] linhas = retorno.Replace("\r", "").Trim().Split('\n');
            foreach (string linha in linhas)
            {
                string[] p = linha.Split(',');
                if (p.Length < 3) continue;

                string codCercado = p[0].Trim();
                string codDino = p[1].Trim(); // Br, Ep, Et, Pa, Ti, Tr
                int qtd = Convert.ToInt32(p[2].Trim());

                if (cercadosVisuais.ContainsKey(codCercado))
                {
                    for (int i = 0; i < qtd; i++)
                    {
                        PictureBox pb = new PictureBox();
                        pb.Size = new Size(30, 30);
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;

                        // Mapeamento dos nomes das imagens no seu Resource
                        string nomeImagem = ObterNomeResource(codDino);
                        pb.Image = (Image)Properties.Resources.ResourceManager.GetObject(nomeImagem);

                        cercadosVisuais[codCercado].Controls.Add(pb);
                    }
                }
            }
        }

        private string ObterNomeResource(string cod)
        {
            switch (cod)
            {
                case "Br": return "braquiossauro";
                case "Ep": return "espinossauro";
                case "Et": return "estegossauro";
                case "Pa": return "parassaurolofo";
                case "Ti": return "tiranossauro";
                case "Tr": return "triceratops";
                default: return "";
            }
        }
    }
}