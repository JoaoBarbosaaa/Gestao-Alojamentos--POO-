/*
*	<copyright file="Regras.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>João Barbosa</author>
*   <date>17/12/2024 18:27:39</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trataProblemas
{



    /// <summary>
    /// Classe base para as exceções do sistema de reservas.
    /// </summary>
    public class BaseReservaException : Exception
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="BaseReservaException"/> com o código de erro especificado.
        /// </summary>
        /// <param name="codigoErro">Código de erro associado à exceção.</param>
        public BaseReservaException(string codigoErro) : base(codigoErro) { }
    }

    /// <summary>
    /// Exceção lançada quando o acesso é negado.
    /// </summary>
    public class AcessoNegadoException : BaseReservaException
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="AcessoNegadoException"/> com um código de erro padrão (-1).
        /// </summary>
        public AcessoNegadoException() : base("-1") { }
    }

    /// <summary>
    /// Exceção lançada devido a um erro de entrada/saída.
    /// </summary>
    public class ErroDeIOException : BaseReservaException
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ErroDeIOException"/> com um código de erro padrão (-2).
        /// </summary>
        public ErroDeIOException() : base("-2") { }
    }

    /// <summary>
    /// Exceção lançada quando ocorre um erro de serialização.
    /// </summary>
    public class SerializacaoException : BaseReservaException
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="SerializacaoException"/> com um código de erro padrão (-3).
        /// </summary>
        public SerializacaoException() : base("-3") { }
    }

    /// <summary>
    /// Exceção lançada quando um ficheiro não é encontrado.
    /// </summary>
    public class FicheiroNaoEncontradoException : BaseReservaException
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="FicheiroNaoEncontradoException"/> com um código de erro padrão (-5).
        /// </summary>
        public FicheiroNaoEncontradoException() : base("-5") { }
    }

}
