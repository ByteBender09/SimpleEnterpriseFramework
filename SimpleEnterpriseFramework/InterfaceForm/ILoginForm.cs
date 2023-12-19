using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnterpriseFramework.InterfaceForm
{
    public interface ILoginForm
    {
        event EventHandler LoginClicked;

        void ShowForm();
        void HideForm();
        void ShowError(string errorMessage);
        string GetUsername();
        string GetPassword();
        void ClearUsername();
        void ClearPassword();
        void SetTables(List<string> tables);
    }
}
