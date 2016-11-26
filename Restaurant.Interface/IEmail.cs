using Restaurant.Core.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Interface
{
    public interface IEmail
    {
        void Send(EmailDetails details);
    }
}
