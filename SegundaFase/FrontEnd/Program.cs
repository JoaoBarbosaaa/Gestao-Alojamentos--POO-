/*
*	<copyright file="Regras.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>17/12/2024 16:27:39</date>
*	<description></description>
**/
using BO;
using Regras;
using trataProblemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FrontEnd
{


    class Program
    {
        static void Main(string[] args)
        {


           
            Cliente cliente = Cliente.CriaCliente("João Silva", 123456789);
            Cliente cliente1 = Cliente.CriaCliente("Rui Gomes", 999999999);

            Alojamento alojamento = new Alojamento("Hotel XYZ", 10, 50, 1);

           
            ReservaBO reserva = new ReservaBO(cliente.NumIdentificacao, alojamento.NumAlojamento, DateTime.Now.Date, DateTime.Now.Date.AddDays(2), 3);
            ReservaBO reserva1 = new ReservaBO(cliente1.NumIdentificacao, alojamento.NumAlojamento, DateTime.Now.Date, DateTime.Now.Date.AddDays(5), 4);

          
            ReservasRegras reservasManager = new ReservasRegras();

           
            int codigoReserva = reservasManager.AdicionarReservaBO(reserva);

            if (codigoReserva > 0)
            {
                decimal precoPorNoite = alojamento.PrecoPorNoite;
                decimal precoTotal = reservasManager.CalcularPrecoReservaRegra(codigoReserva, precoPorNoite);
            }
            else if (codigoReserva == -1)
            {
            }
            else if (codigoReserva == -2)
            {
            }


            try
            {
                reservasManager.GuardarReservasRegra("reservas.dat");
                reservasManager.CarregarReservasRegra("reservas.dat");
            }
            catch (AcessoNegadoException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (ErroDeIOException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (SerializacaoException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (FicheiroNaoEncontradoException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (BaseReservaException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            int codigoReserva1 = reservasManager.AdicionarReservaBO(reserva1);

            if (codigoReserva > 0)
            {
                decimal precoPorNoite = alojamento.PrecoPorNoite;
                decimal precoTotal = reservasManager.CalcularPrecoReservaRegra(codigoReserva1, precoPorNoite);
            }
            else if (codigoReserva == -1)
            {
            }
            else if (codigoReserva == -2)
            {
            }


            try
            {
                reservasManager.GuardarReservasRegra("reservas1.dat");
                reservasManager.CarregarReservasRegra("reservas1.dat");
            }
            catch (AcessoNegadoException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (ErroDeIOException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (SerializacaoException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (FicheiroNaoEncontradoException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (BaseReservaException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            reservasManager.RemoverReservaRegra(codigoReserva1);

            RegrasCheckIn checkInManager = new RegrasCheckIn();

         
            CheckInBO checkIn = new CheckInBO(codigoReserva);
            bool checkInAdicionado = checkInManager.AdicionarCheckInRegra(checkIn);;

            
            bool checkInSucesso = checkInManager.RealizarCheckInRegras(codigoReserva);



           
            try
            {
                bool guardar = checkInManager.GuardarCheckInsRegra("checkins.dat");
                bool carregar = checkInManager.CarregarCheckInsRegra("checkins.dat");
            }
            catch (AcessoNegadoException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (ErroDeIOException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (SerializacaoException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (FicheiroNaoEncontradoException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (BaseReservaException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }


        }
    }
}














