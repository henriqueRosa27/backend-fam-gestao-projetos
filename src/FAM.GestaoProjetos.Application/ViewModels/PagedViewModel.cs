using System.Collections.Generic;

namespace FAM.GestaoProjetos.Application.ViewModels
{
    public class PagedViewModel<TViewModel>
    {

        public int PageSize { get; set; }

        public IList<TViewModel> Items { get; set; }

        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }
    }
}
