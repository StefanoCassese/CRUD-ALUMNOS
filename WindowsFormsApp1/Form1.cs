using RegistroDeAlumnos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refressPantalla();
            textId.Enabled = false; //para que se pueda modificar todos los datos menos el ID

        }

        public void refressPantalla()
        {
            dataGridView1.DataSource = AlumnoDAL.PresentarRegistro();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.nombre = textNombre.Text;
            alumno.edad = Convert.ToInt32(textEdad.Text);
            alumno.curso = textCurso.Text;
            alumno.direccion = textDomicilio.Text;

            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

                if (id != null)
                {
                    alumno.id = id;
                    int result = AlumnoDAL.ModificarAlumno(alumno);

                    if (result > 0)
                    {
                        MessageBox.Show("Modificado exitosamente");
                    }
                    else
                    {
                        MessageBox.Show("Error al intentar modificar los datos");
                    }

                }
            }
            else
            {
                int result = AlumnoDAL.AgregarAlumno(alumno);

                if (result > 0)
                {
                    MessageBox.Show("Guardado exitosamente");
                }
                else
                {
                    MessageBox.Show("Error al intentar agregar los datos");
                }

            }

            refressPantalla();
        }
    
            
    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textId.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id"].Value);
            textNombre.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
            textEdad.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["edad"].Value);
            textDomicilio.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["direccion"].Value);
            textCurso.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["curso"].Value);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textId.Clear();
            textNombre.Clear();
            textEdad.Clear();
            textDomicilio.Clear();
            textCurso.Clear();
            dataGridView1.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)

        {
            if (dataGridView1.SelectedRows.Count == 1)
            {

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                int resultado = AlumnoDAL.EliminarAlumno(id);
                if (resultado > 0)
                {
                    MessageBox.Show("Eliminado correctamente");
                }
                else
                {
                    MessageBox.Show("Error al eliminar");
                }
            
            }
            refressPantalla();
        }
    }

}
