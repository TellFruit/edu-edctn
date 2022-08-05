using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Interfaces.InnerImpl
{
    public interface IUserAuth
    {
        public bool IsAuthenticated { get; set; }
        Task<bool> Login(string email, string password);
        Task Register(string email, string password);
    }
}
