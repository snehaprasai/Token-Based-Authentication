using Glene.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Glene.API.Controllers
{
   
    public class ValuesController : ApiController
    {
        private ICustomerRepository CustomerRepo = new CustomerRepository();
        private ICategoryRepository CategoryRepo = new CategoryRepository();
        private IContactRepository ContactRepo = new ContactRepository();
        private ICustomerDemoRepository cdRepo = new CustomerDemoRepository();
        private IEmployeeRepository emRepo = new EmployeeRepository();
        private IEmployeeTerritoryRepository etRepo = new EmployeeTerritoryRepository();
        private IOrderRepository oRepo = new OrderRepository();
        private IOrderDetailRepository odRepo = new OrderDetailRepository();
        private IProductRepository pRepo = new ProductRepository();
        private IRegionRepository rRepo = new RegionRepository();
        private IShipperRepository sRepo = new ShipperRepository();
        private ISupplierRepository suRepo = new SupplierRepository();
        private ITerritoryRepository tRepo = new TerritoryRepository();
        private ICustomerCustomerDemoRepository ccdRepo = new CustomerCustomerDemoRepository();


        //[AllowAnonymous]
        //[HttpGet]
        //[Route("api/data/forall")]
        //public IHttpActionResult Get()
        //{
        //    return Ok("Now server time is: " + DateTime.Now.ToString());
        //}

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + " Role: " + string.Join(",", roles.ToList()));
        }
       

        [Authorize]
        [HttpGet]
        [Route("api/CustomerList")]

        public IHttpActionResult CustomerGetAll()
        {
            var allRecords = CustomerRepo.GetAll();
            return Ok(allRecords);
        }
        
        [Authorize]
        [HttpGet]
        [Route("api/CategoryList")]
        public IHttpActionResult CategoryGetAll()
        {
            var allRecords = CategoryRepo.GetAll();
            return Ok(allRecords);
        }
        [Authorize]
        [HttpGet]
        [Route("api/ContactList")]
        public IHttpActionResult ContactGetAll()
        {
            var allRecords = ContactRepo.GetAll();
            return Ok(allRecords);
        }
        [Authorize]
        [HttpGet]
        [Route("api/CustomerDemographics")]
        public IHttpActionResult CDGetAll()
        {
            var allRecords = cdRepo.GetAll();
            return Ok(allRecords);
        }
        [Authorize]
        [HttpGet]
        [Route("api/EmployeeList")]
        public IHttpActionResult EmployeeGetAll()
        {
            var allRecords = emRepo.GetAll();
            return Ok(allRecords);
        }
        [Authorize]
        [HttpGet]
        [Route("api/EmpTerritoryList")]
        public IHttpActionResult ETGetAll()
        {
            var allRecords = etRepo.GetAll();
            return Ok(allRecords);
        }
        [Authorize]
        [HttpGet]
        [Route("api/OrderList")]
        public IHttpActionResult OrderGetAll()
        {
            var allRecords = oRepo.GetAll();
            return Ok(allRecords);
        }
        [Authorize]
        [HttpGet]
        [Route("api/OrderDetails")]
        public IHttpActionResult ODGetAll()
        {
            var allRecords = odRepo.GetAll();
            return Ok(allRecords);
        }
        [Authorize]
        [HttpGet]
        [Route("api/ProductList")]
        public IHttpActionResult ProductGetAll()
        {
            var allRecords = pRepo.GetAll();
            return Ok(allRecords);
        }
        [Authorize]
        [HttpGet]
        [Route("api/RegionList")]
        public IHttpActionResult RegionGetAll()
        {
            var allRecords = rRepo.GetAll();
            return Ok(allRecords);
        }
        [Authorize]
        [HttpGet]
        [Route("api/ShipperList")]
        public IHttpActionResult ShipperGetAll()
        {
            var allRecords = sRepo.GetAll();
            return Ok(allRecords);
        }
        [Authorize]
        [HttpGet]
        [Route("api/SupplierList")]
        public IHttpActionResult SupplierGetAll()
        {
            var allRecords = suRepo.GetAll();
            return Ok(allRecords);
        }
        [Authorize]
        [HttpGet]
        [Route("api/TerritoryList")]
        public IHttpActionResult TerritoryGetAll()
        {
            var allRecords = tRepo.GetAll();
            return Ok(allRecords);
        }
        [Authorize]
        [HttpGet]
        [Route("api/CCDList")]
        public IHttpActionResult CCDGetAll()
        {
            var allRecords = ccdRepo.GetAll();
            return Ok(allRecords);
        }


        [Authorize]
        [HttpGet]
        [Route("api/Customer/{id}")]
        public IHttpActionResult CustomerGetByID(string id)
        {
            var customer = CustomerRepo.GetByID(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [Authorize]
        [HttpGet]
        [Route("api/Category/{id}")]
        public IHttpActionResult CatrgoryGetByID(int id)
        {
            var category = CategoryRepo.GetByID(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [Authorize]
        [HttpGet]
        [Route("api/Contact/{id}")]
        public IHttpActionResult ContactGetByID(int id)
        {
            var Contact = ContactRepo.GetByID(id);
            if (Contact == null)
            {
                return NotFound();
            }
            return Ok(Contact);
        }
        [Authorize]
        [HttpGet]
        [Route("api/CustomerDemographics/{id}")]
        public IHttpActionResult CDGetByID(string id)
        {
            var cd = cdRepo.GetByID(id);
            if (cd == null)
            {
                return NotFound();
            }
            return Ok(cd);
        }
        [Authorize]
        [HttpGet]
        [Route("api/Employee/{id}")]
        public IHttpActionResult EmployeeGetByID(int id)
        {
            var record = emRepo.GetByID(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
        [Authorize]
        [HttpGet]
        [Route("api/EmpTerritory/{id}")]
        public IHttpActionResult ETGetByID(int id)
        {
            var record = etRepo.GetByID(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
        [Authorize]
        [HttpGet]
        [Route("api/Order/{id}")]
        public IHttpActionResult OrderGetByID(int id)
        {
            var record = oRepo.GetByID(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
        [Authorize]
        [HttpGet]
        [Route("api/OrderDetails/{id}")]
        public IHttpActionResult ODGetByID(int id)
        {
            var record = odRepo.GetByID(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
        [Authorize]
        [HttpGet]
        [Route("api/Products/{id}")]
        public IHttpActionResult ProductGetByID(int id)
        {
            var record = pRepo.GetByID(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
        [Authorize]
        [HttpGet]
        [Route("api/Region/{id}")]
        public IHttpActionResult RegionGetByID(int id)
        {
            var record = rRepo.GetByID(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
        [Authorize]
        [HttpGet]
        [Route("api/Shipper/{id}")]
        public IHttpActionResult ShipperGetByID(int id)
        {
            var record = sRepo.GetByID(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
        [Authorize]
        [HttpGet]
        [Route("api/Supplier/{id}")]
        public IHttpActionResult SupplierGetByID(int id)
        {
            var record = suRepo.GetByID(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
        [Authorize]
        [HttpGet]
        [Route("api/Territory/{id}")]
        public IHttpActionResult TerritoryGetByID(string id)
        {
            var record = tRepo.GetByID(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
        [Authorize]
        [HttpGet]
        [Route("api/CCD/{id}")]
        public IHttpActionResult CCDGetByID(string id)
        {
            var record = ccdRepo.GetByID(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

    }
}
