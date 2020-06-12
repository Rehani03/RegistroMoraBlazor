using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroMoraBlazor.BLL;
using RegistroMoraBlazor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroMoraBlazor.BLL.Tests
{
    [TestClass()]
    public class PrestamoBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Prestamo prestamo = new Prestamo();
            prestamo.prestamoId = 0;
            prestamo.fecha = DateTime.Now;
            prestamo.concepto = "Comida";
            prestamo.monto = 100;
            prestamo.balance = 100;
            bool paso = PrestamoBLL.Guardar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Prestamo prestamo;
            prestamo = PrestamoBLL.Buscar(1);
            Assert.AreEqual(prestamo, prestamo);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Prestamo>();
            lista = PrestamoBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = PrestamoBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = PrestamoBLL.Eliminar(1);
            Assert.AreEqual(paso, true);
        }
    }
}