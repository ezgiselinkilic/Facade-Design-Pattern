using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
   public class FormControl
    {
        public static ReceteForm _receteForm;
        public static void CreateReceteForm()
        {
            if (_receteForm == null || _receteForm.IsDisposed)
                _receteForm = new ReceteForm();
            _receteForm.Show();
        }
    }
}
