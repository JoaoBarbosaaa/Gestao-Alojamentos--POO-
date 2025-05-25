/*
*	<copyright file="dados.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>18/12/2024 16:11:51</date>
*	<description></description>
**/
using System;
using BO;

namespace dados
{
    /// <summary>
    /// Purpose:
    /// Created by: João Barbosa
    /// Created on: 18/12/2024 16:11:51
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>

    [Serializable]
    public class CheckInConcreto : CheckIn
    {
        /// <summary>
        /// Construtor da classe <see cref="CheckInConcreto"/> que inicializa um novo objeto com o código da reserva.
        /// </summary>
        /// <param name="codigoReserva">Código da reserva que será associado ao check-in concreto.</param>

        public CheckInConcreto(int codigoReserva) : base(codigoReserva)
        {
        }

        /// <summary>
        /// Construtor da classe <see cref="CheckInConcreto"/> que inicializa um novo objeto com o código da reserva e a data/hora do check-in.
        /// </summary>
        /// <param name="codigoReserva">Código da reserva que será associado ao check-in concreto.</param>
        /// <param name="dataHoraCheckIn">Data e hora do check-in que será registrado.</param>
        public CheckInConcreto(int codigoReserva, DateTime dataHoraCheckIn) : base(codigoReserva)
        {
            RegistarCheckIn(dataHoraCheckIn);
        }

        /// <summary>
        /// Adiciona um check-in à lista de check-ins.
        /// </summary>
        /// <param name="checkIn">Objeto do tipo <see cref="CheckIn"/> que representa o check-in a ser adicionado.</param>
        /// <returns>Retorna true, indicando que o check-in foi adicionado com sucesso. A lógica de adição pode ser ajustada conforme necessário.</returns>
        public override bool AdicionarCheckIn(CheckIn checkIn)
        {
            return true;
        }

        /// <summary>
        /// guarda os check-ins em um ficheiro.
        /// </summary>
        /// <param name="caminhoFicheiro">Caminho do ficheiro onde os check-ins serão guadados.</param>
        /// <returns>Retorna true, indicando que os check-ins foram guardados com sucesso. A lógica de guardar pode ser ajustada conforme necessário.</returns>
        public override bool GuardarCheckIns(string caminhoFicheiro)
        {
            return true; 
        }

        /// <summary>
        /// Carrega os check-ins a partir de um ficheiro.
        /// </summary>
        /// <param name="caminhoFicheiro">Caminho do ficheiro de onde os check-ins serão carregados.</param>
        /// <returns>Retorna true, indicando que os check-ins foram carregados com sucesso. A lógica de carregamento pode ser ajustada conforme necessário.</returns>
        public override bool CarregarCheckIns(string caminhoFicheiro)
        {
            return true;
        }

        /// <summary>
        /// Verifica se o check-in foi realizado com base na data e hora do check-in.
        /// </summary>
        /// <returns>Retorna true se o check-in foi realizado (ou seja, se a data/hora do check-in foi definida), caso contrário retorna false.</returns>
        public override bool CheckInRealizado()
        {
            return DataHoraCheckIn.HasValue; // Verifica se a data do check-in foi definida
        }
    }

}
