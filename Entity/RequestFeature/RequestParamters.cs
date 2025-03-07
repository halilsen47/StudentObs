using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.RequestFeature
{
    public abstract class RequestParamters
    {
        const int maxPage = 10;
        public int pageNumber { get; set; }
        private int _pageSize { get; set; }
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > maxPage? maxPage : value; }
        }

    }
}
