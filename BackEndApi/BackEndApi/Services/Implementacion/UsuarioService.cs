using Microsoft.EntityFrameworkCore;
using BackEndApi.Models;
using BackEndApi.Services.Contrato;

namespace BackEndApi.Services.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private PruebasContext _dbContext;

        public UsuarioService(PruebasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Usuario>> GetList()
        {
            try
            {
                List<Usuario> lista = new List<Usuario>();
                lista = await _dbContext.Usuarios.ToListAsync();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> GetById(int idUsuario)
        {
            try
            {
                Usuario? usuario = new Usuario();
                usuario = await _dbContext.Usuarios
                                .Where(e => e.Id == idUsuario).FirstOrDefaultAsync();
                
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> Add(Usuario modelo)
        {
            try
            {
                _dbContext.Usuarios.Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(Usuario modelo)
        {
            try
            {
                _dbContext.Usuarios.Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(Usuario modelo)
        {
            try
            {
                _dbContext.Usuarios.Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
