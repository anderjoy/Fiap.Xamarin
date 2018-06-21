using XF.Contatos.Model;

namespace XF.Contatos.API
{
    public interface ILocalizacao
    {
        void GetCoordenada();

        void GoToCoordenada(Coordenada coordenada);
    }
}
