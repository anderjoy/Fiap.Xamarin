using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace XF.Recursos.Lista
{
    public class ColecaoDeCores
    {
        private ColecaoDeCores() { }

        public string Nome { private set; get; }
        public string Descricao { private set; get; }
        public Color Cor { private set; get; }
        public string RgbDisplay { private set; get; }

        static ColecaoDeCores()
        {
            List<ColecaoDeCores> todos = new List<ColecaoDeCores>();
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in typeof(Color).GetRuntimeFields())
            {
                if (item.IsPublic &&
                    item.IsStatic &&
                    item.FieldType == typeof(Color))
                {
                    string name = item.Name;
                    stringBuilder.Clear();
                    int index = 0;
                    foreach (char itemChar in name)
                    {
                        if (index != 0 && Char.IsUpper(itemChar))
                        {
                            stringBuilder.Append(' ');
                        }
                        stringBuilder.Append(itemChar);
                        index++;
                    }

                    Color cor = (Color)item.GetValue(null);
                    ColecaoDeCores namedColor = new ColecaoDeCores
                    {
                        Nome = name,
                        Descricao = stringBuilder.ToString(),
                        Cor = cor,
                        RgbDisplay = String.Format("{0:X2}-{1:X2}-{2:X2}",
                                                   (int)(255 * cor.R),
                                                   (int)(255 * cor.G),
                                                   (int)(255 * cor.B))
                    };
                    todos.Add(namedColor);
                }
            }
            todos.TrimExcess();
            ResultadoCores = todos;
        }
        public static IList<ColecaoDeCores> ResultadoCores { private set; get; }
    }
}
