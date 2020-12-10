using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsolaEventos
{
    class GetEventos
    {
      
        public zkemkeeper.CZKEM axCZKEM1 = new zkemkeeper.CZKEM();
        public zkemkeeper.CZKEM axCZKEM2 = new zkemkeeper.CZKEM();
        public zkemkeeper.CZKEM axCZKEM3 = new zkemkeeper.CZKEM();
        public zkemkeeper.CZKEM axCZKEM4 = new zkemkeeper.CZKEM();

        private bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private bool bIsConnected2 = false;
        private bool bIsConnected3 = false;
        private bool bIsConnected4 = false;

        private int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.
        public string idwEnrollNumber;
        private int idwVerifyMode;
        private int idwInOutMode;
        private int idwYear;
        private int idwMonth;
        public int idwDay;
        public int idwHour;
        public int idwMinute;
        public int idwSecond;
        public int idwWorkCode;

        public List<List<Eventos>> GetListas(int dia,int mes, int año)
        {

            List<List<Eventos>> ListaPadre = new List<List<Eventos>>();
            List<Eventos> ListaE = new List<Eventos>();
            List<Eventos> ListaC = new List<Eventos>();

            if (conectar())
            {
                
                while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out idwEnrollNumber, out idwVerifyMode
                         , out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkCode))//get records from the memory
                    {
                        if (idwDay == dia && idwMonth== mes && idwYear == año)
                        {
                            var obj = new Eventos()
                            {
                                IdEmpleado = idwEnrollNumber,
                                Hora = idwHour + ":" + idwMinute + ":" + idwSecond,
                                Fecha = idwDay + "/" + idwMonth + "/" + idwYear

                            };

                        ListaE.Add(obj);
                        }

                    }

                while (axCZKEM2.SSR_GetGeneralLogData(iMachineNumber, out idwEnrollNumber, out idwVerifyMode
                     , out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkCode))//get records from the memory
                {
                    if (idwDay == dia && idwMonth == mes && idwYear == año)
                    {
                        var obj = new Eventos()
                        {
                            IdEmpleado = idwEnrollNumber,
                            Hora = idwHour + ":" + idwMinute + ":" + idwSecond,
                            Fecha = idwDay + "/" + idwMonth + "/" + idwYear

                        };

                        ListaE.Add(obj);
                    }

                }

                while (axCZKEM3.SSR_GetGeneralLogData(iMachineNumber, out idwEnrollNumber, out idwVerifyMode
                         , out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkCode))//get records from the memory
                {
                    if (idwDay == dia && idwMonth == mes && idwYear == año)
                    {
                        var obj = new Eventos()
                        {
                            IdEmpleado = idwEnrollNumber,
                            Hora = idwHour + ":" + idwMinute + ":" + idwSecond,
                            Fecha = idwDay + "/" + idwMonth + "/" + idwYear

                        };

                        ListaE.Add(obj);
                    }

                }

                while (axCZKEM4.SSR_GetGeneralLogData(iMachineNumber, out idwEnrollNumber, out idwVerifyMode
                  , out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkCode))//get records from the memory
                {
                    if (idwDay == dia && idwMonth == mes && idwYear == año)
                    {
                        var obj = new Eventos()
                        {
                            IdEmpleado = idwEnrollNumber,
                            Hora = idwHour + ":" + idwMinute + ":" + idwSecond,
                            Fecha = idwDay + "/" + idwMonth + "/" + idwYear

                        };

                        ListaC.Add(obj);
                    }

                }

                //IEnumerable<Eventos> evento = Lista;

                ListaPadre.Add(ListaE);
                ListaPadre.Add(ListaC);

                return ListaPadre;
                
            }

            else
            {
                //Error al leer maquina
            }

            return null;
        }


        private bool conectar()
        {
            //Create Standalone SDK class dynamicly.
            int idwErrorCode = 0;

            bIsConnected = axCZKEM1.Connect_Net("172.19.7.21", 4370);
            bIsConnected2 = axCZKEM2.Connect_Net("172.19.7.20", 4370);
            bIsConnected3 = axCZKEM3.Connect_Net("172.19.7.24", 4370);
            bIsConnected4 = axCZKEM4.Connect_Net("172.19.7.22", 4370);

            if (bIsConnected == true)
            {
                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                //axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                return true;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                return false;
            }
        }

    }

}

