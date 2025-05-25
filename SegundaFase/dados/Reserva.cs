/*
*	<copyright file="BO.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>17/12/2024 14:36:54</date>
*	<description></description>
**/
using System;
using BO;

namespace dados
{
    /// <summary>
    /// Purpose:
    /// Created by: João Barbosa
    /// Created on: 17/12/2024 14:36:54
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class Reserva
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
        /// Data e hora do check-in, se realizado.
        /// </summary>
        DateTime? dataHoraCheckIn;

        /// <summary>
        /// Código da reserva 
        /// </summary>
        int codigoReserva;

        /// <summary>
        /// Estado da reserva (ativo, cancelado, expirado).
        /// </summary>
        string status;
        #endregion


        #region Properties

        /// <summary>
        /// Obtém ou define o número de identificação do Cliente.
        /// </summary>
        public int NumIdentificacao
        {
            get { return numIdentificacao; }
            set { numIdentificacao = value; }
        }

        /// <summary>
        /// Obtém ou define o número de Identificação do Alojamento.
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
        /// Obtém ou define a data e hora do check-in, se realizado.
        /// </summary>
        public DateTime? DataHoraCheckIn
        {
            get { return dataHoraCheckIn; }
            set { dataHoraCheckIn = value; }
        }

        /// <summary>
        /// Obtém ou define o código da reserva
        /// </summary>
        public int CodigoReserva
        {
            get { return codigoReserva; }
            set { codigoReserva = value; }
        }

        /// <summary>
        /// Obtém ou define o estado da reserva (ativo, cancelado, expirado)
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        #endregion


        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Reserva"/>.
        /// </summary>
        /// <param name="cliente">Cliente que fez a reserva.</param>
        /// <param name="alojamento">Alojamento onde será feita a reserva.</param>
        /// <param name="dataEntrada">Data de entrada na reserva.</param>
        /// <param name="dataSaida">Data de saída na reserva.</param>
        /// <param name="quantidadeQuartos">Quantidade de quartos a serem reservados.</param>
        public Reserva(int numIdentificacao, int numAlojamento, DateTime dataEntrada, DateTime dataSaida, int quantidadeQuartos)
        {
            NumIdentificacao = numIdentificacao;
            NumAlojamento = numAlojamento;
            DataEntrada = dataEntrada;
            DataSaida = dataSaida;
            QuantidadeQuartos = quantidadeQuartos;
        }


        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Reserva"/>.
        /// </summary>
        /// <param name="cliente">Pessoa cliente que realizou a reserva.</param>
        /// <param name="alojamento">Alojamento onde será realizada a reserva.</param>
        /// <param name="dataEntrada">Data prevista para entrada na reserva.</param>
        /// <param name="dataSaida">Data prevista para saída da reserva.</param>
        /// <param name="quantidadeQuartos">Quantidade de quartos incluídos na reserva.</param>

        public static Reserva CriaReserva(int numIdentificacao, int numAlojamento, DateTime dataEntrada, DateTime dataSaida, int quantidadeQuartos)
        {
            return new Reserva(numIdentificacao, numAlojamento, dataEntrada, dataSaida, quantidadeQuartos);
        }

    }

}
