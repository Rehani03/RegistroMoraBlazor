using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroMoraBlazor.BLL;
using RegistroMoraBlazor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroMoraBlazor.BLL.Tests
{
    [TestClass()]
    public class MoraBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Mora mora = new Mora();
            mora.moraId = 0;
            mora.fecha = DateTime.Now;
            mora.total = 10;
            mora.MoraDetalles.Add(new MoraDetalle
            {
                moraDetalleId = 0,
                moraId = mora.moraId,
                prestamoId = 1,
                valor = 10
            });

            Assert.IsTrue(MoraBLL.Guardar(mora));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Mora mora;
            mora = MoraBLL.Buscar(1);
            Assert.IsNotNull(mora);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Mora>();
            lista = MoraBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = MoraBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = MoraBLL.Eliminar(1);
            Assert.AreEqual(paso, true);
        }
    }
}