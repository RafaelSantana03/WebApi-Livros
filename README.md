# WebApi-Livros
![Captura de tela 2024-06-23 202411](https://github.com/RafaelSantana03/WebApi-Livros/assets/131009931/b8eb7c4f-fe59-4053-bcff-315e874346cf)

Esta API permite gerenciar autores e livros. 

## Funcionalidades

### Autores
- **Criar Autor**: Permite criar um novo autor.
- **Pesquisar Autor por ID**: Permite pesquisar um autor pelo seu ID.
- **Listar autores**: Lista todos os autores
- **Pesquisar Autor pelo ID do Livro**: Permite pesquisar um autor pelo ID do livro que ele escreveu.
- **Atualizar Autor**: Permite atualizar informações de um autor existente.
- **Deletar Autor**: Permite deletar um autor existente.

### Livros
- **Criar Livro**: Permite criar um novo livro.
- **Pesquisar Livro por ID**: Permite pesquisar um livro pelo seu IdLivro.
- **Pesquisar Livro por Id do Autor**: Permite pesquisar um livro pelo IdAutor.
- **Listar livros**: Lista todos os livros
- **Atualizar Livro**: Permite atualizar informações de um livro existente.
- **Deletar Livro**: Permite deletar um livro existente.

## Tecnologias Utilizadas
- C#
- .NET
- SQL Server
- Entity Framework

### Endpoints
## Autores
GET /api/Autor/ListarAutores: Lista todos os autores.
GET /api/Autor/BuscarAutorPorId/{idAutor}: Retorna um autor pelo seu ID.
GET /api/Autor/BuscarAutorPorIdLivro/{idLivro}: Retorna um autor pelo ID do livro.
POST /api/Autor/CriarAutor: Cria um novo autor.
PUT /api/Autor/EditarAutor: Atualiza um autor existente.
DELETE /api/Autor/ExcluirAutor: Deleta um autor existente.
## Livros
GET /api/Livro/ListarLivros: Lista todos os livros.
GET /api/Livro/BuscarLivroPorId/{idLivro}: Retorna um livro pelo seu ID.
GET /api/Livro/BuscarLivroPorIdAutor/{idAutor}: Retorna um livro pelo ID do autor.
POST /api/Livro/CriarLivro: Cria um novo livro.
PUT /api/Livro/EditarLivro: Atualiza um livro existente.
DELETE /api/Livro/ExcluirLivro: Deleta um livro existente.

### Créditos
Este projeto foi ministrado por Crislaine D' Paula.


