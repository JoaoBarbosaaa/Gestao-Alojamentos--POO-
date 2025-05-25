/*
*	<copyright file="Regras.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>18/12/2024 11:23:58</date>
*	<description></description>
**/
using System;
using BO;
using dados;
using trataProblemas;

namespace Regras
{
    /// <summary>
    /// Purpose:
    /// Created by: João Barbosa
    /// Created on: 18/12/2024 11:23:58
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    /// 

    public class RegrasCheckIn
    {

        private GestaoCheckIn gestaoCheckIn;

        /// <summary>
        /// Construtor da classe <see cref="RegrasCheckIn"/>. Inicializa uma nova instância de <see cref="GestaoCheckIn"/>.
        /// </summary>
        public RegrasCheckIn()
        {
            gestaoCheckIn = new GestaoCheckIn(4);  // O código de reserva é irrelevante no construtor
        }


        /// <summary>
        /// Adiciona um check-in à gestão de check-ins.
        /// </summary>
        /// <param name="checkIn">O check-in a ser adicionado.</param>
        /// <returns>Retorna <c>true</c> se o check-in foi adicionado com sucesso, caso contrário, retorna <c>false</c>.</returns>
        public bool AdicionarCheckInRegra(CheckInBO checkIn)
        {
                return gestaoCheckIn.AdicionarCheckIn(checkIn);
        }


        /// <summary>
        /// Guarda os check-ins em um ficheiro.
        /// </summary>
        /// <param name="caminhoFicheiro">Caminho do ficheiro onde os check-ins serão guardados.</param>
        /// <returns>Retorna <c>true</c> se os check-ins foram guardados com sucesso, caso contrário, retorna <c>false</c>.</returns>
        public bool GuardarCheckInsRegra(string caminhoFicheiro)
        {
            try
            {
                if (gestaoCheckIn.GuardarCheckIns(caminhoFicheiro))
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
        /// Carrega os check-ins a partir de um ficheiro.
        /// </summary>
        /// <param name="caminhoFicheiro">Caminho do ficheiro de onde os check-ins serão carregados.</param>
        /// <returns>Retorna <c>true</c> se os check-ins foram carregados com sucesso, caso contrário, retorna <c>false</c>.</returns>
        public bool CarregarCheckInsRegra(string caminhoFicheiro)
        {
            try
            {
                if (gestaoCheckIn.CarregarCheckIns(caminhoFicheiro))
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


        /// <summary>
        /// Realiza o check-in para a reserva especificada.
        /// </summary>
        /// <param name="codigoReserva">Código da reserva para a qual o check-in será realizado.</param>
        /// <returns>Retorna <c>true</c> se o check-in foi realizado com sucesso, caso contrário, retorna <c>false</c>.</returns>
        public bool RealizarCheckInRegras(int codigoReserva)
        {
            return gestaoCheckIn.RealizarCheckIn(codigoReserva);
        }

    }
}





