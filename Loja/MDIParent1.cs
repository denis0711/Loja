using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja
{
    public partial class MDIParent1 : Form
    {
        

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Chamada do Form Cadastro_usuario no formato de MDI,
             ou seja para abrir dentro do Form Princiapal (MDI)
            Chama-se janela Filha. (CHildFrom), fica dentro da janela Mae*/

            Form childForm = new Cadastro_usuario();
            childForm.MdiParent = this;
            childForm.Show();

        }
    }
}
