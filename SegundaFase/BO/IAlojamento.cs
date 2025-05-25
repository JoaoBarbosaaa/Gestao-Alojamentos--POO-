/*
*	<copyright file="BO.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>17/12/2024 14:32:45</date>
*	<description></description>
**/
using System;


namespace BO
{
    /// <summary>
    /// Purpose:
    /// Created by: João Barbosa
    /// Created on: 17/12/2024 14:32:45
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public interface IAlojamento
    {

        #region metodos


        /// <summary>
        /// Realiza a reserva de uma quantidade de quartos no alojamento para o intervalo de datas especificado.
        /// </summary>
        /// <param name="dataEntrada">Data de início da reserva.</param>
        /// <param name="dataSaida">Data de término da reserva.</param>
        /// <param name="quantidadeQuartos">Número de quartos a serem reservados.</param>
        /// <returns>Retorna <c>true</c> se a reserva foi realizada com sucesso; caso contrário, <c>false</c>.</returns>
        short ReservarQuartos(DateTime dataEntrada, DateTime dataSaida, int quantidadeQuartos);

        /// <summary>
        /// Liberta uma quantidade especificada de quartos.
        /// </summary>
        /// <param name="quantidade">Quantidade de quartos a libetar.</param>
        /// <returns>Retorna <c>true</c> se a operação for bem-sucedida; caso contrário, <c>false</c>.</returns>
        bool LibertaQuartos(int quantidade);


        #endregion
    }
}
