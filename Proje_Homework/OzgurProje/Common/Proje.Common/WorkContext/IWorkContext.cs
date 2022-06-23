using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.WorkContext
{
    public interface IWorkContext
    {
        UserResponse CurrentUser { get; set; }
    }
}
