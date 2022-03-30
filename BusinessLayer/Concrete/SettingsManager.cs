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
	public class SettingsManager : ISettingsService
	{
		ISettingsDal _settingsDal;

		public SettingsManager(ISettingsDal settingsDal)
		{
			_settingsDal = settingsDal;
		}
		public List<Settings> GetAll()
		{
			return _settingsDal.GetAll();
		}

		public Settings GetByID(int id)
		{
			return _settingsDal.Get(x => x.SetId == id);
		}

		public List<Settings> GetSettingsByID(int id)
		{
			return _settingsDal.GetAll(x => x.SetId == id);
		}

		public void SettingsAdd(Settings settings)
		{
			_settingsDal.Add(settings);
		}

		public void SettingsDelete(Settings settings)
		{
			_settingsDal.Delete(settings);
		}

		public void SettingsUpdate(Settings settings)
		{
			_settingsDal.Update(settings);
		}
	}
}
