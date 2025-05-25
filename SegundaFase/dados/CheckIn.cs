/*
*	<copyright file="Regras.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>17/12/2024 16:27:39</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;


namespace dados
{
    [Serializable]
    public abstract class CheckIn
    {
        /// <summary>
        /// Código único que identifica a reserva associada ao check-in.
        /// </summary>
        int codigoReserva;

        /// <summary>
        /// Data e hora em que o check-in foi realizado. O tipo é nullable, permitindo que o valor seja nulo
        /// caso o check-in não tenha sido realizado ainda.
        /// </summary>
        DateTime? dataHoraCheckIn;


        /// <summary>
        /// Propriedade que representa o código da reserva associada ao check-in.
        /// </summary>
        public int CodigoReserva
        {
            get { return codigoReserva; }
            set {  codigoReserva = value; }
        }

        /// <summary>
        /// Propriedade que representa a data e hora em que o check-in foi realizado.
        /// Se não houver check-in, o valor será null.
        public DateTime? DataHoraCheckIn
        {
            get { return dataHoraCheckIn; }
            set { dataHoraCheckIn = value; }
        }


        /// <summary>
        /// Construtor da classe CheckIn.
        /// Inicializa a propriedade CodigoReserva com o valor fornecido e define
        /// a propriedade DataHoraCheckIn como null, indicando que o check-in ainda não foi realizado.
        /// </summary>
        /// <param name="codigoReserva">Código da reserva associada ao check-in.</param>
        public CheckIn(int codigoReserva)
        {
            CodigoReserva = codigoReserva;
            DataHoraCheckIn = null; // Inicializa como null, indicando que o check-in não foi feito
        }


        /// <summary>
        /// Método abstrato que deve ser implementado para adicionar um check-in.
        /// </summary>
        /// <param name="checkIn">Objeto do tipo CheckIn que será adicionado.</param>
        /// <returns>Retorna true se o check-in for adicionado com sucesso, caso contrário, retorna false.</returns>
        public abstract bool AdicionarCheckIn(CheckIn checkIn);

        /// <summary>
        /// Método abstrato que deve ser implementado para guardar os check-ins em um ficheiro.
        /// </summary>
        /// <param name="caminhoFicheiro">Caminho do ficheiro onde os check-ins serão guardados.</param>
        /// <returns>Retorna true se os check-ins forem guardados com sucesso, caso contrário, retorna false.</returns>
        public abstract bool GuardarCheckIns(string caminhoFicheiro);

        /// <summary>
        /// Método abstrato que deve ser implementado para carregar os check-ins de um ficheiro.
        /// </summary>
        /// <param name="caminhoFicheiro">Caminho do ficheiro de onde os check-ins serão carregados.</param>
        /// <returns>Retorna true se os check-ins forem carregados com sucesso, caso contrário, retorna false.</returns>
        public abstract bool CarregarCheckIns(string caminhoFicheiro);

        /// <summary>
        /// Método abstrato que deve ser implementado para verificar se o check-in foi realizado.
        /// </summary>
        /// <returns>Retorna true se o check-in foi realizado, caso contrário, retorna false.</returns>
        public abstract bool CheckInRealizado();

        /// <summary>
        /// Método responsável por registrar a data e hora do check-in.
        /// </summary>
        /// <param name="dataHora">A data e hora do check-in a ser registrado.</param>
        public void RegistarCheckIn(DateTime dataHora)
        {
            DataHoraCheckIn = dataHora;
        }

    }
}


   
