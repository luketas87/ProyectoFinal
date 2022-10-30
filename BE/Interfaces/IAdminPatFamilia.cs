using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace BE.Interfaces
{
    public interface IAdminPatFamilia
    {
        bool FamiliaNueva { get; set; }

        void AsignarPatente(int IdFamilia, int IdPatente);

        void BorrarPatente(int IdFamilia, int IdPatente);

        void Show(); DialogResult ShowDialog();
     }
}
