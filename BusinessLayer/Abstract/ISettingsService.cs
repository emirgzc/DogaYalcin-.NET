using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ISettingsService
	{
        List<Settings> GetAll();
        List<Settings> GetSettingsByID(int id);
        Settings GetByID(int id);
        void SettingsAdd(Settings settings);
        void SettingsUpdate(Settings settings);
        void SettingsDelete(Settings settings);
    }
}
