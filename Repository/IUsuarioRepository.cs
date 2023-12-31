﻿using fusogram_csharp.Models;

namespace fusogram_csharp.Repository
{
    public interface IUsuarioRepository
    {
        public void Salvar(Usuario usuario);

        public bool VerificarEmail(string email);
        Usuario GetUsuarioPorLoginSenha(string email, string senha);
        Usuario GetUsuarioPorId(int id);
        public void AtualizarUsuario(Usuario usuario);
        List<Usuario> GetUsuarioNome(string nome);
    }
}