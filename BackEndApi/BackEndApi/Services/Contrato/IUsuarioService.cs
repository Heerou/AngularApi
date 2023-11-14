using BackEndApi.Models;
namespace BackEndApi.Services.Contrato
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetList();
        Task<Usuario> GetById(int idUsuario);
        Task<Usuario> Add(Usuario modelo);
        Task<bool> Update(Usuario modelo);
        Task<bool> Delete(Usuario modelo);
    }
}
