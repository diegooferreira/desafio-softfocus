# Comunicação de perda simplificada - Softfocus
O Proagro Fácil é um sistema da Softfocus que facilita o gerenciamento de
Proagro (Programa de Garantia da Atividade Agropecuária). O Proagro é um
programa administrado pelo Banco Central do Brasil, que visa exonerar o produtor
rural de obrigações financeiras relativas a operações de crédito, em casos de
ocorrência de perdas nas lavouras. Estas perdas podem ser ocasionadas por
fenômenos naturais, como chuva excessiva, geada, granizo, etc.
No Proagro Fácil, uma das principais etapas para a solicitação de Proagro é
o cadastro da comunicação da perda ocorrida, onde o analista de Proagro irá
informar os dados sobre o produtor rural, sobre a lavoura e sobre o evento que
provocou a perda. É muito importante que essas informações sejam preenchidas
corretamente para que o produtor tenha o benefício aprovado.
Neste desafio, foi implementado uma versão simplificada da comunicação de
perda.

## Demonstração
[Frontend](https://app-desafio-softfocus.azurewebsites.net/)

[Backend](https://api-desafio-softfocus.azurewebsites.net/swagger/)

## Utilização do sistema

## Tela de Listagem
A primeira tela de sistema é a listagem de comunicações de perdas já cadastradas, com opção de filtragem pelo CPF do produtor

#### Imagem - Tela de listagem

![image](https://user-images.githubusercontent.com/3593817/130087452-8d0af2d3-6221-4bf6-8a1b-e30ab73f4d1b.png)

#### Ações principais
O botão ![image](https://user-images.githubusercontent.com/3593817/130078396-52a14834-a88b-44fe-a41e-933e4190466b.png) só é habilitado caso o campo CPF possua o tamanho de 11 caracteres.

O botão ![image](https://user-images.githubusercontent.com/3593817/130079295-3b71e210-7e41-40b7-98b0-df1baad9d5aa.png)
 pesquisa todos os registros no banco de dados, indiferente da informação do filtro CPF.

O botão ![image](https://user-images.githubusercontent.com/3593817/130079074-c05546ee-d017-420d-905c-494a66b42c96.png) permite que o usuário do sistema vá para a tela de cadastro de comunicação de perda.

#### Ações de registro
Quando algum registro é obtido na listagem, são exibidas junto com ele as ações possíveis para o mesmo. São elas:

![image](https://user-images.githubusercontent.com/3593817/130078751-47046b72-3bb5-44ac-80fe-0736adad6742.png) Edição do registro - Abre a tela de cadastro apresentando todos os dados do registro, permitindo a edição dos dados e gravação dos mesmos.

![image](https://user-images.githubusercontent.com/3593817/130078812-fcb6d471-f4c5-4656-9e8d-1c97a0c91118.png) Deleção do registro - Exibe uma mensagem de confirmação que, se confirmada, exclue o registro do banco de dados

![image](https://user-images.githubusercontent.com/3593817/130079343-dceb5a40-a49c-4b1a-afdb-dd10bdd8a0fc.png) Visualização do registro - Abre a tela de cadastro apresentando todos os dados do registro, porém, com os campos read-only.

#### Validações
O botão ![image](https://user-images.githubusercontent.com/3593817/130078396-52a14834-a88b-44fe-a41e-933e4190466b.png) só é habilitado caso o campo CPF possua o tamanho de 11 caracteres. Após habilitado, antes da execução da consulta, o sistema valida se o CPF é válido.

## Tela de Inclusão
Tela para inclusão de uma nova comunicação de perda

#### Imagem - Tela de inclusão

![image](https://user-images.githubusercontent.com/3593817/130080901-8d7a8d39-a136-4079-b29f-5ad6681ed51e.png)

#### Ações principais
O botão ![image](https://user-images.githubusercontent.com/3593817/130083067-cd94d977-977f-4721-8c08-25f71e055224.png) valida os dados e efetiva a gravação das informações

O botão ![image](https://user-images.githubusercontent.com/3593817/130082883-e0c1199e-3d69-4ebc-bf1b-7dfcb9a17183.png) cancela a edição e volta para a tela de listagem

#### Validações
- Em tela, todos os campos são validados como obrigatórios.
- O campo CPF é validado em seu formato (validação no frontend e backend)
- O campo E-mail é validado em seu formato (validação no frontend e backend)
- Os campos Latitude e Longitude são validados em seu formato (validação no frontend e backend)
- Antes de efetivar a gravação, o sistema consulta se há uma comunicação de perda na mesma data e com evento diferente e exibe uma confirmação para o usuário, se ele deseja continuar com a gravação do registro ou não

![image](https://user-images.githubusercontent.com/3593817/130085525-837a2267-7321-4ff0-b551-33626148c534.png)


## Tela de edição
Tela para edição de uma comunicação de perda existente

#### Imagem - Tela de edição

![image](https://user-images.githubusercontent.com/3593817/130081121-d734d2e5-9cc5-4e30-bc54-63869f89d3c8.png)

#### Ações principais
O botão ![image](https://user-images.githubusercontent.com/3593817/130083067-cd94d977-977f-4721-8c08-25f71e055224.png) valida os dados e efetiva a gravação das informações

O botão ![image](https://user-images.githubusercontent.com/3593817/130082883-e0c1199e-3d69-4ebc-bf1b-7dfcb9a17183.png) cancela a edição e volta para a tela de listagem

#### Validações
- Em tela, todos os campos são validados como obrigatórios.
- O campo CPF é validado em seu formato (validação no frontend e backend)
- O campo E-mail é validado em seu formato (validação no frontend e backend)
- Os campos Latitude e Longitude são validados em seu formato (validação no frontend e backend)
- Antes de efetivar a gravação, o sistema consulta se há uma comunicação de perda na mesma data e com evento diferente e exibe uma confirmação para o usuário, se ele deseja continuar com a gravação do registro ou não

![image](https://user-images.githubusercontent.com/3593817/130085525-837a2267-7321-4ff0-b551-33626148c534.png)

## Tela de visualização
Tela para visualização dos dados da comunicação de perda

#### Imagem - Tela de visualização

![image](https://user-images.githubusercontent.com/3593817/130082662-d3e9d625-4b9f-4666-9612-67776efa0e9c.png)

#### Ações principais
O botão ![image](https://user-images.githubusercontent.com/3593817/130082830-92647f1d-42da-402c-a983-f4ec62d6cacb.png) retorna para a tela de listagem

## Configuração do ambiente
### Ferramentas mínimas recomendadas
- [Visual Studio 2019 Community](https://visualstudio.microsoft.com/pt-br/downloads/)
- [Visual Studio Code](https://code.visualstudio.com/download)
- [.NET Core 5.0.303 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [NodeJS](https://nodejs.org/en/download/)
- [Angular 11](https://angular.io/guide/setup-local)
- [MySql Community Server 5.6.48](https://downloads.mysql.com/archives/community/?version=5.6.48)
- [MySql workbench](https://dev.mysql.com/downloads/workbench/)

### Banco de dados
- Criar um banco de dados com um nome qualquer (sugestão: softfocus)
- Executar o arquivo db.sql para criação das tabelas e registros básicos no banco de dados recém criado

### Backend
- Abrir a solution (pasta backend) e fazer rebuild para baixar as dependências
- Ir até o arquivo appsettings.json e criar a propriedade 'Connection', conforme exemplo abaixo, substituindo os parâmetros de acordo com a sua instância do banco de dados: 
```sh
Server=[SERVIDOR];port=[PORTA];database=[BANCO DE DADOS];uid=[USUÁRIO];password=[SENHA];SslMode=Preferred
```
- O arquivo appsettings.json deve se parecer com o exemplo abaixo:
```sh
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "Connection": "Server=[SERVIDOR];port=[PORTA];database=[BANCO DE DADOS];uid=[USUÁRIO];password=[SENHA];SslMode=Preferred"
}
```
- Executar o projeto
- Se não abrir automáticamente, colocar '/swagger' no final da URL para abrir o Swagger
- Manter o projeto em execução

### Frontend
- Abrir no VS Code o conteúdo da pasta frontend
- Abrir um terminal e executar o comando abaixo para instalar as dependências
```sh
npm i
```
- Após instalar as dependências, ir até src/environments e mudar o valor da propriedade 'baseUrl' para a url obtida ao executar o backend. 
```sh
export const environment = {
  production: false,
  baseUrl: "[url-backend]"
};
```
> Nota: Pegar a url sem o /swagger (Exemplo: https://localhost:40339/)

- Para executar o comando abaixo para executar o projeto
```sh
ng s -o
```
