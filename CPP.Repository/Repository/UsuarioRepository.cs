﻿using CPP.Entities.Data;
using CPP.Entities.Dtos;
using CPP.Repository.Context;
using CPP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Repository.Repository
{
   public class UsuarioRepository : BaseRepository, IUsuarioRepostory
    {

        private readonly CPPContext _context;
        public UsuarioRepository(CPPContext context) :
             base(context)
        {
            this._context = context;
        }

        public async Task<Usuario> GetUsuarioById(int usuario_id)
        {            
            IQueryable<Usuario> query = from r in _context.usuario
                                         where r.Id == usuario_id
                                        select r;

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUsuarioByName(string user_name)
        {
            IQueryable<Usuario> query = from r in _context.usuario
                                        where r.user == user_name
                                        select r;

            return await query.FirstOrDefaultAsync();
        }

        public async Task<UsuarioDto[]> GetUsuarios()
        {
            IQueryable<UsuarioDto> query = (from r in _context.usuario
                                            join s in _context.sucursal on r.sucursal_id equals s.Id
                                            select new UsuarioDto()
                                            {
                                                activo = r.activo,
                                                Id = r.Id,
                                                nombre = r.nombre,
                                                rol = r.rol_id == 1 ? "Administrador" : "Usuario",
                                                password = r.password,
                                                nombre_sucursal = s.nombre,
                                                user  =r.user,
                                                rol_id = r.rol_id,
                                                sucursal_id = r.sucursal_id
                                            });

            return await query.ToArrayAsync();
        }
    }
}