using System;

namespace PortalCidadao.Shared.Extensions
{
    public static class IntExtensions
    {
        public static T GetEnum<T>(this int n)
        {
            if (!Enum.IsDefined(typeof(T), n))
                throw new ArgumentOutOfRangeException(typeof(T).ToString(), "Valor de enum não encontrado");

            return (T)Enum.ToObject(typeof(T), n);
        }

        public static string ConverterHora(this int hora)
        {
            var horaFormatada = hora.ToString().PadLeft(2, '0');
            return $"{horaFormatada}:00-{horaFormatada}:59";
        }
    }
}
