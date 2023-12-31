﻿using fusogram_csharp.Models;

namespace fusogram_csharp.Repository.Impl
{
    public class ComentarioRepositoryImpl : IComentarioRepository
    {

        private readonly FusogramContext _context;

        public ComentarioRepositoryImpl(FusogramContext context)
        {
            _context = context;
        }

        public void Comentar(Comentario comentario)
        {
            _context.Add(comentario);
            _context.SaveChanges();
        }

        public List<Comentario> GetCometarioPorPublicacao(int idPublicacao)
        {
            return _context.Comentarios.Where(c => c.IdPublicacao == idPublicacao).ToList();
        }
    }
}
