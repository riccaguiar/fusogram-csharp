﻿using fusogram_csharp.Models;

namespace fusogram_csharp.Repository
{
    // Interface que define operações de repositório relacionadas a usuários
    public interface IUsuarioRepository
    {
        // Método para salvar um usuário no repositório
        public void Salvar(Usuario usuario);
    }
}
