using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PROPIEDADES_INMOBILIARIAS.Forms;


namespace PROPIEDADES_INMOBILIARIAS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = new Forms.LoginForm();
            Application.Run(loginForm);
        }
    }
}
