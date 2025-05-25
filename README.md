# Sistema de Gestão de Alojamentos Turísticos

## Introdução

Este projeto, desenvolvido como parte de um trabalho académico no Instituto Politécnico do Cávado e do Ave (IPCA), tem como objetivo criar um sistema robusto e automatizado para a gestão de reservas e check-ins em alojamentos turísticos, como hotéis, pousadas ou plataformas de aluguel de temporada. O sistema foi implementado em **C#**, utilizando os princípios da **Programação Orientada a Objetos (POO)** e seguindo uma arquitetura modular e escalável baseada no modelo **N-tier**. 

O sistema suporta funcionalidades essenciais, como registo e gestão de reservas, verificação de disponibilidade, execução de check-ins e armazenamento seguro de informações, com foco em boas práticas de desenvolvimento, incluindo separação de camadas, documentação detalhada e validações rigorosas.

## Funcionalidades Principais

- **Gestão de Alojamentos**: Permite criar, gerir e consultar detalhes de alojamentos, incluindo nome, preço por noite, capacidade de quartos e disponibilidade.
- **Gestão de Reservas**: Suporta a criação, cancelamento e verificação de reservas, com validação de datas e quantidades de quartos.
- **Gestão de Check-ins**: Regista e verifica check-ins associados a reservas, com suporte para persistência de dados.
- **Persistência de Dados**: Armazena informações em ficheiros binários, garantindo a preservação entre execuções do programa.
- **Tratamento de Exceções**: Inclui tratamento robusto de erros, como acesso negado, ficheiros não encontrados e problemas de serialização.
- **Testes Unitários**: Valida funcionalidades críticas, como a adição de reservas, para garantir confiabilidade.
- **Arquitetura N-tier**: Organiza o sistema em camadas (Apresentação, Regras, Dados e BO - Business Objects) para facilitar manutenção e escalabilidade.

## Estrutura do Projeto

O sistema é composto por várias classes e interfaces, organizadas em diferentes camadas e namespaces:

### Camada de Dados (`dados`)
- **`Reserva`**: Representa uma reserva de quartos, com propriedades como cliente, alojamento, datas de entrada/saída, quantidade de quartos e estado.
- **`CheckIn`**: Classe abstrata para gerir check-ins, com métodos para adicionar, guardar e carregar check-ins.
- **`CheckInConcreto`**: Implementação concreta da classe `CheckIn`, que manipula check-ins com persistência em ficheiros.
- **`GestaoCheckIn`**: Gerencia listas de check-ins, com métodos para adicionar, verificar e persistir check-ins.
- **`Reservas`**: Gerencia listas de reservas, com funcionalidades para adicionar, remover, calcular preços e persistir dados.

### Camada de Regras (`Regras`)
- **`RegrasCheckIn`**: Define regras para a gestão de check-ins, incluindo validações e operações de persistência.
- **`ReservasRegras`**: Define regras para a gestão de reservas, com validações para datas, quantidades de quartos e cálculos de preços.

### Camada de Objetos de Negócio (`BO`)
- **`Alojamento`**: Representa um alojamento com métodos para reservar e liberar quartos.
- **`Cliente`**: Representa um cliente com nome e número de identificação.
- **`CheckInBO`**: Objeto de negócio para check-ins, contendo o código da reserva.
- **`ReservaBO`**: Objeto de negócio para reservas, com informações simplificadas.

### Camada de Exceções (`trataProblemas`)
- **`BaseReservaException`**: Classe base para exceções do sistema de reservas.
- **`AcessoNegadoException`**, **`ErroDeIOException`**, **`FicheiroNaoEncontradoException`**, **`SerializacaoException`**: Exceções específicas para erros de acesso, entrada/saída, ficheiros não encontrados e serialização.

### Camada de Testes (`ReservasTests`)
- **`ReservasTests`**: Contém testes unitários para validar a adição de reservas válidas e inválidas.

### Interfaces
- **`Fase1.IAlojamento`**, **`BO.IAlojamento`**: Definem operações para gerenciamento de alojamentos, como reserva e cancelamento de quartos.

## Alterações Realizadas

Durante o desenvolvimento, foram implementadas melhorias significativas:
- **Uso de Listas**: Substituição de arrays por listas para maior flexibilidade na manipulação de dados.
- **Programação por Camadas**: Adoção da arquitetura N-tier para separação clara de responsabilidades.
- **Testes Unitários**: Implementação de testes para validar a funcionalidade de adição de reservas.
- **Tratamento de Exceções**: Adição de tratamento robusto para erros em operações de ficheiros.
- **Persistência de Dados**: Uso de ficheiros binários para armazenar reservas e check-ins.
- **Otimização de Lógica**: Substituição de passagem de objetos por códigos identificadores para maior eficiência.

## Principais Dificuldades

A maior dificuldade foi a implementação da **programação por camadas**, especialmente na definição das responsabilidades de cada camada e na comunicação entre elas. Este desafio foi superado com ajustes contínuos e aprendizado sobre a arquitetura N-tier.

## Requisitos

- **Linguagem**: C#
- **Ambiente**: .NET Framework ou .NET Core
- **Ferramentas**: Visual Studio ou outro IDE compatível com C#
- **Dependências**: Nenhuma biblioteca externa é necessária, mas o sistema utiliza funcionalidades padrão do .NET para serialização e manipulação de ficheiros.


## Estrutura de Ficheiros
📂 Projeto
├── 📂 BO
│   ├── AlojamentoBO.cs
│   ├── CheckInBO.cs
│   ├── ClienteBO.cs
│   ├── IAlojamento.cs
│   └── ReservasBO.cs
├── 📂 dados
│   ├── CheckIn.cs
│   ├── CheckInConcreto.cs
│   ├── CheckInReserva.cs
│   ├── Reserva.cs
│   ├── Reservas.cs
│   └── GestaoCheckIn.cs
├── 📂 Regras
│   ├── RegrasCheckIn.cs
│   └── ReservasRegras.cs
├── 📂 trataProblemas
│   └── trata.cs
├── 📂 TestesReserva
│   └── testes.AdicionarReserva.cs
└── 📂 Fase1
    ├── Alojamento.cs
    ├── CheckIn.cs
    ├── CheckInReserva.cs
    ├── Cliente.cs
    ├── IAlojamento.cs
    └── Reserva.cs


## Conclusão
O sistema desenvolvido é uma solução robusta e escalável para a gestão de alojamentos turísticos, com suporte a reservas, check-ins e persistência de dados. A arquitetura modular, o uso de boas práticas de POO e a inclusão de testes unitários garantem confiabilidade e facilidade de manutenção. Apesar dos desafios com a programação por camadas, o projeto foi concluído com sucesso, oferecendo uma base sólida para futuras expansões, como integração com sistemas externos ou relatórios analíticos.

##Autor
João Pedro Júnior Barbosa (27964)
Orientador: Professor Luís Gonzaga Martins Ferreira
Data: Novembro de 2024
