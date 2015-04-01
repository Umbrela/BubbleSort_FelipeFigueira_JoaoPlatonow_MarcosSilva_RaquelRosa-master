using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _2015_3003_1BIM_ListaEncadeada
{
    public partial class Form1 : Form
    {
        private Lista lista;
        private float ba;
        public Form1()
        {
            InitializeComponent();
        }

        private void CarregarPrograma(object sender, EventArgs e)
        {
            lista = new Lista();
        }

        private void InicializarLista(object sender, EventArgs e)
        {
            Elemento elemento = new Elemento(lista.Count);
            lista.Adiciona(elemento);
        }

        private void AdicionaElemento(object sender, EventArgs e)
        {
            Random r = new Random();
            //r.Next(1,100) + (2 * DateTime.Now.Second)
            Elemento elemento = new Elemento(lista.Count);
            lista.Adiciona(elemento);
        }

        private void ExibirLista(object sender, EventArgs e)
        {
            lista.ImprimeLista();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int newNumber;
            newNumber = r.Next(1, 100);
            Elemento elemento = new Elemento(newNumber, null, lista.BuscaUltimo());
            lista.BuscaUltimo().Proximo = elemento;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(textBox1.Text) < lista.Count &&
               textBox1.Text != "" && textBox3.Text != "")
            {
                Elemento temp = lista.pegarPosicao(Convert.ToInt32(textBox1.Text) - 2);
                Elemento temp2;
                temp2 = temp.Proximo;
                Elemento elemento = new Elemento(Convert.ToInt32(textBox3.Text), temp2, temp);
                temp.Proximo = elemento;
                if (temp2 != null)
                {
                    temp2.Anterior = elemento;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lista.pegarValor(Convert.ToInt32(textBox2.Text)).Valor != Convert.ToInt32(textBox4.Text))
            {
                Elemento temp = lista.pegarValor(Convert.ToInt32(textBox2.Text) - 1);
                Elemento temp2;
                temp2 = temp.Proximo;
                Elemento elemento = new Elemento(Convert.ToInt32(textBox4.Text), temp2, temp);
                temp.Proximo = elemento;
                if (temp2 != null)
                {
                    temp2.Anterior = elemento;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            lista.BSort();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            label3.Text = "Número de elementos: " + lista.Count;
            label4.Text = "Tempo(Em milisegundos): " + ts.Milliseconds;
            label5.Text = "Número de comparações: " + lista.tempo;
            label6.Text = "Elementos por milisegundo: " + Convert.ToDouble(lista.Count) / ts.Milliseconds;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                Elemento elemento = new Elemento(lista.Count);
                elemento.Valor = r.Next(1, 100);
                lista.Adiciona(elemento);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            //if (lista.))
            //{
                for (var i = 1; i < 400; i++)
                {
                    for (var j = 1; j < i + 5; j++)
                    {
                        Elemento elemento = new Elemento(lista.Count);
                        elemento.Valor = r.Next(1, 100);
                        lista.Adiciona(elemento);
                    }
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    lista.BSort();
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    Console.WriteLine(lista.Count + ";" + ts.Milliseconds);
                    listBox1.Text = lista.Count + ";" + ts.Milliseconds;
                    lista.RemoveTodos();
                }
            //}
        }


    }
}
