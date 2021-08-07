using System;
using System.IO;

namespace Hackaton_DAVH___AFPE
{
    class Program
    {
        static void Main(string[] args)
        {
            bool reinicio = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Listado de opciones: \n");
                Console.WriteLine("1 - Laberinto");
                Console.WriteLine("2 - Impresora de puntos");
                Console.WriteLine("3 - Calculadora de ecuaciones cuadráticas");
                Console.WriteLine("4 - Triángulo de Pascal");
                Console.WriteLine("\nSeleccione el número del problema:");
                switch(Console.ReadLine())
                {
                    case "1":
                        E1:
                        Console.Clear();
                        Console.WriteLine("Escriba la ubicación exacta del archivo que desea leer (Solo se acpetan archivos tipo csv)");
                        string path1 = Console.ReadLine();
                        if(path1.EndsWith(".csv"))
                        {
                            try
                            {
                                string[,] mapa = new string[20, 20];
                                StreamReader reader = new StreamReader(path1);
                                string contenido = reader.ReadToEnd();
                                string[] lineas = contenido.Split("\n");
                                int cont = 0;
                                if(lineas.Length == 20)
                                {
                                    for(int i = 19; i >= 0; i--)
                                    {
                                        string[] celdas = lineas[i].Split(";");
                                        if (celdas.Length == 20)
                                        {
                                            for (int j = 0; j < 20; j++)
                                            {
                                                mapa[cont, j] = celdas[j];
                                            }
                                            cont++;
                                        }
                                        else
                                        {
                                            Console.WriteLine("El archivo inválido");
                                            reader.Close();
                                            goto E1;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("El archivo inválido");
                                    reader.Close();
                                    goto E1;
                                }
                                reader.Close();

                                string recorrido = "0,0;";
                                int posx = 0;
                                int posy = 0;
                                if(mapa[0,0] != "*" && mapa[19,19] != "*")
                                {
                                    while(posx != 19 && posy != 19)
                                    {
                                        if(mapa[posx, posy + 1] == "*")
                                        {
                                            posx++;
                                            recorrido += posx + "," + posy + ";";
                                        }
                                        else if(mapa[posx + 1, posy] == "*")
                                        {
                                            posy++;
                                            recorrido += posx + "," + posy + ";";
                                        }
                                        else
                                        {
                                            posx++;
                                            recorrido += posx + "," + posy + ";";
                                        }
                                    }
                                    Console.WriteLine("Esta es la solución:");
                                    string[] pasos = recorrido.Split(";");
                                    foreach(string paso in pasos)
                                    {
                                        Console.WriteLine(paso);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Mapa inválido, los puntos de inicio y/o final estan bloqueados");
                                    reader.Close();
                                    goto E1;
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tipo de archivo o path incorrecto");
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Escriba la ubicación exacta del archivo que desea leer (Solo se acpetan archivos tipo csv)");
                        string path2 = Console.ReadLine();
                        try
                        {
                            StreamReader reader = new StreamReader(path2);
                            string content1 = reader.ReadToEnd();
                            string resultt = "";
                            string[] lines = content1.Split('\n');
                            string figura;
                            Console.WriteLine("\nEl archivo contiene las siguientes figuras:\n");
                            for (int i = 0; i < lines.Length; i++)
                            {
                                figura = lines[i];
                                string[] arregloFig = figura.Split(';');
                                int fig = Convert.ToInt32(arregloFig[0]);
                                switch (fig)
                                {
                                    case 1:
                                        int cont = 1;
                                        for (int j = 0; j < Convert.ToInt32(arregloFig[1]); j++)
                                        {
                                            for (int x = 0; x < cont; x++)
                                            {
                                                Console.Write("*");
                                            }
                                            Console.Write("\n");
                                            cont++;
                                        }
                                        Console.Write("\n");
                                        break;
                                    case 2:
                                        int baseP = Convert.ToInt32(arregloFig[1]);
                                        int cant = 0;
                                        if(baseP % 2 != 0)
                                        {
                                            int posicion = baseP / 2;
                                            for(int y = 0; y < (baseP / 2 + 1); y++)
                                            {
                                                cant = 1 + 2 * y;
                                                for(int x = 0; x < posicion; x++)
                                                {
                                                    Console.Write(" ");
                                                }
                                                posicion--;
                                                for(int z = 0; z < cant; z++)
                                                {
                                                    Console.Write("*");
                                                }
                                                Console.Write("\n");
                                            }
                                            Console.Write("\n");

                                        }
                                        else
                                        {
                                            Console.WriteLine("\nEl número de la base debe de ser impar\n");
                                        }
                                        break;
                                    case 3:
                                        int largo = Convert.ToInt32(arregloFig[1]);
                                        int cantR = 1;
                                        if (largo % 2 != 0)
                                        {
                                            int posicion = largo / 2;
                                            for (int y = 0; y < largo; y++)
                                            {
                                                for (int x = 0; x < posicion; x++)
                                                {
                                                    Console.Write(" ");
                                                }
                                                for (int z = 0; z < cantR; z++)
                                                {
                                                    Console.Write("*");
                                                }
                                                if (y < (largo / 2))
                                                {
                                                    posicion--;
                                                    cantR = cantR + 2;
                                                }
                                                else
                                                {
                                                    posicion++;
                                                    cantR = cantR - 2;
                                                }
                                                Console.Write("\n");
                                            }
                                            Console.Write("\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nEl número de la base debe de ser impar\n");
                                        }
                                        break;
                                    case 4:
                                        int lado = Convert.ToInt32(arregloFig[1]);
                                        for (int j = 0; j < lado; j++)
                                        {
                                            for(int k = 0; k < lado; k++)
                                            {
                                                Console.Write("*");
                                            }
                                            Console.Write("\n");
                                        }
                                        Console.Write("\n");
                                        break;

                                }

                            }
                            reader.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Ingrese los coeficientes de los terminos separados por comas:");
                        string entrada = Console.ReadLine();
                        string[] terminos = entrada.Split(",");
                        int a, b, c;
                        if(terminos.Length == 3)
                        {
                            if(int.TryParse(terminos[0], out a) && int.TryParse(terminos[1], out b) && int.TryParse(terminos[2], out c))
                            {
                                double result1 = 0, result2 = 0;
                                try
                                {
                                    result1 = ( - b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / 2 * a;
                                    Console.WriteLine("Solución 1: " + result1);
                                }
                                catch
                                {
                                    Console.WriteLine("Solución 1 no exite.");
                                }
                                try
                                {
                                    result2 = (-b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / 2 * a;
                                    Console.WriteLine("Solución 1: " + result2);
                                }
                                catch
                                {
                                    Console.WriteLine("Solución 2 no exite.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Formato de los términos incorrecto");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cantidad de términos incorrecta");
                        }
                        break;
                    case "4":
                        Console.Clear();
                        int[,] TMatriz;
                        Console.WriteLine("Ingrese la altura deseada para el triangulo de pascal");
                        int altura = Convert.ToInt32(Console.ReadLine());
                        if(altura > 0)
                        {
                            TMatriz = new int[altura, altura];
                            for (int i = 0; i < altura; i++)
                            {
                                TMatriz[i, 0] = 1;
                            }
                            for (int i = 1; i < altura; i++)
                            {
                                for (int j = 1; j < i + 1; j++)
                                {
                                    TMatriz[i, j] = TMatriz[i - 1, j] + TMatriz[i - 1, j - 1];
                                }
                            }
                            for (int i = 0; i < altura; i++)
                            {
                                for (int j = 0; j < altura; j++)
                                {
                                    if(TMatriz[i,j] != 0)
                                    {
                                        Console.Write(TMatriz[i, j] + "\t");
                                    }
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tamaño inválido");
                        }
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta, intentelo de nuevo.");
                        reinicio = true;
                        break;
                }
                Console.ReadLine();
                if (!reinicio)
                {
                    continuar:
                    Console.WriteLine("Desea volver al menú? (S/N)");
                    if(Console.ReadLine() == "S")
                    {
                        reinicio = true;
                        Console.Clear();
                    }
                    else if(Console.ReadLine() != "N")
                    {
                        goto continuar;
                    }
                }
            } while (reinicio);





        }
    }
}
