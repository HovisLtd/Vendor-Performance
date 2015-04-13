using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hovis.Web.Base.Models
{
    [MetadataType(typeof(VPDMetaData))]
    public partial class t_HovisVPD_Details
    {
    }

    [MetadataType(typeof(DocumentsMetaData))]
    public partial class t_HovisVPD_Documents
    {
    }

    [MetadataType(typeof(DocumentTypesMetaData))]
    public partial class t_HovisVPD_Document_Types_Drop_Down
    {
    }

    [MetadataType(typeof(CategoryMetaData))]
    public partial class t_HovisVPD_Category_Drop_Down
    {
    }

    [MetadataType(typeof(ContactMetaData))]
    public partial class t_HovisVPD_Contact_Mode_Drop_Down
    {
    }

    [MetadataType(typeof(PriorityMetaData))]
    public partial class t_HovisVPD_Priority_Drop_Down
    {
    }

    [MetadataType(typeof(RatingMetaData))]
    public partial class t_HovisVPD_Supplier_Rating_Drop_Down
    {
    }
}