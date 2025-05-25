/*
*	<copyright file="Regras.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>17/12/2024 11:27:39</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using BO;
using trataProblemas;


namespace dados
{
    [Serializable]
    public class GestaoCheckIn : CheckIn
    {
        public static List<CheckIn> listaCheckIns = new List<CheckIn>();

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="GestaoCheckIn"/>.
        /// </summary>
        /// <param name="codigoReserva">O código da reserva associada ao check-in.</param>
        public GestaoCheckIn(int codigoReserva) : base(codigoReserva) { }

        /// <summary>
        /// Converte um objeto <see cref="CheckInBO"/> para um objeto <see cref="CheckInConcreto"/>.
        /// </summary>
        /// <param name="checkInBO">O objeto <see cref="CheckInBO"/> a ser convertido.</param>
        /// <returns>Retorna um novo objeto <see cref="CheckInConcreto"/> com o código de reserva do <see cref="CheckInBO"/>.</returns>
        private CheckIn ConverteCheckInBOParaCheckInConcreto(CheckInBO checkInBO)
        {
            return new CheckInConcreto(checkInBO.CodigoReserva);
        }


        /// <summary>
        /// Adiciona um novo check-in à lista de check-ins após convertê-lo de <see cref="CheckInBO"/> para <see cref="CheckInConcreto"/>.
        /// </summary>
        /// <param name="checkInBO">O objeto <see cref="CheckInBO"/> que contém os dados do check-in a ser adicionado.</param>
        /// <returns>Retorna <c>true</c> após adicionar o check-in à lista.</returns>
        public bool AdicionarCheckIn(CheckInBO checkInBO)
        {

                CheckIn checkIn = ConverteCheckInBOParaCheckInConcreto(checkInBO);  // Converte o CheckInBO
                listaCheckIns.Add(checkIn);  
                return true;

        }

        /// <summary>
        /// Realiza o check-in para a reserva especificada, criando um novo objeto <see cref="CheckInConcreto"/> e adicionando-o à lista de check-ins.
        /// </summary>
        /// <param name="codigoReserva">Código da reserva para a qual o check-in será realizado.</param>
        /// <returns>Retorna <c>true</c> se o check-in for realizado com sucesso, ou <c>false</c> caso contrário.</returns>
        public bool RealizarCheckIn(int codigoReserva)
        {
 
                // Cria um novo objeto CheckInConcreto com o código da reserva e a data/hora atual
                CheckInConcreto novoCheckIn = new CheckInConcreto(codigoReserva, DateTime.Now);

                if (AdicionarCheckIn(novoCheckIn)) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
  
        }


        /// <summary>
        /// Adiciona um check-in à lista de check-ins caso ele já tenha sido realizado.
        /// </summary>
        /// <param name="checkIn">Objeto do tipo <see cref="CheckIn"/> a ser adicionado.</param>
        /// <returns>
        /// Retorna <c>true</c> se o check-in foi adicionado com sucesso; 
        /// retorna <c>false</c> caso contrário.
        /// </returns>

        public override bool AdicionarCheckIn(CheckIn checkIn)
        {
            if (checkIn.CheckInRealizado()) // Só adiciona se o check-in foi realizado
            {
                listaCheckIns.Add(checkIn);
                return true; 
            }
            else
            {
                return false; 
            }
        }


        /// <summary>
        /// Guarda a lista de check-ins no ficheiro especificado.
        /// </summary>
        /// <param name="caminhoFicheiro">Caminho do ficheiro onde os check-ins serão guardados.</param>
        /// <returns>Retorna <c>true</c> se guardar for bem-sucedido.</returns>
        /// <exception cref="AcessoNegadoException">Sem permissão para acessar o ficheiro.</exception>
        /// <exception cref="ErroDeIOException">Erro ao guardar no ficheiro.</exception>
        /// <exception cref="SerializacaoException">Erro durante a serialização dos dados.</exception>
        /// <exception cref="BaseReservaException">Erro genérico com código "-4".</exception>

        public override bool GuardarCheckIns(string caminhoFicheiro)
        {
            try
            {
                using (FileStream stream = new FileStream(caminhoFicheiro, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, listaCheckIns);
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
        /// Carrega a lista de check-ins a partir de um ficheiro.
        /// </summary>
        /// <param name="caminhoFicheiro">Caminho do ficheiro a ser carregado.</param>
        /// <returns>Retorna <c>true</c> se o carregamento for bem-sucedido.</returns>
        /// <exception cref="FicheiroNaoEncontradoException">Lançada se o ficheiro não existir.</exception>
        /// <exception cref="AcessoNegadoException">Sem permissão para acessar o ficheiro.</exception>
        /// <exception cref="ErroDeIOException">Erro ao carregar do ficheiro.</exception>
        /// <exception cref="SerializacaoException">Erro durante a desserialização dos dados.</exception>
        /// <exception cref="BaseReservaException">Erro genérico com código "-4".</exception>

        public override bool CarregarCheckIns(string caminhoFicheiro)
        {

            try
            {
                if (!File.Exists(caminhoFicheiro))
                {
                    throw new FicheiroNaoEncontradoException();
                }
                using (FileStream stream = new FileStream(caminhoFicheiro, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    listaCheckIns = (List<CheckIn>)formatter.Deserialize(stream);
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
        /// Verifica se o check-in foi realizado.
        /// </summary>
        /// <returns>Retorna <c>true</c> se o check-in foi realizado; caso contrário, <c>false</c>.</returns>

        public override bool CheckInRealizado()
        {
            return DataHoraCheckIn.HasValue;
        }
    }
}








