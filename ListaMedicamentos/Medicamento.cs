﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaMedicamentos
{
    public class Medicamento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }

        public double MontoInvertido
        {
            get { return Cantidad * PrecioUnitario; }
        }

        public Medicamento(int codigo, string nombre, int cantidad, double precioUnitario)
        {
            Codigo = codigo;
            Nombre = nombre;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }
}
