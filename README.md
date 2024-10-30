![Badge em Desenvolvimento](http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge)

# :rocket: Volvo-Truck 

*Este projeto foi desenvolvido para um teste técnico, sendo necessário o desenvolvimento de duas aplicações: uma de Back-End (API RESTful) em .NET Core 8 e uma de Front-End em React 7.25.9.*

### :hammer: Requisito do Sistema:
```

Requisitos Principais
Implementar uma Web API com as funções de CRUD com os seguintes requisitos:
1) Permitir o cadastro de caminhões com os seguintes requisitos;
    a. Modelo (FH/FM/VM)
    b. Ano de fabricação
    c. Código do chassi
    d. Cor
    e. Planta (Brasil/Suécia/Estados Unidos/França)
2) A aplicação deve permitir a seleção e edição dos campos cadastrados para um caminhão.
3) A aplicação deve permitir o cadastro de novos caminhões.
4) A aplicação deve permitir a exclusão de caminhões cadastrados.

Requisitos Técnicos
• Utilizar .NET Core 6 ou superior
• Utilizar base de dados local
• Utilizar ORM para mapear as tabelas de base de dados
    - Utilizar “Migrations” para a criação da base de dados
    - A criação da base de dados deverá ser automática (sem a necessidade de utilizar algum comando adicional).
• Criar testes unitários para os métodos implementados no back-end.
• Com relação ao front-End, fica a critério do candidato qual tecnologia utilizar, por exemplo, React, Angular, VueJS etc.
  
```
### :hammer_and_wrench: Abrir e Executar o projeto - Back-End.
```
O projeto foi desenvolvido utilizando o Rider IDM em um Macbook. 

    - Dentro do diretório Back-end/VolvoTrucks, há um arquivo .sln para abrir o projeto no Visual Studio 2022.
    - Na solução, clique com o botão direito sobre o projeto VolvoTrucks.Api e defina-o como padrão de inicialização para facilitar a execução rotineira,     clicando no ícone verde na barra superior.
    - Para executar os testes unitários no Visual Studio 2022: Acesse o menu superior -> Test -> Test Explorer -> Run All Tests in View.

```
Tela do Swagger da API
<img width="1192" alt="Captura de Tela 2024-10-30 às 01 31 31" src="https://github.com/user-attachments/assets/85fc3ddd-3f14-4ea4-958d-aef7ee534a60">

Collection do Postman 
[Volvo.postman_collection.json](https://github.com/user-attachments/files/17566803/Volvo.postman_collection.json)


### :hammer_and_wrench: Abrir e Executar o projeto - Back-End.
```
O projeto foi desenvolvido utilizando o Visual Studio Code. 

	- No Visual Studio Code, selecione Open Folder e busque o diretório da aplicação.
	- Verifique o arquivo config.js, localizado em VolvoTruck -> src -> utils. A URL base da aplicação deve apontar para a mesma URL usada no Visual Studio 2022 para execução da API.
    - Executar os seguintes comandados.
        npm install - Baixar as dependencias do projeto. 
        npm start   - Executar o projeto. 
	
```
Tela Inicial do sistema 
![Captura de Tela 2024-10-30 às 02 00 30](https://github.com/user-attachments/assets/eef40051-866b-494d-a8c3-4ee57f2c4e7d)

Tela de Adição e Atualização 
![Captura de Tela 2024-10-30 às 02 00 46](https://github.com/user-attachments/assets/9824a38b-66a1-4092-ac9f-36980e5a8e11)


