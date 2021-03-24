﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Loja.DTO;
using Loja.BLLL;

namespace Loja
{
    public partial class Cadastro_usuario : Form
    {
        string modo = "";
        public Cadastro_usuario()
        {
            InitializeComponent();
        }

        private void Cadastro_usuario_Load(object sender, EventArgs e)
        { 
            /*Metodo carregaGrid.
             Para atualizar os dados do Grid
            Basta chamar o metodo.*/
            
                carregaGrid();
            }
            private void carregaGrid()
            {

        
            try
            {
                IList<usuario_DTO> ListUsuario_DTO = new List<usuario_DTO>();
                ListUsuario_DTO = new UsuarioBLL().cargaUsario();
                /*Preencher dados no DataGridView*/
                dataGridView1.DataSource = ListUsuario_DTO;


            }
            catch(Exception ex )
            {
                throw ex;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Linha atual que estiver selecionada aparacera nos 
             * campos do Textbox acima do dataGrid*/
            int sel = dataGridView1.CurrentRow.Index;
            /*Valor de cada datagrid sera enviado ao seu respectivo textbox*/

            txtNome.Text = Convert.ToString(dataGridView1["nome", sel].Value);
            txtLogin.Text = Convert.ToString(dataGridView1["login", sel].Value);
            txtEmail.Text = Convert.ToString(dataGridView1["email", sel].Value);
            txtSenha.Text = Convert.ToString(dataGridView1["senha", sel].Value);
            txtCadastro.Text = Convert.ToString(dataGridView1["cadastro", sel].Value);
            
            /*Condicao se a situacao for igual a "A" entao o combobox ficar
             Ativo senao "Inativo"*/

            if(Convert.ToString(dataGridView1["situacao", sel].Value)== "A")
            {
                cboSituacao.Text = "Ativo";
            }
            else
            {
                cboSituacao.Text = "Inativo";
               
            }
            switch  (Convert.ToString(dataGridView1["perfil", sel].Value))
            {
                /*Caso seja 1, sera escolhido Amdministrador caso seja 2, operador 
                 caso 3 Gerencial*/
                case "1":
                    cboPerfil.Text = "Administrador";
                    break;
                case "2":
                    cboPerfil.Text = "Operador";
                    break;
                case "3":
                    cboPerfil.Text = "Gerencial";
                    break;

            }


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtCadastro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            /*Chamando Metodo Limp[ar campos que foi criado*/
            limpar_campos();
            
            /*Inserindo a data atual automaticamente no txtCadastro*/
            txtCadastro.Text = Convert.ToString(System.DateTime.Now);

            /*apos clicar no botao novo, modo passa a ser novo 
             (incluindo um resgistro)*/
            modo = "novo";



        }
        /*Criando metodo limpar campos, para que todas as vezes em
         * que for necessario limpar nao sera necessario repetir o
         * codigo apenas chamar o metodo.
         */

        private void limpar_campos()
        {
            txtNome.Text = "";
            txtLogin.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtCadastro.Text = "";
            cboPerfil.Text = "";
            cboSituacao.Text = "";

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(modo == "novo")
            {
                /*Tratamento de erros, exibe msg*/

                try
                {
                    //Objeto USU
                    usuario_DTO USU = new usuario_DTO();
                    USU.nome = txtNome.Text;
                    USU.login = txtLogin.Text;
                    USU.email = txtEmail.Text;
                    USU.cadastro = System.DateTime.Now;
                    USU.senha = txtSenha.Text;

               

                    if(cboSituacao.Text == "Ativo")
                    {
                        USU.situacao = "A";
                    }else
                    {
                        USU.situacao = "I";

                    }
                    switch (cboPerfil.Text)
                    {
                        case "Administrador":
                            USU.perfil = 1;
                            break;
                        case "Operador":
                            USU.perfil = 2;
                            break;
                        case "Gerencial":
                            USU.perfil = 3;
                            break;

                         
    
                    }
                    /*Metodo insere usuario na classe UsuarioBLL*/
                    int x = new UsuarioBLL().insereUsuario(USU);
                    if(x > 0)
                    {
                        MessageBox.Show("Gravado com Sucesso!!");
                    }
                    /*Recarrega o Grid*/
                    carregaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado" + ex.Message);
                }

                modo = "";

            }

           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            modo = "altera";
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpar_campos();
        }
    }
}
