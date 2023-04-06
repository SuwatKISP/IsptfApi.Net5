using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Repository.Category
{
    public interface ICategoryRepository
    {
        public Task<List<Models.Category.Category>> GetAll();
    }
}
