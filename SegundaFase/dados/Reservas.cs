/*
*	<copyright file="Regras.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>17/12/2024 15:07:39</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using trataProblemas;
using BO;


namespace dados
{

    [Serializable]
    public class Reservas
    {
        public static List<Reserva> reservas = new List<Reserva>();
        int codigoReservaAtual = 1000;


        /// <summary>
        /// Obtém ou define o código da reserva atual.
        /// </summary>
        /// <value>O código da reserva atual.</value>
        public int CodigoReservaAtual
        {
            get { return codigoReservaAtual; }
            set { codigoReservaAtual = value; }
        }


        /// <summary>
        /// Construtor estático da classe <see cref="Reservas"/>. 
        /// Inicializa a lista de reservas quando a classe é carregada.
        /// </summary>
        static Reservas()
        {
            reservas = new List<Reserva>();
        }


        /// <summary>
        /// Converte uma ReservaBO para uma instância de dados.Reserva.
        /// </summary>
        /// <param name="reservaBO">ReservaBO a ser convertida.</param>
        /// <returns>Uma nova instância de dados.Reserva.</returns>
        private Reserva ConverterParaReserva(ReservaBO reservaBO)
        {
            return new Reserva(
                reservaBO.NumIdentificacao,
                reservaBO.NumAlojamento,
                reservaBO.DataEntrada,
                reservaBO.DataSaida,
                reservaBO.QuantidadeQuartos)
            {
                CodigoReserva = reservaBO.CodigoReserva, // Usa o código existente, ou 0 para novo
                DataHoraCheckIn = null                   // Check-in ainda não realizado
            };
        }

        /// <summary>
        /// Adiciona uma nova reserva BO à lista, convertendo-a para dados.Reserva.
        /// </summary>
        /// <param name="reservaBO">ReservaBO a ser adicionada.</param>
        /// <returns>Código da reserva gerado ou -1 se a reserva for inválida.</returns>
        public int AdicionarReservaBO(ReservaBO reservaBO)
        {
            if (reservaBO == null)
                return -1; 

            // Converte ReservaBO para dados.Reserva
            Reserva reserva = ConverterParaReserva(reservaBO);

            return AdicionarReserva(reserva);
        }

        /// <summary>
        /// Adiciona uma nova reserva à lista.
        /// </summary>
        /// <param name="reserva">Reserva a ser adicionada</param>
        /// <returns>Código da reserva ou -1 se inválida</returns>
        public int AdicionarReserva(Reserva reserva)
        {
            if (reserva.QuantidadeQuartos <= 0 || reserva.DataSaida <= reserva.DataEntrada)
            {
                return -1; // Dados inválidos
            }

            reserva.CodigoReserva = codigoReservaAtual++;
            reservas.Add(reserva);
            return reserva.CodigoReserva;
        }


        /// <summary>
        /// Remove uma reserva pelo código.
        /// </summary>
        /// <param name="codigoReserva">Código da reserva</param>
        /// <returns>True se removida com sucesso, False caso contrário</returns>
        public bool RemoverReserva(int codigoReserva)
        {
            foreach (Reserva reserva in reservas)
            {
                if (reserva.CodigoReserva == codigoReserva)
                {
                    reservas.Remove(reserva);
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Calcula o preço total da reserva.
        /// </summary>
        /// <param name="codigoReserva">Código da reserva</param>
        /// <param name="precoPorNoite">Preço por noite</param>
        /// <returns>Preço total ou -1 se reserva não for encontrada</returns>
        public decimal CalcularPrecoReserva(int codigoReserva, decimal precoPorNoite)
        {
            if (!ReservaExiste(codigoReserva))
            {
                return -1; // Reserva não encontrada
            }

            foreach (Reserva reserva in reservas)
            {
                if (reserva.CodigoReserva == codigoReserva)
                {
                    int diasReservados = (reserva.DataSaida - reserva.DataEntrada).Days + 1;
                    return diasReservados * reserva.QuantidadeQuartos * precoPorNoite;
                }
            }

            return -1; // Reserva não encontrada
        }


        /// <summary>
        /// Verifica se uma reserva existe na lista de reservas.
        /// </summary>
        /// <param name="codigoReserva">Código da reserva a ser verificada.</param>
        /// <returns>Retorna <c>true</c> se a reserva existir, caso contrário, <c>false</c>.</returns>
        public bool ReservaExiste(int codigoReserva)
        {
            foreach (Reserva reserva in reservas)
            {
                if (reserva.CodigoReserva == codigoReserva)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Guarda a lista de reservas em um ficheiro binário especificado.
        /// </summary>
        /// <param name="caminhoFicheiro">O caminho completo do ficheiro onde as reservas serão guardadas.</param>
        /// <returns>Retorna <c>true</c> se o processo de guardar for bem-sucedido.</returns>
        /// <exception cref="AcessoNegadoException">Lançada quando não há permissão para acessar o ficheiro.</exception>
        /// <exception cref="ErroDeIOException">Lançada quando ocorre um erro de entrada/saída ao acessar o ficheiro.</exception>
        /// <exception cref="SerializacaoException">Lançada quando ocorre um erro ao serializar os dados.</exception>
        /// <exception cref="BaseReservaException">Lançada para erros genéricos não específicos (-4).</exception>
        public bool GuardarReservas(string caminhoFicheiro)
        {
            try
            {
                using (FileStream fs = new FileStream(caminhoFicheiro, FileMode.Create))
                {
                    BinaryFormatter bfw = new BinaryFormatter();
                    bfw.Serialize(fs, reservas);
                }
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                throw new AcessoNegadoException();
            }
            catch (IOException)
            {
                throw new ErroDeIOException();
            }
            catch (SerializacaoException)
            {
                throw new SerializacaoException();
            }

            catch (Exception)
            {
                throw new BaseReservaException("-4"); // Erro genérico
            }
        }

        /// <summary>
        /// Carrega a lista de reservas a partir de um ficheiro binário especificado.
        /// </summary>
        /// <param name="caminhoFicheiro">O caminho completo do ficheiro de onde as reservas serão carregadas.</param>
        /// <returns>Retorna <c>true</c> se o processo de carregamento for bem-sucedido.</returns>
        /// <exception cref="FicheiroNaoEncontradoException">Lançada quando o ficheiro especificado não é encontrado.</exception>
        /// <exception cref="AcessoNegadoException">Lançada quando não há permissão para acessar o ficheiro.</exception>
        /// <exception cref="ErroDeIOException">Lançada quando ocorre um erro de entrada/saída ao acessar o ficheiro.</exception>
        /// <exception cref="SerializacaoException">Lançada quando ocorre um erro ao desserializar os dados.</exception>
        /// <exception cref="BaseReservaException">Lançada para erros genéricos não específicos (-4).</exception>
        public bool CarregarReservas(string caminhoFicheiro)
        {
            try
            {
                if (!File.Exists(caminhoFicheiro))
                {
                    throw new FicheiroNaoEncontradoException();
                }

                using (FileStream fs = new FileStream(caminhoFicheiro, FileMode.Open))
                {
                    BinaryFormatter bfw = new BinaryFormatter();
                    reservas = (List<Reserva>)bfw.Deserialize(fs);
                }
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                throw new AcessoNegadoException();
            }
            catch (IOException)
            {
                throw new ErroDeIOException();
            }
            catch (SerializacaoException)
            {
                throw new SerializacaoException();
            }

            catch (Exception)
            {
                throw new BaseReservaException("-4"); // Erro genérico
            }
        }
   
    
    
    }

}
