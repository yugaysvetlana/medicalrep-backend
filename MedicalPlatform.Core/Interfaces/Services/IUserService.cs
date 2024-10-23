using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlatform.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task Register(string userName, string password);
    }
}
