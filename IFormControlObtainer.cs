namespace DabRadio
{
    using System.Windows.Forms;

    public interface IFormControlObtainer
    {
        Control GetControl(Form form, string controlName);
    }
}