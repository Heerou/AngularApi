using BackEndApi.Models;
namespace BackEndApi.Services.Contrato
{
    public interface IPersonaService
    {
        Task<List<Persona>> GetList();
        Task<Persona> GetById(int idPersona);
        Task<Persona> Add(Persona modelo);
        Task<bool> Update(Persona modelo);
        Task<bool> Delete(Persona modelo);
    }
}
