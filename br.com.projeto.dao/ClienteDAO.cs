﻿using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using Projeto_Controle_de_Vendas.br.com.projeto.conexao;
using Projeto_Controle_de_Vendas.br.com.projeto.model;
using Projeto_Controle_de_Vendas.br.com.projeto.view;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Projeto_Controle_de_Vendas.br.com.projeto.dao
{
   public class ClienteDAO
    {
        private MySqlConnection conexao;

        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }


        // Método Cadastrar Cliente;
       
        #region CadastrarCliente

        public void cadastrarCliente(Cliente obj)
        {
            try
            {
                // Executando o Insert into - MySQL;

                string sql = @"insert into tb_clientes (nome,rg,cpf,email,telefone,celular,endereco,cep,numero,complemento,bairro,cidade,estado)
                            values (@nome,@rg,@cpf,@email,@telefone,@celular,@endereco,@cep,@numero,@complemento,@bairro,@cidade,@estado)";

                // Organizando o cmd sql;

                MySqlCommand executacmd = new MySqlCommand(sql,conexao);

                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);             
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                // Abrir a conexão e executar o comando sql;
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente Cadastrado com Sucesso!");


            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um erro " + erro);

            }


        }

        #endregion

        #region ListarClientes
        public DataTable listarCliente()
        {
            try
            {
                // 1) Criar o DataTable e o  comando sql
                DataTable tabelacliente = new DataTable();
                string sql = "select * from tb_clientes";

                // 2) Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                // 3) Criar MySqlDataApter para preencher os dados do DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                return tabelacliente;

            }

            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando sql" + erro);
                return null;
            }
        }
        #endregion










    }
}

