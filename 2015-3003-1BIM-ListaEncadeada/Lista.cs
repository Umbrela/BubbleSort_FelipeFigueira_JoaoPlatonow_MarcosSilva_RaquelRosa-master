using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _2015_3003_1BIM_ListaEncadeada
{
    class Lista
    {
        private Elemento primeiro;
        public float tempo;
        public Elemento Primeiro
        {
            get
            {
                return primeiro;
            }
            set
            {
                primeiro = value;
            }
        }

        public Elemento Ultimo
        {
            get
            {
                return BuscaUltimo();
            }
        }

        public Lista()
        {
            
        }

        public void Adiciona(Elemento e)
        {
            if (Primeiro == null)
            {
                Primeiro = e;
            }
            else
            {
                Ultimo.Proximo = e;
            }
        }

        public Elemento BuscaUltimo()
        {
            Elemento current = Primeiro;
            while (current.Proximo != null)
            {
                current = current.Proximo;
            }
            return current;
        }

        public void RemoveTodos()
        {
            Elemento current = Primeiro;
            while (current.Proximo != null)
            {
                Elemento prox = current.Proximo;
                current.Valor = 0;
                current.Proximo = null;
                current.Anterior = null;
                current = prox;
            }
        }

        public int Count
        {
            get {
                int count = 1;
                Elemento current = Primeiro;
                while (current != null)

                {
                    current = current.Proximo;
                    count++;
                }
                return count;
            }
        }

        public void ImprimeLista()
        {
            Elemento current = Primeiro;
            while (current != null)
            {
                Debug.WriteLine(current.AsString);
                current = current.Proximo;
            } 
        }

        public Elemento pegarPosicao(int pos)
        {
            Elemento current = Primeiro;
            for (int i = 0; i < pos; i++)
            {
                current = current.Proximo;
            }
            return current;
        }

        public Elemento pegarValor(int valor)
        {
            Elemento current = Primeiro;
            while (current.Valor != valor && current.Proximo != null)
            {
                current = current.Proximo;
            }
            return current;
        }

        public void BSort()
        {
            tempo = 0;
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count - 1; j++)
                {
                    tempo++;
                    if (pegarPosicao(i).Valor > pegarPosicao(j).Valor)
                    {
                        int temp = pegarPosicao(i).Valor;
                        pegarPosicao(i).Valor = pegarPosicao(j).Valor;
                        pegarPosicao(j).Valor = temp;
                    }
                }
            }
        }
    }
}
