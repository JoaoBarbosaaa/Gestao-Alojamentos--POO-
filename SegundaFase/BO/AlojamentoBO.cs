/*
*	<copyright file="BO.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>17/12/2024 17:32:51</date>
*	<description></description>
**/
using System;

namespace BO
{
    /// <summary>
    /// Purpose:
    /// Created by: João Barbosa
    /// Created on: 17/12/2024 17:32:51
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>

        [Serializable]
        public class Alojamento : IAlojamento
        {
            /// <summary>
            /// Nome do alojamento.
            /// </summary>
            string nome;

            /// <summary>
            /// Número de identificação do alojamento
            /// </summary>
            int numAlojamento;

            /// <summary>
            /// Preço por noite do alojamento.
            /// </summary>
            decimal precoPorNoite;

            /// <summary>
            /// Capacidade total de quartos do alojamento.
            /// </summary>
            int totalQuartos;



            #region Properties
            /// <summary>
            /// Obtém ou define o nome do alojamento.
            /// </summary>
            public string Nome
            {
                get { return nome; }
                set { nome = value; }
            }

            /// <summary>
            /// Obtém ou define o preço por noite.
            /// </summary>
            public decimal PrecoPorNoite
            {
                get { return precoPorNoite; }
                set { precoPorNoite = value; }
            }

            /// <summary>
            /// Obtém ou define a capacidade de quartos do alojamento.
            /// </summary>
            public int TotalQuartos
            {
                get { return totalQuartos; }
                set { totalQuartos = value; }
            }


            /// <summary>
            /// Número de identificação do Alojamento.
            /// </summary>
            public int NumAlojamento
            {
                get { return numAlojamento; }
                set { numAlojamento = value; }
            }

            #endregion

            /// <summary>
            /// Construtor para inicializar um alojamento com o nome, preço por noite e capacidade de quartos.
            /// </summary>
            /// <param name="nome">O nome do alojamento.</param>
            /// <param name="precoPorNoite">O preço por noite do alojamento.</param>
            /// <param name="capacidadeQuartos">O número máximo de quartos disponíveis no alojamento.</param>
            public Alojamento(string nome, decimal precoPorNoite, int totalQuartos, int numAlojamento)
            {
                Nome = nome;
                PrecoPorNoite = precoPorNoite;
                TotalQuartos = totalQuartos;
                NumAlojamento = numAlojamento;
            }


        /// <summary>
        /// Cria uma nova instância de um alojamento com as informações especificadas.
        /// </summary>
        /// <param name="nome">Nome do alojamento.</param>
        /// <param name="precoPorNoite">Preço por noite do alojamento.</param>
        /// <param name="totalQuartos">Quantidade total de quartos disponíveis no alojamento.</param>
        /// <param name="numAlojamento">Número de identificação do alojamento.</param>
        /// <returns>Uma nova instância da classe <see cref="Alojamento"/>.</returns>

        public static Alojamento CriaAlojamento(string nome, decimal precoPorNoite, int totalQuartos, int numAlojamento)
            {
                return new Alojamento(nome, precoPorNoite, totalQuartos, numAlojamento);
            }


        /// <summary>
        /// Realiza a reserva de uma quantidade de quartos no alojamento para o intervalo de datas especificado.
        /// </summary>
        /// <param name="dataEntrada">Data de início da reserva.</param>
        /// <param name="dataSaida">Data de término da reserva.</param>
        /// <param name="quantidadeQuartos">Número de quartos a serem reservados.</param>
        /// <returns>Retorna <c>true</c> se a reserva foi realizada com sucesso; caso contrário, <c>false</c>.</returns>
        public short ReservarQuartos(DateTime dataEntrada, DateTime dataSaida, int quantidadeQuartos)
        {
            if (dataEntrada > dataSaida)
            {
                return -1; 
            }

            if (quantidadeQuartos > TotalQuartos)
            {
                return -2; 
            }

            TotalQuartos -= quantidadeQuartos;
            return 1; 
        }

        /// <summary>
        /// Libera uma quantidade especificada de quartos.
        /// </summary>
        /// <param name="quantidade">Quantidade de quartos a liberar.</param>
        /// <returns>Retorna <c>true</c> se a operação for bem-sucedida; caso contrário, <c>false</c>.</returns>

        public bool LibertaQuartos(int quantidade)
        {
            if (quantidade > TotalQuartos || quantidade <= 0)
            {
                return false;
            }
            TotalQuartos += quantidade; // atenção ao mais 
            return true;
        }
    }
    }

