/*
*	<copyright file="Regras.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>17/12/2024 16:27:39</date>
*	<description></description>
**/
using dados;
using BO;
using trataProblemas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Regras
{
    /// <summary>
    /// Purpose:
    /// Created by: João Barbosa
    /// Created on: 17/12/2024 16:27:39
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ReservasRegras
    {
        private Reservas reservas = new Reservas(); // Instância da camada de dados

        /// <summary>
        /// Adiciona uma nova reserva à lista de reservas, realizando as devidas validações.
        /// </summary>
        /// <param name="reservaBO">Objeto que contém os dados da reserva a ser adicionada.</param>
        /// <returns>Retorna o código da reserva se adicionada com sucesso, ou um código de erro específico caso ocorra uma falha.</returns>
        /// <remarks>
        /// Os seguintes códigos de erro são retornados:
        /// <list type="bullet">
        /// <item><description>-1: Reserva inválida (objeto nulo)</description></item>
        /// <item><description>-2: Data de entrada inválida (antes da data atual)</description></item>
        /// <item><description>-3: Intervalo de datas inválido (data de saída anterior à de entrada)</description></item>
        /// <item><description>-4: Quantidade de quartos inválida (menor ou igual a 0)</description></item>
        /// <item><description>-5: Falha ao adicionar a reserva</description></item>
        public int AdicionarReservaBO(ReservaBO reservaBO)
        {
            if (reservaBO == null)
            {
                return -1; 
            }

            if (reservaBO.DataEntrada < DateTime.Now.Date)
            {
                return -2; 
            }

            if (reservaBO.DataSaida <= reservaBO.DataEntrada)
            {
                return -3; 
            }

            if (reservaBO.QuantidadeQuartos <= 0)
            {
                return -4; 
            }

            
            int codigoReserva = reservas.AdicionarReservaBO(reservaBO);

            if (codigoReserva > 0)
            {
                return codigoReserva; 
            }

         
            return -5; 
        }

        /// <summary>
        /// Remove uma reserva com base no código fornecido.
        /// </summary>
        /// <param name="codigoReserva">Código da reserva a ser removida.</param>
        /// <returns><c>true</c> se a reserva for removida com sucesso, caso contrário, <c>false</c>.</returns>
        public bool RemoverReservaRegra(int codigoReserva)
        {
            return reservas.RemoverReserva(codigoReserva); 
        }


        /// <summary>
        /// Calcula o preço total da reserva com base no código da reserva e no preço por noite.
        /// </summary>
        /// <param name="codigoReserva">Código da reserva para a qual o preço será calculado.</param>
        /// <param name="precoPorNoite">Preço por noite de hospedagem.</param>
        /// <returns>Preço total da reserva ou 0 se a reserva não for encontrada.</returns>
        public decimal CalcularPrecoReservaRegra(int codigoReserva, decimal precoPorNoite)
        {
            return reservas.CalcularPrecoReserva(codigoReserva, precoPorNoite);
        }

        /// <summary>
        /// Verifica se uma reserva existe com base no código fornecido.
        /// </summary>
        /// <param name="codigoReserva">Código da reserva a ser verificada.</param>
        /// <returns>Retorna true se a reserva existir, caso contrário, retorna false.</returns>
        public bool ReservaExisteRegra(int codigoReserva)
        {
            return reservas.ReservaExiste(codigoReserva); 
        }


        /// <summary>
        /// Tenta guardar as reservas em um ficheiro especificado.
        /// </summary>
        /// <param name="caminhoFicheiro">Caminho do ficheiro onde as reservas serão guardadas.</param>
        /// <returns>Retorna true se as reservas forem guardadas com sucesso, caso contrário, retorna false.</returns>
        public bool GuardarReservasRegra(string caminhoFicheiro)
        {
            try
            {
                if (reservas.GuardarReservas(caminhoFicheiro))
                {
                    return true;
                }

                return false;
            }
            catch (AcessoNegadoException)
            {
                return false;
            }
            catch (ErroDeIOException)
            {
                return false;
            }
            catch (SerializacaoException)
            {
                return false;
            }
            catch (BaseReservaException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Tenta carregar as reservas de um ficheiro especificado.
        /// </summary>
        /// <param name="caminhoFicheiro">Caminho do ficheiro de onde as reservas serão carregadas.</param>
        /// <returns>Retorna true se as reservas forem carregadas com sucesso, caso contrário, retorna false.</returns>
        public bool CarregarReservasRegra(string caminhoFicheiro)
        {
            try
            {
                if (reservas.CarregarReservas(caminhoFicheiro))
                {
                    return true;
                }

                return false;
            }
            catch (FicheiroNaoEncontradoException)
            {
                return false;
            }
            catch (AcessoNegadoException)
            {
                return false;
            }
            catch (ErroDeIOException)
            {
                return false;
            }
            catch (SerializacaoException)
            {
                return false;
            }
            catch (BaseReservaException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return false;
            }
        }

    }



}

