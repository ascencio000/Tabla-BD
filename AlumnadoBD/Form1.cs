using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlumnadoBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Probar_Click(object sender, EventArgs e)
        {
            AlumnadoClase objClase = new AlumnadoClase();
            if (objClase.conectando()) // esto equivale a un true
            {

                MessageBox.Show("Conexión establecida, lo lograste", "Conexión");


            }else
            {
                MessageBox.Show("Conexión fallida, te equivocaste", "Conexión");


            }


        }

        private void Btn_Mostrar_Click(object sender, EventArgs e)
        {
            AlumnadoClase objeto = new AlumnadoClase();
            dataGridView1.DataSource = objeto.mostrar();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
          
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                int suma = 0, asistencia = 0;
                double promedio = 0;

                id = Convert.ToInt32(Txt_ID.Text);
                AlumnadoClase objclasee = new AlumnadoClase();
                List<Perfiles> perfilconid = new List<Perfiles>();
                perfilconid = objclasee.mostrar(id);

                suma = perfilconid[0].Notap1 + perfilconid[0].Notap2 + perfilconid[0].Notap3;
                promedio = Convert.ToDouble(suma) / 3;
                asistencia = perfilconid[0].Asistencia;
                if (promedio >= 6 && asistencia >= 75)
                {
                    Txt_aprobado.Text = "Si";
                    Txt_comple.Text = "No aplica";
                    label2.Text = "Ha cumplido con la asistencia";
                }
                else if (promedio >= 5 && promedio < 6 && asistencia >= 75)
                {

                    Txt_aprobado.Text = "No";
                    Txt_comple.Text = "Si aplica";
                    label2.Text = "Ha cumplido con la asistencia";
                }
                else if (asistencia < 75)
                {

                    Txt_aprobado.Text = "No";
                    Txt_comple.Text = "No aplica";
                    label2.Text = "No ha cumplido con la asistencia";
                }
                else
                {
                    Txt_aprobado.Text = "No";
                    Txt_comple.Text = "No aplica";
                    label2.Text = "Reprobado por promedio";
                }


            }catch (Exception ex){

                MessageBox.Show("Solo se aceptan número, no letras", "Aviso");
                Txt_ID.Clear();
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Txt_ID.Clear();
            Txt_comple.Clear();
            Txt_aprobado.Clear();
            label2.Text = " ";
            Txt_ID.Focus();
        
        }
    }
}
