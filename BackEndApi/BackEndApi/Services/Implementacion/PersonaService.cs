using Microsoft.EntityFrameworkCore;
using BackEndApi.Models;
using BackEndApi.Services.Contrato;

namespace BackEndApi.Services.Implementacion
{
    public class PersonaService : IPersonaService
    {
        private PruebasContext _dbContext;

        public PersonaService(PruebasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Persona>> GetList()
        {
            try
            {
                List<Persona> lista = new List<Persona>();
                lista = await _dbContext.Personas.ToListAsync();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Persona> GetById(int Persona)
        {
            try
            {
                Persona? persona = new Persona();
                persona = await _dbContext.Personas
                                .Where(e => e.Id == Persona).FirstOrDefaultAsync();

                return persona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Persona> Add(Persona modelo)
        {
            try
            {
                _dbContext.Personas.Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(Persona modelo)
        {
            try
            {
                _dbContext.Personas.Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(Persona modelo)
        {
            try
            {
                _dbContext.Personas.Remove(modelo);
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
