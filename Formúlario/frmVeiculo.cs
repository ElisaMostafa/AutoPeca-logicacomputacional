using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPeca
{
    public partial class frmVeiculo : Form
    {
        private VO.Veiculo vo;
        private List<VO.Veiculo> lista;

        public frmVeiculo()
        {
            InitializeComponent();
            InicializarVeiculos();
            vo = new VO.Veiculo();
            lista = new List<VO.Veiculo>();
            liberarEdicao(false);
            Carregar();
        }

        private void InicializarVeiculos()
        {
            vo = new VO.Veiculo();
            if (DAO.DAO.listaveiculo == null)
            {
                DAO.DAO.listaveiculo = new List<VO.Veiculo>();
            }
            lista = new List<VO.Veiculo>();
        }

        private void interfaceToObject()
        {
            vo.ano = int.Parse(txtAno.Text);
            vo.codigo = int.Parse(txtCodigo.Text);
            vo.modelo = txtModelo.Text;
            vo.potencia = txtPotencia.Text;
            vo.fabricante = cmbFabricante.SelectedItem.ToString();
        }

        private void Limpar()
        {
            txtCodigo.Text = "";
            txtModelo.Text = "";
            txtAno.Text = "";
            txtPotencia.Text = "";
            cmbFabricante.SelectedIndex = -1;
        }

        private void Carregar()
        {
            lstVeiculos.DataSource = null;
            lstVeiculos.DataSource = lista;
            lstVeiculos.SelectedIndex = -1;
            lstVeiculos.ValueMember = "codigo";
            lstVeiculos.DisplayMember = "modelo";
            lstVeiculos.Refresh();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
            liberarEdicao(false);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                vo = new VO.Veiculo();
                interfaceToObject();
                lista.Add(vo);
                Limpar();
                Carregar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro no Aplicativo");
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            vo = ((VO.Veiculo)lstVeiculos.Items[lstVeiculos.SelectedIndex]);
            objecttoInterface();
            liberarEdicao(true);
        }

        private void objecttoInterface()
        {
            txtCodigo.Text = vo.codigo.ToString();
            txtModelo.Text = vo.modelo.ToString();
            txtAno.Text = vo.ano.ToString();
            txtPotencia.Text = vo.potencia.ToString();
            cmbFabricante.SelectedItem = vo.fabricante.ToString();
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            lista.RemoveAt(lstVeiculos.SelectedIndex);
            Carregar();
        }

        private void btnPagina_Click(object sender, EventArgs e)
        {
            AutoPeca.Formúlario.Fabricante  tela = new AutoPeca.Formúlario.Fabricante();
            tela.Show();
        }

        private void lstVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
