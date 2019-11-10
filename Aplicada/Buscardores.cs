using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicada
{
    public class Buscadores
    {
        public cliente ocliente(vehiculo ovehiculo)
        {
            cliente ocliente = new cliente();
            if (ovehiculo.id_cliente != null)
            {



                using (aplicadaBDEntities DBF = new aplicadaBDEntities())
                {

                    ocliente = (from q in DBF.cliente where q.id == ovehiculo.id_cliente select q).FirstOrDefault();



                }
                return ocliente;
            }
            return ocliente;
        }

        public vehiculo buscarvehiculo(string patente)
        {
            vehiculo objvehiculo = new vehiculo();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objvehiculo = (from q in DBF.vehiculo where q.patente == patente select q).FirstOrDefault();



            }
            return objvehiculo;
        }
        public modelo buscarmodelo(vehiculo objvehiculo)
        {
            modelo objmodelo = new modelo();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objmodelo = (from q in DBF.modelo where q.id_modelo == objvehiculo.id_modelo select q).FirstOrDefault();


            }
            return objmodelo;
        }

        public marca buscarmarca(modelo objmodelo)
        {
            marca objmarca = new marca();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objmarca = (from q in DBF.marca where q.id_marca == objmodelo.id_marca select q).FirstOrDefault();


            }
            return objmarca;
        }

        public servicio buscarservicio(int id)
        {
            servicio objserv = new servicio();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objserv = (from q in DBF.servicio where q.id_servicios == id select q).FirstOrDefault();


            }
            return objserv;
        }


        public List<empleado> Lempleado()
        {
            List<empleado> Lempleados = new List<empleado>();

            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {
                IQueryable<empleado> lista = (from q in DBF.empleado select q);
                Lempleados = lista.ToList();

            }
            return Lempleados;
        }



        public List<stock> Lstock()
        {
            List<stock> Lstock = new List<stock>();

            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {
                IQueryable<stock> lista = (from q in DBF.stock select q);
                Lstock = lista.ToList();

            }
            return Lstock;
        }

        public List<serviciostock> Lstockservi()
        {
            List<serviciostock> Lstockservi = new List<serviciostock>();

            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {
                IQueryable<serviciostock> lista = (from q in DBF.serviciostock select q);
                Lstockservi = lista.ToList();

            }
            return Lstockservi;
        }

        public cliente oclientedni(string dni)
        {
            cliente ocliente = new cliente();

            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                ocliente = (from q in DBF.cliente where q.dni == dni select q).FirstOrDefault();



            }
            return ocliente;
        }

        public orden ultimaorden()
        {
            orden result = new orden();
            using (aplicadaBDEntities context = new aplicadaBDEntities())
            {

                result = (from item in context.orden orderby item.id_orden descending select item).First();

            }


            return result;

        }
        public empleado buscarempleado(string email)
        {
            empleado objmarca = new empleado();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objmarca = (from q in DBF.empleado where q.correo == email select q).FirstOrDefault();


            }
            return objmarca;
        }


        public ordenempleado buscarempleadoorden(int id)
        {
            ordenempleado objmarca = new ordenempleado();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objmarca = (from q in DBF.ordenempleado orderby q.id_ordenemple descending where q.id_empleado == id select q).FirstOrDefault();


            }
            return objmarca;
        }

        public orden buscarordenporvehiculo(int id)
        {
            orden objmarca = new orden();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objmarca = (from q in DBF.orden orderby q.id_orden descending where q.id_vehiculo == id select q).FirstOrDefault();


            }
            return objmarca;
        }

        public orden buscarorden(int id)
        {
            orden objmarca = new orden();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objmarca = (from q in DBF.orden where q.id_orden == id select q).FirstOrDefault();


            }
            return objmarca;
        }
        public vehiculo buscarvehiculoid(int id)
        {
            vehiculo objmarca = new vehiculo();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objmarca = (from q in DBF.vehiculo where q.id_vehiculo == id select q).FirstOrDefault();


            }
            return objmarca;
        }

        public List<ordenservicio> buscarlistaid(int id)
        {
            List<ordenservicio> a = new List<ordenservicio>();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                a = (from q in DBF.ordenservicio where q.id_orden == id select q).ToList();


            }
            return a;
        }

        public ordenestado buscarvestadoorden(int id)
        {
            ordenestado objmarca = new ordenestado();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objmarca = (from q in DBF.ordenestado where q.id_orden == id select q).FirstOrDefault();


            }
            return objmarca;
        }

        public List<ordenestado> buscarListOrdenEstado(int n)
        {
            List<ordenestado> objmarca = new List<ordenestado>();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objmarca = (from q in DBF.ordenestado where q.estado == n select q).ToList();


            }
            return objmarca;
        }


        public List<orden> buscarordeestado(List<ordenestado> Lorde)
        {
            List<orden> objmarca = new List<orden>();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {
                foreach (ordenestado x in Lorde)
                {
                    orden oorden = (from q in DBF.orden where q.id_orden == x.id_orden select q).FirstOrDefault();
                    x.orden = oorden;
                    objmarca.Add(oorden);
                }

            }
            return objmarca;
        }

        public List<vehiculo> buscarordevehiculo(List<orden> Lorde)
        {
            List<vehiculo> objmarca = new List<vehiculo>();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {
                foreach (orden x in Lorde)
                {
                    vehiculo oorden = (from q in DBF.vehiculo where q.id_vehiculo == x.id_vehiculo select q).FirstOrDefault();
                    x.vehiculo = oorden;
                }

            }
            return objmarca;
        }

        public List<stock> listastock()
        {
            List<stock> Lstock = new List<stock>();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {
                IQueryable<stock> lista = (from q in DBF.stock select q);
                Lstock = lista.ToList();

            }
            return Lstock;

        }
        public List<stock> listastockmarca(string marca)
        {
            List<stock> Lstock = new List<stock>();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {
                IQueryable<stock> lista = (from q in DBF.stock select q);
                Lstock = lista.ToList();
                Lstock = Lstock.FindAll(x => x.marca == marca);

            }
            return Lstock;

        }

        public List<stock> listastockproducto(string producto)
        {
            List<stock> Lstock = new List<stock>();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {
                IQueryable<stock> lista = (from q in DBF.stock select q);
                Lstock = lista.ToList();
                Lstock = Lstock.FindAll(x => x.detalle == producto);

            }
            return Lstock;

        }

        public List<orden> listasordenmp(string metodop)
        {
            List<orden> Lstock = new List<orden>();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {
                IQueryable<orden> lista = (from q in DBF.orden select q);
                Lstock = lista.ToList();
                Lstock = Lstock.FindAll(x => x.mpago == metodop);

            }
            return Lstock;

        }
        public List<orden> ordenponervyc(List<orden> Lorden)
        {
            foreach (orden oorden in Lorden)
            {
                int v2 = oorden.id_vehiculo ?? default(int);
                oorden.vehiculo = buscarvehiculoid(v2);
                oorden.vehiculo.cliente = ocliente(oorden.vehiculo);



            }
            return Lorden;
        }

        public List<serviciostock> Lserviciostock(string id)
        {
            Buscadores bus = new Buscadores();
            List<serviciostock> Lserviciostocks = bus.Lstockservi();
            List<serviciostock> NLserviciostock = new List<serviciostock>();
            NLserviciostock = Lserviciostocks.FindAll(s => s.id_servicio == int.Parse(id));

            return NLserviciostock;

        }
        public List<stock> Lstockuso(String id)
        {
            Buscadores bus = new Buscadores();
            List<stock> Lstock = bus.Lstock();
            List<stock> stockactivo = new List<stock>();
            List<serviciostock> LSS = Lserviciostock(id);
            foreach (stock Stock in Lstock)
            {
                foreach (serviciostock Servistock in LSS)
                {
                    if (Stock.id_stock == Servistock.id_stock)
                    {
                        stockactivo.Add(Stock);

                    }

                }
            }

            return stockactivo;
        }

        public List<vehiculo> buscarclientevehiculo(int idcliente)
        {
            List<vehiculo> objmarca = new List<vehiculo>();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {


                objmarca = (from q in DBF.vehiculo where q.id_cliente == idcliente select q).ToList();



            }
            return objmarca;
        }

        public List<orden> buscarListaordenporvehiculo(int id)
        {
            List<orden> objmarca = new List<orden>();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objmarca = (from q in DBF.orden orderby q.id_orden descending where q.id_vehiculo == id select q).ToList();


            }
            return objmarca;
        }

        public List<servicio> ObtenerServicios(List<ordenservicio> Lidservidcios)
        {
            List<servicio> Lservicio = new List<servicio>();
            Buscadores bus = new Buscadores();
            foreach (ordenservicio idservicios in Lidservidcios)
            {
                servicio oservicio = bus.buscarservicio(idservicios.id_servicio);
                Lservicio.Add(oservicio);
            }
            return Lservicio;


        }

        public List<ordenempleado> buscarListaempleadoorden(int id)
        {
            List<ordenempleado> objmarca = new List<ordenempleado>();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objmarca = (from q in DBF.ordenempleado orderby q.id_ordenemple descending where q.id_empleado == id select q).ToList();


            }
            return objmarca;
        }
        public List<ordenempleado> buscarListOrdenEstadoporempleado(int n)
        {
            List<ordenempleado> objmarca = new List<ordenempleado>();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {

                objmarca = (from q in DBF.ordenempleado where q.id_empleado == n select q).ToList();


            }
            return objmarca;
        }

        public List<orden> buscarordexempleado(List<ordenempleado> Lorde)
        {
            List<orden> objmarca = new List<orden>();
            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {
                foreach (ordenempleado x in Lorde)
                {
                    orden oorden = (from q in DBF.orden where q.id_orden == x.id_orden select q).FirstOrDefault();
                    x.orden = oorden;
                    objmarca.Add(oorden);
                }

            }
            return objmarca;
        }



    }
}