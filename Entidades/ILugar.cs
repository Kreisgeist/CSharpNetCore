namespace CoreEscuela.Entidades
{
    public interface ILugar //inicia por I para denotar que es una interfaz
    {
        string Dirección { get; set; }
        void LimpiarLugar();
    }
}