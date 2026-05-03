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
            // Criamos uma estrutura que guarda Posição e Tamanho para cada código
            var configuracaoCercados = new Dictionary<string, (Point Posicao, Size Tamanho)>
    {
        // Exemplo de ajuste (Você vai alterar os números testando no mapa)
        { "CD", (new Point(618, 283),  new Size(349, 163)) },
        { "FI", (new Point(62, 34),  new Size(340, 174)) },
        { "IS", (new Point(769, 452), new Size(220, 146))   }, // Ilha é pequena
        { "MT", (new Point(49, 253), new Size(268, 167)) },
        { "PA", (new Point(120, 468), new Size(258, 188)) },
        { "RI", (new Point(502, 527), new Size(181, 92))  }, // Rio é largo e baixo
        { "RS", (new Point(682, 70), new Size(147, 93)) }
    };

            foreach (var config in configuracaoCercados)
            {
                string cod = config.Key;
                Point pos = config.Value.Posicao;
                Size tam = config.Value.Tamanho;

                FlowLayoutPanel field = new FlowLayoutPanel();
                field.Name = "field_" + cod;
                field.Location = pos;
                field.Size = tam; // AQUI aplicamos o tamanho individual

                // Mantemos as bordas e labels para você mapear agora
                field.BorderStyle = BorderStyle.FixedSingle;
                field.BackColor = Color.FromArgb(100, Color.Red);
                field.FlowDirection = FlowDirection.LeftToRight; // Organiza os dinos em linha
                field.WrapContents = true; // Se não couber na linha, pula para baixo

                Label lbl = new Label { Text = cod, AutoSize = true, BackColor = Color.Yellow };
                field.Controls.Add(lbl);

                this.Controls.Add(field);
                field.BringToFront();
                cercadosVisuais.Add(cod, field);
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
                        //pb.Image = (Image)Properties.Resources.ResourceManager.GetObject(nomeImagem);
                        pb.Image = Image.FromFile(nomeImagem);
                        cercadosVisuais[codCercado].Controls.Add(pb);
                    }
                }
            }
        }

        private string ObterNomeResource(string cod)
        {
            string pastaResources = @"C:\Users\bruno\source\repos\projeto_integrador_entrega1\Resources\";

            switch (cod)
            {
                case "Br": return pastaResources + "braquiossauro.png";
                case "Ep": return pastaResources + "espinossauro.png";
                case "Et": return pastaResources + "estegossauro.png";
                case "Pa": return pastaResources + "parassaurolofo.png";
                case "Ti": return pastaResources + "tiranossauro.png";
                case "Tr": return pastaResources + "triceratops.png";
                default: return "";
            }
        }

        //        private void btnVerMao_Click(object sender, EventArgs e)
        //{
        //    string retorno = Jogo.ExibirMao(meuId, minhaSenha);
        //    if (VerificarErro(retorno)) return;
        //    lstMao.Items.Clear();
        //    foreach (string d in retorno.Replace("\r", "").Trim().Split('\n'))
        //    {
        //        if (string.IsNullOrEmpty(d)) continue;
        //        string[] partes = d.Trim().Split(',');
        //        if (partes.Length < 2) continue;
        //        string codigo = partes[0].Trim();
        //        string nome = nomesDinos.ContainsKey(codigo) ? nomesDinos[codigo] : codigo;
        //        int qtd;
        //        if (!int.TryParse(partes[1].Trim(), out qtd)) continue;
        //        lstMao.Items.Add($"{codigo} : {nome} (x{qtd})");
        //    }
        //}

        private void btnCarregarMao_Click(object sender, EventArgs e) { }
    }
}