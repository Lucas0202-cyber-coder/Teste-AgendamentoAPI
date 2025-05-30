# Sistema de Agendamento

Um sistema simples para gerenciar usuários, salas e agendamentos de reuniões.  
Permite criar, ler, atualizar e deletar informações de usuários, salas (agendamentos trocam de status mas nunca deletados)

---

## Tecnologias Utilizadas

- Backend: API RESTful em .NET 8 (C#) - Documentação Via Swagger
- Banco de Dados: PostgreSQL
- ORM : Entity Framework
- Controle de versão: Git

---

## Funcionalidades

### Autenticação Via Token JWT Bearer
- Acesso a API somente via login e senha do usuário cadastrado no sistema
Após copiar o token , clicar no ícone "Authorize" , cole o token ("Bearer + (token) )
Dessa forma o usuário terá acesso às demais funcionalidades.

### Usuários
- Criar novo usuário
- Listar todos os usuários
- Trazer usuário por id
- Atualizar dados do usuário
- Remover usuário

### Salas
- Criar nova sala
- Listar salas
- Trazer sala pelo id
- Atualizar dados da sala
- Excluir sala

### Agendamentos
- Criar agendamento (associando usuário + sala + horário)
- Listar agendamentos
- Filtrar agendamentos por data, status, usuário que fez o agendamento e sala onde será a reunião)
- Cancelar/excluir agendamento( troca apenas o status )


## Estrutura de dados (Exemplo JSON)

### Usuário

{
  "id": 1,
  "name": "Lucas Smith",
  "senha": "teste123"
}
