/*
*	<copyright file="BO.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>18/12/2024 16:30:50</date>
*	<description></description>
**/
using System;

namespace BO
{
    /// <summary>
    /// Purpose:
    /// Created by: João Barbosa
    /// Created on: 18/12/2024 16:30:50
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
   [Serializable]
    public class CheckInBO
    {

       /// <summary>
       /// Código da reserva 
       /// </summary>
        int codigoReserva;


        /// <summary>
        /// Propriedade que obtém ou define o código da reserva.
        /// </summary>
        public int CodigoReserva
            {
                get { return codigoReserva; }
                set { codigoReserva = value; }
            }


        /// <summary>
        /// Construtor que inicializa uma nova instância da classe CheckInBO com um código de reserva.
        /// </summary>
        /// <param name="codigoReserva">Código da reserva associada ao check-in.</param>
        public CheckInBO(int codigoReserva)
            {
                CodigoReserva = codigoReserva;
            }
        }
}
