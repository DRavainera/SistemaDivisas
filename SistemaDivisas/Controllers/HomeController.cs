using Microsoft.AspNetCore.Mvc;
using SistemaDivisas.Models;
using SistemaDivisas.DAO;
using System.Diagnostics;

namespace SistemaDivisas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        ClienteDAO clienteDAO = new ClienteDAO();

        CuentaDAO cuentaDAO = new CuentaDAO();

        RegistroMovimientoDAO registroMovimientoDAO = new RegistroMovimientoDAO();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult LoginAction(ClienteModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }
            else
            {   
                ClienteModel usuario = clienteDAO.LoginCliente(cliente.Usuario, cliente.Contrasenia);
                
                if (usuario.Login)
                {
                    return RedirectToAction("Perfil", usuario);
                }
                else
                {
                    return View("Login");
                }
            }
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistroAction(ClienteModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return View("Registro");
            }
            else
            {
                bool respuesta = clienteDAO.RegistrarCliente(cliente);
                
                if (respuesta)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View("Registro");
                }
            }
        }

        public IActionResult Perfil(ClienteModel cliente)
        {
            return View(cliente);
        }

        public IActionResult Logout(int id)
        {
            ClienteModel cliente = clienteDAO.TraerCliente(id);

            return View(cliente);
        }

        public IActionResult LogoutAction(ClienteModel cliente)
        {
            bool respuesta = clienteDAO.LogoutCliente(cliente);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Logout", cliente.Id);
            }
        }

        public IActionResult CuentasPeso(int Id)
        {
            ClienteModel cliente = clienteDAO.TraerCliente(Id);

            List<CuentaPesoModel> cuentasPeso = cuentaDAO.ListarCuentasPeso(cliente);

            foreach (var c in cuentasPeso)
            {
                c.ClienteId = cliente.Id;
            }

            ViewBag.Cliente = cliente;

            return View(cuentasPeso);
        }

        public IActionResult CuentasDolar(int Id)
        {
            ClienteModel cliente = clienteDAO.TraerCliente(Id);

            List<CuentaDolarModel> cuentasDolar = cuentaDAO.ListarCuentasDolar(cliente);

            foreach (var c in cuentasDolar)
            {
                c.ClienteId = cliente.Id;
            }

            ViewBag.Cliente = cliente;

            return View(cuentasDolar);
        }

        public IActionResult CuentasCripto(int Id)
        {
            ClienteModel cliente = clienteDAO.TraerCliente(Id);

            List<CuentaCriptoModel> cuentasCripto = cuentaDAO.ListarCuentasCripto(cliente);

            foreach (var c in cuentasCripto)
            {
                c.ClienteId = cliente.Id;
            }

            ViewBag.Cliente = cliente;

            return View(cuentasCripto);
        }

        public IActionResult MovimientosPeso(long CBU)
        {
            CuentaPesoModel cuentaPeso = cuentaDAO.TraerCuentaPeso(CBU);

            ViewBag.CuentaPeso = cuentaPeso;

            List<RegistroMovimientoModel> registros = registroMovimientoDAO.ListarRegistros(cuentaPeso.NumeroCuenta.ToString());

            return View(registros);
        }

        public IActionResult MovimientosDolar(long CBU)
        {
            CuentaDolarModel cuentaDolar = cuentaDAO.TraerCuentaDolar(CBU);

            ViewBag.CuentaDolar = cuentaDolar;

            List<RegistroMovimientoModel> registros = registroMovimientoDAO.ListarRegistros(cuentaDolar.NumeroCuenta.ToString());

            return View(registros);
        }

        public IActionResult MovimientosCripto(string UUID)
        {
            CuentaCriptoModel cuentaCripto = cuentaDAO.TraerCuentaCripto(UUID);

            ViewBag.CuentaCripto = cuentaCripto;

            List<RegistroMovimientoModel> registros = registroMovimientoDAO.ListarRegistros(cuentaCripto.UUID);

            return View(registros);
        }

        public IActionResult CrearCuentaPeso(int Id)
        {
            ViewBag.ClienteId = Id;

            CuentaPesoModel cuentaPeso = new CuentaPesoModel();

            cuentaPeso.ClienteId = Id;

            return View(cuentaPeso);
        }

        [HttpPost]
        public IActionResult CrearCuentaPesoAction(CuentaPesoModel cuentaPeso)
        {
            if (!ModelState.IsValid)
            {
                return View("CrearCuentaPeso", cuentaPeso);
            }
            else
            {
                bool respuesta = cuentaDAO.CrearCuentaPeso(cuentaPeso);

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaPeso.ClienteId);
                    
                    List<CuentaPesoModel> cuentasPeso = cuentaDAO.ListarCuentasPeso(cliente);

                    return RedirectToAction("CuentasPeso",cuentasPeso);
                }
                else
                {
                    return View("CrearCuentaPeso", cuentaPeso);
                }
            }
        }

        public IActionResult CrearCuentaDolar(int Id)
        {
            ViewBag.ClienteId = Id;

            CuentaDolarModel cuentaDolar = new CuentaDolarModel();

            cuentaDolar.ClienteId = Id;

            return View(cuentaDolar);
        }

        [HttpPost]
        public IActionResult CrearCuentaDolarAction(CuentaDolarModel cuentaDolar)
        {
            if (!ModelState.IsValid)
            {
                return View("CrearCuentaDolar", cuentaDolar);
            }
            else
            {
                bool respuesta = cuentaDAO.CrearCuentaDolar(cuentaDolar);

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaDolar.ClienteId);
                    
                    List<CuentaDolarModel> cuentasDolar = cuentaDAO.ListarCuentasDolar(cliente);

                    return RedirectToAction("CuentasDolar", cuentasDolar);
                }
                else
                {
                    return View("CrearCuentaDolar", cuentaDolar);
                }
            }
        }

        public IActionResult CrearCuentaCripto(int Id)
        {
            ViewBag.ClienteId = Id;

            CuentaCriptoModel cuentaCripto = new CuentaCriptoModel();

            cuentaCripto.ClienteId = Id;

            return View(cuentaCripto);
        }

        [HttpPost]
        public IActionResult CrearCuentaCriptoAction(CuentaCriptoModel cuentaCripto)
        {
            if (!ModelState.IsValid)
            {
                return View("CrearCuentaCripto", cuentaCripto);
            }
            else
            {
                bool respuesta = cuentaDAO.CrearCuentaCripto(cuentaCripto);

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaCripto.ClienteId);
                   
                    List<CuentaCriptoModel> cuentasCripto = cuentaDAO.ListarCuentasCripto(cliente);

                    return RedirectToAction("CuentasCripto", cuentasCripto);
                }
                else
                {
                    return View("CrearCuentaCripto", cuentaCripto);
                }
            }
        }

        public IActionResult BorrarCuentaPeso(long CBU)
        {
            CuentaPesoModel cuentaPeso = cuentaDAO.TraerCuentaPeso(CBU);

            return View(cuentaPeso);
        }

        [HttpPost]
        public IActionResult BorrarCuentaPesoAction(CuentaPesoModel cuentaPeso)
        {
            bool respuesta = cuentaDAO.BorrarCuentaPeso(cuentaPeso.Id);

            if (respuesta)
            {
                ClienteModel cliente = clienteDAO.TraerCliente(cuentaPeso.ClienteId);

                List<CuentaPesoModel> cuentasPeso = cuentaDAO.ListarCuentasPeso(cliente);

                return RedirectToAction("CuentasPeso", cuentasPeso);
            }
            else
            {
                return View("BorrarCuentaPeso", cuentaPeso.CBU);
            }

        }

        public IActionResult BorrarCuentaDolar(long CBU)
        {
            CuentaDolarModel cuentaDolar = cuentaDAO.TraerCuentaDolar(CBU);

            return View(cuentaDolar);
        }

        [HttpPost]
        public IActionResult BorrarCuentaDolarAction(CuentaDolarModel cuentaDolar)
        {
            bool respuesta = cuentaDAO.BorrarCuentaDolar(cuentaDolar.Id);

            if (respuesta)
            {
                ClienteModel cliente = clienteDAO.TraerCliente(cuentaDolar.ClienteId);

                List<CuentaDolarModel> cuentasDolar = cuentaDAO.ListarCuentasDolar(cliente);

                return RedirectToAction("CuentasDolar", cuentasDolar);
            }
            else
            {
                return View("BorrarCuentaDolar", cuentaDolar.CBU);
            }

        }

        public IActionResult BorrarCuentaCripto(string UUID)
        {
            CuentaCriptoModel cuentaCripto = cuentaDAO.TraerCuentaCripto(UUID);

            return View(cuentaCripto);
        }

        [HttpPost]
        public IActionResult BorrarCuentaCriptoAction(CuentaCriptoModel cuentaCripto)
        {
            bool respuesta = cuentaDAO.BorrarCuentaCripto(cuentaCripto.Id);

            if (respuesta)
            {
                ClienteModel cliente = clienteDAO.TraerCliente(cuentaCripto.ClienteId);

                List<CuentaCriptoModel> cuentasCripto = cuentaDAO.ListarCuentasCripto(cliente);

                return RedirectToAction("CuentasCripto", cuentasCripto);
            }
            else
            {
                return View("BorrarCuentaPeso", cuentaCripto.UUID);
            }

        }

        public IActionResult TransferirPesoApeso(int id)
        {
            ClienteModel cliente = clienteDAO.TraerCliente(id);

            ViewBag.ClienteId = id;

            List<CuentaPesoModel> cuentasPeso = cuentaDAO.ListarCuentasPeso(cliente);

            return View(cuentasPeso);
        }

        [HttpPost]
        public IActionResult TransferirPesoAPesoAction( long cuentaOrigen, long cuentaDestino, double importe)
        {
            if (!ModelState.IsValid)
            {
                return View("TransferirPesoAPeso", cuentaOrigen);
            }
            else
            {
                ViewBag.CuentaOrigen = cuentaOrigen;

                ViewBag.CuentaDestino = cuentaDestino;

                ViewBag.Importe = importe;

                CuentaPesoModel cuentaPeso1 = cuentaDAO.TraerCuentaPeso(cuentaOrigen);

                CuentaPesoModel cuentaPeso2 = cuentaDAO.TraerCuentaPeso(cuentaDestino);

                bool respuesta = cuentaDAO.TransferirPeso(cuentaPeso1, cuentaPeso2, importe);

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaPeso1.ClienteId);

                    List<CuentaPesoModel> cuentasPeso = cuentaDAO.ListarCuentasPeso(cliente);

                    return RedirectToAction("CuentasPeso", cuentasPeso);
                }
                else
                {
                    return View("TransferirPesoAPeso", cuentaOrigen);
                }
            }

        }

        public IActionResult TransferirPesoADolar(int id)
        {
            ClienteModel cliente = clienteDAO.TraerCliente(id);

            ViewBag.ClienteId = id;

            List<CuentaPesoModel> cuentasPeso = cuentaDAO.ListarCuentasPeso(cliente);

            List<CuentaDolarModel> cuentasDolar = cuentaDAO.ListarCuentasDolar(cliente);

            ViewBag.CuentasDolar = cuentasDolar;

            return View(cuentasPeso);
        }

        [HttpPost]
        public IActionResult TransferirPesoADolarAction(long cuentaOrigen, long cuentaDestino, double importe)
        {
            if (!ModelState.IsValid)
            {
                return View("TransferirPesoADolar", cuentaOrigen);
            }
            else
            {
                ViewBag.CuentaOrigen = cuentaOrigen;

                ViewBag.CuentaDestino = cuentaDestino;

                ViewBag.Importe = importe;

                CuentaPesoModel cuentaPeso = cuentaDAO.TraerCuentaPeso(cuentaOrigen);

                CuentaDolarModel cuentaDolar = cuentaDAO.TraerCuentaDolar(cuentaDestino);

                bool respuesta = cuentaDAO.TransferirPesoADolar(cuentaPeso, cuentaDolar, importe);

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaPeso.ClienteId);

                    List<CuentaPesoModel> cuentasPeso = cuentaDAO.ListarCuentasPeso(cliente);

                    return RedirectToAction("CuentasPeso", cuentasPeso);
                }
                else
                {
                    return View("TransferirPesoADolar", cuentaOrigen);
                }
            }

        }

        public IActionResult TransferirPesoACripto(int id)
        {
            ClienteModel cliente = clienteDAO.TraerCliente(id);

            ViewBag.ClienteId = id;

            List<CuentaPesoModel> cuentasPeso = cuentaDAO.ListarCuentasPeso(cliente);

            List<CuentaCriptoModel> cuentasCripto = cuentaDAO.ListarCuentasCripto(cliente);

            ViewBag.CuentasCripto = cuentasCripto;

            return View(cuentasPeso);
        }

        [HttpPost]
        public IActionResult TransferirPesoACriptoAction(long cuentaOrigen, string cuentaDestino, double importe)
        {
            if (!ModelState.IsValid)
            {
                return View("TransferirPesoACripto", cuentaOrigen);
            }
            else
            {
                ViewBag.CuentaOrigen = cuentaOrigen;

                ViewBag.CuentaDestino = cuentaDestino;

                ViewBag.Importe = importe;

                CuentaPesoModel cuentaPeso = cuentaDAO.TraerCuentaPeso(cuentaOrigen);

                CuentaCriptoModel cuentaCripto = cuentaDAO.TraerCuentaCripto(cuentaDestino);

                bool respuesta = cuentaDAO.TransferirPesoACripto(cuentaPeso, cuentaCripto, importe);

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaPeso.ClienteId);

                    List<CuentaPesoModel> cuentasPeso = cuentaDAO.ListarCuentasPeso(cliente);

                    return RedirectToAction("CuentasPeso", cuentasPeso);
                }
                else
                {
                    return View("TransferirPesoACripto", cuentaOrigen);
                }
            }

        }

        public IActionResult TransferirDolarADolar(int id)
        {
            ClienteModel cliente = clienteDAO.TraerCliente(id);

            ViewBag.ClienteId = id;

            List<CuentaDolarModel> cuentasDolar = cuentaDAO.ListarCuentasDolar(cliente);

            return View(cuentasDolar);
        }

        [HttpPost]
        public IActionResult TransferirDolarADolarAction(long cuentaOrigen, long cuentaDestino, double importe)
        {
            if (!ModelState.IsValid)
            {
                return View("TransferirDolarADolar", cuentaOrigen);
            }
            else
            {
                ViewBag.CuentaOrigen = cuentaOrigen;

                ViewBag.CuentaDestino = cuentaDestino;

                ViewBag.Importe = importe;

                CuentaDolarModel cuentaDolar1 = cuentaDAO.TraerCuentaDolar(cuentaOrigen);

                CuentaDolarModel cuentaDolar2 = cuentaDAO.TraerCuentaDolar(cuentaDestino);

                bool respuesta = cuentaDAO.TransferirDolar(cuentaDolar1, cuentaDolar2, importe);

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaDolar1.ClienteId);

                    List<CuentaDolarModel> cuentasDolar = cuentaDAO.ListarCuentasDolar(cliente);

                    return RedirectToAction("CuentasDolar", cuentasDolar);
                }
                else
                {
                    return View("TransferirDolarADolar", cuentaOrigen);
                }
            }

        }

        public IActionResult TransferirDolarACripto(int id)
        {
            ClienteModel cliente = clienteDAO.TraerCliente(id);

            ViewBag.ClienteId = id;

            List<CuentaDolarModel> cuentasDolar = cuentaDAO.ListarCuentasDolar(cliente);

            List<CuentaCriptoModel> cuentasCripto = cuentaDAO.ListarCuentasCripto(cliente);

            ViewBag.CuentasCripto = cuentasCripto;

            return View(cuentasDolar);
        }

        [HttpPost]
        public IActionResult TransferirDolarACriptoAction(long cuentaOrigen, string cuentaDestino, double importe)
        {
            if (!ModelState.IsValid)
            {
                return View("TransferirDolarACripto", cuentaOrigen);
            }
            else
            {
                ViewBag.CuentaOrigen = cuentaOrigen;

                ViewBag.CuentaDestino = cuentaDestino;

                ViewBag.Importe = importe;

                CuentaDolarModel cuentaDolar = cuentaDAO.TraerCuentaDolar(cuentaOrigen);

                CuentaCriptoModel cuentaCripto = cuentaDAO.TraerCuentaCripto(cuentaDestino);

                bool respuesta = cuentaDAO.TransferirDolarACripto(cuentaDolar, cuentaCripto, importe);

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaDolar.ClienteId);

                    List<CuentaDolarModel> cuentasDolar = cuentaDAO.ListarCuentasDolar(cliente);

                    return RedirectToAction("CuentasDolar", cuentasDolar);
                }
                else
                {
                    return View("TransferirDolarACripto", cuentaOrigen);
                }
            }

        }

        public IActionResult TransferirDolarAPeso(int id)
        {
            ClienteModel cliente = clienteDAO.TraerCliente(id);
            
            ViewBag.ClienteId = id;

            List<CuentaDolarModel> cuentasDolar = cuentaDAO.ListarCuentasDolar(cliente);

            List<CuentaPesoModel> cuentasPeso = cuentaDAO.ListarCuentasPeso(cliente);

            ViewBag.CuentasPeso = cuentasPeso;

            return View(cuentasDolar);
        }

        [HttpPost]
        public IActionResult TransferirDolarAPesoAction(long cuentaOrigen, long cuentaDestino, double importe)
        {
            if (!ModelState.IsValid)
            {
                return View("TransferirDolarAPeso", cuentaOrigen);
            }
            else
            {
                ViewBag.CuentaOrigen = cuentaOrigen;

                ViewBag.CuentaDestino = cuentaDestino;

                ViewBag.Importe = importe;

                CuentaDolarModel cuentaDolar = cuentaDAO.TraerCuentaDolar(cuentaOrigen);

                CuentaPesoModel cuentaPeso = cuentaDAO.TraerCuentaPeso(cuentaDestino);

                bool respuesta = cuentaDAO.TransferirDolarAPeso(cuentaDolar, cuentaPeso, importe);

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaDolar.ClienteId);

                    List<CuentaDolarModel> cuentasDolar = cuentaDAO.ListarCuentasDolar(cliente);

                    return RedirectToAction("CuentasDolar", cuentasDolar);
                }
                else
                {
                    return View("TransferirDolarAPeso", cuentaOrigen);
                }
            }

        }

        public IActionResult TransferirCriptoACripto(int id)
        {
            ClienteModel cliente = clienteDAO.TraerCliente(id);

            ViewBag.ClienteId = id;

            List<CuentaCriptoModel> cuentasCripto = cuentaDAO.ListarCuentasCripto(cliente);

            return View(cuentasCripto);
        }

        [HttpPost]
        public IActionResult TransferirCriptoACriptoAction(string cuentaOrigen, string cuentaDestino, double importe)
        {
            if (!ModelState.IsValid)
            {
                return View("TransferirCriptoACripto", cuentaOrigen);
            }
            else
            {
                ViewBag.CuentaOrigen = cuentaOrigen;

                ViewBag.CuentaDestino = cuentaDestino;

                ViewBag.Importe = importe;

                CuentaCriptoModel cuentaCripto1 = cuentaDAO.TraerCuentaCripto(cuentaOrigen);

                CuentaCriptoModel cuentaCripto2 = cuentaDAO.TraerCuentaCripto(cuentaDestino);

                bool respuesta = cuentaDAO.TransferirCripto(cuentaCripto1, cuentaCripto2, importe);

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaCripto1.ClienteId);

                    List<CuentaCriptoModel> cuentasCripto = cuentaDAO.ListarCuentasCripto(cliente);

                    return RedirectToAction("CuentasCripto", cuentasCripto);
                }
                else
                {
                    return View("TransferirCriptoACripto", cuentaOrigen);
                }
            }
        }

        public IActionResult TransferirCriptoADolar(int id)
        {
            ClienteModel cliente = clienteDAO.TraerCliente(id);

            ViewBag.ClienteId = id;

            List<CuentaCriptoModel> cuentasCripto = cuentaDAO.ListarCuentasCripto(cliente);

            List<CuentaDolarModel> cuentasDolar = cuentaDAO.ListarCuentasDolar(cliente);

            ViewBag.CuentasDolar = cuentasDolar;

            return View(cuentasCripto);
        }

        [HttpPost]
        public IActionResult TransferirCriptoADolarAction(string cuentaOrigen, long cuentaDestino, double importe)
        {
            if (!ModelState.IsValid)
            {
                return View("TransferirCriptoADolar", cuentaOrigen);
            }
            else
            {
                ViewBag.CuentaOrigen = cuentaOrigen;

                ViewBag.CuentaDestino = cuentaDestino;

                ViewBag.Importe = importe;

                CuentaCriptoModel cuentaCripto = cuentaDAO.TraerCuentaCripto(cuentaOrigen);

                CuentaDolarModel cuentaDolar = cuentaDAO.TraerCuentaDolar(cuentaDestino);

                bool respuesta = cuentaDAO.TransferirCriptoADolar(cuentaCripto, cuentaDolar, importe);

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaCripto.ClienteId);

                    List<CuentaCriptoModel> cuentasCripto = cuentaDAO.ListarCuentasCripto(cliente);

                    return RedirectToAction("CuentasCripto", cuentasCripto);
                }
                else
                {
                    return View("TransferirCriptoADolar", cuentaOrigen);
                }
            }
        }

        public IActionResult TransferirCriptoAPeso(int id)
        {
            ClienteModel cliente = clienteDAO.TraerCliente(id);

            ViewBag.ClienteId = id;

            List<CuentaCriptoModel> cuentasCripto = cuentaDAO.ListarCuentasCripto(cliente);

            List<CuentaPesoModel> cuentasPeso = cuentaDAO.ListarCuentasPeso(cliente);

            ViewBag.CuentasPeso = cuentasPeso;

            return View(cuentasCripto);
        }

        [HttpPost]
        public IActionResult TransferirCriptoAPesoAction(string cuentaOrigen, long cuentaDestino, double importe)
        {
            if (!ModelState.IsValid)
            {
                return View("TransferirCriptoAPeso", cuentaOrigen);
            }
            else
            {
                ViewBag.CuentaOrigen = cuentaOrigen;

                ViewBag.CuentaDestino = cuentaDestino;

                ViewBag.Importe = importe;

                CuentaCriptoModel cuentaCripto = cuentaDAO.TraerCuentaCripto(cuentaOrigen);

                CuentaPesoModel cuentaPeso = cuentaDAO.TraerCuentaPeso(cuentaDestino);

                bool respuesta = cuentaDAO.TransferirCriptoAPeso(cuentaCripto, cuentaPeso, importe);

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaCripto.ClienteId);

                    List<CuentaCriptoModel> cuentasCripto = cuentaDAO.ListarCuentasCripto(cliente);

                    return RedirectToAction("CuentasCripto", cuentasCripto);
                }
                else
                {
                    return View("TransferirCriptoAPeso", cuentaOrigen);
                }
            }
        }

        public IActionResult DepositarPeso(long CBU)
        {
            CuentaPesoModel cuentaPeso = cuentaDAO.TraerCuentaPeso(CBU);

            return View(cuentaPeso);
        }

        [HttpPost]
        public IActionResult DepositarPesoAction(long CBU, double importe)
        {
            if (!ModelState.IsValid)
            {
                return View("DepositarPeso", CBU);
            }
            else
            {
                ViewBag.Importe = importe;

                ViewBag.CBU = CBU;

                CuentaPesoModel cuentaPeso = cuentaDAO.TraerCuentaPeso(CBU);

                bool respuesta = cuentaDAO.ActualizarSaldoPeso(cuentaPeso, importe, "agregar");

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaPeso.ClienteId);

                    List<CuentaPesoModel> cuentasPeso = cuentaDAO.ListarCuentasPeso(cliente);

                    return RedirectToAction("CuentasPeso", cuentasPeso);
                }
                else
                {
                    return View("DepositarPeso", CBU);
                }
            }
        }

        public IActionResult DepositarDolar(long CBU)
        {
            CuentaDolarModel cuentaDolar = cuentaDAO.TraerCuentaDolar(CBU);

            return View(cuentaDolar);
        }

        [HttpPost]
        public IActionResult DepositarDolarAction(long CBU, double importe)
        {
            if (!ModelState.IsValid)
            {
                return View("DepositarDolar", CBU);
            }
            else
            {
                ViewBag.Importe = importe;

                ViewBag.CBU = CBU;

                CuentaDolarModel cuentaDolar = cuentaDAO.TraerCuentaDolar(CBU);

                bool respuesta = cuentaDAO.ActualizarSaldoDolar(cuentaDolar, importe, "agregar");

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaDolar.ClienteId);

                    List<CuentaDolarModel> cuentasDolar = cuentaDAO.ListarCuentasDolar(cliente);

                    return RedirectToAction("CuentasDolar", cuentasDolar);
                }
                else
                {
                    return View("DepositarPeso", CBU);
                }
            }
        }

        public IActionResult ExtraerPeso(long CBU)
        {
            CuentaPesoModel cuentaPeso = cuentaDAO.TraerCuentaPeso(CBU);

            return View(cuentaPeso);
        }

        [HttpPost]
        public IActionResult ExtraerPesoAction(long CBU, double importe)
        {
            if (!ModelState.IsValid)
            {
                return View("ExtraerPeso", CBU);
            }
            else
            {
                ViewBag.Importe = importe;

                ViewBag.CBU = CBU;

                CuentaPesoModel cuentaPeso = cuentaDAO.TraerCuentaPeso(CBU);

                bool respuesta = cuentaDAO.ActualizarSaldoPeso(cuentaPeso, importe, "quitar");

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaPeso.ClienteId);

                    List<CuentaPesoModel> cuentasPeso = cuentaDAO.ListarCuentasPeso(cliente);

                    return RedirectToAction("CuentasPeso", cuentasPeso);
                }
                else
                {
                    return View("ExtraerPeso", CBU);
                }
            }
        }

        public IActionResult ExtraerDolar(long CBU)
        {
            CuentaDolarModel cuentaDolar = cuentaDAO.TraerCuentaDolar(CBU);

            return View(cuentaDolar);
        }

        [HttpPost]
        public IActionResult ExtraerDolarAction(long CBU, double importe)
        {
            if (!ModelState.IsValid)
            {
                return View("ExtraerDolar", CBU);
            }
            else
            {
                ViewBag.Importe = importe;

                ViewBag.CBU = CBU;

                CuentaDolarModel cuentaDolar = cuentaDAO.TraerCuentaDolar(CBU);

                bool respuesta = cuentaDAO.ActualizarSaldoDolar(cuentaDolar, importe, "quitar");

                if (respuesta)
                {
                    ClienteModel cliente = clienteDAO.TraerCliente(cuentaDolar.ClienteId);

                    List<CuentaDolarModel> cuentasDolar = cuentaDAO.ListarCuentasDolar(cliente);

                    return RedirectToAction("CuentasDolar", cuentasDolar);
                }
                else
                {
                    return View("ExtraerPeso", CBU);
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}