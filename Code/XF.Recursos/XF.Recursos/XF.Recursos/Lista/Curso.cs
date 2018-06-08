using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Recursos.Lista
{
    public class Curso
    {
        public string Titulo { get; set; }
        public string Unidade { get; set; }

        public static List<Curso> GetListaDeCursos()
        {
            var lista = new List<Curso>();
            lista.Add(new Curso()
            {
                Titulo = "Desenvolvimento de aplicativos com Xamarin",
                Unidade = "FIAP Aclimação"
            });
            lista.Add(new Curso() { Titulo = "Introdução a Big Data & Analytics", Unidade = "FIAP Paulista" });
            lista.Add(new Curso() { Titulo = "Certificação TOGAF Nível 1", Unidade = "FIAP Aclimação" });

            return lista;
        }
    }
}
