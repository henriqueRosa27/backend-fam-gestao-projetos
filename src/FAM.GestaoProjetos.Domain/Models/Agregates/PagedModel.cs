using System.Collections.Generic;

namespace FAM.GestaoProjetos.Domain.Models.Agregates
{
    public class PagedModel<TModel>
    {
        public PagedModel()
        {
            Items = new List<TModel>();
        }

        const int MaxPageSize = 100;
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public IList<TModel> Items { get; set; }

        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }
    }
}
