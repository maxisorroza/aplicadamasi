using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicada
{
    public class Cantidad
    {

        #region Atributos
        private int Codigo;
        private int Cantidade;
        #endregion

        #region constructor
        public Cantidad(int codigo, int cantidad)
        {
            this.Codigo = codigo;
            this.Cantidade = cantidad;

        }
        public Cantidad()
        {
            this.Codigo = 0;
            this.Cantidade = 0;

        }
        #endregion

        #region Propiedades
        public int codigo
        {
            get
            {
                return this.Codigo;
            }
            set
            {
                this.Codigo = value;
            }
        }

        public int cantidade
        {
            get
            {
                return this.Cantidade;
            }
            set
            {
                this.Cantidade = value;
            }
        }
        #endregion




    }
}