using Hovis.Web.Base.Models;
using System.Collections.Generic;

namespace Hovis.Web.Base.ViewModels
{
    public class DocumentListViewModel
    {
        public IEnumerable<t_HovisVPD_Documents> Documents { get; set; }

        //public IEnumerable<HovisExcellenceApplication> Applications { get; set; }
    }
}