using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;


namespace AplicacionConsolaEventos
{
    class Program
    {
        public static zkemkeeper.CZKEM axCZKEM1 = new zkemkeeper.CZKEM();
        static void Main(string[] args)
        {

            Llenadobasededatos();
            //Console.ReadLine();
        }

      

        private static void  Llenadobasededatos()
        {
            GetEventos eventos = new GetEventos();


            String fecha = DateTime.Now.ToString("d/M/yyyy");

            List<List<Eventos>> ListaPadre = new List<List<Eventos>>();

            List<Eventos> Lista = new List<Eventos>();
            List<Eventos> ListaC = new List<Eventos>();

            ListaPadre = eventos.GetListas(DateTime.Now.Day,DateTime.Now.Month, DateTime.Now.Year).ToList();

            Lista = ListaPadre.First();
            ListaC = ListaPadre.Last();

            List<Eventos> Listaderef = (from m in Lista
                                        orderby m.Hora
                                        select m).ToList();

            List<Eventos> Listaderefc = (from m in ListaC
                                        orderby m.Hora
                                        select m).ToList();

            
            var list=GEtEventos(fecha);

            foreach (Eventos evento in Listaderef)
            {

                var context = new PermisosQCTTContext();

                if (ValueExists(evento.Hora, evento.IdEmpleado, fecha,list) == false)
                {
                    var count = list
                        .Where(o => o.IdEmpleado.Equals(evento.IdEmpleado) && o.Fecha==evento.Fecha)
                        .Count();

                  

                    if (((count+1) % 2) == 0 )
                    {
                        Console.WriteLine(evento.IdEmpleado + " " + evento.Hora + " " + evento.Fecha+ " Salida");
                        context.Add(new Eventos { IdEmpleado = evento.IdEmpleado.ToString(), Fecha = evento.Fecha.ToString(), Hora = evento.Hora.ToString(), Tevento = "Salida" });
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine(evento.IdEmpleado + " " + evento.Hora + " " + evento.Fecha+ " Entrada");
                        context.Add(new Eventos { IdEmpleado = evento.IdEmpleado.ToString(), Fecha = evento.Fecha.ToString(), Hora = evento.Hora.ToString(), Tevento = "Entrada" });
                        context.SaveChanges();
                    }                 
                }
                else
                {                
                     Console.WriteLine(evento.IdEmpleado + " " + evento.Hora + " " + evento.Fecha+ " Repetido Evento  Normal");
                }
               
            }

            if (Listaderefc.Count > 0) {
            foreach (Eventos evento in Listaderefc)
            {

                var context = new PermisosQCTTContext();

                if (ValueExistsC(evento.Hora, evento.Id, fecha) == false)
                {
                    var count = context.EventosComedor
                        .Where(o => o.IdEmpleado == evento.IdEmpleado && o.Fecha == evento.Fecha)
                        .Count();

                  

                    if (((count + 1) % 2) == 0)
                    {
                        Console.WriteLine(evento.IdEmpleado + " " + evento.Hora + " " + evento.Fecha + " Salida Comedor");


                        context.EventosComedor.Add(new EventosComedor { IdEmpleado = evento.IdEmpleado.ToString(), Fecha = evento.Fecha.ToString(), Hora = evento.Hora.ToString() });
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine(evento.IdEmpleado + " " + evento.Hora + " " + evento.Fecha + " Entrada Comedor");
                        context.EventosComedor.Add(new EventosComedor { IdEmpleado = evento.IdEmpleado.ToString(), Fecha = evento.Fecha.ToString(), Hora = evento.Hora.ToString() });
                        context.SaveChanges();
                    }
                }
                else
                {
                    Console.WriteLine(evento.IdEmpleado + " " + evento.Hora + " " + evento.Fecha + " Repetido Evento Comedor");
                }

            }
            }
            //Console.ReadKey();
        }

        private static bool  ValueExists(string _Value,string idemp, string fecha,List<Eventos> listae)
        {
     
            return listae.Any(x => x.Hora.Equals(_Value)&&x.IdEmpleado.Equals(idemp)&&x.Fecha==fecha); //Reducir el ámbito del contexto
        }

        static public List<Eventos> GEtEventos(string fecha)
        {
            var context = new PermisosQCTTContext();
            var list =  context.Eventos.Where(x =>x.Fecha == fecha).ToList(); //Reducir el ámbito del contexto

            return list;
        }



        private static bool ValueExistsC(string _Value, int idemp, string fecha)
        {
            var context = new PermisosQCTTContext();
            return context.EventosComedor.Any(x => x.Hora == _Value && x.IdEmpleado == idemp.ToString()&& x.Fecha == fecha); //Reducir el ámbito del contexto
        }


    }
}
