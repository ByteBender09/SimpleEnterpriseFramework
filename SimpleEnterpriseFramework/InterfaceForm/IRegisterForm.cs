using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnterpriseFramework.InterfaceForm
{
    public interface IRegisterForm
    {
        event EventHandler RegisterClicked;

        void ShowForm();
        void HideForm();
    }
}
