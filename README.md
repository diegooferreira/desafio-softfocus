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

## Utilização
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
