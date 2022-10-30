using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Interfaces
{
    public interface IDigitoVerificador
    {
        List<string> Entidades { get; set; }

        int CalcularDVHorizontal(List<string> columnasString);

        void InsertarDVVertical(string entidad);

        void ActualizarDVVertical(string entidad);

        bool ComprobarPrimerDigito(string entidad);

        bool ComprobarIntegridad();
    }
}
