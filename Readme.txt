Crie uma API RESTful para gerenciar tarefas e projetos. A aplicação deve permitir:

Entidades principais:
📁 Projeto (Project)
	Id (Guid)
	Nome (string)
	Descrição (string?)
	DataInicio (DateTime)
	DataFim (DateTime?)
	Status (enum: Pendente, EmAndamento, Concluido)

✅ Tarefa (Task)
	Id (Guid)
	Titulo (string)
	Descricao (string?)
	Prioridade (enum: Baixa, Media, Alta)
	DataCriacao (DateTime)
	DataConclusao (DateTime?)
	Concluida (bool)
	ProjetoId (Guid) → relacionamento com Projeto

⚙️ Funcionalidades obrigatórias da API:
	Criar, listar, editar e excluir Projetos
	Criar, listar, editar e excluir Tarefas
	Filtrar tarefas por prioridade ou por status
	Relacionar tarefas a projetos
	Endpoint para marcar tarefa como concluída
	Swagger configurado com exemplos
	Validar entrada com FluentValidation