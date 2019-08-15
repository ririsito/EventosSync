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

            List<Eventos> Lista = new List<Eventos>();

            List<EventosComedor> ListaC = new List<EventosComedor>();

            Lista = eventos.Get(DateTime.Now.Day).Even.ToList();
            ListaC = eventos.Get(DateTime.Now.Day).EvenComedor.ToList();

            List<Eventos> Listaderef = (from m in Lista
                                        orderby m.Hora
                                        select m).ToList();

            List<EventosComedor> Listaderefc = (from m in ListaC
                                        orderby m.Hora
                                        select m).ToList();

            foreach (Eventos evento in Listaderef)
            {

                var context = new PermisosQCTTContext();

                if (ValueExists(evento.Hora, evento.Id) == false)
                {
                    var count = context.Eventos
                        .Where(o => o.IdEmpleado == evento.Id && o.Fecha==evento.Fecha)
                        .Count();

                  

                    if (((count+1) % 2) == 0 )
                    {
                        Console.WriteLine(evento.Id + " " + evento.Hora + " " + evento.Fecha+ " Salida");
                        context.Add(new Eventos { IdEmpleado = evento.Id, Fecha = evento.Fecha.ToString(), Hora = evento.Hora.ToString(), Tevento = "Salida" });
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine(evento.Id + " " + evento.Hora + " " + evento.Fecha+ " Entrada");
                        context.Add(new Eventos { IdEmpleado = evento.Id, Fecha = evento.Fecha.ToString(), Hora = evento.Hora.ToString(), Tevento = "Entrada" });
                        context.SaveChanges();
                    }                 
                }
                else
                {                
                     Console.WriteLine(evento.Id + " " + evento.Hora + " " + evento.Fecha+ " Repetido Evento  Normal");
                }
               
            }

            foreach (EventosComedor evento in Listaderefc)
            {

                var context = new PermisosQCTTContext();

                if (ValueExistsC(evento.Hora, evento.Id) == false)
                {
                    var count = context.EventosComedor
                        .Where(o => o.IdEmpleado == evento.IdEmpleado && o.Fecha == evento.Fecha)
                        .Count();

                  

                    if (((count + 1) % 2) == 0)
                    {
                        Console.WriteLine(evento.Id + " " + evento.Hora + " " + evento.Fecha + " Salida Comedor");


                        context.EventosComedor.Add(new EventosComedor { IdEmpleado = evento.Id.ToString(), Fecha = evento.Fecha.ToString(), Hora = evento.Hora.ToString() });
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine(evento.Id + " " + evento.Hora + " " + evento.Fecha + " Entrada Comedor");
                        context.EventosComedor.Add(new EventosComedor { IdEmpleado = evento.Id.ToString(), Fecha = evento.Fecha.ToString(), Hora = evento.Hora.ToString() });
                        context.SaveChanges();
                    }
                }
                else
                {
                    Console.WriteLine(evento.Id + " " + evento.Hora + " " + evento.Fecha + " Repetido Evento Comedor");
                }

            }

            //Console.ReadKey();
        }

        private static bool  ValueExists(string _Value,int idemp)
        {
            var context = new PermisosQCTTContext();
            return context.Eventos.Any(x => x.Hora.Equals(_Value)&&x.IdEmpleado.Equals(idemp)); //Reducir el ámbito del contexto
        }


        //private static bool EntradaSAlida(string _Value, int idemp)
        //{
        //    var context = new PermisosQCTTContext();
        //    return context.Eventos.Any(x => x.Hora.Equals(_Value) && x.IdEmpleado.Equals(idemp)); //Reducir el ámbito del contexto
        //}

        private static bool ValueExistsC(string _Value, int idemp)
        {
            var context = new PermisosQCTTContext();
            return context.EventosComedor.Any(x => x.Hora == _Value && x.IdEmpleado == idemp.ToString()); //Reducir el ámbito del contexto
        }


    }
}
