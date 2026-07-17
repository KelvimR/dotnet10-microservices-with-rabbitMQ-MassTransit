# .NET Lab Infrastructure

![CI](https://github.com/KelvimR/dotnet10-microservices-with-rabbitMQ-MassTransit/actions/workflows/ci.yml/badge.svg)
![CodeQL](https://github.com/KelvimR/dotnet10-microservices-with-rabbitMQ-MassTransit/actions/workflows/codeql.yml/badge.svg)

Infraestrutura Docker utilizada para estudos de desenvolvimento backend com **.NET**, **RabbitMQ**, **SQL Server**, **PostgreSQL**, **MongoDB** e **Redis**.

O objetivo deste projeto é fornecer um ambiente de desenvolvimento completo para praticar APIs, microsserviços, mensageria, cache, bancos relacionais e NoSQL sem instalar essas ferramentas diretamente na máquina.

---

# Tecnologias

- Docker
- Docker Compose
- RabbitMQ
- SQL Server 2022
- PostgreSQL 17
- MongoDB 8
- Redis 8

---

# Estrutura

```
.
├── docker-compose.yml
├── .env
└── README.md
```

---

# Serviços disponíveis

| Serviço | Porta | Finalidade |
|----------|------:|------------|
| RabbitMQ | 5672 | Broker de Mensageria |
| RabbitMQ Management | 15672 | Interface Web |
| SQL Server | 1433 | Banco Relacional |
| PostgreSQL | 5432 | Banco Relacional |
| MongoDB | 27017 | Banco NoSQL |
| Redis | 6379 | Cache em Memória |

---

# Iniciando o ambiente

Subir todos os containers

```bash
docker compose up -d
```

Verificar containers

```bash
docker ps
```

Visualizar logs

```bash
docker compose logs
```

Visualizar logs de um serviço

```bash
docker compose logs rabbitmq
```

Parar os containers

```bash
docker compose stop
```

Remover containers

```bash
docker compose down
```

Remover containers e volumes

```bash
docker compose down -v
```

---

# Volumes

Todos os bancos utilizam volumes Docker para persistência dos dados.

Isso significa que remover um container **não remove os bancos**.

Para apagar completamente os dados:

```bash
docker compose down -v
```

---

# Rede

Todos os serviços fazem parte da rede Docker:

```
backend
```

Dentro da rede Docker, os serviços se comunicam utilizando o hostname.

Exemplo:

| Serviço | Hostname |
|----------|-----------|
| RabbitMQ | rabbitmq |
| SQL Server | sqlserver |
| PostgreSQL | postgres |
| MongoDB | mongo |
| Redis | redis |

---

# RabbitMQ

Management

```
http://localhost:15672
```

Usuário

```
admin
```

Senha

```
********
```

Connection String

```
Host=rabbitmq
Port=5672
Username=admin
Password=*******
```

---

# SQL Server

Servidor

```
localhost
```

Porta

```
1433
```

Usuário

```
sa
```

Connection String (.NET)

```csharp
Server=localhost,1433;
Database=MinhaBase;
User Id=sa;
Password=SuaSenha;
TrustServerCertificate=True;
```

---

# PostgreSQL

Host

```
localhost
```

Porta

```
5432
```

Connection String

```text
Host=localhost;
Port=5432;
Database=dotnetdb;
Username=admin;
Password=*******
```

---

# MongoDB

Host

```
localhost
```

Porta

```
27017
```

Connection String

```text
mongodb://admin:******@localhost:27017
```

---

# Redis

Host

```
localhost
```

Porta

```
6379
```

Connection String

```text
localhost:6379
```

---

# Health Checks

Todos os containers possuem Health Check configurado.

Verificar status:

```bash
docker ps
```

ou

```bash
docker inspect rabbitmq
```

Status esperado

```
healthy
```

---

# Variáveis de Ambiente

As credenciais são configuradas através do arquivo:

```
.env
```

Exemplo:

```properties
RABBITMQ_USER=admin
RABBITMQ_PASSWORD=admin123

SQL_PASSWORD=StrongPassword123!

POSTGRES_USER=admin
POSTGRES_PASSWORD=admin123
POSTGRES_DB=dotnetdb

MONGO_USER=admin
MONGO_PASSWORD=admin123
```

---

# Objetivo deste laboratório

Este ambiente será utilizado para estudar:

- APIs com .NET
- Entity Framework Core
- Dapper
- RabbitMQ
- MassTransit
- Microsserviços
- Clean Architecture
- Docker
- Docker Compose
- Redis
- MongoDB
- PostgreSQL
- SQL Server
- Background Services
- Mensageria
- Event Driven Architecture
- Cache
- Observabilidade
- Kubernetes (futuramente)

---

# Roadmap

- [x] Docker Compose
- [x] RabbitMQ
- [x] SQL Server
- [x] PostgreSQL
- [x] MongoDB
- [x] Redis
- [ ] API ASP.NET Core
- [ ] Entity Framework Core
- [ ] Dapper
- [ ] RabbitMQ Producer
- [ ] RabbitMQ Consumer
- [ ] MassTransit
- [ ] Background Services
- [ ] Redis Cache
- [ ] Serilog
- [ ] Seq
- [ ] OpenTelemetry
- [ ] Grafana
- [ ] Prometheus
- [ ] Kubernetes

---

# Licença

Projeto criado para fins de estudo e prática de desenvolvimento backend utilizando tecnologias modernas do ecossistema .NET.
