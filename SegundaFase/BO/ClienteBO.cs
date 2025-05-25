/*
*	<copyright file="BO.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>17/12/2024 14:32:04</date>
*	<description></description>
**/
using System;

namespace BO
{
    /// <summary>
    /// Purpose:
    /// Created by: João Barbosa
    /// Created on: 17/12/2024 14:32:04
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class Cliente
    {
        #region Attributes
        /// <summary>
        /// Nome do cliente.
        /// </summary>
        string nome;
        /// <summary>
        /// Número de identificação do cliente.
        /// </summary>
        int numIdentificacao;

        #endregion

        #region Constructors
        /// <summary>
        /// Construtor padrão da classe Cliente.
        /// Inicializa o nome como uma string vazia e o número de identificação como "0".
        /// </summary>
        public Cliente()
        {
            nome = "";
            numIdentificacao = 0;
        }
        /// <summary>
        /// Construtor com parâmetros da classe Cliente.
        /// </summary>
        /// <param name="nome">Nome do cliente.</param>
        /// <param name="numIdentificacao">Número de identificação do cliente.</param>
        public Cliente(string nome, int numIdentificacao)
        {
            Nome = nome;
            NumIdentificacao = numIdentificacao;
        }



        public static Cliente CriaCliente(string nome, int numIdentificacao)
        {
            return new Cliente(nome, numIdentificacao);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Obtém ou define o nome do cliente.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Obtém ou define o número de identificação do cliente.
        /// </summary>
        public int NumIdentificacao
        {
            get { return numIdentificacao; }
            set { numIdentificacao = value; }
        }

        #endregion
    }
}
