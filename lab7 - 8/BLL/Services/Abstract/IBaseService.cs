using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Abstract
{
    public interface IBaseService<TDTO> where TDTO : class
    {
        IEnumerable<TDTO> GetAll();
        TDTO Get(int id);
        void Create(TDTO model);
        void Update(TDTO model);
        void Delete(int id);
    }
}
