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
	public class AdminManager : IAdminService
	{
		IAdminDal _adminDal;

		public AdminManager(IAdminDal adminDal)
		{
			_adminDal = adminDal;
		}
		public void AdminAdd(Admin admin)
		{
			_adminDal.Add(admin);
		}

		public void AdminDelete(Admin admin)
		{
			_adminDal.Delete(admin);
		}

		public void AdminUpdate(Admin admin)
		{
			_adminDal.Update(admin);
		}

		public List<Admin> GetAdminByID(int id)
		{
			return _adminDal.GetAll(x => x.AdminId == id);
		}

		public List<Admin> GetAll()
		{
			return _adminDal.GetAll();
		}

		public Admin GetByID(int id)
		{
			return _adminDal.Get(x => x.AdminId == id);
		}
	}
}
