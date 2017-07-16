sing System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tarea2_ProgramacionAvanzadaII
{
    public partial class Form1 : Form
    {
        
        String[] listaTabla1 = new String[100]; // Define el Array Pirncipal
        int[] listaNumeros = new int[60]; // Define el array para el DataGridView de sólo números
        String[] listaLetras = new String[60]; // Define el Array para el DataGridView de sólo Letras
        int indice = 0; // Indice del Array de la tabla principal
        public Form1()
        {
            
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Thread b = new Thread(DatosDeTabla2);
            Thread c = new Thread(DatosDeTabla3);

            b.Start();
            c.Start();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
           
            Thread a = new Thread(  () => DatosDeTabla1(nuevoDato.Text)  );
            a.Start();
           
            

        }

        public void DatosDeTabla1(String valor)
        {

            TablaPrincipal.ColumnCount = 1;
            TablaNumeros.RowCount = 101;

            listaTabla1[indice] = nuevoDato.Text; // Agregamos el dato en el campo nuevoDato (TextBox) cada vez que se presiona el botón
            TablaPrincipal.Rows.Add(listaTabla1[indice]); // Agregamos al DataGridView cada elemento nuevo de la lista 
            indice++;
        }

        public void DatosDeTabla2()
        {

            
           
            TablaNumeros.ColumnCount = 1;
            TablaNumeros.RowCount = 61;
            int j = 0;
            int i = 0;
            int x=0;
            int mayor=0;

            Thread.Sleep(5001);
            for (;i< 10; i++)
            {
                try
                {
                    x = Convert.ToInt32( listaTabla1[i]  ); // Intenta convertir los elementos de la tabla1

                    if (x > mayor)
                    {
                        listaNumeros[j] = x;
                        j++;
                        mayor = x;
                    }
                }
                catch (FormatException e)
                {  }
                
                
            }
            
            for (int m = 0; m < 60; m++)
            {
                TablaNumeros.Rows[m].Cells[0].Value = Convert.ToString(listaNumeros[m]);
            }
            
        }

        public void DatosDeTabla3()
        {

            listaSoloLetras.ColumnCount = 1;
            listaSoloLetras.RowCount = 61;
            int j = 0;
            int i = 0;
            int x = 0;
            Thread.Sleep(5001);
            for (; i < 60; i++)
            {
                try
                {
                    x = Convert.ToInt32(listaTabla1[i]); // Intenta convertir los elementos de la tabla1
                    

                }
                catch (FormatException e)
                {

                    listaLetras[j] = listaTabla1[i];
                    j++;

                }


            }

            for (int m = 0; m < 60; m++)
            {
                listaSoloLetras.Rows[m].Cells[0].Value = Convert.ToString(listaLetras[m]);
            }
        }


        private void nuevoDato_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }// Fin de Form1


}
