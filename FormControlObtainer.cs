namespace DabRadio
{
    using System.Windows.Forms;

    public class FormControlObtainer : IFormControlObtainer
    {
        public Control GetControl(Form form, string controlName)
        {
            foreach (Control formControl in form.Controls)
            {
                if (formControl.Name == controlName)
                {
                    return formControl;
                }
            }

            throw new ControlNotFoundException($"Form control, {controlName}");
        }
    }
}