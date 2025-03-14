﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Utilitarios
{
    public static class MetodosExtensao
    {
        public static bool ValidarCPF(this string vrCPF)
        {
            string valor = vrCPF.Replace(".", "").Replace("-", "");

            if (valor.Length != 11) return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
            {
                if (valor[i] != valor[0]) igual = false;
            }

            if (igual || valor == "123456789") return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
            {
                numeros[i] = int.Parse(valor[i].ToString());
            }

            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += (10 - i) * numeros[i];
            }

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0) return false;
            }
            else if (numeros[9] != 11 - resultado)
            {
                return false;
            }

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += (11 - i) * numeros[i];
            }

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0) return false;
            }
            else if (numeros[10] != 11 - resultado)
            {
                return false;
            }

            return true;
        }
    }
}
