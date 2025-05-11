using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbProject
{
    internal class OpenForm
    {
        public void openForm(Form currentForm, Form newForm)
        {
            newForm.Size = currentForm.Size;
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = currentForm.Location;
            newForm.Show();
            currentForm.Hide();
        }
    }
}
