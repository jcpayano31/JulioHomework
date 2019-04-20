using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework2JP
{
    class UserRepository
    {
        public IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User() {Name = "Dave", Password = "hello" },
                new User() {Name = "Steve", Password = "steve" },
                new User() {Name = "Lisa", Password = "hello" }
            };

        }

    }
}
