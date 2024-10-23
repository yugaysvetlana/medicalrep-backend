using MedicalPlatform.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlatform.Application.Interfaces.Auth
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
