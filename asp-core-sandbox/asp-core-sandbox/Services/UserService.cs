using Microsoft.Extensions.Configuration;
using asp_core_sandbox.Models;
using asp_core_sandbox.Database.Context;

namespace asp_core_sandbox.Services

{
    public class UserService
    {
        private IConfiguration configuration;
        public UserService(IConfiguration configuration) { this.configuration = configuration; }

        public UserInfo GetUserInfoById(int id) 
        {
            SandboxDBContext sandboxDBContext = new SandboxDBContext(configuration);
            return sandboxDBContext.GetUserInfo(id);
        }

        public UserInfo createUser(UserInfo newUser)
        {
            SandboxDBContext sandboxDBContext = new SandboxDBContext(configuration);
            return sandboxDBContext.createUser(newUser.Name, newUser.Age, newUser.Job);
        }

    }

}
