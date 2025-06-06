# 🌦️ ClimaESP - Sistema de Monitoramento e Alerta Climático

Projeto desenvolvido como parte da disciplina **Advanced Business Development with .NET** da FIAP. A proposta é oferecer uma solução inovadora e funcional para **monitoramento climático comunitário**, com ênfase em urgências como calor extremo, chuvas intensas e ventos fortes. 

A API REST desenvolvida fornece acesso aos dados e integrações com IoT via ESP32, com armazenamento em banco Oracle e acesso via interface web (MVC com Razor Pages).

---

## 🚀 Funcionalidades da Solução

- 📡 **Recebimento de dados climáticos** via API externa e sensores simulados
- 🌍 **CRUD completo de dispositivos (ESP32)** vinculados à localização
- 👥 **Cadastro e gestão de usuários**
- 🌦️ **Regras de risco climático** aplicadas:
  - Aciona lógica de alerta conforme temperatura, chuva e condição do tempo
- 🧾 **Documentação dos endpoints com Swagger**
- 🧑‍💻 **Interface Razor (MVC)** para navegação visual dos dados e gestão

---

## 🧱 Arquitetura da Solução

- **.NET 9** + **Entity Framework Core**
- Banco de dados: **Oracle**
- Estrutura MVC separada por camadas
- API REST bem estruturada, documentada e versionada

---

## 🔧 Como Executar

### 1. Clone o projeto

```
git clone https://github.com/Maciel0123/GS1-.NET.git
cd GS1-.NET
```
### 2. Configure a connection string no appsettings.json

Preecha com seus dados do banco Oracle
```
"ConnectionStrings": {
  "DefaultConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=oracle.fiap.com.br:1521/ORCL;"
}
```
### 3. Execute a migration e rode a aplicação
```
dotnet ef database update
dotnet run --project Clima.API
```
## 🧪 Testes de API com Swagger
Após executar o projeto da API:

📌 Acesse:
```
https://localhost:port/swagger
```
Exemplos de rotas disponíveis:
GET /api/usuario → lista todos os usuários

POST /api/usuario → cadastra novo usuário

GET /api/dispositivo → lista dispositivos

POST /api/dadosclimaticos → envia dados climáticos

GET /evento/index → exibe eventos climáticos tratados via lógica

## 🧪 Testes do projeto MVC
Após executar o projeto MVC:

📌 Acesse os endpoints para testes:
```
http://localhost:5012/usuario
```
```
http://localhost:5012
```
Funcionalidades:
http://localhost:5012/usuario -> Mostra todas as opções de CRUD com interface grafica intuitiva
http://localhost:5012 -> Mostra os dados climaticos e estado atual (Estavel, Aleta, Critico)

## 📊 Diagrama de Entidades

![Diagrama ER](Entidades.png)

## 👨‍👩‍👧‍👦 Equipe
Henrique Maciel (RM556480),
Gabriela Moguinho Gonçalves (RM556143),
Mariana Christina Rodrigues Fernandes (RM554773)
