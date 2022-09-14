using System;
using System.Data;
using System.Windows.Forms;


namespace CRUD_MySQL
{
    public partial class Form1 : Form
    {
        ConexionMySQL obj = new ConexionMySQL();
        string Estado;
        public Form1()
        {
            InitializeComponent();
            LimpiarCampos();
            panel1.Enabled = false;
        }

        private void VerTabla()
        {
            DataSet dsTabla = obj.VerTabla();
            dataGridView1.DataSource = dsTabla.Tables[0];
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            VerTabla();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch(Estado)
            {
                case "Agregar":
                    MessageBox.Show(obj.Agregar(Convert.ToInt32(txtid.Text), txtnombre.Text, txtapellido.Text));
                    break;
                case "Editar":
                    MessageBox.Show(obj.Editar(Convert.ToInt32(txtid.Text), txtnombre.Text, txtapellido.Text));
                    break;
            }
            VerTabla();
            LimpiarCampos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Estado = "Agrear";
            panel1.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                Estado = "Editar";
                panel1.Enabled = true;
                txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtnombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtapellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un registro a editar");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                MessageBox.Show(obj.Eliminar(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString())));
                VerTabla();
            }
            else
            {
                MessageBox.Show("Seleccione un registro a eliminar");
            }
        }

        private void LimpiarCampos()
        {
            txtid.Clear();
            txtnombre.Clear();
            txtapellido.Clear();
            panel1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
