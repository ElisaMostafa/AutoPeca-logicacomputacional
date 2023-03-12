using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPeca.Formúlario
{
    public partial class Fabricante : Form
    {
        private VO.Fabricante vo;
        private List<VO.Fabricante> lista;
        public Fabricante()
        {
            InicializarFabricante();
            InitializeComponent();
            vo = new VO.Fabricante();
            lista = new List<VO.Fabricante>();
            liberarEdicao(false);
            Carregar();
        }

        private void InicializarFabricante()
        {
            vo = new VO.Fabricante();
            if (DAO.DAO.listafabricante == null)
            {
                DAO.DAO.listafabricante = new List<VO.Fabricante>();
            }
            lista = new List<VO.Fabricante>();
        }

        private void Limpar()
        {
            txtCodigo.Text = "";
            txtDescricao.Text = "";
            cmbNome.SelectedIndex = -1;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Carregar()
        {
            lstFabricante.DataSource = null;
            lstFabricante.DataSource = lista;
            lstFabricante.SelectedIndex = -1;
            lstFabricante.ValueMember = "codigo";
            lstFabricante.DisplayMember = "descrição";
            lstFabricante.Refresh();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                vo = new VO.Fabricante();
                Limpar();
                Carregar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro no Aplicativo");
            }
        }

        private void interfaceToObject()
        {
            vo.codigo = int.Parse(txtCodigo.Text);
            vo.descrição = txtDescricao.Text;
            vo.nome = cmbNome.SelectedItem.ToString();
        }

        private void liberarEdicao(bool habilita)
        {
            btnGravar.Enabled = !habilita;
            btnEditar.Enabled = habilita;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            interfaceToObject();
            Carregar();
        }
        
        private void objecttoInterface()
        {
            txtCodigo.Text = vo.codigo.ToString();
            txtDescricao.Text = vo.descrição.ToString();
            cmbNome.SelectedItem = vo.nome.ToString();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            vo = ((VO.Fabricante)lstFabricante.Items[lstFabricante.SelectedIndex]);
            objecttoInterface();
            liberarEdicao(true);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            lista.RemoveAt(lstFabricante.SelectedIndex);
            Carregar();
        }

        private void lstFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
