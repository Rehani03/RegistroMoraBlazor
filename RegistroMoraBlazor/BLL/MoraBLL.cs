using Microsoft.EntityFrameworkCore;
using RegistroMoraBlazor.DAL;
using RegistroMoraBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroMoraBlazor.BLL
{
    public class MoraBLL
    {
        public static bool Guardar(Mora mora)
        {
            if (!Existe(mora.moraId))//si no existe insertamos
                return Insertar(mora);
            else
                return Modificar(mora);

        }

        private static bool Insertar(Mora mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                foreach (var item in mora.MoraDetalles)
                {
                    var auxPrestamo = contexto.Prestamos.Find(item.prestamoId);
                    if (auxPrestamo != null)
                        auxPrestamo.balance += item.valor;
                }

                contexto.Moras.Add(mora);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        private static bool Modificar(Mora mora)
        {
            bool paso = false;
            var Anterior = Buscar(mora.moraId);
            Contexto contexto = new Contexto();

            try
            {
                //aqui borro y disminuyo la mora al prestamo
                foreach (var item in Anterior.MoraDetalles)
                {
                    var auxPrestamo = contexto.Prestamos.Find(item.prestamoId);
                    if (!mora.MoraDetalles.Exists(d => d.moraDetalleId == item.moraDetalleId))
                    {
                        if (auxPrestamo != null)
                            auxPrestamo.balance -= item.valor;
                        contexto.Entry(item).State = EntityState.Deleted;
                    }

                }

                //aqui agrego lo nuevo al detalle
                foreach (var item in mora.MoraDetalles)
                {
                    var auxPrestamo = contexto.Prestamos.Find(item.prestamoId);
                    if (item.moraDetalleId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                        if (auxPrestamo != null)
                            auxPrestamo.balance += item.valor;
                    }
                    else
                        contexto.Entry(item).State = EntityState.Modified;
                }

                contexto.Entry(mora).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            var Anterior = Buscar(id);
            Contexto contexto = new Contexto();

            try
            {
                foreach (var item in Anterior.MoraDetalles)
                {
                    var prestamo = contexto.Prestamos.Find(item.prestamoId);
                    if (prestamo != null)
                        prestamo.balance -= item.valor;
                }


                var auxMora = contexto.Moras.Find(id);
                if (auxMora != null)
                {
                    contexto.Moras.Remove(auxMora);//remueve la entidad
                    paso = contexto.SaveChanges() > 0;

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Mora Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Mora mora;

            try
            {
                mora = contexto.Moras.Where(m => m.moraId == id).Include(d => d.MoraDetalles).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return mora;

        }

        public static List<Mora> GetList(Expression<Func<Mora, bool>> mora)
        {
            List<Mora> lista = new List<Mora>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Moras.Where(mora).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Moras.Any(m =>m.moraId == id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;

        }
    }
}
