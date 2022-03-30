using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IServicesService
	{
        List<Services> GetAll();
        List<Services> GetListStatusTrue();
        List<Services> GetServicesByID(int id);
        Services GetByID(int id);
        void ServicesAdd(Services services);
        void ServicesUpdate(Services services);
        void ServicesDelete(Services services);
    }
}
