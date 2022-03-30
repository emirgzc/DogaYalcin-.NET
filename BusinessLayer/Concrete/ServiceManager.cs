using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ServiceManager:IServicesService
	{
		IServicesDal _servicesDal;

		public ServiceManager(IServicesDal servicesDal)
		{
			_servicesDal = servicesDal;
		}

		public List<Services> GetAll()
		{
			return _servicesDal.GetAll();
		}

		public Services GetByID(int id)
		{
			return _servicesDal.Get(x => x.ServicesId == id);
		}

		public List<Services> GetListStatusTrue()
		{
			return _servicesDal.GetAll(x=>x.Status==true);
		}

		public List<Services> GetServicesByID(int id)
		{
			return _servicesDal.GetAll(x => x.ServicesId == id);
		}

		public void ServicesAdd(Services services)
		{
			_servicesDal.Add(services);
		}

		public void ServicesDelete(Services services)
		{
			_servicesDal.Delete(services);
		}

		public void ServicesUpdate(Services services)
		{
			_servicesDal.Update(services);
		}
	}
}
