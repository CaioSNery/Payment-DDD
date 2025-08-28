# 💳 PaymentContext API

[![.NET](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/)  
[![Swagger](https://img.shields.io/badge/docs-Swagger-orange)](#-documentação-swagger)  

API desenvolvida em **.NET 8** para gerenciamento de **assinaturas de alunos**, permitindo criar uma inscrição a partir de diferentes tipos de pagamento:  
- Boleto  
- PayPal  
- Cartão de Crédito  

A aplicação foi construída com **DDD (Domain-Driven Design)**, aplicando conceitos de **Value Objects, Entities, Repositories e Handlers**.  

--

⚙️ Tecnologias Utilizadas

ASP.NET Core 8
Entity Framework Core
SQL Server (padrão, mas pode ser alterado para InMemory)
Swagger para documentação
Flunt (validações / notificações)

🚀 Como Executar o Projeto

Clone o repositório:
git clone https://github.com/seuusuario/paymentcontext.git
cd paymentcontext

Configure a conexão com o banco de dados no arquivo appsettings.json:
"ConnectionStrings": {
  "Default": "Server=localhost;Database=PaymentContext;Trusted_Connection=True;TrustServerCertificate=True;"
}

Se quiser rodar em memória (sem banco de dados), basta substituir no Program.cs:
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("PaymentContextDB"));


Restaure as dependências e execute:
dotnet restore
dotnet build
dotnet run --project PaymentContext.Api


Acesse a documentação Swagger em:
https://localhost:5001/swagger

📌 Endpoints Principais
Criar Assinatura com Boleto

POST /api/subscriptions/boleto

Body (exemplo):
{
  "firstName": "Caio",
  "lastName": "Nery",
  "document": "12345678901",
  "email": "caio@email.com",
  "street": "Rua A",
  "number": "123",
  "neighborhood": "Centro",
  "city": "São Paulo",
  "state": "SP",
  "country": "Brasil",
  "zipCode": "12345678",
  "type": "Residential",
  "barCode": "123456789",
  "boletoNumber": "000111222",
  "paidDate": "2025-08-01",
  "expireDate": "2025-09-01",
  "total": 100,
  "paidTotal": 100,
  "payer": "Caio Nery",
  "payerDocument": "12345678901",
  "payerDocumentType": 1
}

Criar Assinatura com PayPal
POST /api/subscriptions/paypal


Criar Assinatura com Cartão de Crédito
POST /api/subscriptions/creditcard


🏛️ Padrões e Boas Práticas

DDD (Domain-Driven Design):
Separação clara de Entities, ValueObjects, Repositories, Handlers e Commands.

Notificações com Flunt:
Validação de objetos de valor e entidades.

Dependency Injection:
Serviços e repositórios injetados no Program.cs.

✅ Próximos Passos

🔐  Implementar autenticação (JWT)

⚠️ Criar testes automatizados

🔨 Adicionar logs e monitoramento

📄 Licença

Este projeto é open-source e pode ser usado para estudos ou melhorias pessoais.
