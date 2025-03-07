using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.RequestFeature
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }

        //Ctor
        public PagedList(List<T> items, int count, int pageSize, int PageNumber)
        {
            MetaData = new MetaData()
            {
                CurrentPage = PageNumber,
                PageSize = pageSize,
                TotalCount = count,
                TotalPage = (int)Math.Ceiling((double)count / pageSize)
            };
            AddRange(items);
        }
        public static PagedList<T> ToPagedList(List<T> source,int pageNumber,int pageSize)
        {
            var count = source.Count();
            
            var items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedList<T>(items,count,pageSize,pageNumber);
        }
    }
}
