/*
*	<copyright file="BO.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>17/12/2024 14:59:30</date>
*	<description></description>
**/
using System;

namespace BO
{


    [Serializable]
    public class ReservaBO
    {
        #region Attributes

        /// <summary>
        /// Número de identificação do cliente
        /// </summary>
        int numIdentificacao;

        /// <summary>
        /// Número de identificação do alojamento
        /// </summary>
        int numAlojamento;

        /// <summary>
        /// Data de entrada na reserva.
        /// </summary>
        DateTime dataEntrada;

        /// <summary>
        /// Data de saída na reserva.
        /// </summary>
        DateTime dataSaida;

        /// <summary>
        /// Quantidade de quartos reservados.
        /// </summary>
        int quantidadeQuartos;

        /// <summary>
        /// Código da reserva 
        /// </summary>
        int codigoReserva;
        #endregion


        #region Properties


        /// <summary>
        /// Obtém ou define o número de identificação do cliente.
        /// </summary>
        public int NumIdentificacao
        {
            get { return numIdentificacao; }
            set { numIdentificacao = value; }
        }

        /// <summary>
        /// Obtém ou define o número de identificação do Alojamento.
        /// </summary>
        public int NumAlojamento
        {
            get { return numAlojamento; }
            set { numAlojamento = value; }
        }


        /// <summary>
        /// Obtém ou define a data de entrada na reserva.
        /// </summary>
        public DateTime DataEntrada
        {
            get { return dataEntrada; }
            set { dataEntrada = value; }
        }

        /// <summary>
        /// Obtém ou define a data de saída na reserva.
        /// </summary>
        public DateTime DataSaida
        {
            get { return dataSaida; }
            set { dataSaida = value; }
        }

        /// <summary>
        /// Obtém ou define a quantidade de quartos reservados.
        /// </summary>
        public int QuantidadeQuartos
        {
            get { return quantidadeQuartos; }
            set { quantidadeQuartos = value; }
        }

        /// <summary>
        /// Obtém ou define o código da reserva.
        /// </summary>
        public int CodigoReserva
        {
            get { return codigoReserva; }
            set { codigoReserva = value; }
        }

        #endregion

        #region contrutores
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Reserva"/>.
        /// </summary>
        /// <param name="cliente">Cliente que fez a reserva.</param>
        /// <param name="alojamento">Alojamento onde será feita a reserva.</param>
        /// <param name="dataEntrada">Data de entrada na reserva.</param>
        /// <param name="dataSaida">Data de saída na reserva.</param>
        /// <param name="quantidadeQuartos">Quantidade de quartos a serem reservados.</param>
        public ReservaBO(int numIdentificacao, int numAlojamento, DateTime dataEntrada, DateTime dataSaida, int quantidadeQuartos)
        {
            NumIdentificacao = numIdentificacao;
            NumAlojamento = numAlojamento;
            DataEntrada = dataEntrada;
            DataSaida = dataSaida;
            QuantidadeQuartos = quantidadeQuartos;
        }
        #endregion


    }

}

