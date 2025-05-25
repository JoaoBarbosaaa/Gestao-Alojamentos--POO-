/*
*	<copyright file="Regras.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>19/12/2024 14:17:19</date>
*	<description></description>
**/
using dados;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ReservasTests
{
    [TestClass]
    public class ReservasTests
    {
        private Reservas reservas;


        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Reservas"/> antes de cada teste.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            reservas = new Reservas();
        }



        /// <summary>
        /// Testa o método <see cref="Reservas.AdicionarReserva"/> com uma reserva válida.
        /// Verifica se o código da reserva retornado é diferente de -1 e corresponde ao valor esperado.
        /// </summary>
        [TestMethod]
        public void AdicionarReservaValida()
        {
            // Arrange
            Reserva reserva = new Reserva(123, 1, DateTime.Now, DateTime.Now.AddDays(2), 2);

            // Act
            int codigo = reservas.AdicionarReserva(reserva);

            // Assert
            Assert.AreNotEqual(-1, codigo);
            Assert.AreEqual(1000, codigo);
        }


        /// <summary>
        /// Testa o método <see cref="Reservas.AdicionarReserva"/> com uma reserva inválida (data de saída anterior à data de entrada).
        /// Verifica se o código retornado é -1.
        /// </summary>
        [TestMethod]
        public void AdicionarReservaInvalida()
        {
            // Arrange
            Reserva reserva = new Reserva(123, 1, DateTime.Now, DateTime.Now.AddDays(-1), 2); 

            // Act
            int codigo = reservas.AdicionarReserva(reserva);

            // Assert
            Assert.AreEqual(-1, codigo);
        }


        /// <summary>
        /// Testa o método <see cref="Reservas.AdicionarReserva"/> com uma reserva contendo uma quantidade negativa de quartos.
        /// Verifica se o código retornado é -1.
        /// </summary>
        [TestMethod]
        public void AdicionarReservaQuartosNegativos()
        {
            // Arrange
            Reserva reserva = new Reserva(123, 1, DateTime.Now, DateTime.Now.AddDays(2), -3); 

            // Act
            int codigo = reservas.AdicionarReserva(reserva);

            // Assert
            Assert.AreEqual(-1, codigo);
        }
    }
}


