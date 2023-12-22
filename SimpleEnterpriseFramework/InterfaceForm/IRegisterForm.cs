using System;

namespace SimpleEnterpriseFramework.InterfaceForm
{
    public interface IRegisterForm
    {
        event EventHandler RegisterClicked;

        void ShowForm();
        void HideForm();
    }
}
