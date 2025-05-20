using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;
using RestAPI.Data;
using RestAPI.Models.DTOs.UserDto;
using Microsoft.EntityFrameworkCore;
using System;

namespace RestAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioEntity?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.Usuarios.AnyAsync(u => u.Id == id);
        }

        public async Task<bool> CreateAsync(UsuarioEntity usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<UsuarioEntity>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }

}
